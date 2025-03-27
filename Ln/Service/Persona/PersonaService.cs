using Ad.DataContext;
using DTOs.Persona;
using DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Persona
{
    public class PersonaService : IPersonaService
    {
        readonly IGenericRepositorio<PersonaDTO> _repositorio;
        public PersonaService(IGenericRepositorio<PersonaDTO> persona) // Esta interfaz es la que hace la conexion con la bdd
        {
            _repositorio = persona;
        }
        public async Task<bool> Actualizar(PersonaDTO models)
        {
            return await _repositorio.Actualizar(models);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(PersonaDTO model)
        {
            return await _repositorio.Insertar(model);
        }

        public async Task<PersonaDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }

        public async Task<PersonaDTO> ObtenerPorNombre(string nombre)
        {
            IQueryable<PersonaDTO> queryUsuarioSQL = await _repositorio.ObtenerTodos();
            PersonaDTO user = queryUsuarioSQL.Where(u => u.Nombre == nombre).FirstOrDefault();
            return user;
        }

        public async Task<IQueryable<PersonaDTO>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
    }
}
