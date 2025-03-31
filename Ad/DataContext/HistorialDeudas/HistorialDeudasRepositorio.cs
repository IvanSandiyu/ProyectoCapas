using DTOs.HistorialDeudas;
using DTOs.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ad.DataContext.HistorialDeudas
{
    public class HistorialDeudasRepositorio : IGenericRepositorio<HistorialDeudasDTO>
    {
        readonly BasePruebasContext _dbContext;

        public HistorialDeudasRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public Task<bool> Actualizar(HistorialDeudasDTO models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insertar(HistorialDeudasDTO model)
        {
            _dbContext.HistorialDeudas.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<HistorialDeudasDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginacionDTO<HistorialDeudasDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<HistorialDeudasDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
