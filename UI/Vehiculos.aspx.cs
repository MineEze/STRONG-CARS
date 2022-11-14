using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using Microsoft.Reporting.WebForms;

namespace UI
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        List<Vehiculo> vehiculos;

        protected void Page_Load(object sender, EventArgs e)    
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionVehiculo"))
                Response.Redirect("NoEncontrado.aspx");

            ListarVehiculosEnGrilla();
        }

        public void ListarVehiculosEnGrilla()
        {
            var bllVehiculo = new BLLVehiculo();
            vehiculos = bllVehiculo.ListarVehiculos();
            GridViewVehiculos.DataSource = vehiculos;
            GridViewVehiculos.DataBind();

            if (!vehiculos.Any())
            {
                LabelGrillaSinRegistros.Visible = true;
                ButtonReporteExcel.Visible = false;
                ButtonReportePDF.Visible = false;
            }
            else
            {
                LabelGrillaSinRegistros.Visible = false;
                ButtonReporteExcel.Visible = true;
                ButtonReportePDF.Visible = true;
            }
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            int idVehiculo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var vehiculoSeleccionado = vehiculos.First(s => s.Id == idVehiculo);

            Session["VehiculoSeleccionado"] = vehiculoSeleccionado;
            Response.Redirect("ModificarVehiculo.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            int idVehiculo = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var vehiculoSeleccionado = vehiculos.First(s => s.Id == idVehiculo);

            var bllVehiculo = new BLLVehiculo(Session["Usuario"] as Usuario);
            bllVehiculo.BajaVehiculo(vehiculoSeleccionado);

            ListarVehiculosEnGrilla();
        }

        protected void ButtonReporteExcel_Click(object sender, EventArgs e)
        {
            GenerarReporte("Excel", "xls");
        }

        protected void ButtonReportePDF_Click(object sender, EventArgs e)
        {
            GenerarReporte("Pdf", "pdf");
        }

        private void GenerarReporte(string formato, string extensionArchivo)
        {
            var reporte = new LocalReport();
            reporte.ReportPath = Server.MapPath("~/VehiculosReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLVehiculo().ListarVehiculosReporte();

            reporte.DataSources.Add(reporteDataSource);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string filename;

            byte[] bytes = reporte.Render(
               formato,
               null,
               out mimeType,
               out encoding,
               out extension,
               out streamids,
               out warnings);

            filename = string.Format("{0}.{1}", "Reporte vehículos", extensionArchivo);
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.ContentType = mimeType;
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}