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
    public partial class Choferes : System.Web.UI.Page
    {
        List<Chofer> choferes;

        public string MensajeConfirmacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionChofer"))
                Response.Redirect("NoEncontrado.aspx");

            ListarChoferesEnGrilla();
        }

        public void ListarChoferesEnGrilla()
        {
            var bllChofer = new BLLChofer();
            choferes = bllChofer.ListarChoferes();
            GridViewChoferes.DataSource = choferes;
            GridViewChoferes.DataBind();

            if (!choferes.Any())
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
            int idChofer = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var choferSeleccionado = choferes.First(em => em.Id == idChofer);

            Session["ChoferSeleccionado"] = choferSeleccionado;
            Response.Redirect("EditarChofer.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            int idChofer = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var choferSeleccionado = choferes.First(em => em.Id == idChofer);

            var bllChofer = new BLLChofer(Session["Usuario"] as Usuario);
            bllChofer.BajaChofer(choferSeleccionado);

            ListarChoferesEnGrilla();
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
            reporte.ReportPath = Server.MapPath("~/ChoferesReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLChofer().ListarChoferesReporte();

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

            filename = string.Format("{0}.{1}", "Reporte chóferes", extensionArchivo);
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