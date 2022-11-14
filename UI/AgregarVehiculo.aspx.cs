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
    public partial class AgregarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionVehiculo"))
                Response.Redirect("NoEncontrado.aspx");

            LabelCreacionVehiculoExito.Visible = false;

            if (!IsPostBack)
            {
                CalendarFechaInicio.SelectedDate = DateTime.Today;

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
            }
        }

        protected void ButtonCrearVehiculo_Click(object sender, EventArgs e)
        {
            var vehiculo = new Vehiculo
            {
                FechaDeInicio = CalendarFechaInicio.SelectedDate,
                Patente = TextBoxPatente.Text,
                Kilometraje = Convert.ToInt32(TextBoxKilometraje.Text),
                PrecioDiarioBase = Convert.ToInt32(TextBoxPrecioDiarioBase.Text),
                NivelBlindaje = Convert.ToInt32(DropDownListNivelBlindaje.SelectedValue)
            };

            var modelos = (List<Modelo>)Session["Modelos"];
            var modeloSeleccionado = modelos.First(i => i.Nombre == DropDownListModelo.SelectedItem.Value);
            vehiculo.Modelo = modeloSeleccionado;

            var sucursales = (List<Sucursal>)Session["Sucursales"];
            var sucursalSeleccionada = sucursales.First(i => i.NombreSucursal == DropDownListSucursales.SelectedItem.Value);
            vehiculo.Sucursal = sucursalSeleccionada;

            var bllVehiculo = new BLLVehiculo(Session["Usuario"] as Usuario);
            bllVehiculo.AltaVehiculo(vehiculo);

            DropDownListMarca.Enabled = false;
            DropDownListModelo.Enabled = false;
            DropDownListNivelBlindaje.Enabled = false;
            DropDownListSucursales.Enabled = false;

            TextBoxPatente.Enabled = false;
            TextBoxKilometraje.Enabled = false;
            TextBoxPrecioDiarioBase.Enabled = false;

            ButtonCrearVehiculo.Enabled = false;
            ButtonCrearVehiculo.CssClass = "btn btn-primary";

            Session["Modelos"] = null;
            Session["Sucursales"] = null;

            LabelCreacionVehiculoExito.Visible = true;
        }

        protected void DropDownListMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarModelos();
        }

        private void ListarModelos()
        {
            var marcaSeleccionada = DropDownListMarca.SelectedValue;

            var modelos = (List<Modelo>)Session["Modelos"];

            DropDownListModelo.DataSource = modelos.Where(m => m.Marca.Nombre == marcaSeleccionada);
            DropDownListModelo.DataBind();
        }
    }
}