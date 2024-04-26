using Microsoft.AspNetCore.Mvc;

namespace BasketballProj.Controllers
{
    public class AdminPagesController : Controller
    {
        public IActionResult EventAdPage() => View();
        public IActionResult MatchupsManaging() => View();
        public IActionResult PlayersManaging() => View();
        public IActionResult SeasonsManaging() => View();
        public IActionResult TeamsManaging() => View();


        public IActionResult TechnicalAdPage() => View();
        public IActionResult TeamsReportsManaging() => View();
        public IActionResult ExecutionsManaging() => View();

    }
}

