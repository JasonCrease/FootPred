using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootPredWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Created by Jason Crease to help you predict football scores and stuff.";

            return View();
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult AutocompleteTeam(string term)
        {
            string[] teams = FootPredWeb.Models.TeamList.AllTeams;
            string[] relevantTeams = teams.Where(x => x.ToLowerInvariant().StartsWith(term.ToLowerInvariant())).ToArray();

            return Json(relevantTeams, JsonRequestBehavior.AllowGet);
        }
    }
}