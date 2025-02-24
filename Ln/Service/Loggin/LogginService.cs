using Ad.DataContext;
using Ad.DataContext.LogginRepositorio;
using DTOs.CredencialesUsuarios;
using DTOs.Usuarios;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Text;


namespace Ln.Service.Loggin
{
    public class LogginService : ILogginService
    {
        readonly LogginRepositorio _repositorio;
        bool loginExitoso = false;

        public LogginService(LogginRepositorio usuario)
        {
            _repositorio = usuario;
        }

        public bool Validar(string user, string pass)
        {
            
            // Hashear la contraseña ingresada por el usuario
            string hashedPassword = HashPassword(pass);

            if (_repositorio.VerificarCredenciales(user, hashedPassword)) loginExitoso = true;
            else loginExitoso = false;

            return loginExitoso;

           
        }
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

    }
}
