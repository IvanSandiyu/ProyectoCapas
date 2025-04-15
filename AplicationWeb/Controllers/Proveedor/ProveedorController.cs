using Ln.Service.Loggin;
using Ln.Service.Proveedor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AplicationWeb.Controllers.Proveedor
{
    public class ProveedorController : Controller
    {
        private readonly ILogginService _repositorio;
        private readonly IProveedorService _proveedorService;

        public ProveedorController(ILogginService repo, IProveedorService p)
        {
            _repositorio = repo;
            _proveedorService = p;
        }

        public IActionResult ProveedorIndex()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedores = await _proveedorService.ObtenerTodos();
            return Json(proveedores.ToList());
        }
    }
}
