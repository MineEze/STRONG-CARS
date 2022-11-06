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
    public partial class EditarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "VentasCliente"))
                Response.Redirect("NoEncontrado.aspx");

            LabelModificarClienteExito.Visible = false;

            if (!IsPostBack)
            {
                var clienteSeleccionado = (Cliente)Session["ClienteSeleccionado"];

                TextBoxNombre.Text = clienteSeleccionado.Nombre;
                TextBoxApellido.Text = clienteSeleccionado.Apellido;

                TextBoxDNI.Text = clienteSeleccionado.DNI;
                TextBoxLicencia.Text = clienteSeleccionado.Licencia;
                TextBoxEmail.Text = clienteSeleccionado.Email;
                TextBoxCalle.Text = clienteSeleccionado.Direccion.Calle;
                TextBoxAltura.Text = clienteSeleccionado.Direccion.Altura.ToString();
                TextBoxUnidad.Text = clienteSeleccionado.Direccion.Unidad;
                TextBoxCodigoPostal.Text = clienteSeleccionado.Direccion.CodigoPostal;

                TextBoxTelefonoCaracteristica.Text = clienteSeleccionado.Telefono.Caracteristica;
                TextBoxTelefonoNumero.Text = clienteSeleccionado.Telefono.Numero;
            }
        }

        protected void ButtonModificarCliente_Click(object sender, EventArgs e)
        {
            var clienteSeleccionado = (Cliente)Session["ClienteSeleccionado"];

            clienteSeleccionado.Nombre = TextBoxNombre.Text;
            clienteSeleccionado.Apellido = TextBoxApellido.Text;
            clienteSeleccionado.DNI = TextBoxDNI.Text;
            clienteSeleccionado.Licencia = TextBoxLicencia.Text;
            clienteSeleccionado.Email = TextBoxEmail.Text;

            clienteSeleccionado.Direccion.Calle = TextBoxCalle.Text;
            clienteSeleccionado.Direccion.Altura = Convert.ToInt32(TextBoxAltura.Text);
            clienteSeleccionado.Direccion.Unidad = TextBoxUnidad.Text;
            clienteSeleccionado.Direccion.CodigoPostal = TextBoxCodigoPostal.Text;

            clienteSeleccionado.Telefono.Caracteristica = TextBoxTelefonoCaracteristica.Text;
            clienteSeleccionado.Telefono.Numero = TextBoxTelefonoNumero.Text;

            var bllCliente = new BLLCliente(Session["Usuario"] as Usuario);
            bllCliente.ModificarCliente(clienteSeleccionado);

            TextBoxNombre.Enabled = false;
            TextBoxApellido.Enabled = false;
            TextBoxDNI.Enabled = false;
            TextBoxLicencia.Enabled = false;
            TextBoxEmail.Enabled = false;
            TextBoxCalle.Enabled = false;
            TextBoxAltura.Enabled = false;
            TextBoxUnidad.Enabled = false;
            TextBoxCodigoPostal.Enabled = false;
            TextBoxTelefonoCaracteristica.Enabled = false;
            TextBoxTelefonoNumero.Enabled = false;

            ButtonModificarCliente.Enabled = false;
            ButtonModificarCliente.CssClass = "btn btn-primary";
            LabelModificarClienteExito.Visible = true;
        }
    }
}