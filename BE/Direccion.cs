using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Direccion
    {
        public int Id { get; set; }

        public string CodigoPostal { get; set; }

        public string Calle { get; set; }

        public int Altura { get; set; }

        public string Unidad { get; set; }
    }
}
