using BankApp.MVC.Infrastructures.Configurations;
using BankApp.MVC.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.MVC.Infrastructures.Context
{
    public class BankContext : DbContext
    {
        public BankContext( DbContextOptions<BankContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //We will add the FluentAPI which we apply in the configuration classes
            //here through the modelBuilder.

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
