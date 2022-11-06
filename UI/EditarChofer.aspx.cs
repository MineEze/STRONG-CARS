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
    public partial class EditarChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionChofer"))
                Response.Redirect("NoEncontrado.aspx");

            LabelModificarChoferExito.Visible = false;

            if (!IsPostBack)
            {
                var choferSeleccionado = (Chofer)Session["ChoferSeleccionado"];

                TextBoxNombre.Text = choferSeleccionado.Nombre;
                TextBoxApellido.Text = choferSeleccionado.Apellido;

                TextBoxDNI.Text = choferSeleccionado.DNI;
                TextBoxEmail.Text = choferSeleccionado.Email;
                TextBoxCalle.Text = choferSeleccionado.Direccion.Calle;
                TextBoxAltura.Text = choferSeleccionado.Direccion.Altura.ToString();
                TextBoxUnidad.Text = choferSeleccionado.Direccion.Unidad;
                TextBoxCodigoPostal.Text = choferSeleccionado.Direccion.CodigoPostal;

                TextBoxTelefonoCaracteristica.Text = choferSeleccionado.Telefono.Caracteristica;
                TextBoxTelefonoNumero.Text = choferSeleccionado.Telefono.Numero;
            }
        }

        protected void ButtonModificarChofer_Click(object sender, EventArgs e)
        {
            var choferSeleccionado = (Chofer)Session["ChoferSeleccionado"];


            choferSeleccionado.Nombre = TextBoxNombre.Text;
            choferSeleccionado.Apellido = TextBoxApellido.Text;
            choferSeleccionado.DNI = TextBoxDNI.Text;
            choferSeleccionado.Email = TextBoxEmail.Text;

            choferSeleccionado.Direccion.Calle = TextBoxCalle.Text;
            choferSeleccionado.Direccion.Altura = Convert.ToInt32(TextBoxAltura.Text);
            choferSeleccionado.Direccion.Unidad = TextBoxUnidad.Text;
            choferSeleccionado.Direccion.CodigoPostal = TextBoxCodigoPostal.Text;

            choferSeleccionado.Telefono.Caracteristica = TextBoxTelefonoCaracteristica.Text;
            choferSeleccionado.Telefono.Numero = TextBoxTelefonoNumero.Text;

            var bllChofer = new BLLChofer(Session["Usuario"] as Usuario);
            bllChofer.ModificarChofer(choferSeleccionado);

            TextBoxNombre.Enabled = false;
            TextBoxApellido.Enabled = false;
            TextBoxDNI.Enabled = false;
            TextBoxEmail.Enabled = false;
            TextBoxCalle.Enabled = false;
            TextBoxAltura.Enabled = false;
            TextBoxUnidad.Enabled = false;
            TextBoxCodigoPostal.Enabled = false;
            TextBoxTelefonoCaracteristica.Enabled = false;
            TextBoxTelefonoNumero.Enabled = false;

            ButtonModificarChofer.Enabled = false;
            ButtonModificarChofer.CssClass = "btn btn-primary";
            LabelModificarChoferExito.Visible = true;
        }
    }
}