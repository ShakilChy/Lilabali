namespace Lilabali.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            datewisePayments = new HashSet<datewisePayment>();
        }

        [Key]
        public int MID { get; set; }

        [Required]
        [StringLength(200)]
        public string M_Name { get; set; }

        public int TID { get; set; }

        public int IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datewisePayment> datewisePayments { get; set; }

        public virtual Team Team { get; set; }
    }
}
