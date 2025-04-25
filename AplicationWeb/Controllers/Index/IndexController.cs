using Ln.Service.Loggin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ln.Service.Producto;
using Ad.DataContext.Categoria;
using Ad.DataContext.Cliente;
using Ad.DataContext.ProductoRepositorio;
using DTOs.Producto;
using Microsoft.EntityFrameworkCore;

namespace AplicationWeb.Controllers.Index
{
    [Authorize]
    public class IndexController : Controller
    {
        private readonly ILogginService _repositorio;
        private readonly IProductoService _productoService;
        
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

        [HttpGet]
        [Route("api/productos")]

        public async Task<IActionResult> GetProductos(int page = 1, int pageSize = 10)
        {
            var productosPaginados = await _productoService.ObtenerProductosPaginados(page, pageSize);

            var resultado = new
            {
                items = productosPaginados,
                totalCount = productosPaginados.TotalCount
            };

            return Ok(resultado); // Devuelve los datos en formato JSON
        }

        [HttpGet]
        public IActionResult CrearProducto() 
        {
            //Falta hacer que al hacerle click cambie de pestaña
            return Redirect("/Producto/CrearProducto");
        }
       

        //[HttpGet]
        //[Route("api/busqueda")]
        //public async Task<IActionResult> BusquedaPorFiltros(string filter)
        //{
        //    var products = await _productoService.ProductosPorFiltro(filter);
        //    return Ok(products);
        //}


    }
}
