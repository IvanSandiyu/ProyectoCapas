using DTOs.HistorialDeudas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.HistorialDeudas
{
    public interface IHistorialDeudasService
    {
        Task<bool> Insertar(HistorialDeudasDTO model);
    }
}
