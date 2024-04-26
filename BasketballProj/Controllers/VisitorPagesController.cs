using Microsoft.AspNetCore.Mvc;

namespace BasketballProj.Controllers
{
    public class VisitorPagesController : Controller
    {
        public IActionResult Matchups() => View();
        public IActionResult MatchupInfo() => View();
        public IActionResult Photos() => View();
        public IActionResult Players() => View();
        public IActionResult PlayerInfo() => View();
        public IActionResult Teams() => View();
        public IActionResult TeamInfo() => View();
    }
}
