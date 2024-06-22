using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lilabali.ViewModels
{
    public class PaymentDetails
    {
        public DateTime P_Date { get; set; }

        public int MID { get; set; }

        public string M_Name { get; set; }

        public decimal Amount { get; set; }

        public int HostID { get; set; }

        public string Host { get; set; }

        public string Payment_Status { get; set; }

    }
}