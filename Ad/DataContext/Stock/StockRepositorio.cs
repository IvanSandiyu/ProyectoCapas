using DTOs.Paginacion;
using DTOs.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.Stock
{
    public class StockRepositorio : IGenericRepositorio<StockDTO>
    {
        readonly BasePruebasContext _dbContext;

        public StockRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public Task<bool> Actualizar(StockDTO models)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insertar(StockDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<StockDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaginacionDTO<StockDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<StockDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
