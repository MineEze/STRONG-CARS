using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class MPBitacora
    {
        public void RegistrarMensaje(MensajeBitacora mensajeBitacora)
        {
            var acceso = new Acceso();

            if (mensajeBitacora.Usuario != null)
            {
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = acceso.CrearParametro("MensajeParam", mensajeBitacora.Mensaje);
                parametros[1] = acceso.CrearParametro("IdUsuarioParam", mensajeBitacora.Usuario.Id);
                parametros[2] = acceso.CrearParametro("FechaYHoraParam", mensajeBitacora.FechaYHora);

                acceso.Abrir();
                acceso.Escribir("RegistrarMensajeBitacora", parametros);
                acceso.Cerrar();
            }
            else
            {
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = acceso.CrearParametro("MensajeParam", mensajeBitacora.Mensaje);
                parametros[1] = acceso.CrearParametro("FechaYHoraParam", mensajeBitacora.FechaYHora);

                acceso.Abrir();
                acceso.Escribir("RegistrarMensajeBitacoraSinUsuario", parametros);
                acceso.Cerrar();
            }
        }

        public List<MensajeBitacora> ListarBitacora()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarBitacora");
            acceso.Cerrar();

            var mensajes = new List<MensajeBitacora>();

            foreach (DataRow registro in resultado.Rows)
            {
                mensajes.Add(new MensajeBitacora
                {
                    Mensaje = registro["Mensaje"].ToString(),
                    Usuario = new Usuario { NombreDeUsuario = registro["NombreDeUsuario"].ToString() },
                    FechaYHora = Convert.ToDateTime(registro["FechaYHora"])
                });
            }

            return mensajes;
        }
    }
}
