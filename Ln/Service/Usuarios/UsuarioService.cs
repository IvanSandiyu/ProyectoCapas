using Ad.DataContext;
using DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        readonly IGenericRepositorio<Usuario> _repositorio;
        public UsuarioService(IGenericRepositorio<Usuario> usuario) // Esta interfaz es la que hace la conexion con la bdd
        {
            _repositorio = usuario;
        }
        public async Task<bool> Actualizar(Usuario models)
        {
           return await _repositorio.Actualizar(models);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(Usuario model)
        {
           return await _repositorio.Insertar(model);
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }

        public async Task<Usuario> ObtenerPorNombre(string nombre)
        {
            IQueryable<Usuario> queryUsuarioSQL = await _repositorio.ObtenerTodos();
            Usuario user = queryUsuarioSQL.Where(u => u.Nombre == nombre).FirstOrDefault();
            return user;
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
    }
}
