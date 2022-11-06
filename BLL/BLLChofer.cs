using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLChofer
    {
        private Usuario _usuarioLogueado;
        private BLLBitacora _bllBitacora;

        public BLLChofer(Usuario usuario)
        {
            _bllBitacora = new BLLBitacora();
            _usuarioLogueado = usuario;
        }

        public BLLChofer()
        {

        }

        public void AltaChofer(Chofer chofer)
        {
            var mpChofer = new MPChofer();
            mpChofer.AltaChofer(chofer);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Alta chofer: {chofer.Nombre} {chofer.Apellido}."));
        }

        public List<Chofer> ListarChoferes()
        {
            var mpChofer = new MPChofer();
            return mpChofer.ListarChoferes();
        }

        public List<ChoferReporte> ListarChoferesReporte()
        {
            var mpChofer = new MPChofer();
            var choferes = mpChofer.ListarChoferes();

            var choferesReporte = new List<ChoferReporte>();

            foreach (var c in choferes)
            {
                choferesReporte.Add(new ChoferReporte
                {
                    Legajo = c.Legajo,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido
                });
            }

            return choferesReporte;
        }

        public List<Chofer> ListarChoferesDisponibles(DateTime inicio, DateTime fin)
        {
            var mpReserva = new MPReserva();
            var alquileresConChofer = mpReserva.ListarAlquileresConChofer();

            var mpChofer = new MPChofer();
            var choferes = mpChofer.ListarChoferes();

            var choferesNoDisponiblesIds = new List<int>();

            foreach (var acc in alquileresConChofer)
            {
                if ((inicio >= acc.FechaInicio && inicio <= acc.FechaFin) || (fin >= acc.FechaInicio && fin <= acc.FechaFin))
                    choferesNoDisponiblesIds.Add(acc.Chofer.Id);
            }

            return choferes.Where(c => !choferesNoDisponiblesIds.Contains(c.Id)).ToList();
        }

        public void BajaChofer(Chofer chofer)
        {
            var mpChofer = new MPChofer();
            mpChofer.BajaChofer(chofer);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Baja chofer: {chofer.Nombre} {chofer.Apellido}."));
        }

        public void ModificarChofer(Chofer chofer)
        {
            var mpChofer = new MPChofer();
            mpChofer.ModificarChofer(chofer);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Modificación chofer: {chofer.Nombre} {chofer.Apellido}."));
        }
    }
}
