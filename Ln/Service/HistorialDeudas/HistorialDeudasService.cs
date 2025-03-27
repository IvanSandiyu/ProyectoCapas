using Ad.DataContext;
using DTOs.HistorialDeudas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.HistorialDeudas
{
    public class HistorialDeudasService : IHistorialDeudasService
    {
        readonly IGenericRepositorio<HistorialDeudasDTO> _repository;

        public HistorialDeudasService(IGenericRepositorio<HistorialDeudasDTO> models)
        {
            _repository = models;
        }
        public async Task<bool> Insertar(HistorialDeudasDTO model)
        {
            return await _repository.Insertar(model);
        }
    }
}
