using DTOs.Auditoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Auditoria
{
    public interface IAuditoriaService
    {
        public Task<bool> Insertar(AuditoriaDTO model);
    }
}
