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
    public class MPCliente
    {
        public void AltaCliente(Cliente cliente)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[4];
            parametrosDireccion[0] = acceso.CrearParametro("@Calle", cliente.Direccion.Calle);
            parametrosDireccion[1] = acceso.CrearParametro("@Altura", cliente.Direccion.Altura);
            parametrosDireccion[2] = acceso.CrearParametro("@Unidad", cliente.Direccion.Unidad);
            parametrosDireccion[3] = acceso.CrearParametro("@CodigoPostal", cliente.Direccion.CodigoPostal);

            acceso.Abrir();
            cliente.Direccion.Id = acceso.LeerEscalar("AltaDireccion", parametrosDireccion);

            SqlParameter[] parametrosPersona = new SqlParameter[6];
            parametrosPersona[0] = acceso.CrearParametro("@Nombre", cliente.Nombre);
            parametrosPersona[1] = acceso.CrearParametro("@Apellido", cliente.Apellido);
            parametrosPersona[2] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);
            parametrosPersona[3] = acceso.CrearParametro("@DNI", cliente.DNI);
            parametrosPersona[4] = acceso.CrearParametro("@Email", cliente.Email);
            parametrosPersona[5] = acceso.CrearParametro("@IdDireccion", cliente.Direccion.Id);

            cliente.Id = acceso.LeerEscalar("AltaPersona", parametrosPersona);

            var mpTelefono = new MPTelefono();
            var telefonoId = mpTelefono.AltaTelefono(cliente.Telefono);

            if (cliente.Empresa == null)
            {
                SqlParameter[] parametrosCliente = new SqlParameter[3];
                parametrosCliente[0] = acceso.CrearParametro("@Id", cliente.Id);
                parametrosCliente[1] = acceso.CrearParametro("@IdTelefono", telefonoId);
                parametrosCliente[2] = acceso.CrearParametro("@Licencia", cliente.Licencia);

                acceso.Escribir("AltaCliente", parametrosCliente);
            }
            else
            {
                if (cliente.Empresa.Id == 0)
                {
                    SqlParameter[] parametrosEmpresa = new SqlParameter[1];
                    parametrosEmpresa[0] = acceso.CrearParametro("@Nombre", cliente.Empresa.Nombre);
                    cliente.Empresa.Id = acceso.LeerEscalar("AltaEmpresa", parametrosEmpresa);
                }

                SqlParameter[] parametrosCliente = new SqlParameter[4];
                parametrosCliente[0] = acceso.CrearParametro("@Id", cliente.Id);
                parametrosCliente[1] = acceso.CrearParametro("@IdTelefono", telefonoId);
                parametrosCliente[2] = acceso.CrearParametro("@IdEmpresa", cliente.Empresa.Id);
                parametrosCliente[3] = acceso.CrearParametro("@Licencia", cliente.Licencia);

                acceso.Escribir("AltaClienteConEmpresa", parametrosCliente);
            }

            acceso.Cerrar();
        }

        public List<Empresa> ListarEmpresas()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarEmpresas");
            acceso.Cerrar();

            var empresas = new List<Empresa>();

            foreach (DataRow Registro in resultado.Rows)
            {
                empresas.Add(new Empresa
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Nombre = Registro["Nombre"].ToString()
                });
            }

            return empresas;
        }

        public List<Cliente> ListarClientes()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarClientes");
            acceso.Cerrar();

            var clientes = new List<Cliente>();

            foreach (DataRow Registro in resultado.Rows)
            {
                var cliente = new Cliente
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Email = Registro["Email"].ToString(),
                    DNI = Registro["DNI"].ToString(),
                    Nombre = Registro["PersonaNombre"].ToString(),
                    Apellido = Registro["Apellido"].ToString(),
                    Telefono = new Telefono
                    {
                        Id = Convert.ToInt32(Registro["IdTelefono"]),
                        Caracteristica = Registro["Caracteristica"].ToString(),
                        Numero = Registro["Numero"].ToString(),
                    },
                    Direccion = new Direccion
                    {
                        Id = Convert.ToInt32(Registro["IdDireccion"]),
                        Calle = Registro["Calle"].ToString(),
                        Altura = Convert.ToInt32(Registro["Altura"]),
                        Unidad = Registro["Unidad"].ToString(),
                        CodigoPostal = Registro["CodigoPostal"].ToString()
                    },
                    Licencia = Registro["Licencia"].ToString(),
                };

                if (Registro["EmpresaNombre"] != null)
                    cliente.Empresa = new Empresa { Nombre = Registro["EmpresaNombre"].ToString() };

                clientes.Add(cliente);
            }

            return clientes;
        }

        public void BajaCliente(Cliente cliente)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@Id", cliente.Id);

            acceso.Abrir();
            acceso.Escribir("BajaCliente", parametros);
            acceso.Cerrar();
        }

        public void ModificarCliente(Cliente cliente)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[5];
            parametrosDireccion[0] = acceso.CrearParametro("@Id", cliente.Direccion.Id);
            parametrosDireccion[1] = acceso.CrearParametro("@Calle", cliente.Direccion.Calle);
            parametrosDireccion[2] = acceso.CrearParametro("@Altura", cliente.Direccion.Altura);
            parametrosDireccion[3] = acceso.CrearParametro("@Unidad", cliente.Direccion.Unidad);
            parametrosDireccion[4] = acceso.CrearParametro("@CodigoPostal", cliente.Direccion.CodigoPostal);

            SqlParameter[] parametrosPersona = new SqlParameter[6];
            parametrosPersona[0] = acceso.CrearParametro("@Id", cliente.Id);
            parametrosPersona[1] = acceso.CrearParametro("@Nombre", cliente.Nombre);
            parametrosPersona[2] = acceso.CrearParametro("@Apellido", cliente.Apellido);
            parametrosPersona[3] = acceso.CrearParametro("@DNI", cliente.DNI);
            parametrosPersona[4] = acceso.CrearParametro("@Email", cliente.Email);
            parametrosPersona[5] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            SqlParameter[] parametrosTelefono = new SqlParameter[3];
            parametrosTelefono[0] = acceso.CrearParametro("@Id", cliente.Telefono.Id);
            parametrosTelefono[1] = acceso.CrearParametro("@Caracteristica", cliente.Telefono.Caracteristica);
            parametrosTelefono[2] = acceso.CrearParametro("@Numero", cliente.Telefono.Numero);

            SqlParameter[] parametrosCliente = new SqlParameter[2];
            parametrosCliente[0] = acceso.CrearParametro("@Id", cliente.Id);
            parametrosCliente[1] = acceso.CrearParametro("@Licencia", cliente.Licencia);

            acceso.Abrir();
            acceso.Escribir("ModificarDireccion", parametrosDireccion);
            acceso.Escribir("ModificarPersona", parametrosPersona);
            acceso.Escribir("ModificarTelefono", parametrosTelefono);
            acceso.Escribir("ModificarCliente", parametrosCliente);
            acceso.Cerrar();
        }
    }
}
