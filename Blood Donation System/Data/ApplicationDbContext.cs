using System;
using System.Collections.Generic;
using System.Text;
using Blood_Donation_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Donors> Donors { get; set; }

        public DbSet<Donations> Donations { get; set; }
        public object Donor { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Donors>()
                .HasMany<Donations>(g => g.Donations)
                .WithOne(s => s.Donor)
                .HasForeignKey(s => s.CurrentDonorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
