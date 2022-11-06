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
    public partial class Retorno : System.Web.UI.Page
    {
        List<Alquiler> alquileres;

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuarioActual = Session["Usuario"] as Usuario;
            var bllPermiso = new BLLPermiso();
            if (!bllPermiso.PermisoEncontrado(usuarioActual.Permisos, "InspeccionRetorno"))
                Response.Redirect("NoEncontrado.aspx");

            ListarAlquileresEnGrilla();
        }

        private void ListarAlquileresEnGrilla()
        {
            var bllReserva = new BLLReserva();
            alquileres = bllReserva.ListarAlquileresEnCurso();
            GridViewAlquileres.DataSource = alquileres;
            GridViewAlquileres.DataBind();

            if (!alquileres.Any())
                LabelGrillaSinRegistros.Visible = true;
            else
                LabelGrillaSinRegistros.Visible = false;
        }

        protected void Retorno_Click(object sender, EventArgs e)
        {
            int idAlquiler = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var alquilerSeleccionado = alquileres.First(em => em.Id == idAlquiler);

            Session["AlquilerRetorno"] = alquilerSeleccionado;

            Response.Redirect("RetornoDetalle.aspx");
        }
    }
}