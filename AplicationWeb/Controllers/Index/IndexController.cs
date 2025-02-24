using Microsoft.AspNetCore.Mvc;

namespace AplicationWeb.Controllers.Index
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
