using DTOs.CredencialesUsuarios;
using DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ln.Service.Loggin
{
    public interface ILogginService
    {
        public bool Validar(string u, string p);
    }
}
