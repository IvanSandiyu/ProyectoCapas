using DTOs.Deudas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Deudas
{
    public interface IDeudasService
    {
        Task<bool> Insertar(DeudasDTO model);
        Task<bool> Actualizar(DeudasDTO models);

        Task<bool> Eliminar(int id);

        Task<DeudasDTO> Obtener(int id);
    }
}
