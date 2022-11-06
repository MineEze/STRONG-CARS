using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Chofer : Persona
    {
        public Telefono Telefono { get; set; }

        public override string ToString()
        {
            return $"{Legajo} {Nombre} {Apellido}";
        }
    }

    public class ChoferReporte
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
