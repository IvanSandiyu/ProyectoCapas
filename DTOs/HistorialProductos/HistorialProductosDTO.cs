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
        public int ProductoId { get; set; }
        public DateTime FechaCambio { get; set; }
        public float PrecioUnitario { get; set; }
        public float PorcentajeGanancia { get; set; }
        public float PrecioAnterior { get; set; }
        public float PrecioActual { get; set; }
        public float PrecioPublico { get; set; }
    }
}
