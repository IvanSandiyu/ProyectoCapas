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
        public async Task<IActionResult> CreacionProducto(string nombreProducto, string nombreProveedor, string nombreCategoria, int stockDisponible, decimal precioProducto, decimal porcentajeGanancia,decimal precioPublico)
        {
            if (string.IsNullOrEmpty(nombreProducto) || string.IsNullOrEmpty(nombreProveedor) || string.IsNullOrEmpty(nombreCategoria))
            {
                return Json(new { success = false, message = "Ocurrió un error al crear el producto." });
            } 
            bool respuesta = await _productoService.Insertar(nombreProducto, nombreProveedor, nombreCategoria, stockDisponible, precioProducto, porcentajeGanancia, precioPublico);

            if (respuesta)
            {
                return Json(new { success = true, message = "El producto se creó correctamente." });
            }
            return Json(new { success = false, message = "Ocurrió un error al crear el producto." });
        }

        public IActionResult EditarProducto(int id)
        {
            // Se utiliza 'await' para obtener el resultado de la tarea y se corrige el tipo de retorno.
            ProductoDTO producto = _productoService.Obtener(id).Result;
            if(producto != null) 
                return View(producto); // Se pasa el producto al modelo de la vista.
            else return NotFound(); // Manejo de error si el producto no se encuentra.
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarProducto(ProductoDTO p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Lógica para actualizar el producto
                    await _productoService.Actualizar(p);

                    return Json(new { success = true, message = "Producto actualizado correctamente." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"Error al actualizar el producto: {ex.Message}" });
                }
            }

            return Json(new { success = false, message = "Los datos proporcionados no son válidos." });
        }


    }
    
}
