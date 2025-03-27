using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Auditoria;

namespace Ad.DataContext.Auditoria
{
    public class AuditoriaRepositorio : IGenericRepositorio<AuditoriaDTO>
    {
        readonly BasePruebasContext _dbContext;
        public AuditoriaRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Insertar(AuditoriaDTO model)
        {
            _dbContext.Auditoria.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Actualizar(AuditoriaDTO models)
        {
            _dbContext.Auditoria.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

       

        public Task<AuditoriaDTO> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AuditoriaDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
