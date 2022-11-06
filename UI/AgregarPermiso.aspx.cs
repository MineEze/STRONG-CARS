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
    public partial class AgregarPermiso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionPermiso"))
                Response.Redirect("NoEncontrado.aspx");

            if (!IsPostBack)
            {
                RadioButtonListPermisos.DataSource = bllPermiso.ListarPermisos();
                RadioButtonListPermisos.DataBind();
            }
        }

        protected void ButtonAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (TextBoxNombrePermiso.Text == string.Empty)
            {
                LabelValidacionNombrePermiso.Visible = true;
                return;
            }

            var bllPermiso = new BLLPermiso(Session["Usuario"] as Usuario);

            var permisos = bllPermiso.ListarPermisos();

            var nuevoId = permisos.Max(p => p.Id) + 1;

            var permiso = new Permiso { Id = nuevoId, Nombre = TextBoxNombrePermiso.Text };

            if (RadioButtonListPermisos.SelectedIndex != -1)
            {
                var permisoPadre = permisos.First(p => p.Nombre == RadioButtonListPermisos.SelectedValue);
                bllPermiso.AltaPermiso(permiso, permisoPadre);
            }
            else
                bllPermiso.AltaPermiso(permiso, null);

            RadioButtonListPermisos.Enabled = false;
            TextBoxNombrePermiso.Enabled = false;
            ButtonAgregarPermiso.Enabled = false;
            ButtonAgregarPermiso.CssClass = "btn btn-primary";

            LabelPermisoCreado.Visible = true;
        }
    }
}