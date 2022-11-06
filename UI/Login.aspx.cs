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
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;

            if (usuarioLogueado != null)
                RedirigirUsuarioSegunPermisos(usuarioLogueado);

            TextBoxPassword.Attributes.Add("onkeypress", "return controlEnter('" + ButtonLogIn + "', event)");

            Page.DataBind();
            DataBind();
        }

        private void RedirigirUsuarioSegunPermisos(Usuario usuarioLogueado)
        {
            if (usuarioLogueado.Permisos.Any())
                Response.Redirect("MenuPrincipal.aspx");

            Response.Redirect("NoEncontrado.aspx");
        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario { NombreDeUsuario = TextBoxUsuario.Text, Password = TextBoxPassword.Text };

            var bllUsuario = new BLLUsuario();

            var usuarioLogueado = bllUsuario.LogIn(usuario);

            if (usuarioLogueado != null)
            {
                if (usuarioLogueado.Bloqueado)
                {
                    LabelUsuarioBloqueado.Visible = true;
                }
                else
                {
                    Session["Usuario"] = usuarioLogueado;
                    Session["UsuarioNombre"] = usuarioLogueado.Nombre;

                    RedirigirUsuarioSegunPermisos(usuarioLogueado);
                }
            }
            else
            {
                LabelLogInError.Visible = true;
            }
        }

        protected void ButtonRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}