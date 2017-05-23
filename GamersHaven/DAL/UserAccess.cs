using GamersHaven.Models;
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
    }
}