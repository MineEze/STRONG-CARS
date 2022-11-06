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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            administracion.Visible = false;
            ventas.Visible = false;
            inspeccion.Visible = false;

            var usuarioLogueado = Session["Usuario"] as Usuario;

            if (usuarioLogueado != null)
            {
                UsuarioLogueado.Text = "logueado";
                LinkButtonLogOut.Visible = true;
                EsconderOpcionesSegunPermisos(usuarioLogueado);
            }
            else
            {
                LinkButtonLogOut.Visible = false;
                UsuarioLogueado.Text = "logout";
            }
        }

        public void EsconderOpcionesSegunPermisos(Usuario usuario)
        {
            var bllPermiso = new BLLPermiso();

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionSucursal"))
            {
                lblAdminSucursal.Text = "1";
                ButtonAgregarSucursal.Visible = true;
                ButtonListarSucursales.Visible = true;
                administracion.Visible = true;
            }
            else
            {
                lblAdminSucursal.Text = "0";
                ButtonAgregarSucursal.Visible = false;
                ButtonListarSucursales.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionUsuario"))
            {
                lblAdminUsuario.Text = "1";
                ButtonRegistrarUsuario.Visible = true;
                ButtonUsuarios.Visible = true;
                administracion.Visible = true;
            }
            else
            {
                lblAdminUsuario.Text = "0";
                ButtonRegistrarUsuario.Visible = false;
                ButtonUsuarios.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionBitacora"))
            {
                lblAdminBitacora.Text = "1";
                ButtonBitacora.Visible = true;
                administracion.Visible = true;
            }
            else
            {
                lblAdminBitacora.Text = "0";
                ButtonBitacora.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionChofer"))
            {
                lblAdminChofer.Text = "1";
                ButtonAgregarChofer.Visible = true;
                ButtonVerChoferes.Visible = true;
                administracion.Visible = true;
            }
            else
            {
                lblAdminChofer.Text = "0";
                ButtonAgregarChofer.Visible = false;
                ButtonVerChoferes.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "AdministracionPermiso"))
            {
                lblAdminPermiso.Text = "1";
                ButtonAgregarPermiso.Visible = true;
                administracion.Visible = true;
            }
            else
            {
                lblAdminPermiso.Text = "0";
                ButtonAgregarPermiso.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "VentasCliente"))
            {
                lblVentasCliente.Text = "1";
                ButtonAltaCliente.Visible = true;
                ButtonVerClientes.Visible = true;
                ventas.Visible = true;
            }
            else
            {
                lblVentasCliente.Text = "0";
                ButtonAltaCliente.Visible = false;
                ButtonVerClientes.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "VentasAlquiler"))
            {
                lblVentasAlquiler.Text = "1";
                ButtonVerAlquileres.Visible = true;
                ButtonNuevoAlquiler.Visible = true;
                ventas.Visible = true;
            }
            else
            {
                lblVentasAlquiler.Text = "0";
                ButtonVerAlquileres.Visible = false;
                ButtonNuevoAlquiler.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "InspeccionVehiculo"))
            {
                lblInspeccionVehiculo.Text = "1";
                ButtonAgregarVehiculo.Visible = true;
                ButtonVerVehiculos.Visible = true;
                inspeccion.Visible = true;
            }
            else
            {
                lblInspeccionVehiculo.Text = "0";
                ButtonAgregarVehiculo.Visible = false;
                ButtonVerVehiculos.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "InspeccionRetorno"))
            {
                lblInspeccionRetorno.Text = "1";
                ButtonRetorno.Visible = true;
                inspeccion.Visible = true;
            }
            else
            {
                lblInspeccionRetorno.Text = "0";
                ButtonRetorno.Visible = false;
            }

            if (bllPermiso.PermisoEncontrado(usuario.Permisos, "InspeccionReporte"))
            {
                lblInspeccionReporte.Text = "1";
                ButtonReportes.Visible = true;
                inspeccion.Visible = true;
            }
            else
            {
                lblInspeccionReporte.Text = "0";
                ButtonReportes.Visible = false;
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            LinkButtonLogOut.Visible = false;

            var usuario = Session["Usuario"] as Usuario;

            var bllBitacora = new BLLBitacora();
            bllBitacora.RegistrarMensaje(new MensajeBitacora(usuario, $"Log out."));

            Session.Clear();

            Response.Redirect("Login.aspx");
        }

        protected void ButtonStrongCars_Click(object sender, EventArgs e)
        {
            var usuario = Session["Usuario"] as Usuario;

            if (usuario != null)
                Response.Redirect("MenuPrincipal.aspx");
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

        protected void ButtonAltaCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }

        protected void ButtonVerClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void ButtonAgregarVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarVehiculo.aspx");
        }

        protected void ButtonVerVehiculos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehiculos.aspx");
        }

        protected void ButtonAgregarPermiso_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPermiso.aspx");
        }

        protected void ButtonVerAlquileres_Click(object sender, EventArgs e)
        {
            Response.Redirect("Alquileres.aspx");
        }

        protected void ButtonNuevoAlquiler_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoAlquiler.aspx");
        }

        protected void ButtonRetorno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Retorno.aspx");
        }

        protected void ButtonReportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }

        protected void ButtonAgregarChofer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarChofer.aspx");
        }

        protected void ButtonVerChoferes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Choferes.aspx");
        }
    }
}