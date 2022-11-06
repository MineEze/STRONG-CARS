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
    public partial class Sucursales : System.Web.UI.Page
    {
        List<Sucursal> sucursales;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionSucursal"))
                Response.Redirect("NoEncontrado.aspx");

            ListarSucursalesEnGrilla();
        }

        public void ListarSucursalesEnGrilla()
        {
            var bllSucursal = new BLLSucursal();
            sucursales = bllSucursal.ListarSucursales();
            GridViewSucursales.DataSource = sucursales;
            GridViewSucursales.DataBind();

            if (!sucursales.Any())
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
            int idSucursal = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var sucursalSeleccionada = sucursales.First(s => s.Id == idSucursal);

            Session["ModificarSucursalSeleccionada"] = sucursalSeleccionada;
            Response.Redirect("ModificarSucursal.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            int idSucursal = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var sucursalSeleccionada = sucursales.First(s => s.Id == idSucursal);

            var bllSucursal = new BLLSucursal(Session["Usuario"] as Usuario);
            bllSucursal.BajaSucursal(sucursalSeleccionada);

            ListarSucursalesEnGrilla();
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
            reporte.ReportPath = Server.MapPath("~/SucursalesReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLSucursal().ListarSucursalesReporte();

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

            filename = string.Format("{0}.{1}", "Reporte sucursales", extensionArchivo);
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