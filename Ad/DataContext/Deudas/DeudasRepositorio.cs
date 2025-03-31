using DTOs.Auditoria;
using DTOs.Deudas;
using DTOs.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.Deudas
{
    public class DeudasRepositorio : IGenericRepositorio<DeudasDTO>
    {
       readonly BasePruebasContext _dbContext;
        public DeudasRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Actualizar(DeudasDTO models)
        {
            _dbContext.Deudas.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            DeudasDTO deuda = _dbContext.Deudas.First(u => u.IdDeuda == id);
            _dbContext.Deudas.Remove(deuda);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(DeudasDTO model)
        {
            _dbContext.Deudas.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<DeudasDTO> Obtener(int id)
        {
            return await _dbContext.Deudas.FindAsync(id);
        }

        public Task<IQueryable<DeudasDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
        public Task<PaginacionDTO<DeudasDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

    }
}
