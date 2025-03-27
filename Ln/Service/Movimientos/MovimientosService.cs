using Ad.DataContext;
using DTOs.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Movimientos
{
    public class MovimientosService : IMovimientosServices
    {
        readonly IGenericRepositorio<MovimientosDTO> _repositorio;
        public MovimientosService(IGenericRepositorio<MovimientosDTO> models)
        {
            _repositorio = models;
        }
        public async Task<bool> Insertar(MovimientosDTO model)
        {
            return await _repositorio.Insertar(model);
        }

        public async Task<MovimientosDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }
    }
}
