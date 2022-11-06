using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente : Persona
    {
        public Telefono Telefono { get; set; }

        public string Licencia { get; set; }

        public Empresa Empresa { get; set; }

        public string EmpresaNombre
        {
            get
            {
                if (Empresa != null)
                    return Empresa.Nombre;
                else
                    return "";
            }
        }
    }

    public class ClienteReporte
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string EmpresaNombre { get; set; }
    }
}
