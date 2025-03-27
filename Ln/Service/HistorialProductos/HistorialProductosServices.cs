using Ad.DataContext;
using DTOs.HistorialProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.HistorialProductos
{
    public class HistorialProductosServices : IHistorialProductosService
    {
        readonly IGenericRepositorio<HistorialProductosDTO> _repository;
        public HistorialProductosServices(IGenericRepositorio<HistorialProductosDTO> models)
        {
            _repository = models;
        }
        public async Task<bool> Insertar(HistorialProductosDTO model)
        {
            return await _repository.Insertar(model);
        }
    }
}
