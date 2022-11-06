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
    public partial class ModificarSucursal : System.Web.UI.Page
    {
        List<Sucursal> sucursales;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionSucursal"))
                Response.Redirect("NoEncontrado.aspx");

            if (!IsPostBack)
            {
                var sucursal = (Sucursal)Session["ModificarSucursalSeleccionada"];
                TextBoxCalle.Text = sucursal.Direccion.Calle;
                TextBoxAltura.Text = sucursal.Direccion.Altura.ToString();
                TextBoxUnidad.Text = sucursal.Direccion.Unidad;
                TextBoxCodigoPostal.Text = sucursal.Direccion.CodigoPostal;

                Session["ModificarSucursalTelefonos"] = sucursal.Telefonos;
                Session["ModificarSucursalRecargos"] = sucursal.RecargoSucursales;

                ListarSucursalesEnGrilla();

                var bllUsuario = new BLLUsuario();
                var usuarios = bllUsuario.ListarUsuarios();
                Session["ModificarSucursalUsuariosGerente"] = usuarios;

                DropDownListGerente.DataSource = usuarios;
                DropDownListGerente.DataBind();
            }

            LabelModificacionSucursalExito.Visible = false;

            var recargos = new Dictionary<int, decimal>();

            foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
            {
                var idSucursal = Convert.ToInt32(GridViewSucursalesRecargos.DataKeys[row.RowIndex]["id"]);

                var recargo = ((TextBox)row.FindControl("TextBoxRecargo")).Text;

                if (decimal.TryParse(recargo, out decimal recargoDecimal))
                    recargos.Add(idSucursal, recargoDecimal);
            }

            Session["ModificarSucursalRecargos"] = recargos;

            ListarSucursalesEnGrilla();
            ListarGrillaTelefonos();
        }

        protected void DropDownListGerente_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sucursal = (Sucursal)Session["ModificarSucursalSeleccionada"];

                DropDownListGerente.Items.FindByValue(sucursal.Gerente.NombreDeUsuario).Selected = true;
            }
        }

        protected void GridViewSucursalesRecargos_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sucursal = (Sucursal)Session["ModificarSucursalSeleccionada"];

                foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
                {
                    var idSucursal = Convert.ToInt32(GridViewSucursalesRecargos.DataKeys[row.RowIndex]["id"]);

                    if (sucursal.RecargoSucursales.ContainsKey(idSucursal))
                        ((TextBox)row.FindControl("TextBoxRecargo")).Text = sucursal.RecargoSucursales[idSucursal].ToString();
                }
            }
            else
            {
                var recargos = (Dictionary<int, decimal>)Session["ModificarSucursalRecargos"];

                foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
                {
                    var idSucursal = Convert.ToInt32(GridViewSucursalesRecargos.DataKeys[row.RowIndex]["id"]);

                    ((TextBox)row.FindControl("TextBoxRecargo")).Text = recargos[idSucursal].ToString();
                }
            }
        }

        public void ListarSucursalesEnGrilla()
        {
            var sucursal = (Sucursal)Session["ModificarSucursalSeleccionada"];

            var bllSucursal = new BLLSucursal();
            sucursales = bllSucursal.ListarSucursales().Where(s => s.Id != sucursal.Id).ToList();
            GridViewSucursalesRecargos.DataSource = sucursales;
            GridViewSucursalesRecargos.DataBind();
        }
        protected void ButtonModificarSucursal_Click(object sender, EventArgs e)
        {
            var sucursal = (Sucursal)Session["ModificarSucursalSeleccionada"];

            sucursal.Direccion.Calle = TextBoxCalle.Text;
            sucursal.Direccion.Altura = Convert.ToInt32(TextBoxAltura.Text);
            sucursal.Direccion.Unidad = TextBoxUnidad.Text;
            sucursal.Direccion.CodigoPostal = TextBoxCodigoPostal.Text;

            var usuarios = (List<Usuario>)Session["ModificarSucursalUsuariosGerente"];
            var gerenteSeleccionado = usuarios.First(i => i.NombreDeUsuario == DropDownListGerente.SelectedItem.Value);
            sucursal.Gerente = gerenteSeleccionado;

            var telefonos = (List<Telefono>)Session["ModificarSucursalTelefonos"];
            sucursal.Telefonos = telefonos;

            var bllSucursal = new BLLSucursal(Session["Usuario"] as Usuario);
            var recargos = (Dictionary<int, decimal>)Session["ModificarSucursalRecargos"];

            sucursal.RecargoSucursales.Clear();

            foreach (var sucursalExistente in bllSucursal.ListarSucursales().Where(s => s.Id != sucursal.Id).ToList())
            {
                if (recargos.ContainsKey(sucursalExistente.Id))
                    sucursal.RecargoSucursales.Add(sucursalExistente.Id, Convert.ToDecimal(recargos[sucursalExistente.Id]));
                else
                    sucursal.RecargoSucursales.Add(sucursalExistente.Id, 0);
            }

            bllSucursal.ModificarSucursal(sucursal);

            ButtonAgregarTelefono.Enabled = false;
            ButtonModificarSucursal.Enabled = false;
            TextBoxCalle.Enabled = false;
            TextBoxAltura.Enabled = false;
            TextBoxUnidad.Enabled = false;
            TextBoxCodigoPostal.Enabled = false;
            TextBoxTelefonoCaracteristica.Enabled = false;
            TextBoxTelefonoNumero.Enabled = false;
            DropDownListGerente.Enabled = false;

            ButtonAgregarTelefono.CssClass = "btn btn-primary";
            ButtonModificarSucursal.CssClass = "btn btn-primary";

            foreach (GridViewRow row in GridViewSucursalesRecargos.Rows)
                ((TextBox)row.FindControl("TextBoxRecargo")).Enabled = false;

            GridViewTelefonos.Enabled = false;

            LabelModificacionSucursalExito.Visible = true;

            LimpiarSessionAgregarSucursal();
        }

        private void LimpiarSessionAgregarSucursal()
        {
            Session["ModificarSucursalTelefonos"] = null;
            Session["ModificarSucursalRecargos"] = null;
            Session["ModificarSucursalUsuariosGerente"] = null;
        }

        protected void ButtonAgregarTelefono_Click(object sender, EventArgs e)
        {
            var telefono = new Telefono
            {
                Caracteristica = TextBoxTelefonoCaracteristica.Text,
                Numero = TextBoxTelefonoNumero.Text
            };

            var telefonos = (List<Telefono>)Session["ModificarSucursalTelefonos"];

            if (telefonos == null) telefonos = new List<Telefono>();

            if (telefonos.Any(t => t.Caracteristica == telefono.Caracteristica && t.Numero == telefono.Numero))
            {
                LabelValidacionTelefonoRepetido.Visible = true;
                return;
            }
            else
                LabelValidacionTelefonoRepetido.Visible = false;

            telefonos.Add(telefono);

            Session["ModificarSucursalTelefonos"] = telefonos;

            ListarGrillaTelefonos();

            TextBoxTelefonoCaracteristica.Text = string.Empty;
            TextBoxTelefonoNumero.Text = string.Empty;
        }

        private void ListarGrillaTelefonos()
        {
            var telefonos = (List<Telefono>)Session["ModificarSucursalTelefonos"];

            GridViewTelefonos.DataSource = telefonos;
            GridViewTelefonos.DataBind();
        }

        protected void BorrarTelefono_Click(object sender, EventArgs e)
        {
            var boton = (sender as LinkButton).DataItemContainer;
            var caracteristica = (boton as GridViewRow).Cells[0].Text;
            var numero = (boton as GridViewRow).Cells[1].Text;

            var telefonos = (List<Telefono>)Session["ModificarSucursalTelefonos"];

            if (telefonos == null) telefonos = new List<Telefono>();

            telefonos.RemoveAll(t => t.Caracteristica == caracteristica && t.Numero == numero);

            ListarGrillaTelefonos();
        }
    }
}