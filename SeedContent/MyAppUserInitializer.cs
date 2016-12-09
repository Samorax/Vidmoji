using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.SeedContent
{
    public class MyAppUserInitializer:DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                using (var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
                {
                    var roleName = "Admin";
                    var Password = "Admin123";

                    if (!rolemanager.RoleExists(roleName))
                        rolemanager.Create(new IdentityRole(roleName));

                    var adminUser = new ApplicationUser();

                    var adminResult = userManager.Create(adminUser, Password);
                    if (adminResult.Succeeded)
                        userManager.AddToRole(adminUser.Id, roleName);
                    base.Seed(context);
                }
            }
        }
    }
}