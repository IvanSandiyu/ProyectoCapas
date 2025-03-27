using Ad.DataContext;
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
        public ProductoService(IGenericRepositorio<ProductoDTO> producto)
        {
            _repositorio = producto;
        }
        public async Task<bool> Actualizar(ProductoDTO models)
        {
            return await _repositorio.Actualizar(models);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(ProductoDTO model)
        {
            return await _repositorio.Insertar(model);
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
    }
}
