using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLReporte
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;

        public BLLReporte(Usuario usuario)
        {
            _bllBitacora = new BLLBitacora();
            _usuarioLogueado = usuario;
        }

        public BLLReporte() { }

        public void AltaReporte(Reporte reporte)
        {
            var mpReporte = new MPReporte();
            mpReporte.AltaReporte(reporte);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Reporte de daños creado para vehículo: {reporte.Vehiculo}."));
        }

        public List<Reporte> ListarReportes()
        {
            var mpReporte = new MPReporte();
            return mpReporte.ListarReportes();
        }

        public List<ReporteReporte> ListarReportesReporte()
        {
            var mpReporte = new MPReporte();
            var reportes = mpReporte.ListarReportes();

            var reportesReporte = new List<ReporteReporte>();

            foreach (var r in reportes)
            {
                reportesReporte.Add(new ReporteReporte
                {
                    Fecha = r.Fecha.ToString("dd/MM/yyyy"),
                    Descripcion = r.Descripcion,
                    Vehiculo = r.Vehiculo.ToString()
                });
            }

            return reportesReporte;
        }
    }
}
