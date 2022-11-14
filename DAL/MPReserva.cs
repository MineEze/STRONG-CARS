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
    public class MPReserva
    {
        public List<Reserva> ListarReservas()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarReservas");

            var reservas = new List<Reserva>();

            foreach (DataRow Registro in resultado.Rows)
            {
                reservas.Add(new Reserva
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Vehiculo = new Vehiculo { Id = Convert.ToInt32(Registro["IdVehiculo"]) },
                    FechaInicio = Convert.ToDateTime(Registro["FechaDeInicio"]),
                    FechaFin = Convert.ToDateTime(Registro["FechaDeFin"]),
                    CostoVehiculo = Convert.ToDecimal(Registro["CostoVehiculo"]),
                    CostoChofer = Convert.ToDecimal(Registro["CostoChofer"]),
                    RecargoSucursal = Convert.ToDecimal(Registro["RecargoSucursal"]),
                    Total = Convert.ToDecimal(Registro["Total"])
                });
            }

            acceso.Cerrar();

            return reservas;
        }


        public List<AlquilerConChofer> ListarAlquileresConChofer()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarAlquilerConChofer");

            var alquileresConChofer = new List<AlquilerConChofer>();

            foreach (DataRow Registro in resultado.Rows)
            {
                alquileresConChofer.Add(new AlquilerConChofer
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Vehiculo = new Vehiculo { Id = Convert.ToInt32(Registro["IdVehiculo"]) },
                    FechaInicio = Convert.ToDateTime(Registro["FechaDeInicio"]),
                    FechaFin = Convert.ToDateTime(Registro["FechaDeFin"]),
                    Chofer = new Chofer { Id = Convert.ToInt32(Registro["IdChofer"]) },
                    CostoVehiculo = Convert.ToDecimal(Registro["CostoVehiculo"]),
                    CostoChofer = Convert.ToDecimal(Registro["CostoChofer"]),
                    RecargoSucursal = Convert.ToDecimal(Registro["RecargoSucursal"]),
                    Total = Convert.ToDecimal(Registro["Total"])
                });
            }

            acceso.Cerrar();

            return alquileresConChofer;
        }

        public List<Alquiler> ListarAlquileres()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarAlquileres");

            var alquileres = new List<Alquiler>();

            var mpSucursal = new MPSucursal();
            var sucursales = mpSucursal.ListarSucursales();

            var mpVehiculo = new MPVehiculo();
            var vehiculos = mpVehiculo.ListarVehiculos();

            foreach (DataRow Registro in resultado.Rows)
            {
                var vehiculo = vehiculos.FirstOrDefault(v => v.Id == Convert.ToInt32(Registro["IdVehiculo"]));

                if (vehiculo != null)
                    alquileres.Add(new Alquiler
                    {
                        Id = Convert.ToInt32(Registro["Id"]),
                        Vehiculo = vehiculo,
                        FechaInicio = Convert.ToDateTime(Registro["FechaDeInicio"]),
                        FechaFin = Convert.ToDateTime(Registro["FechaDeFin"]),
                        Retornado = Convert.ToBoolean(Registro["Retornado"]),
                        SucursalOrigen = sucursales.First(s => s.Id == Convert.ToInt32(Registro["IdSucursalOrigen"])),
                        SucursalDestino = sucursales.First(s => s.Id == Convert.ToInt32(Registro["IdSucursalDestino"])),
                        Cliente = new Cliente { Nombre = Registro["Nombre"].ToString(), Apellido = Registro["Apellido"].ToString() },
                        CostoVehiculo = Convert.ToDecimal(Registro["CostoVehiculo"]),
                        CostoChofer = Convert.ToDecimal(Registro["CostoChofer"]),
                        RecargoSucursal = Convert.ToDecimal(Registro["RecargoSucursal"]),
                        Total = Convert.ToDecimal(Registro["Total"])
                    });
            }

            acceso.Cerrar();

            return alquileres;
        }

        public void AltaAlquiler(AlquilerConChofer alquiler)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosReserva = new SqlParameter[8];
            parametrosReserva[0] = acceso.CrearParametro("@IdVehiculo", alquiler.Vehiculo.Id);
            parametrosReserva[1] = acceso.CrearParametro("@FechaDeInicio", alquiler.FechaInicio);
            parametrosReserva[2] = acceso.CrearParametro("@FechaDeFin", alquiler.FechaFin);
            parametrosReserva[3] = acceso.CrearParametro("@CostoVehiculo", alquiler.CostoVehiculo.ToString());
            parametrosReserva[4] = acceso.CrearParametro("@CostoChofer", alquiler.CostoChofer.ToString());
            parametrosReserva[5] = acceso.CrearParametro("@RecargoSucursal", alquiler.RecargoSucursal.ToString());
            parametrosReserva[6] = acceso.CrearParametro("@Total", alquiler.Total.ToString());
            parametrosReserva[7] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            acceso.Abrir();

            alquiler.Id = acceso.LeerEscalar("AltaReserva", parametrosReserva);

            SqlParameter[] parametrosAlquiler = new SqlParameter[4];
            parametrosAlquiler[0] = acceso.CrearParametro("@Id", alquiler.Id);
            parametrosAlquiler[1] = acceso.CrearParametro("@IdSucursalOrigen", alquiler.SucursalOrigen.Id);
            parametrosAlquiler[2] = acceso.CrearParametro("@IdSucursalDestino", alquiler.SucursalDestino.Id);
            parametrosAlquiler[3] = acceso.CrearParametro("@IdCliente", alquiler.Cliente.Id);

            acceso.Escribir("AltaAlquiler", parametrosAlquiler);

            if (alquiler.Chofer != null)
                AltaAlquilerConChofer(alquiler);

            acceso.Cerrar();
        }

        public void AltaAlquilerConChofer(AlquilerConChofer alquiler)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = acceso.CrearParametro("@Id", alquiler.Id);
            parametros[1] = acceso.CrearParametro("@IdChofer", alquiler.Chofer.Id);

            acceso.Abrir();

            acceso.Escribir("AltaAlquilerConChofer", parametros);

            acceso.Cerrar();
        }

        public void BajaReserva(Reserva reserva)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@Id", reserva.Id);

            acceso.Abrir();
            acceso.Escribir("BajaAlquilerConChofer", parametros);
            acceso.Escribir("BajaAlquiler", parametros);
            acceso.Escribir("BajaReserva", parametros);
            acceso.Cerrar();
        }

        public void RetornarVehiculo(Alquiler alquiler)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@Id", alquiler.Id);

            acceso.Abrir();
            acceso.Escribir("RetornarVehiculo", parametros);
            acceso.Cerrar();
        }
    }
}
