using DTOs.Producto;
using DTOs.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Stock
{
    public interface IStockService
    {
        Task<bool> Insertar(StockDTO model);
        Task<bool> Actualizar(StockDTO models);

        Task<bool> Eliminar(int id);

        Task<StockDTO> Obtener(int id);

        //Task<IQueryable<Usuario>> ObtenerTodos();

        //Task<Producto> ObtenerPorNombre(string nombre);
    }
}
