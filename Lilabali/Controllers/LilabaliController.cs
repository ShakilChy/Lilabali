using Lilabali.Models;
using Lilabali.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lilabali.Controllers
{
    public class LilabaliController : Controller
    {
        // GET: Lilabali
        public LilabaliDbContext lbc = new LilabaliDbContext();
        public ActionResult Home()
        {
            var member = lbc.Members.ToList();
            DropDownRepo ddr = new DropDownRepo();
            var team = lbc.Teams.ToList();
            if (team.Count > 0)
            {
                ViewBag.Teams = ddr.GetTeam();
            }
            else
            {
                ViewBag.Teams = null;
            }
            return View(member);
        }
        [HttpPost]//Members will be added through this method
        public ActionResult AddMember(Member M)
        {
            if (M.TID > 0)
            {
                lbc.Members.Add(M);
                lbc.SaveChanges();
            }
            return RedirectToAction("Home");
        }
        public ActionResult Teams()
        {
            var team = lbc.Teams.ToList();
            return View(team);
        }
        [HttpPost]//Add new team
        public ActionResult AddTeam(string Tname)
        {
            Team tms = new Team();
            if (!string.IsNullOrEmpty(Tname))
            {
                tms.TeamName = Tname;
                tms.IsActive = 1;
                lbc.Teams.Add(tms);
                lbc.SaveChanges();

            }

            return RedirectToAction("Teams");
        }
    }
}