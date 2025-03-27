using DTOs.CredencialesUsuarios;
using DTOs.Usuarios;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.DataContext.LogginRepositorio
{
    public class LogginRepositorio
    {
        private readonly BasePruebasContext _dbContext;
        public LogginRepositorio(BasePruebasContext repo)
        {
            _dbContext = repo;
        }
        public bool VerificarCredenciales(string username, string hashedPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(hashedPassword))
            {
                throw new ArgumentException("Username and password cannot be null or empty");
            }
            int resultado = _dbContext.Credencial
                               .Count(c => c.Username == username && c.Password == hashedPassword);

            return resultado > 0;
        }

        //public bool VerificarCredenciales(string username, string hashedPassword)
        //{
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(hashedPassword))
        //    {
        //        throw new ArgumentException("Username and password cannot be null or empty");
        //    }

        //    const string query = "SELECT COUNT(1) FROM CredencialesUsuarios WHERE Username = @username AND PasswordHash = @hashedPassword";
        //    int resultado = _dbContext.Database.ExecuteSqlRaw(query, new SqlParameter("@username", username), new SqlParameter("@hashedPassword", hashedPassword));
        //    if (resultado == 1) return true;
        //    return false;
        //}

        //public bool VerificarCredenciales(string username, string hashedPassword)
        //{
        //    const string query = "SELECT COUNT(1) FROM CredencialesUsuarios WHERE Username = @username AND PasswordHash = @hashedPassword";
        //    int resultado = _dbContext.Database.ExecuteSqlRaw(query, new SqlParameter("@username", username), new SqlParameter("@hashedPassword", hashedPassword));
        //    if (resultado == 1) return true;
        //    return false;
        //}

        //public bool VerificarCredenciales(string username, string hashedPassword)
        //{

        //    const string query = "SELECT COUNT(1) FROM CredencialesUsuarios WHERE Username = @username AND PasswordHash = @hashedPassword";
        //    int resultado = _dbContext.Database.ExecuteSqlRaw(query);
        //    if (resultado == 1) return true;
        //    return false;
        //}
    }
}
