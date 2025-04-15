using DTOs.HistorialProductos;
using DTOs.Paginacion;
using DTOs.Persona;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.ProveedorRepositorio
{
    public class ProveedorRepositorio : IGenericRepositorio<ProveedorDTO>
    {
        private readonly BasePruebasContext _dbContext;
        public ProveedorRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Actualizar(ProveedorDTO models)
        {
            _dbContext.Proveedor.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            ProveedorDTO usuario = _dbContext.Proveedor.First(u => u.IdProveedor == id);
            _dbContext.Proveedor.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(ProveedorDTO model)
        {
            _dbContext.Proveedor.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProveedorDTO> Obtener(int id)
        {
            return await _dbContext.Proveedor.FindAsync(id);
        }

        public Task<PaginacionDTO<ProveedorDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<ProveedorDTO>> ObtenerTodos()
        {
             IQueryable < ProveedorDTO > queryProductoSQL = _dbContext.Proveedor.Select(p => new ProveedorDTO
             {
                IdProveedor = p.IdProveedor,
                NombreEmpresa = p.NombreEmpresa ?? "",
                 Telefono = p.Telefono ?? 0,
                 DiasVisita = string.IsNullOrWhiteSpace(p.DiasVisita) ? "No especifica":p.DiasVisita,
                 DatosAdicionales = string.IsNullOrWhiteSpace(p.DatosAdicionales) ? "-" : p.DatosAdicionales,
                 TipoProducto = string.IsNullOrWhiteSpace(p.TipoProducto) ? "-": p.TipoProducto ,
                 Estado =  p.Estado,
                
                //DatosAdicionales = p.DatosAdicionales ?? "",
                //StockDisponible = _dbContext.Stock.Where(s => s.ProductoId == p.IdProducto).FirstOrDefault(),
                //NombreProveedor = _dbContext.Proveedor.FirstOrDefault(pr => pr.IdProveedor == p.ProveedorId).NombreEmpresa,
                ////NombreCategoria = _dbContext.Categoria.FirstOrDefault(c => c.IdCategoria == p.Categoria.IdCategoria).Nombre,
                //Categoria = _dbContext.Categoria.FirstOrDefault(c => c.IdCategoria == p.Categoria.IdCategoria),
                //HistorialProductos = _dbContext.HistorialProductos.Where(h => h.ProductoId == p.IdProducto).OrderByDescending(h => h.FechaCambio).FirstOrDefault() ?? new HistorialProductosDTO { PrecioPublico = 0 }

            });

            return await Task.FromResult(queryProductoSQL);
        }
    }
}
