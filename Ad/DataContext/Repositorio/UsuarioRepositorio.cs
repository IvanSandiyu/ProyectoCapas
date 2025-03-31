using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DTOs.Paginacion;
using DTOs.Usuarios;
using Microsoft.IdentityModel.Tokens;

namespace Ad.DataContext.Repositorio
{
    public class UsuarioRepositorio : IGenericRepositorio<Usuario>
    {
        private readonly BasePruebasContext _dbContext;
        public UsuarioRepositorio(BasePruebasContext context)
        {
           _dbContext = context;
        }
        public async Task<bool> Actualizar(Usuario models)
        {
           _dbContext.Usuarios.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
           Usuario usuario = _dbContext.Usuarios.First(u=>u.IdUsuario == id);
            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Usuario model)
        {
            _dbContext.Usuarios.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public Task<PaginacionDTO<Usuario>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<Usuario>> IGenericRepositorio<Usuario>.ObtenerTodos()
        {
            //IQueryable<Usuario> queryUsuarioSQL = _dbContext.Usuarios;
            //return queryUsuarioSQL;
            throw new NotImplementedException();
        }
    }
}
