using Azure;
using DTOs.Categoria;
using DTOs.Paginacion;
using DTOs.Producto;
using DTOs.Proveedor;
using DTOs.Stock;
using DTOs.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.ProductoRepositorio
{
    public class ProductoRepositorio : IGenericRepositorio<ProductoDTO>, IProductoRepositorio<ProductoDTO>
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

        public async Task<bool> InsertarProducto(string nombreProducto, string nombreProveedor, string nombreCategoria, int stockDisponible, float precioProducto, float porcentajeGanancia)
        {
            if (string.IsNullOrWhiteSpace(nombreProveedor) || string.IsNullOrWhiteSpace(nombreCategoria) || string.IsNullOrWhiteSpace(nombreProducto))
            {
                throw new Exception("El nombre del proveedor o la categoría no puede estar vacío.");
            }

            //var proveedor = await _dbContext.Proveedor.FirstOrDefaultAsync(p => p.NombreEmpresa.ToUpper() == nombreProveedor.ToUpper().Trim());
            //var categoria = await _dbContext.Categoria.FirstOrDefaultAsync(c => c.Nombre.ToUpper() == nombreCategoria.ToUpper().Trim());

            //if (proveedor == null || categoria == null)
            //{
            //    throw new Exception("Proveedor o Categoría no encontrados");
            //}

            var producto = new ProductoDTO
            {
                Nombre = nombreProducto,
                ProveedorId = 1,
                CategoriaId = 1,
            };


            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Producto.Add(producto);
                    await _dbContext.SaveChangesAsync();

                    StockDTO stock = new StockDTO
                    {
                        ProductoId = producto.IdProducto,
                        CantidadActual = stockDisponible
                    };
                    _dbContext.Stock.Add(stock);
                    await _dbContext.SaveChangesAsync();



                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
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
                CategoriaId = p.CategoriaId,
                StockDisponible = _dbContext.Stock.Where(s => s.ProductoId == p.IdProducto).FirstOrDefault(),
                NombreProveedor = _dbContext.Proveedor.FirstOrDefault(pr => pr.IdProveedor == p.ProveedorId).NombreEmpresa,
                NombreCategoria = _dbContext.Categoria.FirstOrDefault(c => c.IdCategoria == p.Categoria.IdCategoria).Nombre,
                Categoria = _dbContext.Categoria.FirstOrDefault(c => c.IdCategoria == p.Categoria.IdCategoria)
            });

            return await Task.FromResult(queryProductoSQL);
            
        }

        public async Task<PaginacionDTO<ProductoDTO>> ObtenerProductosPaginados(int page = 1, int pageSize = 10)
        {
            // Obtener los productos paginados con mapeo directo a ProductoDTO
            var productos = await _dbContext.Producto
                .Skip((page - 1) * pageSize) // Salta los registros previos
                .Take(pageSize) // Toma el número de registros requeridos
                .Select(p => new ProductoDTO // Crear directamente instancias de ProductoDTO
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    StockDisponible = _dbContext.Stock.Where(s => s.ProductoId == p.IdProducto).FirstOrDefault(), // Relación con Stock
                    CategoriaId = p.CategoriaId,
                    NombreProveedor = _dbContext.Proveedor.FirstOrDefault(pr => pr.IdProveedor == p.ProveedorId).NombreEmpresa
                })
                .ToListAsync();

            int totalProductos = await _dbContext.Producto.CountAsync();

            return new PaginacionDTO<ProductoDTO>
            {
                Items = productos,
                TotalCount = totalProductos
            };


        }

        public Task<bool> Insertar(ProductoDTO model)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<ProductoDTO>> ProductosPorFiltro(string filtro)
        //{
        //    var products = await _dbContext.Producto
        //                    .Where(p => p.Nombre.Contains(filtro))
        //                    .ToListAsync();

        //    return products;
        //}
    }
}
