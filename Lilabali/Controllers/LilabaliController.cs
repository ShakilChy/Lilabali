using Lilabali.Models;
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
            return View();
        }
        [HttpPost]//Members will be added through this method
        public ActionResult AddMember(Member M)
        {
            if (M != null)
            {

            }
            return RedirectToAction("Home");
        }
    }
}