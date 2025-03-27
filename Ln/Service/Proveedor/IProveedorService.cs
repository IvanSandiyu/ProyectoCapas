using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Proveedor;

namespace Ln.Service.Proveedor
{
    public interface IProveedorService
    {
        Task<bool> Insertar(ProveedorDTO model);
        Task<bool> Actualizar(ProveedorDTO models);

        Task<bool> Eliminar(int id);

        Task<ProveedorDTO> Obtener(int id);

        Task<IQueryable<ProveedorDTO>> ObtenerTodos();

        Task<ProveedorDTO> ObtenerPorNombre(string nombre);
    }
}
