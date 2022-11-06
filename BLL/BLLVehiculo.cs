using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLVehiculo
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;

        public BLLVehiculo()
        {
            _bllBitacora = new BLLBitacora();
        }

        public BLLVehiculo(Usuario usuario) : this()
        {
            _usuarioLogueado = usuario;
        }

        public List<Marca> ListarMarcas()
        {
            var mpVehiculo = new MPVehiculo();
            return mpVehiculo.ListarMarcas();
        }

        public List<Modelo> ListarModelos()
        {
            var mpVehiculo = new MPVehiculo();
            return mpVehiculo.ListarModelos();
        }

        public void AltaVehiculo(Vehiculo vehiculo)
        {
            var mpVehiculo = new MPVehiculo();
            mpVehiculo.AltaVehiculo(vehiculo);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Vehiculo agregado: {vehiculo.Modelo.Marca.Nombre} {vehiculo.Modelo.Nombre} {vehiculo.Patente}"));
        }

        public List<Vehiculo> ListarVehiculos()
        {
            var mpVehiculo = new MPVehiculo();
            return mpVehiculo.ListarVehiculos();
        }

        public List<VehiculoReporte> ListarVehiculosReporte()
        {
            var mpVehiculo = new MPVehiculo();
            var vehiculos = mpVehiculo.ListarVehiculos();

            var vehiculosReporte = new List<VehiculoReporte>();

            foreach (var v in vehiculos)
            {
                vehiculosReporte.Add(new VehiculoReporte
                {
                    Marca = v.MarcaNombre,
                    Modelo = v.ModeloNombre,
                    Patente = v.Patente
                });
            }

            return vehiculosReporte;
        }

        public void BajaVehiculo(Vehiculo vehiculo)
        {
            var mpVehiculo = new MPVehiculo();
            mpVehiculo.BajaVehiculo(vehiculo);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Vehiculo borrado: {vehiculo.Modelo.Marca.Nombre} {vehiculo.Modelo.Nombre} {vehiculo.Patente}"));
        }

        public void ModificarVehiculo(Vehiculo vehiculo)
        {
            var mpVehiculo = new MPVehiculo();
            mpVehiculo.ModificarVehiculo(vehiculo);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Vehiculo modificado: {vehiculo.Modelo.Marca.Nombre} {vehiculo.Modelo.Nombre} {vehiculo.Patente}"));
        }
    }
}
