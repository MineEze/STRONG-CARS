using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class MPReporte
    {
        public void AltaReporte(Reporte reporte)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = acceso.CrearParametro("@IdVehiculo", reporte.Vehiculo.Id);
            parametros[1] = acceso.CrearParametro("@Descripcion", reporte.Descripcion);
            parametros[2] = acceso.CrearParametro("@Fecha", DateTime.Now);

            acceso.Abrir();
            acceso.Escribir("AltaReporte", parametros);
            acceso.Cerrar();
        }

        public List<Reporte> ListarReportes()
        {
            var mpVehiculo = new MPVehiculo();
            var vehiculos = mpVehiculo.ListarVehiculos();

            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarReportes");
            acceso.Cerrar();

            var reportes = new List<Reporte>();

            foreach (DataRow Registro in resultado.Rows)
            {
                var vehiculo = vehiculos.FirstOrDefault(v => v.Id == Convert.ToInt32(Registro["IdVehiculo"]));

                if (vehiculo != null)
                    reportes.Add(new Reporte
                    {
                        Id = Convert.ToInt32(Registro["Id"]),
                        Vehiculo = vehiculo,
                        Descripcion = Registro["Descripcion"].ToString(),
                        Fecha = Convert.ToDateTime(Registro["Fecha"])
                    });
            }

            return reportes;
        }
    }
}
