using DTOs.Categoria;
using DTOs.Proveedor;
using DTOs.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Producto
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public int ProveedorId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }

        public StockDTO StockDisponible { get; set;}

      

        public ProveedorDTO Proveedor { get; set; }

        public CategoriaDTO Categoria { get; set;}
    }
}
