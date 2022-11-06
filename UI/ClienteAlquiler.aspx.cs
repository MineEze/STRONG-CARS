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
    public partial class ClienteAlquiler : System.Web.UI.Page
    {
        List<Cliente> clientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "VentasCliente"))
                Response.Redirect("NoEncontrado.aspx");

            ListarClientesEnGrilla();
        }

        public void ListarClientesEnGrilla(string nombreApellido = null, string nombreEmpresa = null)
        {
            var bllCliente = new BLLCliente();
            clientes = bllCliente.ListarClientes();

            if (nombreApellido != null)
            {
                clientes = clientes
                    .Where(c => c.Nombre.ToLower().Contains(nombreApellido.ToLower()) || c.Apellido.ToLower().Contains(nombreApellido.ToLower()))
                    .ToList();

                TextBoxFiltroEmpresa.Text = "";
            }

            if (nombreEmpresa != null)
            {
                clientes = clientes
                    .Where(c => c.Empresa.Nombre.ToLower().Contains(nombreEmpresa.ToLower()))
                    .ToList();

                TextBoxFiltroNombreApellido.Text = "";
            }

            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();

            if (!clientes.Any())
                LabelGrillaSinRegistros.Visible = true;
            else
                LabelGrillaSinRegistros.Visible = false;
        }

        protected void CrearAlquiler_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var clienteSeleccionado = clientes.First(em => em.Id == idCliente);

            var alquiler = (AlquilerConChofer)Session["NuevoAlquiler"];

            alquiler.Cliente = clienteSeleccionado;

            var bllReserva = new BLLReserva(Session["Usuario"] as Usuario);

            bllReserva.AltaAlquiler(alquiler);

            LabelAlquilerCreado.Visible = true;
            GridViewClientes.Visible = false;
            LabelClienteSeleccione.Visible = false;

            ButtonFiltroNombreApellido.Enabled = false;
            ButtonFiltroNombreApellido.CssClass = "btn btn-primary";
            TextBoxFiltroNombreApellido.Enabled = false;

            ButtonFiltroEmpresa.Enabled = false;
            ButtonFiltroEmpresa.CssClass = "btn btn-primary";
            TextBoxFiltroEmpresa.Enabled = false;
        }

        protected void ButtonFiltroNombreApellido_Click(object sender, EventArgs e)
        {
            ListarClientesEnGrilla(TextBoxFiltroNombreApellido.Text);
        }

        protected void ButtonFiltroEmpresa_Click(object sender, EventArgs e)
        {
            ListarClientesEnGrilla(null, TextBoxFiltroEmpresa.Text);
        }
    }
}