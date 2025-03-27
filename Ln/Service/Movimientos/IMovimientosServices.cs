using DTOs.Movimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Movimientos
{
    public interface IMovimientosServices
    {
        Task<bool> Insertar(MovimientosDTO model);
        //Task<bool> Actualizar(MovimientosDTO models);

        //Task<bool> Eliminar(int id);

        Task<MovimientosDTO> Obtener(int id);
    }
}
