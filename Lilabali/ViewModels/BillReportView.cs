using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lilabali.ViewModels
{
    public class BillReportView
    {
        public DateTime P_Date { get; set; }

        public int MID { get; set; }

        public string M_Name { get; set; }

        public int HostID { get; set; }

        public decimal Amount { get; set; }

        public int P_Status { get; set; }
    }
}