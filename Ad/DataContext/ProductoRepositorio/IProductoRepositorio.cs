using DTOs.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.ProductoRepositorio
{
    public interface IProductoRepositorio<ProductoDTO>
    {
        Task<bool> InsertarProducto(string nombreProducto, string nombreProveedor, string nombreCategoria, int stockDisponible, decimal precioProducto, decimal porcentajeGanancia, decimal precioPublico);

    }
}
