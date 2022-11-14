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
    public partial class NuevoAlquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "VentasAlquiler"))
                Response.Redirect("NoEncontrado.aspx");

            if (!IsPostBack)
            {
                CalendarAlquilerFechaInicio.SelectedDate = DateTime.Today.AddDays(1);
                CalendarAlquilerFechaFin.SelectedDate = DateTime.Today.AddDays(7);

                ButtonPresupuestar.Enabled = false;
                ButtonPresupuestar.CssClass = "btn btn-primary";

                var bllSucursal = new BLLSucursal();
                var sucursales = bllSucursal.ListarSucursales();
                Session["SucursalesAlquiler"] = sucursales;

                DropDownListSucursalesOrigen.DataSource = sucursales;
                DropDownListSucursalesOrigen.DataBind();

                DropDownListSucursalesDestino.DataSource = sucursales;
                DropDownListSucursalesDestino.DataBind();

                DropDownListNivelBlindaje.DataSource = new List<int> { 1, 2, 3 };
                DropDownListNivelBlindaje.DataBind();
            }
        }

        protected void ButtonCargarVehiculos_Click(object sender, EventArgs e)
        {
            var fechaInicio = CalendarAlquilerFechaInicio.SelectedDate;
            var fechaFin = CalendarAlquilerFechaFin.SelectedDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (fechaInicio < DateTime.Today || fechaInicio > fechaFin)
            {
                LabelValidacionFechas.Visible = true;
                return;
            }
            else
                LabelValidacionFechas.Visible = false;

            var sucursales = (List<Sucursal>)Session["SucursalesAlquiler"];
            var sucursalSeleccionada = sucursales.First(i => i.NombreSucursal == DropDownListSucursalesOrigen.SelectedItem.Value);

            var nivelBlindaje = Convert.ToInt32(DropDownListNivelBlindaje.SelectedValue);

            var bllReserva = new BLLReserva();
            var vehiculosDisponibles = bllReserva.ListarVehiculosDisponibles(sucursalSeleccionada, fechaInicio, fechaFin, nivelBlindaje);

            Session["VehiculosDisponibles"] = vehiculosDisponibles;
            DropDownListVehiculosDisponibles.DataSource = vehiculosDisponibles;
            DropDownListVehiculosDisponibles.DataBind();

            if (vehiculosDisponibles.Any())
            {
                ButtonPresupuestar.Enabled = true;
                ButtonPresupuestar.CssClass = "btn btn-primary";
            }
            else
            {
                ButtonPresupuestar.Enabled = false;
                ButtonPresupuestar.CssClass = "btn btn-primary";
                ButtonConfirmarAlquiler.Visible = false;
                ButtonConfirmarAlquiler.CssClass = "btn btn-success";
            }

            RecargarListaChoferes();
            HtmlPresupuesto.Visible = false;
        }

        protected void CheckBoxChofer_CheckedChanged(object sender, EventArgs e)
        {
            RecargarListaChoferes();
            HtmlPresupuesto.Visible = false;
        }

        private void RecargarListaChoferes()
        {
            LabelChoferValidacion.Visible = false;

            if (CheckBoxChofer.Checked)
            {
                DropDownListChoferes.Enabled = true;

                var fechaInicio = CalendarAlquilerFechaInicio.SelectedDate;
                var fechaFin = CalendarAlquilerFechaFin.SelectedDate.AddHours(23).AddMinutes(59).AddSeconds(59);

                var bllChofer = new BLLChofer();
                var choferes = bllChofer.ListarChoferesDisponibles(fechaInicio, fechaFin);

                Session["ChoferesAlquiler"] = choferes;
                DropDownListChoferes.DataSource = choferes;
                DropDownListChoferes.DataBind();
            }
            else
                DropDownListChoferes.Enabled = false;
        }

        protected void ButtonPresupuestar_Click(object sender, EventArgs e)
        {
            var alquiler = new AlquilerConChofer();

            alquiler.FechaInicio = CalendarAlquilerFechaInicio.SelectedDate;
            alquiler.FechaFin = CalendarAlquilerFechaFin.SelectedDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (CheckBoxChofer.Checked)
            {
                var choferes = (List<Chofer>)Session["ChoferesAlquiler"];

                if (!choferes.Any())
                {
                    LabelChoferValidacion.Visible = true;
                    return;
                }
                else
                    LabelChoferValidacion.Visible = false;

                var choferSeleccionado = choferes.First(c => c.ToString() == DropDownListChoferes.SelectedItem.Value);

                alquiler.Chofer = choferSeleccionado;
            }

            var sucursales = (List<Sucursal>)Session["SucursalesAlquiler"];

            var sucursalSeleccionadaOrigen = sucursales.First(i => i.NombreSucursal == DropDownListSucursalesOrigen.SelectedItem.Value);
            alquiler.SucursalOrigen = sucursalSeleccionadaOrigen;

            var sucursalSeleccionadaDestino = sucursales.First(i => i.NombreSucursal == DropDownListSucursalesDestino.SelectedItem.Value);
            alquiler.SucursalDestino = sucursalSeleccionadaDestino;

            var vehiculosDisponibles = (List<Vehiculo>)Session["VehiculosDisponibles"];
            var vehiculoDisponibleSeleccionado = vehiculosDisponibles.First(c => c.ToString() == DropDownListVehiculosDisponibles.SelectedItem.Value);

            alquiler.Vehiculo = vehiculoDisponibleSeleccionado;

            Session["NuevoAlquiler"] = alquiler;

            var bllReserva = new BLLReserva();
            var presupuesto = bllReserva.CalcularPresupuesto(alquiler);

            var formato = string.Format("F{0}", 2);

            LabelPresupuestoDiasValor.Text = presupuesto.Dias.ToString();
            LabelPresupuestoChoferValor.Text = presupuesto.CostoChofer.ToString(formato);
            LabelPresupuestoVehiculoValor.Text = presupuesto.CostoVehiculo.ToString(formato);
            LabelPresupuestoRecargoValor.Text = presupuesto.RecargoSucursal.ToString(formato);
            LabelTotalValor.Text = presupuesto.Total.ToString(formato);

            HtmlPresupuesto.Visible = true;
            ButtonConfirmarAlquiler.Visible = true;
            ButtonConfirmarAlquiler.CssClass = "btn btn-success";
        }

        protected void ButtonConfirmarAlquiler_Click(object sender, EventArgs e)
        {
            DropDownListSucursalesOrigen.Enabled = false;
            CalendarAlquilerFechaInicio.Enabled = false;
            CalendarAlquilerFechaFin.Enabled = false;
            DropDownListNivelBlindaje.Enabled = false;
            ButtonCargarVehiculos.Enabled = false;
            ButtonCargarVehiculos.CssClass = "btn btn-primary";
            DropDownListVehiculosDisponibles.Enabled = false;
            DropDownListSucursalesDestino.Enabled = false;
            DropDownListChoferes.Enabled = false;
            ButtonPresupuestar.Enabled = false;
            ButtonPresupuestar.CssClass = "btn btn-primary";
            ButtonConfirmarAlquiler.Enabled = false;
            ButtonConfirmarAlquiler.CssClass = "btn btn-success";

            Response.Redirect("ClienteAlquiler.aspx");
        }

        protected void CalendarAlquilerFechaInicio_SelectionChanged(object sender, EventArgs e)
        {
            ButtonPresupuestar.Enabled = false;
            ButtonPresupuestar.CssClass = "btn btn-primary";

            ButtonConfirmarAlquiler.Visible = false;
            ButtonConfirmarAlquiler.CssClass = "btn btn-success";

            HtmlPresupuesto.Visible = false;
        }

        protected void CalendarAlquilerFechaFin_SelectionChanged(object sender, EventArgs e)
        {
            ButtonPresupuestar.Enabled = false;
            ButtonPresupuestar.CssClass = "btn btn-primary";

            ButtonConfirmarAlquiler.Visible = false;
            ButtonConfirmarAlquiler.CssClass = "btn btn-success";

            HtmlPresupuesto.Visible = false;
        }

        protected void DropDownListSucursalesOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlPresupuesto.Visible = false;
        }

        protected void DropDownListNivelBlindaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlPresupuesto.Visible = false;
        }

        protected void DropDownListVehiculosDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlPresupuesto.Visible = false;
        }

        protected void DropDownListSucursalesDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlPresupuesto.Visible = false;
        }

        protected void DropDownListChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlPresupuesto.Visible = false;
        }
    }
}