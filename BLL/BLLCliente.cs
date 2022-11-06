using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLCliente
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;

        public BLLCliente(Usuario usuario)
        {
            _bllBitacora = new BLLBitacora();
            _usuarioLogueado = usuario;
        }

        public BLLCliente()
        {

        }

        public void AltaCliente(Cliente cliente)
        {
            var mpCliente = new MPCliente();
            mpCliente.AltaCliente(cliente);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Alta cliente: {cliente.Nombre} {cliente.Apellido}."));
        }

        public List<Cliente> ListarClientes()
        {
            var mpCliente = new MPCliente();
            return mpCliente.ListarClientes();
        }

        public List<ClienteReporte> ListarClientesReporte()
        {
            var mpCliente = new MPCliente();
            var clientes = mpCliente.ListarClientes();

            var clientesReporte = new List<ClienteReporte>();

            foreach (var cliente in clientes)
            {
                clientesReporte.Add(new ClienteReporte
                {
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    EmpresaNombre = cliente.EmpresaNombre,
                    Legajo = cliente.Legajo
                });
            }

            return clientesReporte;
        }

        public List<Empresa> ListarEmpresas()
        {
            var mpCliente = new MPCliente();
            return mpCliente.ListarEmpresas();
        }

        public void BajaCliente(Cliente cliente)
        {
            var mpCliente = new MPCliente();
            mpCliente.BajaCliente(cliente);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Baja cliente: {cliente.Nombre} {cliente.Apellido}."));
        }

        public void ModificarCliente(Cliente cliente)
        {
            var mpCliente = new MPCliente();
            mpCliente.ModificarCliente(cliente);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Modificación cliente: {cliente.Nombre} {cliente.Apellido}."));
        }
    }
}
