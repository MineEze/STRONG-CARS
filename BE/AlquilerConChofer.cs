using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AlquilerConChofer : Alquiler
    {
        public Chofer Chofer { get; set; }
    }
}
