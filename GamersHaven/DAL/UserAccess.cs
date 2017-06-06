using GamersHaven.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.DAL
{
    public class UserAccess
    {
        public string GetUsernameFromEmail(LoginViewModel model)
        {
            SiteContext context = new SiteContext();
            var users = context.Users.Where(b => b.Email == model.Email);
            string userName = string.Empty;
            foreach (var user in users)
            {
                userName = user.UserName;
            }

            return userName;
        }

        private string GetUserIDFromUserName(string userName)
        {
            SiteContext context = new SiteContext();
            var users = context.Users.Where(b => b.UserName == userName);
            string userID = string.Empty;
            foreach(var user in users)
            {
                userID = user.Id;
            }
            return userID;
        }

        public string PromoteUserToAdmin(string userName, out bool isSuccess)
        {
            string ID = GetUserIDFromUserName(userName);
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (ID != null && ID != string.Empty)
            {
                if(!userManager.IsInRole(ID, "Admin"))
                {
                    var result = userManager.AddToRole(ID, "Admin");
                    isSuccess = true;
                    return "User " + userName + " has been promoted to administrator";
                }
                else
                {
                    isSuccess = false;
                    return "User " + userName + " is already an administrator";
                }                
            }
            else
            {
                isSuccess = false;
                return "Failed to add " + userName +" to administrator group. Could not find the user";
            }
            
        }
    }
}