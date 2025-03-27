using DTOs.Persona;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.ProveedorRepositorio
{
    public class ProveedorRepositorio : IGenericRepositorio<ProveedorDTO>
    {
        private readonly BasePruebasContext _dbContext;
        public ProveedorRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Actualizar(ProveedorDTO models)
        {
            _dbContext.Proveedor.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            ProveedorDTO usuario = _dbContext.Proveedor.First(u => u.idProveedor == id);
            _dbContext.Proveedor.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(ProveedorDTO model)
        {
            _dbContext.Proveedor.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProveedorDTO> Obtener(int id)
        {
            return await _dbContext.Proveedor.FindAsync(id);
        }

        public async Task<IQueryable<ProveedorDTO>> ObtenerTodos()
        {
            //IQueryable<Usuario> queryUsuarioSQL = _dbContext.Usuarios;
            //return queryUsuarioSQL;
            throw new NotImplementedException();
        }
    }
}
