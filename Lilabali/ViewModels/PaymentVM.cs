using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lilabali.ViewModels
{
    public class PaymentVM
    {
        public List<string> SelectedMembers { get; set; }
        //public List<string> SelectedItems { get; set; }
        public DateTime P_Date { get; set; }
        public int Host { get; set; }
        public int MID { get; set; }
        public int Amount { get; set; }
    }
}