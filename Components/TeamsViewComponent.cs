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
            var id = RouteData?.Values["teamID"];
            ViewBag.SelectedType = RouteData?.Values["teamID"];

            var teams = _repo.Teams
                .OrderBy(x => x.TeamName);

            var team = teams.FirstOrDefault(x => x.TeamID.ToString() == id);                                        

            if (team != null)
            {
                ViewBag.SelectedTeam = team.TeamName;
            }


            return View(teams);
        }
    }
}
