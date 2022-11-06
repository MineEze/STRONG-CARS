using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Vehiculo
    {
        public int Id { get; set; }

        public string Patente { get; set; }

        public Modelo Modelo { get; set; }

        public int NivelBlindaje { get; set; }

        public int Kilometraje { get; set; }

        public int PrecioDiarioBase { get; set; }

        public int PrecioPorKm { get; set; }

        public Sucursal Sucursal { get; set; }

        public DateTime FechaDeInicio { get; set; }

        public string MarcaNombre
        {
            get { return Modelo.Marca.Nombre; }
        }

        public string ModeloNombre
        {
            get { return Modelo.Nombre; }
        }

        public override string ToString()
        {
            return $"{MarcaNombre} {ModeloNombre} {Patente}";
        }
    }

    public class VehiculoReporte
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Patente { get; set; }
    }
}
