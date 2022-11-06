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
    public partial class AgregarChofer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionChofer"))
                Response.Redirect("NoEncontrado.aspx");

            LabelCreacionChoferExito.Visible = false;
        }

        protected void ButtonCrearChofer_Click(object sender, EventArgs e)
        {
            var chofer = new Chofer
            {
                Nombre = TextBoxNombre.Text,
                Apellido = TextBoxApellido.Text,
                DNI = TextBoxDNI.Text,
                Email = TextBoxEmail.Text,
                Direccion = new Direccion
                {
                    Calle = TextBoxCalle.Text,
                    Altura = Convert.ToInt32(TextBoxAltura.Text),
                    Unidad = TextBoxUnidad.Text,
                    CodigoPostal = TextBoxCodigoPostal.Text
                },
                Telefono = new Telefono
                {
                    Caracteristica = TextBoxTelefonoCaracteristica.Text,
                    Numero = TextBoxTelefonoNumero.Text
                }
            };

            var bllChofer = new BLLChofer(Session["Usuario"] as Usuario);
            bllChofer.AltaChofer(chofer);

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

            ButtonCrearChofer.Enabled = false;
            ButtonCrearChofer.CssClass = "btn btn-primary";
            LabelCreacionChoferExito.Visible = true;
        }
    }
}