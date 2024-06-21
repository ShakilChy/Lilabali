using Lilabali.Models;
using Lilabali.Repo;
using Lilabali.ViewModels;
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
            var member = lbc.Database.SqlQuery<MembersView>("SELECT * FROM MembersView").ToList();
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
            string msg;
            if (M.TID > 0)
            {
                lbc.Members.Add(M);
                lbc.SaveChanges();
                msg = "Saved Successfully";
            }
            else
            {
                msg = "Not Saved";
            }
            TempData["message"] = msg;
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
            string msg;
            if (!string.IsNullOrEmpty(Tname))
            {
                tms.TeamName = Tname;
                tms.IsActive = 1;
                lbc.Teams.Add(tms);
                lbc.SaveChanges();
                msg = "Saved Successfully";
            }
            else
            {
                msg = "Not Saved";
            }
            TempData["message"] = msg;
            return RedirectToAction("Teams");
        }

        public ActionResult Payment()
        {
            DropDownRepo ddr = new DropDownRepo();
            ViewBag.EligibleMembers = ddr.GetEligibleMembers();
            return View();
        }
        [HttpPost]
        public ActionResult CreateBill(PaymentVM pvm)
        {
            string msg;
            DateTime date = DateTime.Now.Date;
            datewisePayment dt = new datewisePayment();
            if(pvm.SelectedMembers.Count>0|| pvm.SelectedMembers != null)
            {
                foreach (var item in pvm.SelectedMembers)
                {
                    dt.P_Date = date;
                    dt.HostID = pvm.Host;
                    dt.MID = Convert.ToInt32(item);
                    dt.Amount = pvm.Amount / pvm.SelectedMembers.Count();
                    if (dt.MID == pvm.Host)
                    {
                        dt.P_Status = 1;
                    }
                    else { dt.P_Status = 0; }
                        ;
                    lbc.datewisePayments.Add(dt);
                    lbc.SaveChanges();
                }
                msg = "Bill has been Created Successfully";
            }
            else
            {
                msg = "Something Went Wrong";
            }
            TempData["message"] = msg;
            return RedirectToAction("Payment");
        }

        //This portion is used for Ajax Call to select HOST
        [HttpGet]
        public JsonResult GetMembers(string[] selectedValues)
        {
            if (selectedValues!=null) {
                var members = lbc.Members
                   .Where(m => selectedValues.Contains(m.MID.ToString()))
                   .Select(m => new
                   {
                       Value = m.MID.ToString(),
                       Text = m.M_Name
                   }).ToList();
                return Json(members, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }

            
        }
    }
}