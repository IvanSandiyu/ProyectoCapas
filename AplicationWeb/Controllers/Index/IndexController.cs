using Ln.Service.Loggin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ln.Service.Producto;
using Ad.DataContext.Categoria;
using Ad.DataContext.Cliente;
using Ad.DataContext.ProductoRepositorio;

namespace AplicationWeb.Controllers.Index
{
    [Authorize]
    public class IndexController : Controller
    {
        private readonly ILogginService _repositorio;
        private readonly IProductoService _productoService;
        //Habria que mostrar los productos
        //select P.Nombre, S.CantidadActual, C.Nombre as Categoria,  PR.NombreEmpresa,  H.PrecioPublico FROM PRODUCTO P, STOCK S , CATEGORIA C, PROVEEDOR PR, HISTORIALPRODUCTOS H
        public IndexController(ILogginService user, IProductoService producto)
        {
            
            _repositorio = user;
            _productoService = producto;
        }
        [HttpGet]
        public IActionResult Home()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Loggin/Loggin");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _productoService.ObtenerTodos();
            return Json(productos.ToList());
        }


    }
}
