using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reporte
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public DateTime Fecha { get; set; }
    }

    public class ReporteReporte
    {
        public string Fecha { get; set; }

        public string Vehiculo { get; set; }

        public string Descripcion { get; set; }
    }
}
