using BasketballProj.Data.Interfaces;
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
        public IActionResult ExecutionsManaging()
        {
            return View();
        }
        private readonly ITeamsReportsManaging _allTeamsForReports;
        public AdminPagesController(ITeamsReportsManaging iTeamsReports)
        {
            _allTeamsForReports = iTeamsReports;
        }
        public ViewResult TeamsReportsList()
        {
            var teams = _allTeamsForReports.teams;
            return View(teams);
        }

    }
}

