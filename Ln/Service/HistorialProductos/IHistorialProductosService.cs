using DTOs.HistorialProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.HistorialProductos
{
    public interface IHistorialProductosService
    {
        public Task<bool> Insertar(HistorialProductosDTO model);
    }
}
