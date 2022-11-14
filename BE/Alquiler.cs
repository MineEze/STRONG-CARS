using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Alquiler : Reserva
    {
        public Cliente Cliente { get; set; }

        public Sucursal SucursalOrigen { get; set; }

        public Sucursal SucursalDestino { get; set; }

        //public decimal Precio { get; set; }

        public bool Retornado { get; set; }
    }

    public class AlquilerReporte
    {
        public string SucursalOrigen { get; set; }

        public string FechaInicio { get; set; }

        public string FechaFin { get; set; }

        public string Vehiculo { get; set; }

        public string Total { get; set; }
    }
}
