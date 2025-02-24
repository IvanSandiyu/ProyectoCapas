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

        public bool VerificarCredenciales(string u, string p)
        {
            const string query = "SELECT COUNT(1) FROM CredencialesUsuarios WHERE Username = @username AND PasswordHash = @hashedPassword";
            int resultado = _dbContext.Database.ExecuteSqlRaw(query);
            if (resultado == 1) return true;
            return false;
        }
    }
}
