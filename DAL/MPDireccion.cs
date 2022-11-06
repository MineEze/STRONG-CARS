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
    public class MPDireccion
    {
        public Direccion ObtenerDireccion(int idDireccion)
        {
            var acceso = new Acceso();

            var direccion = new Direccion { Id = idDireccion };

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@Id", idDireccion);

            acceso.Abrir();
            DataTable resultado = acceso.Leer(@"ObtenerDireccion", parametros);
            acceso.Cerrar();

            foreach (DataRow Registro in resultado.Rows)
            {
                direccion.Calle = Registro["Calle"].ToString();
                direccion.Altura = Convert.ToInt32(Registro["Altura"]);
                direccion.Unidad = Registro["Unidad"].ToString();
                direccion.CodigoPostal = Registro["CodigoPostal"].ToString();
            }

            return direccion;
        }

        public int AltaDireccion(Direccion direccion)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[4];
            parametrosDireccion[0] = acceso.CrearParametro("@Calle", direccion.Calle);
            parametrosDireccion[1] = acceso.CrearParametro("@Altura", direccion.Altura);
            parametrosDireccion[2] = acceso.CrearParametro("@Unidad", direccion.Unidad);
            parametrosDireccion[3] = acceso.CrearParametro("@CodigoPostal", direccion.CodigoPostal);

            acceso.Abrir();
            var id = acceso.LeerEscalar("AltaDireccion", parametrosDireccion);
            acceso.Cerrar();

            return id;
        }

        public void ModificarDireccion(Direccion direccion)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[5];
            parametrosDireccion[0] = acceso.CrearParametro("@Id", direccion.Id);
            parametrosDireccion[1] = acceso.CrearParametro("@Calle", direccion.Calle);
            parametrosDireccion[2] = acceso.CrearParametro("@Altura", direccion.Altura);
            parametrosDireccion[3] = acceso.CrearParametro("@Unidad", direccion.Unidad);
            parametrosDireccion[4] = acceso.CrearParametro("@CodigoPostal", direccion.CodigoPostal);

            acceso.Abrir();
            acceso.Escribir("ModificarDireccion", parametrosDireccion);
            acceso.Cerrar();
        }
    }
}
