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
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;

            if (usuarioActual == null || !usuarioActual.Permisos.Any())
                Response.Redirect("NoEncontrado.aspx");

            EsconderOpcionesSegunPermisos(usuarioActual);

            LabelUsuarioNombre.DataBind();
            Page.DataBind();
            DataBind();
        }

        public void EsconderOpcionesSegunPermisos(Usuario usuario)
        {
            var bllPermiso = new BLLPermiso();

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionSucursal"))
            {
                HtmlListarSucursales.Visible = true;
                HtmlAgregarSucursales.Visible = true;
            }
            else
            {
                HtmlListarSucursales.Visible = false;
                HtmlAgregarSucursales.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionUsuario"))
            {
                HtmlRegistrarUsuario.Visible = true;
                HtmlListarUsuarios.Visible = true;
            }
            else
            {
                HtmlRegistrarUsuario.Visible = false;
                HtmlListarUsuarios.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionBitacora"))
            {
                HtmlBitacora.Visible = true;
            }
            else
            {
                HtmlBitacora.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionPermiso"))
            {
                HtmlPermisos.Visible = true;
            }
            else
            {
                HtmlPermisos.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionChofer"))
            {
                HtmlListarChoferes.Visible = true;
                HtmlAgregarChofer.Visible = true;
            }
            else
            {
                HtmlListarChoferes.Visible = false;
                HtmlAgregarChofer.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "VentasCliente"))
            {
                HtmlClienteAgregarCliente.Visible = true;
                HtmlListarCliente.Visible = true;
            }
            else
            {
                HtmlClienteAgregarCliente.Visible = false;
                HtmlListarCliente.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "VentasAlquiler"))
            {
                HtmlListarAlquileres.Visible = true;
                HtmlAlquiler.Visible = true;
            }
            else
            {
                HtmlListarAlquileres.Visible = false;
                HtmlAlquiler.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionVehiculo"))
            {
                HtmlAgregarVehiculo.Visible = true;
                HtmlListarVehiculos.Visible = true;
            }
            else
            {
                HtmlAgregarVehiculo.Visible = false;
                HtmlListarVehiculos.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "InspeccionRetorno"))
            {
                HtmlRetorno.Visible = true;
            }
            else
            {
                HtmlRetorno.Visible = false;
            }


            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "InspeccionReporte"))
            {
                HtmlReportes.Visible = true;
            }
            else
            {
                HtmlReportes.Visible = false;
            }
        }

        protected void ButtonRegistrarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroUsuario.aspx");
        }

        protected void ButtonBitacora_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bitacora.aspx");
        }

        protected void ButtonUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void ButtonListarSucursales_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sucursales.aspx");
        }

        protected void ButtonAgregarSucursal_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarSucursal.aspx");
        }

        protected void ButtonVerChoferes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choferes.aspx");
        }

        protected void ButtonAgregarChofer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarChofer.aspx");
        }

        protected void ButtonAgregarPermiso_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPermiso.aspx");
        }

        protected void ButtonAltaCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }

        protected void ButtonVerClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void ButtonVerAlquileres_Click(object sender, EventArgs e)
        {
            Response.Redirect("Alquileres.aspx");
        }

        protected void ButtonNuevoAlquiler_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoAlquiler.aspx");
        }

        protected void ButtonAgregarVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarVehiculo.aspx");
        }

        protected void ButtonVerVehiculos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehiculos.aspx");
        }

        protected void ButtonReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void ButtonRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Retorno.aspx");
        }
    }
}