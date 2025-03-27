using Ad.DataContext;
using DTOs.Stock;
using DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Stock
{
    public class StockService : IStockService
    {
        readonly IGenericRepositorio<StockDTO> _repositorio;

        public StockService(IGenericRepositorio<StockDTO> models)
        {
            _repositorio = models;
        }
        public async Task<bool> Actualizar(StockDTO stock)
        {
            return await _repositorio.Actualizar(stock);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public async Task<bool> Insertar(StockDTO model)
        {
            return await _repositorio.Insertar(model);
        }

        public async Task<StockDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }
    }
}
