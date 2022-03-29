using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBowlerRepository _repo { get; set; }

        public HomeController(ILogger<HomeController> logger, IBowlerRepository temp)
        {
            _logger = logger;
            _repo = temp;
        }

        public IActionResult Index(int? teamID)
        {
            if (teamID == null)
            {
                var bowlers = _repo.Bowlers
                    .OrderBy(x => x.BowlerFirstName)
                    .ToList();
                return View(bowlers);
            }
            else
            {
                var bowlers = _repo.Bowlers
                    .Where(x => x.TeamID == teamID)
                    .OrderBy(x => x.BowlerFirstName)
                    .ToList();
                return View(bowlers);
            }
        }

        [HttpGet]
        public IActionResult BowlerForm()
        {
            ViewBag.teams = _repo.Teams.Distinct().ToList();

            return View();
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(b);
            }
            else
            {
                return View("BowlerForm");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.teams = _repo.Teams.Distinct().ToList();

            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.Edit(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.Delete(b);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
