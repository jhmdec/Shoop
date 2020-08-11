using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Shoop.Models;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(Shoop.Startup))]
namespace Shoop
{
    /// <summary>
    /// Disabled ConfigureAuth(app) because we're using Identity Authentication
    /// </summary>
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ////ConfigureAuth(app);
            //List<string> roles = new List<string>() {
            //    "SU",
            //    "Admin",
            //    "Manager",
            //    "Customer",
            //    "User",
            //    "Guest"
            //};

            //// Roles that has different levels of access
            //CreateRoles(roles);
            //CreateSuperUser();
        }
        
        public void CreateRoles(List<string> roles)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //var newRole = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //foreach (var role in roles)
            //{
            //    newRole.Name = role;
            //    if (!roleManager.RoleExists(role))
            //    {
            //        roleManager.Create(newRole);
            //    }
            //}
            //context.SaveChanges();
        }

        public void CreateSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //Here we create a Super User user who will have access to all aspects of the website                   
            var user = new ApplicationUser();

            user.UserName = "superu";
            user.Email = "shoopSU@gmail.com";
            user.EmailConfirmed = true;
            string userPWD = "Sup1234";

            var chkUser = userManager.Create(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, "SU");
            }
        }
    }
}
