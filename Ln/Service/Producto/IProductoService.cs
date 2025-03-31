using DTOs.Paginacion;
using DTOs.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Producto
{
    public interface IProductoService
    {
        Task<bool> Insertar(string nombreProducto,string nombreProveedor,string nombreCategoria,int stockDisponible,float precioProducto,float porcentajeGanancia);
        Task<bool> Actualizar(ProductoDTO models);

        Task<bool> Eliminar(int id);

        Task<ProductoDTO> Obtener(int id);

        Task<IQueryable<ProductoDTO>> ObtenerTodos();

        Task<ProductoDTO> ObtenerPorNombre(string nombre);
        Task<PaginacionDTO<ProductoDTO>> ObtenerProductosPaginados(int a, int b);

        //Task<ProductoDTO> ProductosPorFiltro(string filtro);
    }
}
