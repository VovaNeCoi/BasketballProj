using Microsoft.AspNetCore.Mvc;

namespace BasketballProj.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Admin() => View();
        public IActionResult Visitor() => View();
        
    }

}
