using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Cliente;
namespace Ad.DataContext.Cliente
{
    public class ClienteRepositorio : IGenericRepositorio<ClienteDTO>
    {
        readonly BasePruebasContext _dbContext;
        public ClienteRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Actualizar(ClienteDTO models)
        {
           _dbContext .Cliente.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            ClienteDTO cliente = _dbContext .Cliente.First(u => u.IdCliente == id);
            _dbContext.Cliente.Remove(cliente);
             await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(ClienteDTO model)
        {
            _dbContext.Cliente.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ClienteDTO> Obtener(int id)
        {
            return await _dbContext.Cliente.FindAsync(id);
        }

        public Task<IQueryable<ClienteDTO>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
