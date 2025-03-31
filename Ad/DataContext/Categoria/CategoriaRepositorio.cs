using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Categoria;
using DTOs.Paginacion;

namespace Ad.DataContext.Categoria
{
    public class CategoriaRepositorio : IGenericRepositorio<CategoriaDTO>
    {
        private readonly BasePruebasContext _dbContext;
        public CategoriaRepositorio(BasePruebasContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Actualizar(CategoriaDTO models)
        {
            _dbContext.Categoria.Update(models);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            CategoriaDTO usuario = _dbContext.Categoria.First(u => u.IdCategoria == id);
            _dbContext.Categoria.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(CategoriaDTO model)
        {
            _dbContext.Categoria.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriaDTO> Obtener(int id)
        {
            return await _dbContext.Categoria.FindAsync(id);
        }

        public Task<PaginacionDTO<CategoriaDTO>> ObtenerProductosPaginados(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<CategoriaDTO>> IGenericRepositorio<CategoriaDTO>.ObtenerTodos()
        {
            //IQueryable<Usuario> queryUsuarioSQL = _dbContext.Usuarios;
            //return queryUsuarioSQL;
            throw new NotImplementedException();
        }
    }

}
