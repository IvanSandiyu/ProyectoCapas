using DTOs.Proveedor;
using Ln.Service.Loggin;
using Ln.Service.Proveedor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;

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

        public  IActionResult CrearProveedor()
        {
            return View();
        }

        public async Task<IActionResult> CreacionProveedor(string nombreEmpresa,string diasVisita, string tipoP, long tel, string datosAd)
        {
            if (nombreEmpresa.IsNullOrEmpty())
            {
                return Json(new { success = false, message = "Ocurrió un error al crear el proveedor." });
            }

            ProveedorDTO P = new ProveedorDTO
            {
                NombreEmpresa = nombreEmpresa,
                DiasVisita = diasVisita,
                TipoProducto = tipoP,
                Telefono = tel,
                DatosAdicionales = datosAd
            };
            bool respuesta = await _proveedorService.Insertar(P);

            if (respuesta)
            {
                return Json(new { success = true, message = "El proveedor se creó correctamente." });
            }
            return Json(new { success = false, message = "Ocurrió un error al crear el proveedor." });
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedores = await _proveedorService.ObtenerTodos();
            return Json(proveedores.ToList());
        }
    }
}
