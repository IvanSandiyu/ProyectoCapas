using Ad.DataContext;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ln.Service.Proveedor
{
    public class ProveedorService : IProveedorService
    {
        readonly IGenericRepositorio<ProveedorDTO> _repositorio;

        public ProveedorService(IGenericRepositorio<ProveedorDTO> usuario)
        {
            _repositorio = usuario;
        }
        public async Task<bool> Actualizar(ProveedorDTO models)
        {
            return await _repositorio.Actualizar(models);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(ProveedorDTO model)
        {
            return await _repositorio.Insertar(model);
        }

        public async Task<ProveedorDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
            
        }

        public async Task<ProveedorDTO> ObtenerPorNombre(string nombre)
        {
            IQueryable<ProveedorDTO> queryUsuarioSQL = await _repositorio.ObtenerTodos();
            ProveedorDTO user = queryUsuarioSQL.Where(u => u.NombreEmpresa == nombre).FirstOrDefault();
            return user;
        }

        public async Task<IQueryable<ProveedorDTO>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
    }
}
