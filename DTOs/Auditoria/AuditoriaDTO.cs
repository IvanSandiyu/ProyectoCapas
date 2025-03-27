using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Auditoria
{
    public class AuditoriaDTO
    {
        public int idAuditoria { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public string EntidadModificada { get; set; }
        public int IdEntidad { get; set; }
    }
}
