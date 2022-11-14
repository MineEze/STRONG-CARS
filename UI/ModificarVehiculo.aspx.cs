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
    public partial class ModificarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionVehiculo"))
                Response.Redirect("NoEncontrado.aspx");

            LabelModificarVehiculoExito.Visible = false;

            if (!IsPostBack)
            {
                DropDownListNivelBlindaje.DataSource = new List<int> { 1, 2, 3 };
                DropDownListNivelBlindaje.DataBind();

                var bllVehiculo = new BLLVehiculo();
                DropDownListMarca.DataSource = bllVehiculo.ListarMarcas();
                DropDownListMarca.DataBind();

                Session["Modelos"] = bllVehiculo.ListarModelos();

                ListarModelos();

                var bllSucursal = new BLLSucursal();
                var sucursales = bllSucursal.ListarSucursales();
                Session["Sucursales"] = sucursales;
                DropDownListSucursales.DataSource = sucursales;
                DropDownListSucursales.DataBind();

                var vehiculo = (Vehiculo)Session["VehiculoSeleccionado"];
                TextBoxKilometraje.Text = vehiculo.Kilometraje.ToString();
                TextBoxPatente.Text = vehiculo.Patente;
                TextBoxPrecioDiarioBase.Text = vehiculo.PrecioDiarioBase.ToString();

                CalendarFechaInicio.SelectedDate = vehiculo.FechaDeInicio.Date;
                CalendarFechaInicio.VisibleDate = CalendarFechaInicio.SelectedDate;
            }
        }

        private void ListarModelos()
        {
            var marcaSeleccionada = DropDownListMarca.SelectedValue;

            var modelos = (List<Modelo>)Session["Modelos"];

            DropDownListModelo.DataSource = modelos.Where(m => m.Marca.Nombre == marcaSeleccionada);
            DropDownListModelo.DataBind();
        }

        protected void DropDownListMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarModelos();
        }

        protected void DropDownListMarca_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vehiculo = (Vehiculo)Session["VehiculoSeleccionado"];

                DropDownListMarca.Items.FindByValue(vehiculo.Modelo.Marca.Nombre).Selected = true;
            }
        }

        protected void DropDownListModelo_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vehiculo = (Vehiculo)Session["VehiculoSeleccionado"];

                DropDownListModelo.Items.FindByValue(vehiculo.Modelo.Nombre).Selected = true;
            }
        }

        protected void DropDownListNivelBlindaje_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vehiculo = (Vehiculo)Session["VehiculoSeleccionado"];

                DropDownListNivelBlindaje.Items.FindByValue(vehiculo.NivelBlindaje.ToString()).Selected = true;
            }
        }

        protected void DropDownListSucursales_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vehiculo = (Vehiculo)Session["VehiculoSeleccionado"];

                DropDownListSucursales.Items.FindByValue(vehiculo.Sucursal.NombreSucursal).Selected = true;
            }
        }

        protected void ButtonModificarVehiculo_Click(object sender, EventArgs e)
        {
            var vehiculo = (Vehiculo)Session["VehiculoSeleccionado"];
            vehiculo.Patente = TextBoxPatente.Text;
            vehiculo.Kilometraje = Convert.ToInt32(TextBoxKilometraje.Text);
            vehiculo.PrecioDiarioBase = Convert.ToInt32(TextBoxPrecioDiarioBase.Text);

            var modelos = (List<Modelo>)Session["Modelos"];
            vehiculo.Modelo = modelos.First(m => m.Nombre == DropDownListModelo.SelectedItem.Value);

            vehiculo.NivelBlindaje = Convert.ToInt32(DropDownListNivelBlindaje.SelectedItem.Value);
            vehiculo.FechaDeInicio = CalendarFechaInicio.SelectedDate;

            var sucursales = (List<Sucursal>)Session["Sucursales"];
            vehiculo.Sucursal = sucursales.First(m => m.NombreSucursal == DropDownListSucursales.SelectedItem.Value);

            var bllVehiculo = new BLLVehiculo(Session["Usuario"] as Usuario);
            bllVehiculo.ModificarVehiculo(vehiculo);

            DropDownListMarca.Enabled = false;
            DropDownListModelo.Enabled = false;
            DropDownListNivelBlindaje.Enabled = false;
            DropDownListSucursales.Enabled = false;

            TextBoxPatente.Enabled = false;
            TextBoxKilometraje.Enabled = false;
            TextBoxPrecioDiarioBase.Enabled = false;

            ButtonModificarVehiculo.Enabled = false;
            ButtonModificarVehiculo.CssClass = "btn btn-primary";

            Session["Modelos"] = null;
            Session["Sucursales"] = null;

            LabelModificarVehiculoExito.Visible = true;
        }
    }
}