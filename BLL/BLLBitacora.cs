using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLBitacora
    {
        public void RegistrarMensaje(MensajeBitacora mensajeBitacora)
        {
            var mpBitacora = new MPBitacora();

            mpBitacora.RegistrarMensaje(mensajeBitacora);
        }

        public List<MensajeBitacora> ListarBitacora()
        {
            var mpBitacora = new MPBitacora();

            return mpBitacora.ListarBitacora();
        }

        public List<MensajeBitacoraReporte> ListarBitacoraReporte()
        {
            var mpBitacora = new MPBitacora();

            var mensajes = mpBitacora.ListarBitacora();

            var mensajesReporte = new List<MensajeBitacoraReporte>();

            foreach (var mensaje in mensajes)
            {
                mensajesReporte.Add(new MensajeBitacoraReporte
                {
                    FechaYHora = mensaje.FechaYHora.ToString(),
                    Usuario = mensaje.Usuario.NombreDeUsuario,
                    Mensaje = mensaje.Mensaje
                });
            }

            return mensajesReporte;
        }
    }
}
