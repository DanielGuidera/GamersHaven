using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersHaven.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace GamersHaven.DAL
{
    public class SiteContext : DbContext
    {
        public SiteContext() : base("SiteContext")
        {
            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 500;
        }
        public DbSet<ArticleModels> Articles { get; set; }
        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}