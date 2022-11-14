using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLReserva
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;
        public BLLReserva(Usuario usuario)
        {
            _bllBitacora = new BLLBitacora();
            _usuarioLogueado = usuario;
        }

        public BLLReserva() { }

        public void BajaReserva(Reserva reserva)
        {
            var mpReserva = new MPReserva();

            mpReserva.BajaReserva(reserva);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Baja reserva {reserva.Id} para vehículo {reserva.Vehiculo}."));
        }

        public List<Alquiler> ListarAlquileres()
        {
            var mpReserva = new MPReserva();

            return mpReserva.ListarAlquileres()
                .OrderByDescending(a => a.FechaInicio)
                .ToList();
        }

        public List<AlquilerReporte> ListarAlquileresReporte()
        {
            var mpReserva = new MPReserva();

            var alquileres = mpReserva.ListarAlquileres()
                .OrderByDescending(a => a.FechaInicio)
                .ToList();

            var alquileresReporte = new List<AlquilerReporte>();

            foreach (var alquiler in alquileres)
            {
                alquileresReporte.Add(new AlquilerReporte
                {
                    SucursalOrigen = alquiler.SucursalOrigen.ToString(),
                    FechaInicio = alquiler.FechaInicio.ToString("dd/MM/yyyy"),
                    FechaFin = alquiler.FechaFin.ToString("dd/MM/yyyy"),
                    Vehiculo = alquiler.Vehiculo.ToString(),
                    Total = alquiler.Total.ToString()
                });
            }

            return alquileresReporte;
        }

        public List<Alquiler> ListarAlquileresEnCurso()
        {
            var alquileres = ListarAlquileres();

            return alquileres
                .Where(a => !a.Retornado && a.FechaInicio <= DateTime.Now.Date)
                .ToList();
        }

        public List<Vehiculo> ListarVehiculosDisponibles(Sucursal sucursal, DateTime inicio, DateTime fin, int nivelBlindaje)
        {
            var bllVehiculo = new BLLVehiculo();
            var vehiculos = bllVehiculo.ListarVehiculos();

            var vehiculosSucursalyBlindaje = vehiculos.Where(v => v.Sucursal.Id == sucursal.Id && v.NivelBlindaje == nivelBlindaje);

            var mpReserva = new MPReserva();
            var reservas = mpReserva.ListarReservas();

            var vehiculosNoDisponiblesIds = new List<int>();

            foreach (var r in reservas)
            {
                if ((inicio >= r.FechaInicio && inicio <= r.FechaFin) || (fin >= r.FechaInicio && fin <= r.FechaFin))
                    vehiculosNoDisponiblesIds.Add(r.Vehiculo.Id);
            }

            return vehiculosSucursalyBlindaje.Where(vs => !vehiculosNoDisponiblesIds.Contains(vs.Id)).ToList();
        }

        public List<Vehiculo> ListarVehiculosDisponibles(DateTime inicio, DateTime fin, int nivelBlindaje)
        {
            var bllVehiculo = new BLLVehiculo();
            var vehiculos = bllVehiculo.ListarVehiculos();

            var vehiculosBlindaje = vehiculos.Where(v => v.NivelBlindaje == nivelBlindaje);

            var mpReserva = new MPReserva();
            var reservas = mpReserva.ListarReservas();

            var vehiculosNoDisponiblesIds = new List<int>();

            foreach (var r in reservas)
            {
                if ((inicio >= r.FechaInicio && inicio <= r.FechaFin) || (fin >= r.FechaInicio && fin <= r.FechaFin))
                    vehiculosNoDisponiblesIds.Add(r.Vehiculo.Id);
            }

            return vehiculosBlindaje.Where(vs => !vehiculosNoDisponiblesIds.Contains(vs.Id)).ToList();
        }

        public DetallePresupuesto CalcularPresupuesto(AlquilerConChofer alquiler)
        {
            var detallePresupuesto = new DetallePresupuesto();

            detallePresupuesto.Dias = (alquiler.FechaFin - alquiler.FechaInicio).Days;

            detallePresupuesto.CostoVehiculo = alquiler.Vehiculo.PrecioDiarioBase * detallePresupuesto.Dias;

            if (alquiler.Chofer != null)
                detallePresupuesto.CostoChofer = 14300 * detallePresupuesto.Dias;
            else
                detallePresupuesto.CostoChofer = 0;

            alquiler.SucursalOrigen.RecargoSucursales.TryGetValue(alquiler.SucursalDestino.Id, out decimal recargo);

            detallePresupuesto.RecargoSucursal = recargo;

            detallePresupuesto.Total = detallePresupuesto.CostoVehiculo + detallePresupuesto.CostoChofer + recargo;

            return detallePresupuesto;
        }

        public void AltaAlquiler(AlquilerConChofer alquiler)
        {
            var mpReserva = new MPReserva();
            mpReserva.AltaAlquiler(alquiler);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Alta alquiler: {alquiler.Vehiculo}."));
        }

        public void ProcesarRetorno(Alquiler alquiler)
        {
            var mpReserva = new MPReserva();
            mpReserva.RetornarVehiculo(alquiler);

            var mpVehiculo = new MPVehiculo();
            mpVehiculo.ActualizarKilometraje(alquiler.Vehiculo);

            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Retorno alquiler: {alquiler.Id}."));
        }
    }

    public class DetallePresupuesto
    {
        public int Dias { get; set; }

        public decimal Total { get; set; }

        public decimal CostoVehiculo { get; set; }

        public decimal CostoChofer { get; set; }

        public decimal RecargoSucursal { get; set; }
    }
}
