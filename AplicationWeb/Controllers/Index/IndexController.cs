using Microsoft.AspNetCore.Mvc;

namespace AplicationWeb.Controllers.Index
{
    public class IndexController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
    }
}
