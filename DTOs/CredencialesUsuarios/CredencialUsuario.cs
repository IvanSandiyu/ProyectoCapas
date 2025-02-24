using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CredencialesUsuarios
{
    public class CredencialUsuario
    {
        public int Id_usuario { get; set; }
        public string Username { get; set; }

        public string Password { get; set; } //VER por el tema del hash
    }
}
