using Ad.DataContext;
using Ad.DataContext.ProductoRepositorio;
using DTOs.Paginacion;
using DTOs.Producto;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Producto
{
    public class ProductoService : IProductoService
    {
        readonly IGenericRepositorio<ProductoDTO> _repositorio;
        readonly IProductoRepositorio<ProductoDTO> _repositorioProducto;
        public ProductoService(IGenericRepositorio<ProductoDTO> producto, IProductoRepositorio<ProductoDTO> repositorioProducto)
        {
            _repositorio = producto;
            _repositorioProducto = repositorioProducto;
        }
        public async Task<bool> Actualizar(ProductoDTO models)
        {
            return await _repositorio.Actualizar(models);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(string nombreProducto,string nombreProveedor,string nombreCategoria,int stockDisponible, decimal precioProducto, decimal porcentajeGanancia, decimal precioPublico)
        {

            return await _repositorioProducto.InsertarProducto(nombreProducto,nombreProveedor,nombreCategoria,stockDisponible,precioProducto,porcentajeGanancia, precioPublico);
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }

        public async Task<ProductoDTO> ObtenerPorNombre(string nombre)
        {
            IQueryable<ProductoDTO> queryUsuarioSQL = await _repositorio.ObtenerTodos();
            ProductoDTO user = queryUsuarioSQL.Where(u => u.Nombre == nombre).FirstOrDefault();
            return user;
        }

        public async Task<IQueryable<ProductoDTO>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
        public async Task<PaginacionDTO<ProductoDTO>> ObtenerProductosPaginados(int page = 1, int pageSize = 10)
        {
            return await _repositorio.ObtenerProductosPaginados(page, pageSize);
        }

        //public async Task<List<ProductoDTO>> ProductosPorFiltro(string filtro)
        //{
        //    return await _repositorio.ProductosPorFiltro(filtro);
        //}
    }
}
