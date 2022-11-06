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
    public partial class Alquileres : System.Web.UI.Page
    {
        List<Alquiler> alquileres;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "VentasAlquiler"))
                Response.Redirect("NoEncontrado.aspx");

            ListarAlquileresEnGrilla();
        }

        private void ListarAlquileresEnGrilla()
        {
            var bllReserva = new BLLReserva();
            alquileres = bllReserva.ListarAlquileres();
            GridViewAlquileres.DataSource = alquileres;
            GridViewAlquileres.DataBind();

            if (!alquileres.Any())
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

        protected void Borrar_Click(object sender, EventArgs e)
        {
            int idAlquiler = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var alquilerSeleccionado = alquileres.First(em => em.Id == idAlquiler);

            var bllReserva = new BLLReserva(Session["Usuario"] as Usuario);
            bllReserva.BajaReserva(alquilerSeleccionado);

            ListarAlquileresEnGrilla();
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
            reporte.ReportPath = Server.MapPath("~/AlquileresReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLReserva().ListarAlquileresReporte();

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

            filename = string.Format("{0}.{1}", "Reporte alquileres", extensionArchivo);
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