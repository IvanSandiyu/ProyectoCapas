using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.HistorialProductos
{
    public class HistorialProductosDTO
    {
        public int IdHistorial { get; set; }
        public int? ProductoId { get; set; }
        public DateTime? FechaCambio { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? PorcentajeGanancia { get; set; }
        public decimal? PrecioAnterior { get; set; }
        public decimal? PrecioActual { get; set; }
        public decimal? PrecioPublico { get; set; }
    }
}
