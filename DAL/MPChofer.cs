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
    public class MPChofer
    {
        public void AltaChofer(Chofer chofer)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[4];
            parametrosDireccion[0] = acceso.CrearParametro("@Calle", chofer.Direccion.Calle);
            parametrosDireccion[1] = acceso.CrearParametro("@Altura", chofer.Direccion.Altura);
            parametrosDireccion[2] = acceso.CrearParametro("@Unidad", chofer.Direccion.Unidad);
            parametrosDireccion[3] = acceso.CrearParametro("@CodigoPostal", chofer.Direccion.CodigoPostal);

            acceso.Abrir();
            chofer.Direccion.Id = acceso.LeerEscalar("AltaDireccion", parametrosDireccion);

            SqlParameter[] parametrosPersona = new SqlParameter[6];
            parametrosPersona[0] = acceso.CrearParametro("@Nombre", chofer.Nombre);
            parametrosPersona[1] = acceso.CrearParametro("@Apellido", chofer.Apellido);
            parametrosPersona[2] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);
            parametrosPersona[3] = acceso.CrearParametro("@DNI", chofer.DNI);
            parametrosPersona[4] = acceso.CrearParametro("@Email", chofer.Email);
            parametrosPersona[5] = acceso.CrearParametro("@IdDireccion", chofer.Direccion.Id);

            chofer.Id = acceso.LeerEscalar("AltaPersona", parametrosPersona);

            var mpTelefono = new MPTelefono();
            var telefonoId = mpTelefono.AltaTelefono(chofer.Telefono);

            SqlParameter[] parametrosChofer = new SqlParameter[2];
            parametrosChofer[0] = acceso.CrearParametro("@Id", chofer.Id);
            parametrosChofer[1] = acceso.CrearParametro("@IdTelefono", telefonoId);

            acceso.Escribir("AltaChofer", parametrosChofer);

            acceso.Cerrar();
        }

        public List<Chofer> ListarChoferes()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarChoferes");
            acceso.Cerrar();

            var choferes = new List<Chofer>();

            foreach (DataRow Registro in resultado.Rows)
            {
                var chofer = new Chofer
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
                    }
                };

                choferes.Add(chofer);
            }

            return choferes;
        }

        public void BajaChofer(Chofer chofer)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@Id", chofer.Id);

            acceso.Abrir();
            acceso.Escribir("BajaChofer", parametros);
            acceso.Cerrar();
        }

        public void ModificarChofer(Chofer chofer)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[5];
            parametrosDireccion[0] = acceso.CrearParametro("@Id", chofer.Direccion.Id);
            parametrosDireccion[1] = acceso.CrearParametro("@Calle", chofer.Direccion.Calle);
            parametrosDireccion[2] = acceso.CrearParametro("@Altura", chofer.Direccion.Altura);
            parametrosDireccion[3] = acceso.CrearParametro("@Unidad", chofer.Direccion.Unidad);
            parametrosDireccion[4] = acceso.CrearParametro("@CodigoPostal", chofer.Direccion.CodigoPostal);

            SqlParameter[] parametrosPersona = new SqlParameter[6];
            parametrosPersona[0] = acceso.CrearParametro("@Id", chofer.Id);
            parametrosPersona[1] = acceso.CrearParametro("@Nombre", chofer.Nombre);
            parametrosPersona[2] = acceso.CrearParametro("@Apellido", chofer.Apellido);
            parametrosPersona[3] = acceso.CrearParametro("@DNI", chofer.DNI);
            parametrosPersona[4] = acceso.CrearParametro("@Email", chofer.Email);
            parametrosPersona[5] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            SqlParameter[] parametrosTelefono = new SqlParameter[3];
            parametrosTelefono[0] = acceso.CrearParametro("@Id", chofer.Telefono.Id);
            parametrosTelefono[1] = acceso.CrearParametro("@Caracteristica", chofer.Telefono.Caracteristica);
            parametrosTelefono[2] = acceso.CrearParametro("@Numero", chofer.Telefono.Numero);

            acceso.Abrir();
            acceso.Escribir("ModificarDireccion", parametrosDireccion);
            acceso.Escribir("ModificarPersona", parametrosPersona);
            acceso.Escribir("ModificarTelefono", parametrosTelefono);
            acceso.Cerrar();
        }
    }
}
