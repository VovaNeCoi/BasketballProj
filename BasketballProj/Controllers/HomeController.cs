using Microsoft.AspNetCore.Mvc;

namespace BasketballProj.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
