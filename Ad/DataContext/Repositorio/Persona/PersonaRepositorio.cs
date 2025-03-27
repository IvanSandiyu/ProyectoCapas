using DTOs.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.Repositorio.Persona
{
    public class PersonaRepositorio : IGenericRepositorio<PersonaDTO>
    {
        private readonly BasePruebasContext _dbContext;
        public PersonaRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Actualizar(PersonaDTO models)
        {
            _dbContext.Persona.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            PersonaDTO usuario = _dbContext.Persona.First(u => u.IdPersona == id);
            _dbContext.Persona.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(PersonaDTO model)
        {
            _dbContext.Persona.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PersonaDTO> Obtener(int id)
        {
            return await _dbContext.Persona.FindAsync(id);
        }

        Task<IQueryable<PersonaDTO>> IGenericRepositorio<PersonaDTO>.ObtenerTodos()
        {
            //IQueryable<Usuario> queryUsuarioSQL = _dbContext.Usuarios;
            //return queryUsuarioSQL;
            throw new NotImplementedException();
        }
    }
}
