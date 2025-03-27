using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Movimientos
{
    public class MovimientosDTO
    {
        public int IdVenta { get; set; }
        public int StockId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public string TipoMovimiento { get; set; }
        public string Descripcion { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }
    }
}
