using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Sucursal
    {
        public Sucursal()
        {
            RecargoSucursales = new Dictionary<int, decimal>();
            Telefonos = new List<Telefono>();
        }

        public int Id { get; set; }

        public Direccion Direccion { get; set; }

        public List<Telefono> Telefonos { get; set; }

        public Usuario Gerente { get; set; }

        public Dictionary<int, decimal> RecargoSucursales { get; set; }

        public string NombreSucursal
        {
            get { return $"{Direccion.Calle} {Direccion.Altura}"; }
        }

        public string GerenteNombre
        {
            get { return $"{Gerente.Nombre} {Gerente.Apellido}"; }
        }

        public override string ToString()
        {
            return NombreSucursal;
        }
    }
    public class SucursalReporte
    {
        public string Nombre { get; set; }

        public string Gerente { get; set; }
    }
}
