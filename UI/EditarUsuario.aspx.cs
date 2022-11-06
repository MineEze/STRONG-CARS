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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionUsuario"))
                Response.Redirect("NoEncontrado.aspx");

            LabelEditarUsuarioExito.Visible = false;
            LabelNombreDeUsuarioEnUso.Visible = false;

            if (!IsPostBack)
            {
                var usuarioSeleccionado = (Usuario)Session["UsuarioSeleccionado"];

                TextBoxNombre.Text = usuarioSeleccionado.Nombre;
                TextBoxApellido.Text = usuarioSeleccionado.Apellido;
                TextBoxUsuario.Text = usuarioSeleccionado.NombreDeUsuario;
                TextBoxDNI.Text = usuarioSeleccionado.DNI;
                TextBoxEmail.Text = usuarioSeleccionado.Email;
                TextBoxCalle.Text = usuarioSeleccionado.Direccion.Calle;
                TextBoxAltura.Text = usuarioSeleccionado.Direccion.Altura.ToString();
                TextBoxUnidad.Text = usuarioSeleccionado.Direccion.Unidad;
                TextBoxCodigoPostal.Text = usuarioSeleccionado.Direccion.CodigoPostal;
                CheckBoxBloqueado.Checked = usuarioSeleccionado.Bloqueado;

                var bllPermisos = new BLLPermiso();
                CheckBoxListPermisos.DataSource = bllPermisos.ListarPermisos();
                CheckBoxListPermisos.DataBind();
            }
        }

        protected void ButtonEditarUsuario_Click(object sender, EventArgs e)
        {
            var usuarioSeleccionado = (Usuario)Session["UsuarioSeleccionado"];

            List<string> permisosSeleccionados = CheckBoxListPermisos.Items
              .Cast<ListItem>()
              .Where(li => li.Selected)
              .Select(li => li.Value)
              .ToList();

            var bllPermisos = new BLLPermiso();
            var permisos = bllPermisos.ListarPermisos().Where(p => permisosSeleccionados.Contains(p.Nombre)).ToList();

            usuarioSeleccionado.Nombre = TextBoxNombre.Text;
            usuarioSeleccionado.Apellido = TextBoxApellido.Text;
            usuarioSeleccionado.DNI = TextBoxDNI.Text;
            usuarioSeleccionado.Email = TextBoxEmail.Text;
            usuarioSeleccionado.NombreDeUsuario = TextBoxUsuario.Text;
            usuarioSeleccionado.Direccion.Calle = TextBoxCalle.Text;
            usuarioSeleccionado.Direccion.Altura = Convert.ToInt32(TextBoxAltura.Text);
            usuarioSeleccionado.Direccion.Unidad = TextBoxUnidad.Text;
            usuarioSeleccionado.Direccion.CodigoPostal = TextBoxCodigoPostal.Text;
            usuarioSeleccionado.Permisos = permisos;

            if (CheckBoxBloqueado.Checked)
                usuarioSeleccionado.Bloqueado = true;
            else
            {
                if (usuarioSeleccionado.Bloqueado)
                    usuarioSeleccionado.CantidadIntentosLogIn = 0;

                usuarioSeleccionado.Bloqueado = false;
            }

            var bllUsuario = new BLLUsuario(Session["Usuario"] as Usuario);
            var usuarioModificado = bllUsuario.ModificarUsuario(usuarioSeleccionado);

            if (usuarioModificado)
            {
                LabelEditarUsuarioExito.Visible = true;
                Session["UsuarioSeleccionado"] = null;

                TextBoxNombre.Enabled = false;
                TextBoxApellido.Enabled = false;
                TextBoxDNI.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxUsuario.Enabled = false;
                TextBoxCalle.Enabled = false;
                TextBoxAltura.Enabled = false;
                TextBoxUnidad.Enabled = false;
                TextBoxCodigoPostal.Enabled = false;
                CheckBoxListPermisos.Enabled = false;
                ButtonEditarUsuario.Enabled = false;
                ButtonEditarUsuario.CssClass = "btn btn-primary";
            }
            else
                LabelNombreDeUsuarioEnUso.Visible = true;
        }

        protected void CheckBoxListPermisos_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var usuarioSeleccionado = (Usuario)Session["UsuarioSeleccionado"];

                foreach (ListItem li in CheckBoxListPermisos.Items)
                {
                    if (usuarioSeleccionado.Permisos.Any(p => p.Nombre == li.Value))
                        li.Selected = true;
                }
            }
        }
    }
}