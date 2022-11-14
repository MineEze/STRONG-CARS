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
    public class MPVehiculo
    {
        public List<Marca> ListarMarcas()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarMarcas");
            acceso.Cerrar();

            var marcas = new List<Marca>();

            foreach (DataRow Registro in resultado.Rows)
            {
                marcas.Add(new Marca
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Nombre = Registro["Nombre"].ToString()
                });
            }

            return marcas;
        }

        public List<Modelo> ListarModelos()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarModelos");
            acceso.Cerrar();

            var marcas = ListarMarcas();
            var modelos = new List<Modelo>();

            foreach (DataRow Registro in resultado.Rows)
            {
                modelos.Add(new Modelo
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Nombre = Registro["Nombre"].ToString(),
                    Marca = marcas.First(m => Convert.ToInt32(Registro["IdMarca"]) == m.Id)
                });
            }

            return modelos;
        }

        public List<Vehiculo> ListarVehiculos()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarVehiculos");
            acceso.Cerrar();

            var vehiculos = new List<Vehiculo>();

            var mpSucursal = new MPSucursal();
            var sucursales = mpSucursal.ListarSucursales();

            foreach (DataRow r in resultado.Rows)
            {
                var sucursal = sucursales.FirstOrDefault(s => s.Id == Convert.ToInt32(r["IdSucursal"]));

                if (sucursal != null)
                    vehiculos.Add(new Vehiculo
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        Kilometraje = Convert.ToInt32(r["Kilometraje"]),
                        PrecioDiarioBase = Convert.ToInt32(r["PrecioDiarioBase"]),
                        NivelBlindaje = Convert.ToInt32(r["NivelBlindaje"]),
                        Patente = r["Patente"].ToString(),
                        Sucursal = sucursal,
                        FechaDeInicio = Convert.ToDateTime(r["FechaDeInicio"]),
                        Modelo = new Modelo
                        {
                            Marca = new Marca
                            {
                                Id = Convert.ToInt32(r["MarcaId"]),
                                Nombre = r["MarcaNombre"].ToString()
                            },
                            Id = Convert.ToInt32(r["IdModelo"]),
                            Nombre = r["ModeloNombre"].ToString()
                        }
                    });
            }

            return vehiculos;
        }

        public void AltaVehiculo(Vehiculo vehiculo)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = acceso.CrearParametro("@Patente", vehiculo.Patente);
            parametros[1] = acceso.CrearParametro("@IdModelo", vehiculo.Modelo.Id);
            parametros[2] = acceso.CrearParametro("@NivelBlindaje", vehiculo.NivelBlindaje);
            parametros[3] = acceso.CrearParametro("@Kilometraje", vehiculo.Kilometraje);
            parametros[4] = acceso.CrearParametro("@PrecioDiarioBase", vehiculo.PrecioDiarioBase);
            parametros[5] = acceso.CrearParametro("@IdSucursal", vehiculo.Sucursal.Id);
            parametros[6] = acceso.CrearParametro("@FechaDeInicio", vehiculo.FechaDeInicio);
            parametros[7] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            acceso.Abrir();
            acceso.Escribir("AltaVehiculo", parametros);
            acceso.Cerrar();
        }

        public void ModificarVehiculo(Vehiculo vehiculo)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[9];
            parametros[0] = acceso.CrearParametro("@Id", vehiculo.Id);
            parametros[1] = acceso.CrearParametro("@IdModelo", vehiculo.Modelo.Id);
            parametros[2] = acceso.CrearParametro("@IdSucursal", vehiculo.Sucursal.Id);
            parametros[3] = acceso.CrearParametro("@Patente", vehiculo.Patente);
            parametros[4] = acceso.CrearParametro("@Kilometraje", vehiculo.Kilometraje);
            parametros[5] = acceso.CrearParametro("@PrecioDiarioBase", vehiculo.PrecioDiarioBase);
            parametros[6] = acceso.CrearParametro("@NivelBlindaje", vehiculo.NivelBlindaje);
            parametros[7] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);
            parametros[8] = acceso.CrearParametro("@FechaDeInicio", vehiculo.FechaDeInicio);

            acceso.Abrir();
            acceso.Escribir("ModificarVehiculo", parametros);
            acceso.Cerrar();
        }

        public void ActualizarKilometraje(Vehiculo vehiculo)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = acceso.CrearParametro("@Id", vehiculo.Id);
            parametros[1] = acceso.CrearParametro("@Kilometraje", vehiculo.Kilometraje);

            acceso.Abrir();
            acceso.Escribir("ActualizarKilometraje", parametros);
            acceso.Cerrar();
        }

        public void BajaVehiculo(Vehiculo vehiculo)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@Id", vehiculo.Id);

            acceso.Abrir();
            acceso.Escribir("BajaVehiculo", parametros);
            acceso.Cerrar();
        }
    }
}
