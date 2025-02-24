using AplicationWeb.Models;
using AplicationWeb.Models.ViewModels;
using DTOs.Usuarios;
using Ln.Service.Loggin;
using Ln.Service.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
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

        public IActionResult Loggin(ILogginService user)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loggin(string username, string password ) 
        {
            if (_repositorio.Validar(username, password))
            {
                // Redirigir a la página principal si el login es exitoso
                ViewBag.ErrorMessage = "ENTROO";
                return RedirectToAction("Index", "Index");
            }
            else
            {
                // Mostrar un mensaje de error en la vista
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos.";
                return View();
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
