using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLSucursal
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;

        public BLLSucursal(Usuario usuario)
        {
            _bllBitacora = new BLLBitacora();
            _usuarioLogueado = usuario;
        }

        public BLLSucursal() { }

        public List<Sucursal> ListarSucursales()
        {
            var mpSucursal = new MPSucursal();

            return mpSucursal.ListarSucursales();
        }

        public List<SucursalReporte> ListarSucursalesReporte()
        {
            var mpSucursal = new MPSucursal();

            var sucursales = mpSucursal.ListarSucursales();

            var sucursalesReporte = new List<SucursalReporte>();

            foreach (var s in sucursales)
            {
                sucursalesReporte.Add(new SucursalReporte
                {
                    Nombre = s.NombreSucursal,
                    Gerente = $"{s.Gerente.Nombre} {s.Gerente.Apellido}"
                });
            }

            return sucursalesReporte;
        }

        public void AltaSucursal(Sucursal sucursal)
        {
            var mpSucursal = new MPSucursal();
            mpSucursal.AltaSucursal(sucursal);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Sucursal creada: {sucursal.NombreSucursal}"));
        }

        public void BajaSucursal(Sucursal sucursal)
        {
            var mpSucursal = new MPSucursal();
            mpSucursal.BajaSucursal(sucursal);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Sucursal borrada: {sucursal.NombreSucursal}"));
        }

        public void ModificarSucursal(Sucursal sucursal)
        {
            var mpSucursal = new MPSucursal();
            mpSucursal.ModificarSucursal(sucursal);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Sucursal modificada: {sucursal.NombreSucursal}"));
        }
    }
}
