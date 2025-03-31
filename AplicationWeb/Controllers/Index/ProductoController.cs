using DTOs.Producto;
using Ln.Service.Producto;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AplicationWeb.Controllers.Index
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        

        public ProductoController(IProductoService _repositorio)
        {
            _productoService = _repositorio;
        }
        public IActionResult CrearProducto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreacionProducto(string nombreProducto,string nombreProveedor,string nombreCategoria,int stockDisponible,float precioProducto, float porcentajeGanancia)
        {
            if (string.IsNullOrEmpty(nombreProducto) || string.IsNullOrEmpty(nombreProveedor) || string.IsNullOrEmpty(nombreCategoria))
            {
                return BadRequest();
            }
            //ProductoDTO producto = new ProductoDTO { Nombre = nombreProducto };

            bool respuesta = await _productoService.Insertar(nombreProducto, nombreProveedor, nombreCategoria, stockDisponible, precioProducto, porcentajeGanancia);

            if (respuesta)
            {
                return Ok();
            }
            return BadRequest("Ocurrio un error al crear el producto");
        }


    }
    
}
