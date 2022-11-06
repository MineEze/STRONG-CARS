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
    public partial class RetornoDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "InspeccionRetorno"))
                Response.Redirect("NoEncontrado.aspx");

            if (!IsPostBack)
            {
                var alquiler = (Alquiler)Session["AlquilerRetorno"];

                LabelClienteValor.Text = $"{alquiler.Cliente.Nombre} {alquiler.Cliente.Apellido}";
                LabelVehiculoValor.Text = alquiler.Vehiculo.ToString();
                LabelKilometrajeAnteriorValor.Text = alquiler.Vehiculo.Kilometraje.ToString();
                LabelSucursalOrigenValor.Text = alquiler.SucursalOrigen.ToString();
                LabelFechaInicioValor.Text = alquiler.FechaInicio.ToString("dd-MMM-yy");
                LabelFechaFinValor.Text = alquiler.FechaFin.ToString("dd-MMM-yy");
            }
        }

        protected void ButtonRetornar_Click(object sender, EventArgs e)
        {
            var volver = false;

            var alquiler = (Alquiler)Session["AlquilerRetorno"];

            var kilometrajeNumerico = int.TryParse(TextBoxNuevoKilometraje.Text, out int nuevoKilometraje);

            if (kilometrajeNumerico)
                LabelValidacionKilometrajeNumerico.Visible = false;
            else
            {
                LabelValidacionKilometrajeNumerico.Visible = true;
                LabelValidacionNuevoKilometraje.Visible = false;
                volver = true;
            }

            if (alquiler.Vehiculo.Kilometraje > nuevoKilometraje)
            {
                LabelValidacionNuevoKilometraje.Visible = true;
                volver = true;
            }
            else
                LabelValidacionNuevoKilometraje.Visible = false;


            if (CheckBoxDanios.Checked && TextBoxDanios.Text == string.Empty)
            {
                LabelValidacionDanios.Visible = true;
                volver = true;
            }
            else
                LabelValidacionDanios.Visible = false;

            if (volver) return;

            alquiler.Vehiculo.Kilometraje = nuevoKilometraje;

            if (TextBoxDanios.Text != string.Empty)
            {
                var bllReporte = new BLLReporte(Session["Usuario"] as Usuario);

                var reporte = new Reporte { Vehiculo = alquiler.Vehiculo, Descripcion = TextBoxDanios.Text };

                bllReporte.AltaReporte(reporte);
            }

            var bllReserva = new BLLReserva(Session["Usuario"] as Usuario);
            bllReserva.ProcesarRetorno(alquiler);

            TextBoxNuevoKilometraje.Enabled = false;
            TextBoxDanios.Enabled = false;
            CheckBoxDanios.Enabled = false;
            ButtonRetornar.Enabled = false;
            ButtonRetornar.CssClass = "btn btn-primary";
            LabelRetornarExito.Visible = true;
        }

        protected void CheckBoxDanios_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxDanios.Checked)
            {
                LabelDanios.Visible = true;
                TextBoxDanios.Enabled = true;
            }
            else
            {
                LabelDanios.Visible = false;
                TextBoxDanios.Enabled = false;
            }
        }
    }
}