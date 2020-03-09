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

            userManager.Create(admin, "initial44");
            userManager.AddToRole(admin.Id, "admin");
        }
    }
}
