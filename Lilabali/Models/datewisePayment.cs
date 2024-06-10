namespace Lilabali.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("datewisePayment")]
    public partial class datewisePayment
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime P_Date { get; set; }

        public int MID { get; set; }

        public int HostID { get; set; }

        public decimal Amount { get; set; }

        public int P_Status { get; set; }

        public virtual Member Member { get; set; }
    }
}
