using DTOs.HistorialProductos;
using DTOs.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.HistorialProductos
{
    public class HistorialProductosRepositorio : IGenericRepositorio<HistorialProductosDTO>
    {
        readonly BasePruebasContext _dbContext;

        public HistorialProductosRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public Task<bool> Actualizar(HistorialProductosDTO models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(HistorialProductosDTO model)
        {
            _dbContext.HistorialProductos.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<HistorialProductosDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginacionDTO<HistorialProductosDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<HistorialProductosDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
