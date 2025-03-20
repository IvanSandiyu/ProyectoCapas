using Ln.Service.Loggin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AplicationWeb.Controllers.Index
{
    [Authorize]
    public class IndexController : Controller
    {
        private readonly ILogginService _repositorio;
        
        public IndexController(ILogginService user)
        {
            
            _repositorio = user;
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
    }
}
