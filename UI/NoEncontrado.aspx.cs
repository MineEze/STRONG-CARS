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
    public partial class NoEncontrado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCerrarSesionNoEncontrado_Click(object sender, EventArgs e)
        {
            ButtonCerrarSesionNoEncontrado.Visible = false;

            var usuario = Session["Usuario"] as Usuario;

            var bllBitacora = new BLLBitacora();
            bllBitacora.RegistrarMensaje(new MensajeBitacora(usuario, $"Log out."));

            Session.Abandon();

            Response.Redirect("LogIn.aspx");
        }
    }
}