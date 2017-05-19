using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersHaven.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GamersHaven.DAL
{
    public class SiteContext : IdentityDbContext<ApplicationUser>
    {
        public SiteContext() : base("SiteContext")
        {
            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 500;
        }
        public DbSet<ArticleModels> Articles { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}