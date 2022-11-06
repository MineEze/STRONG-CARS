using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public Direccion Direccion { get; set; }

        public string Email { get; set; }

        public string DNI { get; set; }

        public string Legajo
        {
            get
            {
                return Id.ToString("0000");
            }
        }
    }
}
