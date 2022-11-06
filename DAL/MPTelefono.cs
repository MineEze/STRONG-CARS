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
    public class MPTelefono
    {
        public int AltaTelefono(Telefono telefono, int idSucursal = 0)
        {
            var acceso = new Acceso();
            acceso.Abrir();

            SqlParameter[] parametros;
            int idTelefono;

            if (idSucursal != 0)
            {
                parametros = new SqlParameter[3];
                parametros[0] = acceso.CrearParametro("@IdSucursal", idSucursal);
                parametros[1] = acceso.CrearParametro("@Caracteristica", telefono.Caracteristica);
                parametros[2] = acceso.CrearParametro("@Numero", telefono.Numero);
                idTelefono = acceso.LeerEscalar("AltaTelefonoConSucursal", parametros);
            }
            else
            {
                parametros = new SqlParameter[2];
                parametros[0] = acceso.CrearParametro("@Caracteristica", telefono.Caracteristica);
                parametros[1] = acceso.CrearParametro("@Numero", telefono.Numero);
                idTelefono = acceso.LeerEscalar("AltaTelefonoSinSucursal", parametros);
            }

            acceso.Cerrar();

            return idTelefono;
        }
    }
}
