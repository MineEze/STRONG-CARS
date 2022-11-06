using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MPSucursal
    {
        public List<Sucursal> ListarSucursales()
        {
            var sucursales = new List<Sucursal>();

            var acceso = new Acceso();

            acceso.Abrir();

            DataTable resultadoSucursales = acceso.Leer(@"ListarSucursales");
            DataTable resultadoRecargos = acceso.Leer(@"ListarRecargosSucursales");

            var recargos = new List<RecargoSucursalDeBase>();

            foreach (DataRow Registro in resultadoRecargos.Rows)
            {
                recargos.Add(new RecargoSucursalDeBase
                {
                    IdSucursalOrigen = Convert.ToInt32(Registro["IdSucursalOrigen"]),
                    IdSucursalDestino = Convert.ToInt32(Registro["IdSucursalDestino"]),
                    Recargo = Convert.ToDecimal(Registro["Recargo"])
                });
            }

            var mpUsuario = new MPUsuario();
            var mpDireccion = new MPDireccion();

            foreach (DataRow Registro in resultadoSucursales.Rows)
            {
                var sucursal = new Sucursal
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Gerente = mpUsuario.ObtenerUsuario(Convert.ToInt32(Registro["IdGerente"])),
                    Direccion = mpDireccion.ObtenerDireccion(Convert.ToInt32(Registro["IdDireccion"]))
                };

                foreach (var recargo in recargos)
                {
                    if (recargo.IdSucursalOrigen == sucursal.Id)
                        sucursal.RecargoSucursales.Add(recargo.IdSucursalDestino, recargo.Recargo);
                }

                SqlParameter[] parametrosTelefono = new SqlParameter[1];
                parametrosTelefono[0] = acceso.CrearParametro("@IdSucursal", sucursal.Id);

                DataTable resultadoTelefonos = acceso.Leer(@"ListarTelefonos", parametrosTelefono);

                foreach (DataRow RegistroTelefono in resultadoTelefonos.Rows)
                {
                    sucursal.Telefonos.Add(new Telefono
                    {
                        Id = Convert.ToInt32(RegistroTelefono["Id"]),
                        Caracteristica = RegistroTelefono["Caracteristica"].ToString(),
                        Numero = RegistroTelefono["Numero"].ToString()
                    });
                }

                sucursales.Add(sucursal);
            }

            acceso.Cerrar();

            return sucursales;
        }

        public void AltaSucursal(Sucursal sucursal)
        {
            var mpDireccion = new MPDireccion();

            var idDireccion = mpDireccion.AltaDireccion(sucursal.Direccion);

            var acceso = new Acceso();

            SqlParameter[] parametrosSucursal = new SqlParameter[3];
            parametrosSucursal[0] = acceso.CrearParametro("@IdDireccion", idDireccion);
            parametrosSucursal[1] = acceso.CrearParametro("@IdGerente", sucursal.Gerente.Id);
            parametrosSucursal[2] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            acceso.Abrir();
            var idSucursal = acceso.LeerEscalar("AltaSucursal", parametrosSucursal);
            acceso.Cerrar();

            var mpTelefono = new MPTelefono();

            foreach (var telefono in sucursal.Telefonos)
                mpTelefono.AltaTelefono(telefono, idSucursal);

            foreach (var recargo in sucursal.RecargoSucursales)
                AltaRecargo(idSucursal, recargo.Key, recargo.Value);
        }

        private void AltaRecargo(int idSucursalOrigen, int idSucursalDestino, decimal recargo)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = acceso.CrearParametro("@IdSucursalOrigen", idSucursalOrigen);
            parametros[1] = acceso.CrearParametro("@IdSucursalDestino", idSucursalDestino);
            parametros[2] = acceso.CrearParametro("@Recargo", recargo.ToString());

            acceso.Abrir();
            acceso.Escribir("AltaRecargoSucursal", parametros);
            acceso.Cerrar();
        }

        public void BajaSucursal(Sucursal sucursal)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosSucursal = new SqlParameter[1];
            parametrosSucursal[0] = acceso.CrearParametro("@Id", sucursal.Id);

            acceso.Abrir();

            acceso.Escribir("BajaSucursal", parametrosSucursal);

            acceso.Cerrar();
        }

        public void ModificarSucursal(Sucursal sucursal)
        {
            var acceso = new Acceso();

            var mpDireccion = new MPDireccion();
            mpDireccion.ModificarDireccion(sucursal.Direccion);

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@IdSucursal", sucursal.Id);

            acceso.Abrir();

            acceso.Escribir("BajaTelefonoSucursal", parametros);

            var mpTelefono = new MPTelefono();

            foreach (var telefono in sucursal.Telefonos)
                mpTelefono.AltaTelefono(telefono, sucursal.Id);

            acceso.Escribir("BajaRecargoSucursal", parametros);

            foreach (var recargo in sucursal.RecargoSucursales)
                AltaRecargo(sucursal.Id, recargo.Key, recargo.Value);

            SqlParameter[] parametrosSucursal = new SqlParameter[3];
            parametrosSucursal[0] = acceso.CrearParametro("@Id", sucursal.Id);
            parametrosSucursal[1] = acceso.CrearParametro("@IdGerente", sucursal.Gerente.Id);
            parametrosSucursal[2] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            acceso.Escribir("ModificarSucursal", parametrosSucursal);

            acceso.Cerrar();
        }

        public class RecargoSucursalDeBase
        {
            public int IdSucursalOrigen { get; set; }

            public int IdSucursalDestino { get; set; }

            public decimal Recargo { get; set; }
        }
    }
}
