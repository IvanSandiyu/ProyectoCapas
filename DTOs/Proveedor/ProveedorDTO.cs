using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Proveedor
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string DiasVisita { get; set; }
        public string TipoProducto { get; set; }
        public bool Estado { get; set; }
        //public string NombreProveedor { get; set; }
    }
}
