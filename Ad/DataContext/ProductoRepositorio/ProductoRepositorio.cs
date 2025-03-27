using DTOs.Producto;
using DTOs.Proveedor;
using DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.ProductoRepositorio
{
    public class ProductoRepositorio: IGenericRepositorio<ProductoDTO>
    {
        private readonly BasePruebasContext _dbContext;
        public ProductoRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }

        public async Task<bool> Actualizar(ProductoDTO models)
        {
            _dbContext.Producto.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            ProductoDTO producto = _dbContext.Producto.First(u => u.IdProducto == id);
            _dbContext.Producto.Remove(producto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(ProductoDTO model)
        {
            _dbContext.Producto.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProductoDTO> Obtener(int id)
        {
            return await _dbContext.Producto.FindAsync(id);
        }

        public async Task<IQueryable<ProductoDTO>> ObtenerTodos()
        {
            IQueryable<ProductoDTO> queryProductoSQL = _dbContext.Producto.Select(p => new ProductoDTO
            {
                IdProducto = p.IdProducto,
                Nombre = p.Nombre,
                ProveedorId = p.ProveedorId,
                StockDisponible = p.StockDisponible
            });

            return await Task.FromResult(queryProductoSQL); // Simula una operación asincrón
            //IQueryable <ProductoDTO> queryProdcutoSQL = _dbContext.Producto;
            ////return queryUsuarioSQL;
            //throw new NotImplementedException();
        }
    }
}
