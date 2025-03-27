using Ad.DataContext;
using DTOs.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Auditoria
{
    public class AuditoriaService : IAuditoriaService
    {
        readonly IGenericRepositorio<AuditoriaDTO> _repositorio;

        public AuditoriaService(IGenericRepositorio<AuditoriaDTO> models)
        {
            _repositorio = models;
        }
        public async Task<bool> Insertar(AuditoriaDTO model)
        {
            return await _repositorio.Insertar(model);
        }
    }
}
