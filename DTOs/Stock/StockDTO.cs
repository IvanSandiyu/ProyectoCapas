using DTOs.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Stock
{
    public class StockDTO
    {
        public int IdStock { get; set; }
        public int ProductoId { get; set; }
        public int CantidadActual { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public ProductoDTO Producto { get; set; }
    }
}
