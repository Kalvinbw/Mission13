using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission13.Models;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlerRepository _repo { get; set; }

        public TeamsViewComponent(IBowlerRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["teamID"];

            var teams = _repo.Teams
                .OrderBy(x => x.TeamName);

            return View(teams);
        }
    }
}
