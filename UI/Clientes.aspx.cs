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
    public partial class Clientes : System.Web.UI.Page
    {
        List<Cliente> clientes;
        public string MensajeConfirmacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "VentasCliente"))
                Response.Redirect("NoEncontrado.aspx");

            ListarClientesEnGrilla();
        }

        public void ListarClientesEnGrilla(string nombreApellido = null, string nombreEmpresa = null)
        {
            var bllCliente = new BLLCliente();
            clientes = bllCliente.ListarClientes();

            if (nombreApellido != null)
            {
                clientes = clientes
                    .Where(c => c.Nombre.ToLower().Contains(nombreApellido.ToLower()) || c.Apellido.ToLower().Contains(nombreApellido.ToLower()))
                    .ToList();

                TextBoxFiltroEmpresa.Text = "";
            }

            if (nombreEmpresa != null)
            {
                clientes = clientes
                    .Where(c => c.Empresa.Nombre.ToLower().Contains(nombreEmpresa.ToLower()))
                    .ToList();

                TextBoxFiltroNombreApellido.Text = "";
            }

            GridViewClientes.DataSource = clientes;
            GridViewClientes.DataBind();

            if (!clientes.Any())
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
            int idCliente = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var clienteSeleccionado = clientes.First(em => em.Id == idCliente);

            Session["ClienteSeleccionado"] = clienteSeleccionado;
            Response.Redirect("EditarCliente.aspx");
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var clienteSeleccionado = clientes.First(em => em.Id == idCliente);

            var bllCliente = new BLLCliente(Session["Usuario"] as Usuario);
            bllCliente.BajaCliente(clienteSeleccionado);

            ListarClientesEnGrilla();
        }

        protected void ButtonFiltroNombreApellido_Click(object sender, EventArgs e)
        {
            ListarClientesEnGrilla(TextBoxFiltroNombreApellido.Text);
        }

        protected void ButtonFiltroEmpresa_Click(object sender, EventArgs e)
        {
            ListarClientesEnGrilla(null, TextBoxFiltroEmpresa.Text);
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
            reporte.ReportPath = Server.MapPath("~/ClientesReporte.rdlc");

            var reporteDataSource = new ReportDataSource();
            reporteDataSource.Name = "DataSet1";
            reporteDataSource.Value = new BLLCliente().ListarClientesReporte();

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

            filename = string.Format("{0}.{1}", "Reporte clientes", extensionArchivo);
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