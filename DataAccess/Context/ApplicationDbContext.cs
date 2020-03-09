using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Domain.Entities;
using DataAccess.Initializers;

namespace DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new ApplicationDbContextInitializer());
        }

        public ApplicationDbContext()
            : base("ApplicationDbConnection")
        {
        }
        /*
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Payment> Payments { get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentAccount>().HasMany(c => c.CreditCards);
            base.OnModelCreating(modelBuilder);

            
        }*/
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
