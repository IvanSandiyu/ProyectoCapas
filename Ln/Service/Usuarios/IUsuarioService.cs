using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Usuarios;

namespace Ln.Service.Usuarios
{
    public interface IUsuarioService
    {
        Task<bool> Insertar(Usuario model);
        Task<bool> Actualizar(Usuario models);

        Task<bool> Eliminar(int id);

        Task<Usuario> Obtener(int id);

        Task<IQueryable<Usuario>> ObtenerTodos();

        Task<Usuario> ObtenerPorNombre(string nombre);
    }
}
