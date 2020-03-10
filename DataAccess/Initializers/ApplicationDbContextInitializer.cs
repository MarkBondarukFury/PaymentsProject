using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Domain.Entities;
using Domain.PaymentStates;

namespace DataAccess.Initializers
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "moder" };
            var role3 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var admin = new ApplicationUser { Email = "markbondaruk.fury@gmail.com", UserName = "markbondaruk.fury@gmail.com" };

            userManager.Create(admin, "adminPassword1");
            userManager.AddToRole(admin.Id, "admin");

            var moderator = new ApplicationUser { Email = "moderatorEmail@gmail.com", UserName = "moderatorEmail@gmail.com" };

            userManager.Create(moderator, "moderatorPassword1");
            userManager.AddToRole(moderator.Id, "moder");

            var users = new List<ApplicationUser>();

            var user1 = new ApplicationUser() { Email = "someAppUser1@gmail.com", UserName = "someAppUser1@gmail.com" };
            var user2 = new ApplicationUser() { Email = "someAppUser2@gmail.com", UserName = "someAppUser2@gmail.com" };
            var user3 = new ApplicationUser() { Email = "someAppUser3@gmail.com", UserName = "someAppUser3@gmail.com" };

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            users.ForEach(u => userManager.Create(u, "userPassword0"));
            users.ForEach(u => userManager.AddToRole(u.Id, "user"));

            context.Payments.Add(new Payment()
            {
                PaymentDate = DateTime.Now,
                State = new PaymentSentState(),
                User = user1,
                Number = "0001"
            });
            context.Payments.Add(new Payment()
            {
                PaymentDate = new DateTime(2019, 12, 16, 18, 0, 0),
                State = new PaymentSentState(),
                User = user1,
                Number = "0002"
            });
            context.Payments.Add(new Payment()
            {
                PaymentDate = new DateTime(2020, 1, 6, 21, 17, 0),
                State = new PaymentSentState(),
                User = user1,
                Number = "0003"
            });
        }
    }
}