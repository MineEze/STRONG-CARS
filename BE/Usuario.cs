using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario : Persona
    {
        public string NombreDeUsuario { get; set; }

        public string Password { get; set; }
        public List<Permiso> Permisos { get; set; }

        public int CantidadIntentosLogIn { get; set; }

        public bool Bloqueado { get; set; }

        public bool Borrado { get; set; }

        public override string ToString()
        {
            return NombreDeUsuario;
        }
    }

    public class UsuarioReporte
    {
        public string NombreDeUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }
}
