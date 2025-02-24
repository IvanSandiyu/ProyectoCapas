using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext
{
    public interface IGenericRepositorio<TEntidyModel> where TEntidyModel : class
    {
        Task<bool> Insertar(TEntidyModel model);
        Task<bool> Actualizar(TEntidyModel models);

        Task<bool> Eliminar(int id);

        Task<TEntidyModel> Obtener(int id);

        Task<IQueryable<TEntidyModel>> ObtenerTodos();
    }
}
