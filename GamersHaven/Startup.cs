using GamersHaven.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GamersHaven.Startup))]
namespace GamersHaven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateSiteRoles();
        }

        public void CreateSiteRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            string roleName = "Admin";          
            if (!roleManager.RoleExists(roleName))
            {
                CreateRole(roleManager, roleName);

                var user = new ApplicationUser();
                var chkUser = CreateDefaultAdmin(ref user, userManager, "Admin", "danielguider1@gmail.com", "Mypsw64!");

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, roleName);
                }
            }

            roleName = "User";            
            if (!roleManager.RoleExists(roleName))
            {
                CreateRole(roleManager, roleName);

                var user = new ApplicationUser();
                var chkUser = CreateDefaultAdmin(ref user, userManager, "User", "daniel_guidera@hotmail.com", "Mypsw65!");

                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, roleName);
                }
            }
        }

        public void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            role.Name = roleName;
            roleManager.Create(role);
        }

        public IdentityResult CreateDefaultAdmin(ref ApplicationUser user, UserManager<ApplicationUser> userManager, string userName, string email, string pwd)
        {            
            user.UserName = userName;
            user.Email = email;

            string userPWD = pwd;

            return userManager.Create(user, userPWD);
        }
    }
}
