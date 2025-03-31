using DTOs.Movimientos;
using DTOs.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.Movimientos
{
    public class MovimientosRepositorio : IGenericRepositorio<MovimientosDTO>
    {
        readonly BasePruebasContext _dbContext;

        public MovimientosRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public Task<bool> Actualizar(MovimientosDTO models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(MovimientosDTO model)
        {
            _dbContext.Movimiento.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<MovimientosDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginacionDTO<MovimientosDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<MovimientosDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
