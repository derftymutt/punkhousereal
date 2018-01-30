using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PunkHouseReal.Models;

namespace PunkHouseReal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<HouseMate> HouseMates { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<HouseMateExpense> HouseMateExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<HouseMateExpense>()
                .HasKey(hme => new { hme.HouseMateId, hme.ExpenseId });

            builder.Entity<HouseMateExpense>()
                .HasOne(hme => hme.HouseMate)
                .WithMany(e => e.HouseMateExpenses)
                .HasForeignKey(hme => hme.HouseMateId);

            builder.Entity<HouseMateExpense>()
                .HasOne(hme => hme.Expense)
                .WithMany(e => e.HouseMateExpenses)
                .HasForeignKey(hme => hme.ExpenseId);
        }
    }
}
