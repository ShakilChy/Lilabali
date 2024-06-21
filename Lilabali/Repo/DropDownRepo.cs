using Lilabali.Models;
using Lilabali.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lilabali.Repo
{
    public class DropDownRepo
    {
        public LilabaliDbContext ldb = new LilabaliDbContext();
        public IEnumerable<SelectListItem> GetTeam()
        {
            IEnumerable<SelectListItem> datas = ldb.Teams.Select(n => new SelectListItem
            {
                Value = n.TID.ToString(),
                Text = n.TeamName,
            }).Distinct().ToList();
            return new SelectList(datas, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetEligibleMembers()
        {
            //lbc.Database.SqlQuery<MembersView>("SELECT * FROM MembersView").ToList();
            IEnumerable<SelectListItem> datas = ldb.Database.SqlQuery<EligibleMembers>("SELECT * FROM EligibleMembers").ToList().Select(n => new SelectListItem
            {
                Value = n.MID.ToString(),
                Text = n.M_Name,
            }).Distinct().ToList();
            return new SelectList(datas, "Value", "Text");
        }

    }
}