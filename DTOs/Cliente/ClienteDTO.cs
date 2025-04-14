using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Cliente
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public int PersonaId { get; set; }
        public DateTime UltimaCompra { get; set; }
        public string HistorialCompras { get; set; }
        public decimal Saldo { get; set; }
    }
}
