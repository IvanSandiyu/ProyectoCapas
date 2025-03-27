using Ad.DataContext;
using DTOs.Deudas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Deudas
{
    public class DeudasService : IDeudasService
    {
        readonly IGenericRepositorio<DeudasDTO> _repositorio;

        public DeudasService(IGenericRepositorio<DeudasDTO>  models)
        {
            _repositorio = models;
        }
        public async Task<bool> Actualizar(DeudasDTO models)
        {
            return await _repositorio.Actualizar(models);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repositorio.Eliminar(id);
        }

        public Task<bool> Insertar(DeudasDTO model)
        {
           return _repositorio.Insertar(model);
        }

        public async Task<DeudasDTO> Obtener(int id)
        {
            return await _repositorio.Obtener(id);
        }
    }
}
