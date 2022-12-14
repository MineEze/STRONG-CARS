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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelCreacionUsuarioExito.Visible = false;
            LabelNombreDeUsuarioEnUso.Visible = false;
        }

        protected void ButtonCrearUsuario_Click(object sender, EventArgs e)
        {
            var direccion = new Direccion
            {
                Calle = TextBoxCalle.Text,
                Altura = Convert.ToInt32(TextBoxAltura.Text),
                Unidad = TextBoxUnidad.Text,
                CodigoPostal = TextBoxCodigoPostal.Text
            };

            var usuario = new Usuario
            {
                Nombre = TextBoxNombre.Text,
                Apellido = TextBoxApellido.Text,
                DNI = TextBoxDNI.Text,
                Email = TextBoxEmail.Text,
                NombreDeUsuario = TextBoxUsuario.Text,
                Password = TextBoxPassword.Text,
                Direccion = direccion
            };

            var bllUsuario = new BLLUsuario(Session["Usuario"] as Usuario);
            var usuarioCreado = bllUsuario.CrearUsuario(usuario);

            if (usuarioCreado)
            {
                TextBoxNombre.Enabled = false;
                TextBoxApellido.Enabled = false;
                TextBoxDNI.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxCalle.Enabled = false;
                TextBoxAltura.Enabled = false;
                TextBoxUnidad.Enabled = false;
                TextBoxCodigoPostal.Enabled = false;
                TextBoxUsuario.Enabled = false;
                TextBoxPassword.Enabled = false;
                TextBoxPasswordRepetido.Enabled = false;
                ButtonCrearUsuario.Enabled = false;
                ButtonCrearUsuario.CssClass = "btn btn-primary";

                LabelCreacionUsuarioExito.Visible = true;
            }
            else
            {
                LabelNombreDeUsuarioEnUso.Visible = true;
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}