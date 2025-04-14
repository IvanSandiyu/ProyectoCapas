using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Deudas
{
    public class DeudasDTO
    {
        public int IdDeuda { get; set; }
        public int ClienteId { get; set; }
        public int PersonaId { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public string TipoDeuda { get; set; }
    }
}
