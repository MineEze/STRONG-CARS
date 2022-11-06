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
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionBitacora"))
                Response.Redirect("NoEncontrado.aspx");

            ListarMensajesBitacora();

            LabelValidacionFecha.Visible = false;
            LabelValidacionFechaOrden.Visible = false;

            if (!IsPostBack)
            {
                var bllBitacora = new BLLBitacora();
                var mensajesBitacora = bllBitacora.ListarBitacora();
                GridViewBitacora.DataSource = mensajesBitacora;
                GridViewBitacora.DataBind();
            }
        }

        public void ListarMensajesBitacora()
        {
            var bllBitacora = new BLLBitacora();
            var mensajesBitacora = bllBitacora.ListarBitacora();
            GridViewBitacora.DataSource = mensajesBitacora;
            GridViewBitacora.DataBind();
        }

        protected void ButtonFiltroBitacoraUsuario_Click(object sender, EventArgs e)
        {
            var bllBitacora = new BLLBitacora();
            var mensajesBitacora = bllBitacora.ListarBitacora().Where(b => b.Usuario.NombreDeUsuario == TextBoxFiltroBitacoraUsuario.Text);
            GridViewBitacora.DataSource = mensajesBitacora;
            GridViewBitacora.DataBind();
        }

        protected void ButtonFiltroBitacoraFecha_Click(object sender, EventArgs e)
        {
            TextBoxFiltroBitacoraUsuario.Text = "";

            var fechaInicio = CalendarFiltroFechaInicio.SelectedDate;
            var fechaFin = CalendarFiltroFechaFin.SelectedDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (fechaInicio.Year == 1 || fechaFin.Year == 1)
            {
                LabelValidacionFecha.Visible = true;
                LabelValidacionFechaOrden.Visible = false;
                return;
            }

            if (fechaInicio > fechaFin)
            {
                LabelValidacionFecha.Visible = false;
                LabelValidacionFechaOrden.Visible = true;
                return;
            }

            var bllBitacora = new BLLBitacora();
            var mensajesBitacora = bllBitacora.ListarBitacora().Where(b => b.FechaYHora >= fechaInicio && b.FechaYHora <= fechaFin);
            GridViewBitacora.DataSource = mensajesBitacora;
            GridViewBitacora.DataBind();
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
            reporte.ReportPath = Server.MapPath("~/BitacoraReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLBitacora().ListarBitacoraReporte();

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

            filename = string.Format("{0}.{1}", "Reporte bitácora", extensionArchivo);
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