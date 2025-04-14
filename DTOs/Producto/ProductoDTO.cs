using DTOs.Categoria;
using DTOs.HistorialProductos;
using DTOs.Proveedor;
using DTOs.Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Producto
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int? ProveedorId { get; set; }
        public int? CategoriaId { get; set; }
        
        public StockDTO StockDisponible { get; set; }

        [NotMapped]
        public HistorialProductosDTO? HistorialProductos { get; set; }

        [NotMapped]
        public string? NombreProveedor { get; set; }

        [NotMapped]
        public string?  NombreCategoria { get; set;}

        public CategoriaDTO Categoria { get; set; }
    }
}
