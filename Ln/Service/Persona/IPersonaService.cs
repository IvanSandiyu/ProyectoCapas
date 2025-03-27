using DTOs.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Persona
{
    public interface IPersonaService
    {
        Task<bool> Insertar(PersonaDTO model);
        Task<bool> Actualizar(PersonaDTO models);

        Task<bool> Eliminar(int id);

        Task<PersonaDTO> Obtener(int id);

        Task<IQueryable<PersonaDTO>> ObtenerTodos();

        Task<PersonaDTO> ObtenerPorNombre(string nombre);
    }
}
