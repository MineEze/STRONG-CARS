using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reserva
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public decimal CostoVehiculo { get; set; }

        public decimal CostoChofer { get; set; }

        public decimal RecargoSucursal { get; set; }

        public decimal CostoTotal { get; set; }
    }
}
