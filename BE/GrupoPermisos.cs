using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GrupoPermisos : Permiso
    {
        public List<Permiso> Permisos { get; set; }
    }
}
