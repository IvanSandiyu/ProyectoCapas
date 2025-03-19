using Ln.Service.Loggin;
using Microsoft.AspNetCore.Mvc;

namespace AplicationWeb.Controllers.Test
{
    public class TestController : Controller
    {
        private readonly ILogginService _logginService;

        
        public TestController(ILogginService logginService)
        {
            _logginService = logginService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            bool valid = _logginService.Validar("usuario", "contraseña");
            return Ok(valid);
        }
    }
}
