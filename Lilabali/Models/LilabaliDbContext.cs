using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lilabali.Models
{
    public partial class LilabaliDbContext : DbContext
    {
        public LilabaliDbContext()
            : base("name=LilabaliDbContext")
        {
        }

        public virtual DbSet<datewisePayment> datewisePayments { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<datewisePayment>()
                .Property(e => e.Amount)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.datewisePayments)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}
