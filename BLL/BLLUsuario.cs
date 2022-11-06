using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLUsuario
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;

        public BLLUsuario()
        {
            _bllBitacora = new BLLBitacora();
        }

        public BLLUsuario(Usuario usuario) : this()
        {
            _usuarioLogueado = usuario;
        }

        public Usuario LogIn(Usuario usuario)
        {
            var resultadoValidacion = ValidarDatosLogIn(usuario);

            if (!resultadoValidacion) return null;

            var bllEncriptacion = new BLLEncriptacion();
            var mpUsuario = new MPUsuario();

            usuario.Password = bllEncriptacion.Encriptar(usuario.Password);

            var usuarioEncontrado = mpUsuario.ObtenerUsuario(usuario);

            if (usuarioEncontrado == null || usuarioEncontrado.Borrado) return null;

            if (usuarioEncontrado.Bloqueado)
            {
                _bllBitacora.RegistrarMensaje(new MensajeBitacora(usuarioEncontrado, $"Log in fallido. El usuario ya se encontraba bloqueado."));
                return usuarioEncontrado;
            }

            if (usuario.Password == usuarioEncontrado.Password)
            {
                if (usuarioEncontrado.CantidadIntentosLogIn > 0)
                {
                    usuarioEncontrado.CantidadIntentosLogIn = 0;
                    mpUsuario.ActualizarCantidadDeIntentosLogIn(usuarioEncontrado);
                }

                var bllPermiso = new BLLPermiso();
                usuarioEncontrado.Permisos = bllPermiso.ListarPermisos(usuarioEncontrado);

                _bllBitacora.RegistrarMensaje(new MensajeBitacora(usuarioEncontrado, "Log in exitoso."));

                return usuarioEncontrado;
            }
            else
            {
                if (usuarioEncontrado.CantidadIntentosLogIn < 2)
                {
                    usuarioEncontrado.CantidadIntentosLogIn++;
                    mpUsuario.ActualizarCantidadDeIntentosLogIn(usuarioEncontrado);
                    _bllBitacora.RegistrarMensaje(new MensajeBitacora(usuarioEncontrado, $"Log in fallido. Cantidad de intentos de log in restantes {3 - usuarioEncontrado.CantidadIntentosLogIn}."));
                }
                else
                {
                    usuarioEncontrado.Bloqueado = true;
                    mpUsuario.BloquearUsuario(usuarioEncontrado);
                    _bllBitacora.RegistrarMensaje(new MensajeBitacora(usuarioEncontrado, $"Log in fallido. Se bloqueó el usuario."));
                }

                return null;
            }
        }

        private bool ValidarDatosLogIn(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.NombreDeUsuario) ||
                string.IsNullOrWhiteSpace(usuario.Password)) return false;

            return true;
        }

        public List<Usuario> ListarUsuarios()
        {
            var mpUsuario = new MPUsuario();
            return mpUsuario.ListarUsuarios();
        }

        public List<UsuarioReporte> ListarUsuariosReporte()
        {
            var mpUsuario = new MPUsuario();
            var usuarios = mpUsuario.ListarUsuarios();

            var usuariosReporte = new List<UsuarioReporte>();

            foreach (var u in usuarios)
            {
                usuariosReporte.Add(new UsuarioReporte
                {
                    NombreDeUsuario = u.NombreDeUsuario,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido
                });
            }

            return usuariosReporte;
        }

        public bool CrearUsuario(Usuario usuario)
        {
            var mpUsuario = new MPUsuario();
            var usuarioEncontrado = mpUsuario.ObtenerUsuario(usuario);

            if (usuarioEncontrado != null) return false;

            var bllEncriptacion = new BLLEncriptacion();

            usuario.Password = bllEncriptacion.Encriptar(usuario.Password);

            usuario = mpUsuario.CrearUsuario(usuario);
            
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Usuario creado: {usuario.NombreDeUsuario}"));

            return true;
        }

        public void BajaUsuario(Usuario usuario)
        {
            var mpUsuario = new MPUsuario();
            mpUsuario.BajaUsuario(usuario);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Usuario borrado: {usuario.NombreDeUsuario}"));
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            var mpUsuario = new MPUsuario();

            var usuarioEncontrado = mpUsuario.ObtenerUsuario(usuario);

            if (usuarioEncontrado != null && usuario.Id != usuarioEncontrado.Id)
                return false;

            mpUsuario.ModificarUsuario(usuario);

            if (usuario.Bloqueado)
                mpUsuario.BloquearUsuario(usuarioEncontrado);
            else if (usuario.CantidadIntentosLogIn == 0)
                mpUsuario.DesbloquearUsuario(usuarioEncontrado);

            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Usuario modificado: {usuario.NombreDeUsuario}"));

            return true;
        }
    }
}
