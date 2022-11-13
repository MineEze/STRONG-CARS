using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MPUsuario
    {
        public Usuario ObtenerUsuario(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@NombreDeUsuarioParam", usuario.NombreDeUsuario);

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ObtenerUsuario", parametros);
            acceso.Cerrar();

            if (resultado.Rows.Count == 0) return null;

            var usuarioEncontrado = new Usuario();

            foreach (DataRow Registro in resultado.Rows)
            {
                usuarioEncontrado.Id = Convert.ToInt32(Registro["Id"]);
                usuarioEncontrado.Password = Registro["Password"].ToString();
                usuarioEncontrado.CantidadIntentosLogIn = Convert.ToInt32(Registro["CantidadIntentosLogIn"]);
                usuarioEncontrado.Bloqueado = Convert.ToBoolean(Registro["Bloqueado"]);
                usuarioEncontrado.Borrado = Convert.ToBoolean(Registro["Borrado"]);
                usuarioEncontrado.Nombre = Registro["Nombre"].ToString();
                usuarioEncontrado.Apellido = Registro["Apellido"].ToString();
            }

            return usuarioEncontrado;
        }

        public Usuario ObtenerUsuario(int idUsuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@IdUsuario", idUsuario);

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ObtenerUsuarioPorId", parametros);
            acceso.Cerrar();

            if (resultado.Rows.Count == 0) return null;

            var usuarioEncontrado = new Usuario();

            foreach (DataRow Registro in resultado.Rows)
            {
                usuarioEncontrado.Id = Convert.ToInt32(Registro["Id"]);
                usuarioEncontrado.Password = Registro["Password"].ToString();
                usuarioEncontrado.CantidadIntentosLogIn = Convert.ToInt32(Registro["CantidadIntentosLogIn"]);
                usuarioEncontrado.Bloqueado = Convert.ToBoolean(Registro["Bloqueado"]);
                usuarioEncontrado.Borrado = Convert.ToBoolean(Registro["Borrado"]);
                usuarioEncontrado.NombreDeUsuario = Registro["NombreDeUsuario"].ToString();
                usuarioEncontrado.Nombre = Registro["Nombre"].ToString();
                usuarioEncontrado.Apellido = Registro["Apellido"].ToString();
            }

            return usuarioEncontrado;
        }

        public void ActualizarCantidadDeIntentosLogIn(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = acceso.CrearParametro("IdUsuarioParam", usuario.Id);
            parametros[1] = acceso.CrearParametro("CantidadIntentosLogInParam", usuario.CantidadIntentosLogIn);

            acceso.Abrir();
            acceso.Escribir("ActualizarCantidadDeIntentosLogIn", parametros);
            acceso.Cerrar();
        }

        public void BloquearUsuario(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("IdUsuarioParam", usuario.Id);

            acceso.Abrir();
            acceso.Escribir("BloquearUsuario", parametros);
            acceso.Cerrar();
        }

        public void DesbloquearUsuario(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("Id", usuario.Id);

            acceso.Abrir();
            acceso.Escribir("DesbloquearUsuario", parametros);
            acceso.Cerrar();
        }

        public List<Usuario> ListarUsuarios()
        {
            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultado = acceso.Leer("ListarUsuarios");
            acceso.Cerrar();

            var usuarios = new List<Usuario>();

            var mpPermiso = new MPPermiso();

            foreach (DataRow Registro in resultado.Rows)
            {
                var usuario = new Usuario
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Email = Registro["Email"].ToString(),
                    DNI = Registro["DNI"].ToString(),
                    NombreDeUsuario = Registro["NombreDeUsuario"].ToString(),
                    Password = Registro["Password"].ToString(),
                    CantidadIntentosLogIn = Convert.ToInt32(Registro["CantidadIntentosLogIn"]),
                    Bloqueado = Convert.ToBoolean(Registro["Bloqueado"]),
                    Borrado = Convert.ToBoolean(Registro["Borrado"]),
                    Nombre = Registro["PersonaNombre"].ToString(),
                    Apellido = Registro["Apellido"].ToString(),
                    Direccion = new Direccion
                    {
                        Id = Convert.ToInt32(Registro["IdDireccion"]),
                        Calle = Registro["Calle"].ToString(),
                        Altura = Convert.ToInt32(Registro["Altura"]),
                        Unidad = Registro["Unidad"].ToString(),
                        CodigoPostal = Registro["CodigoPostal"].ToString()
                    }
                };

                usuario.Permisos = mpPermiso.ListarPermisos(usuario);

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public Usuario CrearUsuario(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[4];
            parametrosDireccion[0] = acceso.CrearParametro("@Calle", usuario.Direccion.Calle);
            parametrosDireccion[1] = acceso.CrearParametro("@Altura", usuario.Direccion.Altura);
            parametrosDireccion[2] = acceso.CrearParametro("@Unidad", usuario.Direccion.Unidad);
            parametrosDireccion[3] = acceso.CrearParametro("@CodigoPostal", usuario.Direccion.CodigoPostal);

            acceso.Abrir();
            usuario.Direccion.Id = acceso.LeerEscalar("AltaDireccion", parametrosDireccion);

            SqlParameter[] parametrosPersona = new SqlParameter[6];
            parametrosPersona[0] = acceso.CrearParametro("@Nombre", usuario.Nombre);
            parametrosPersona[1] = acceso.CrearParametro("@Apellido", usuario.Apellido);
            parametrosPersona[2] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);
            parametrosPersona[3] = acceso.CrearParametro("@DNI", usuario.DNI);
            parametrosPersona[4] = acceso.CrearParametro("@Email", usuario.Email);
            parametrosPersona[5] = acceso.CrearParametro("@IdDireccion", usuario.Direccion.Id);

            usuario.Id = acceso.LeerEscalar("AltaPersona", parametrosPersona);

            SqlParameter[] parametrosUsuario = new SqlParameter[3];
            parametrosUsuario[0] = acceso.CrearParametro("@Id", usuario.Id);
            parametrosUsuario[1] = acceso.CrearParametro("@NombreDeUsuario", usuario.NombreDeUsuario);
            parametrosUsuario[2] = acceso.CrearParametro("@Password", usuario.Password);

            acceso.Escribir("AltaUsuario", parametrosUsuario);

            if (usuario.Permisos != null)
            {
                foreach (var permiso in usuario.Permisos)
                {
                    SqlParameter[] parametrosUsuarioPermiso = new SqlParameter[2];
                    parametrosUsuarioPermiso[0] = acceso.CrearParametro("@IdUsuario", usuario.Id);
                    parametrosUsuarioPermiso[1] = acceso.CrearParametro("@IdPermiso", permiso.Id);

                    acceso.Escribir("AltaUsuarioPermiso", parametrosUsuarioPermiso);
                }
            }

            acceso.Cerrar();

            return usuario;
        }

        public void BajaUsuario(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = acceso.CrearParametro("@IdUsuario", usuario.Id);

            acceso.Abrir();
            acceso.Escribir("BajaUsuario", parametros);
            acceso.Cerrar();
        }

        public void ModificarUsuario(Usuario usuario)
        {
            var acceso = new Acceso();

            SqlParameter[] parametrosDireccion = new SqlParameter[5];
            parametrosDireccion[0] = acceso.CrearParametro("@Id", usuario.Direccion.Id);
            parametrosDireccion[1] = acceso.CrearParametro("@Calle", usuario.Direccion.Calle);
            parametrosDireccion[2] = acceso.CrearParametro("@Altura", usuario.Direccion.Altura);
            parametrosDireccion[3] = acceso.CrearParametro("@Unidad", usuario.Direccion.Unidad);
            parametrosDireccion[4] = acceso.CrearParametro("@CodigoPostal", usuario.Direccion.CodigoPostal);

            SqlParameter[] parametrosPersona = new SqlParameter[6];
            parametrosPersona[0] = acceso.CrearParametro("@Id", usuario.Id);
            parametrosPersona[1] = acceso.CrearParametro("@Nombre", usuario.Nombre);
            parametrosPersona[2] = acceso.CrearParametro("@Apellido", usuario.Apellido);
            parametrosPersona[3] = acceso.CrearParametro("@DNI", usuario.DNI);
            parametrosPersona[4] = acceso.CrearParametro("@Email", usuario.Email);
            parametrosPersona[5] = acceso.CrearParametro("@UltimaModificacion", DateTime.Now);

            SqlParameter[] parametrosUsuario = new SqlParameter[2];
            parametrosUsuario[0] = acceso.CrearParametro("@Id", usuario.Id);
            parametrosUsuario[1] = acceso.CrearParametro("@NombreDeUsuario", usuario.NombreDeUsuario);

            SqlParameter[] parametrosPermisos = new SqlParameter[1];
            parametrosPermisos[0] = acceso.CrearParametro("@IdUsuario", usuario.Id);

            acceso.Abrir();
            acceso.Escribir("ModificarDireccion", parametrosDireccion);
            acceso.Escribir("ModificarPersona", parametrosPersona);
            acceso.Escribir("ModificarUsuario", parametrosUsuario);
            acceso.Escribir("BajaUsuarioPermiso", parametrosPermisos);

            if (usuario.Permisos != null)
            {
                foreach (var permiso in usuario.Permisos)
                {
                    SqlParameter[] parametrosUsuarioPermiso = new SqlParameter[2];
                    parametrosUsuarioPermiso[0] = acceso.CrearParametro("@IdUsuario", usuario.Id);
                    parametrosUsuarioPermiso[1] = acceso.CrearParametro("@IdPermiso", permiso.Id);

                    acceso.Escribir("AltaUsuarioPermiso", parametrosUsuarioPermiso);
                }
            }
        }
    }
}
