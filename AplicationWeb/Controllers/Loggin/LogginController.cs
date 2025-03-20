using AplicationWeb.Models;
using AplicationWeb.Models.ViewModels;
using DTOs.Usuarios;
using Ln.Service.Loggin;
using Ln.Service.Usuarios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AplicationWeb.Controllers.Loggin
{
    public class LogginController : Controller
    {
        // private readonly IUsuarioService _usuarioService;
        //private readonly ILogger _logger;
        private readonly ILogginService _repositorio;

        public LogginController(ILogginService user)
        {
            _repositorio = user;
        }

        [HttpGet]
        public IActionResult Loggin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarLoggin(string username, string password)
        {
            if (_repositorio.Validar(username, password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username) 
                };

                var identity = new ClaimsIdentity(claims, "Cookies");
                var principal = new ClaimsPrincipal(identity);

                // Establecer la cookie de autenticación
                HttpContext.SignInAsync("Cookies", principal).Wait();
                // Redirigir a la página principal si el login es exitoso
                return Redirect("/Index/Home");
            }
            else
            {
                return View("Loggin");
            }
        }



        //[HttpGet]
        //public async Task<IActionResult> Lista()
        //{
        //    IQueryable<Usuario> queryUsuarioSQL = await _usuarioService.ObtenerTodos();
        //    List<VMUsuario> lista = queryUsuarioSQL
        //        .Select(u => new VMUsuario()
        //        {
        //            IdUsuario = u.IdUsuario,
        //            Nombre = u.Nombre,
        //            Estado = u.Estado
        //        }).ToList();
        //    return StatusCode(statusCode: 200, lista);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Insertar([FromBody] VMUsuario usuario)
        //{
        //    Usuario u = new Usuario()
        //    {
        //        Nombre = usuario.Nombre,
        //        Estado = usuario.Estado
        //    };

        //    bool resp = await _usuarioService.Insertar(u);
        //    return StatusCode(statusCode: 200, new { valor = resp });

        //}

        //[HttpPut]
        //public async Task<IActionResult> Actualizar([FromBody] VMUsuario usuario)
        //{
        //    Usuario u = new Usuario()
        //    {
        //        Nombre = usuario.Nombre,
        //        Estado = usuario.Estado
        //    };

        //    bool resp = await _usuarioService.Insertar(u);
        //    return StatusCode(statusCode: 200, new { valor = resp });

        //}

        //[HttpDelete]
        //public async Task<IActionResult> Eliminar(int id)
        //{

        //    bool resp = await _usuarioService.Eliminar(id);
        //    return StatusCode(statusCode: 200, new { valor = resp });

        //}





    }
}
