using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLPermiso
    {
        private BLLBitacora _bllBitacora;
        private Usuario _usuarioLogueado;

        public BLLPermiso(Usuario usuario)
        {
            _usuarioLogueado = usuario;
        }
        public BLLPermiso()
        {

        }
        public List<Permiso> ListarPermisos()
        {
            var mpPermiso = new MPPermiso();
            return mpPermiso.ListarPermisos();
        }

        public List<Permiso> ListarPermisos(Usuario usuario)
        {
            var mpPermiso = new MPPermiso();
            return mpPermiso.ListarPermisos(usuario);
        }

        public bool PermisoEncontrado(List<Permiso> permisos, string permisoBuscado)
        {
            foreach (var p in permisos)
            {
                if (p.Nombre == permisoBuscado) return true;

                if (p is GrupoPermisos)
                {
                    var grupo = p as GrupoPermisos;

                    foreach (var permisoHijo in grupo.Permisos)
                        if (permisoHijo.Nombre == permisoBuscado) return true;
                }
            }

            return false;
        }

        public void AltaPermiso(Permiso permiso, Permiso permisoPadre)
        {
            var mpPermiso = new MPPermiso();
            mpPermiso.AltaPermiso(permiso, permisoPadre);
            _bllBitacora.RegistrarMensaje(new MensajeBitacora(_usuarioLogueado, $"Alta permiso: {permiso.Nombre}."));
        }
    }
}