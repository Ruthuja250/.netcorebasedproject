using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeLoanapi.Models;

namespace HomeLoanapi.Contextt
{
    public class Appdb:DbContext
    {
        public Appdb(DbContextOptions<Appdb> options) : base(options)
        {
        }
            public DbSet<Users> Userss { get; set; }
        public DbSet<Application_Form> application_Forms { get; set; }
        public DbSet<Loandetails> loandetailss { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("user");

            //Fluent api with applivcationform => one-to-many
            var forms = modelBuilder.Entity<Application_Form>();
                forms.ToTable("Applicationform");
                forms.HasKey(x=>x.Application_id); // pk

                forms.HasOne(x=>x.User)
                     .WithMany(x=>x.ApplicationForm)
                     .HasForeignKey(s=>s.userid);
 
            //Fluent api with loandetails => one-tp-one

            var details = modelBuilder.Entity<Loandetails>();
                 details.ToTable("loandetails");
                 details.HasKey(x => x.LoanId); // pk


            details.HasOne(x => x.ApplicationForm) // fk
                   .WithOne(x => x.details)
                   .HasForeignKey<Loandetails>(fk=>fk.Application_Id);


        }


    }
}
