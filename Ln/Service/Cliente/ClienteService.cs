using Ad.DataContext;
using DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Cliente
{
    public class ClienteService : IClienteService
    {
        readonly IGenericRepositorio<ClienteDTO> _repositorio;
        public ClienteService(IGenericRepositorio<ClienteDTO> models)
        {
            _repositorio = models;
        }
        public async Task<bool> Actualizar(ClienteDTO models)
        {
           return await _repositorio.Actualizar(models);
            
        }

        public async Task<bool> Eliminar(int id)
        {
           return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(ClienteDTO model)
        {
            return await _repositorio.Insertar(model);
        }

        public async Task<ClienteDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }

        public async Task<ClienteDTO> ObtenerPorNombre(string nombre)
        {
            //IQueryable<ClienteDTO> queryUsuarioSQL = await _repositorio.ObtenerTodos();
            //ClienteDTO user = queryUsuarioSQL.Where(u => u.nombre == nombre).FirstOrDefault();
            //return user;
            throw new NotImplementedException();
        }

        public async Task<IQueryable<ClienteDTO>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
    }
}
