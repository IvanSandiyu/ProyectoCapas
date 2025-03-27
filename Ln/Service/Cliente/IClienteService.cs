using DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Cliente
{
    public interface IClienteService
    {
        Task<bool> Insertar(ClienteDTO model);
        Task<bool> Actualizar(ClienteDTO models);

        Task<bool> Eliminar(int id);

        Task<ClienteDTO> Obtener(int id);

        Task<IQueryable<ClienteDTO>> ObtenerTodos();

        Task<ClienteDTO> ObtenerPorNombre(string nombre);
    }
}
