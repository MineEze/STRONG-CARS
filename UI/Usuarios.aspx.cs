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
    public partial class Usuarios : System.Web.UI.Page
    {
        List<Usuario> usuarios;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "AdministracionUsuario"))
                Response.Redirect("NoEncontrado.aspx");

            ListarUsuariosEnGrilla();
        }

        public void ListarUsuariosEnGrilla()
        {
            var bllUsuario = new BLLUsuario();
            usuarios = bllUsuario.ListarUsuarios();
            GridViewUsuarios.DataSource = usuarios;
            GridViewUsuarios.DataBind();
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var usuarioSeleccionado = usuarios.First(em => em.Id == idUsuario);

            Session["UsuarioSeleccionado"] = usuarioSeleccionado;
            Response.Redirect("EditarUsuario.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var usuarioActual = Session["Usuario"] as Usuario;

            if (idUsuario == usuarioActual.Id)
            {
                LabelValidacionBorrado.Visible = true;
                return;
            }
            else
                LabelValidacionBorrado.Visible = false;

            var usuarioSeleccionado = usuarios.First(em => em.Id == idUsuario);

            var bllUsuario = new BLLUsuario(Session["Usuario"] as Usuario);
            bllUsuario.BajaUsuario(usuarioSeleccionado);

            ListarUsuariosEnGrilla();
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
            reporte.ReportPath = Server.MapPath("~/UsuariosReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLUsuario().ListarUsuariosReporte();

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

            filename = string.Format("{0}.{1}", "Reporte usuarios", extensionArchivo);
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