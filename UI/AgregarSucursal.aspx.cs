using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace UI
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        List<Sucursal> sucursales;
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionSucursal"))
                Response.Redirect("NoEncontrado.aspx");

            LabelCreacionSucursalExito.Visible = false;
            var recargos = new Dictionary<int, decimal>();

            foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
            {
                var idSucursal = Convert.ToInt32(GridViewSucursalesRecargos.DataKeys[row.RowIndex]["id"]);

                var recargo = ((TextBox)row.FindControl("TextBoxRecargo")).Text;

                if (decimal.TryParse(recargo, out decimal recargoDecimal))
                    recargos.Add(idSucursal, recargoDecimal);
            }

            Session["AgregarSucursalRecargos"] = recargos;

            ListarSucursalesEnGrilla();

            ListarGrillaTelefonos();

            if (!IsPostBack)
            {
                ListarSucursalesEnGrilla();

                var bllUsuario = new BLLUsuario();
                var usuarios = bllUsuario.ListarUsuarios();
                Session["AgregarSucursalUsuariosGerente"] = usuarios;

                DropDownListGerente.DataSource = usuarios;
                DropDownListGerente.DataBind();
            }
        }

        public void ListarSucursalesEnGrilla()
        {
            var bllSucursal = new BLLSucursal();
            sucursales = bllSucursal.ListarSucursales();
            GridViewSucursalesRecargos.DataSource = sucursales;
            GridViewSucursalesRecargos.DataBind();
        }

        protected void GridViewSucursalesRecargos_DataBound(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var recargos = (Dictionary<int, decimal>)Session["AgregarSucursalRecargos"];

                foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
                {
                    var idSucursal = Convert.ToInt32(GridViewSucursalesRecargos.DataKeys[row.RowIndex]["id"]);

                    if (recargos.ContainsKey(idSucursal))
                        ((TextBox)row.FindControl("TextBoxRecargo")).Text = recargos[idSucursal].ToString();
                }
            }
        }

        protected void ButtonCrearSucursal_Click(object sender, EventArgs e)
        {
            var sucursal = new Sucursal();
            sucursal.Direccion = new Direccion();
            sucursal.Direccion.Calle = TextBoxCalle.Text;
            sucursal.Direccion.Altura = Convert.ToInt32(TextBoxAltura.Text);
            sucursal.Direccion.Unidad = TextBoxUnidad.Text;
            sucursal.Direccion.CodigoPostal = TextBoxCodigoPostal.Text;

            var usuarios = (List<Usuario>)Session["AgregarSucursalUsuariosGerente"];
            var gerenteSeleccionado = usuarios.First(i => i.NombreDeUsuario == DropDownListGerente.SelectedItem.Value);
            sucursal.Gerente = gerenteSeleccionado;

            var telefonos = (List<Telefono>)Session["AgregarSucursalTelefonos"];
            sucursal.Telefonos = telefonos;

            var bllSucursal = new BLLSucursal(Session["Usuario"] as Usuario);
            var recargos = (Dictionary<int, decimal>)Session["AgregarSucursalRecargos"];

            foreach (var sucursalExistente in bllSucursal.ListarSucursales())
            {
                if (recargos.ContainsKey(sucursalExistente.Id))
                    sucursal.RecargoSucursales.Add(sucursalExistente.Id, Convert.ToDecimal(recargos[sucursalExistente.Id]));
            }

            bllSucursal.AltaSucursal(sucursal);

            ButtonAgregarTelefono.Enabled = false;
            ButtonCrearSucursal.Enabled = false;
            TextBoxCalle.Enabled = false;
            TextBoxAltura.Enabled = false;
            TextBoxUnidad.Enabled = false;
            TextBoxCodigoPostal.Enabled = false;
            TextBoxTelefonoCaracteristica.Enabled = false;
            TextBoxTelefonoNumero.Enabled = false;
            DropDownListGerente.Enabled = false;

            ButtonAgregarTelefono.CssClass = "btn btn-primary";
            ButtonCrearSucursal.CssClass = "btn btn-primary";

            foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
                ((TextBox)row.FindControl("TextBoxRecargo")).Enabled = false;

            GridViewTelefonos.Enabled = false;

            LabelCreacionSucursalExito.Visible = true;

            LimpiarSessionAgregarSucursal();
        }

        private void LimpiarSessionAgregarSucursal()
        {
            Session["AgregarSucursalTelefonos"] = null;
            Session["AgregarSucursalRecargos"] = null;
            Session["AgregarSucursalUsuariosGerente"] = null;
        }

        protected void ButtonAgregarTelefono_Click(object sender, EventArgs e)
        {
            var telefono = new Telefono
            {
                Caracteristica = TextBoxTelefonoCaracteristica.Text,
                Numero = TextBoxTelefonoNumero.Text
            };

            var telefonos = (List<Telefono>)Session["AgregarSucursalTelefonos"];

            if (telefonos == null) telefonos = new List<Telefono>();

            if (telefonos.Any(t => t.Caracteristica == telefono.Caracteristica && t.Numero == telefono.Numero))
            {
                LabelValidacionTelefonoRepetido.Visible = true;
                return;
            }
            else
                LabelValidacionTelefonoRepetido.Visible = false;

            telefonos.Add(telefono);

            Session["AgregarSucursalTelefonos"] = telefonos;

            ListarGrillaTelefonos();

            TextBoxTelefonoCaracteristica.Text = string.Empty;
            TextBoxTelefonoNumero.Text = string.Empty;
        }

        private void ListarGrillaTelefonos()
        {
            var telefonos = (List<Telefono>)Session["AgregarSucursalTelefonos"];

            GridViewTelefonos.DataSource = telefonos;
            GridViewTelefonos.DataBind();
        }

        protected void BorrarTelefono_Click(object sender, EventArgs e)
        {
            var boton = (sender as LinkButton).DataItemContainer;
            var caracteristica = (boton as GridViewRow).Cells[0].Text;
            var numero = (boton as GridViewRow).Cells[1].Text;

            var telefonos = (List<Telefono>)Session["AgregarSucursalTelefonos"];

            if (telefonos == null) telefonos = new List<Telefono>();

            telefonos.RemoveAll(t => t.Caracteristica == caracteristica && t.Numero == numero);

            ListarGrillaTelefonos();
        }
    }
}