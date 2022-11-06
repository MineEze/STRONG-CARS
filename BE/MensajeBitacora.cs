using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MensajeBitacora
    {
        public int Id { get; set; }

        public string Mensaje { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime FechaYHora { get; set; }

        public MensajeBitacora(Usuario usuario, string mensaje)
        {
            Usuario = usuario;
            Mensaje = mensaje;
            FechaYHora = DateTime.Now;
        }

        public MensajeBitacora()
        {

        }
    }

    public class MensajeBitacoraReporte
    {
        public string Mensaje { get; set; }

        public string Usuario { get; set; }

        public string FechaYHora { get; set; }
    }
}
