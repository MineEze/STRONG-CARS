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
    public class MPPermiso
    {
        public List<Permiso> ListarPermisos()
        {
            var permisos = new List<Permiso>();

            var acceso = new Acceso();

            acceso.Abrir();
            DataTable resultadoPermisos = acceso.Leer(@"ListarPermiso");
            acceso.Cerrar();

            foreach (DataRow Registro in resultadoPermisos.Rows)
            {
                permisos.Add(new Permiso
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Nombre = Registro["Nombre"].ToString()
                });
            }

            return permisos;
        }

        public void AltaPermiso(Permiso permiso, Permiso permisoPadre)
        {
            var acceso = new Acceso();

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = acceso.CrearParametro("@Id", permiso.Id);
            parametros[1] = acceso.CrearParametro("@Nombre", permiso.Nombre);

            acceso.Abrir();
            acceso.Escribir("AltaPermiso", parametros);

            if (permisoPadre != null)
            {
                SqlParameter[] parametrosGrupo = new SqlParameter[2];
                parametrosGrupo[0] = acceso.CrearParametro("@IdHijo", permiso.Id);
                parametrosGrupo[1] = acceso.CrearParametro("@IdGrupo", permisoPadre.Id);

                acceso.Escribir("AltaGrupoPermiso", parametrosGrupo);
            }

            acceso.Cerrar();
        }

        public List<Permiso> ListarPermisos(Usuario usuario)
        {
            var permisosUsuario = new List<Permiso>();
            var idsPermisosUsuario = new List<int>();
            var gruposPermisos = new List<GrupoPermisoIds>();
            var permisos = new List<Permiso>();

            var acceso = new Acceso();

            SqlParameter[] parametrosUsuarioPermiso = new SqlParameter[1];
            parametrosUsuarioPermiso[0] = acceso.CrearParametro("@IdUsuarioParam", usuario.Id);

            acceso.Abrir();
            DataTable resultadoUsuarioPermiso = acceso.Leer("ListarUsuarioPermiso", parametrosUsuarioPermiso);
            acceso.Cerrar();

            if (resultadoUsuarioPermiso.Rows.Count == 0) return permisosUsuario;

            foreach (DataRow Registro in resultadoUsuarioPermiso.Rows)
                idsPermisosUsuario.Add(Convert.ToInt32(Registro["IdPermiso"]));

            acceso.Abrir();
            DataTable resultadoGrupoPermiso = acceso.Leer(@"ListarGrupoPermiso");
            acceso.Cerrar();

            foreach (DataRow Registro in resultadoGrupoPermiso.Rows)
            {
                gruposPermisos.Add(new GrupoPermisoIds
                {
                    IdGrupo = Convert.ToInt32(Registro["IdGrupo"]),
                    IdHijo = Convert.ToInt32(Registro["IdHijo"])
                });
            }

            acceso.Abrir();
            DataTable resultadoPermisos = acceso.Leer(@"ListarPermiso");
            acceso.Cerrar();

            foreach (DataRow Registro in resultadoPermisos.Rows)
            {
                permisos.Add(new Permiso
                {
                    Id = Convert.ToInt32(Registro["Id"]),
                    Nombre = Registro["Nombre"].ToString()
                });
            }

            foreach (var idPermiso in idsPermisosUsuario)
            {
                if (gruposPermisos.Select(gp => gp.IdGrupo).Contains(idPermiso)) // es grupo
                {
                    var hijos = ObtenerHijos(idPermiso, gruposPermisos, permisos);

                    permisosUsuario.Add(new GrupoPermisos { Id = idPermiso, Permisos = hijos, Nombre = permisos.First(p => p.Id == idPermiso).Nombre });
                }
                else
                    permisosUsuario.Add(new Permiso { Id = idPermiso, Nombre = permisos.First(p => p.Id == idPermiso).Nombre }); // es permiso simple
            }

            return permisosUsuario;
        }

        private List<Permiso> ObtenerHijos(int idPermiso, List<GrupoPermisoIds> gruposPermisos, List<Permiso> permisos)
        {
            var hijosIds = gruposPermisos.Where(gp => gp.IdGrupo == idPermiso).Select(gp => gp.IdHijo);

            var hijos = new List<Permiso>();

            foreach (var hijoId in hijosIds)
                hijos.Add(new Permiso { Id = hijoId, Nombre = permisos.First(p => p.Id == hijoId).Nombre });

            return hijos;
        }


        private class GrupoPermisoIds
        {
            public int IdGrupo { get; set; }

            public int IdHijo { get; set; }
        }
    }
}
