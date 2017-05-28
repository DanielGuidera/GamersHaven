using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersHaven.Models;
using GamersHaven.DAL;

namespace GamersHaven.DAL
{
    public class ArticleAccess
    {
        private SiteContext context = new SiteContext();

        public bool GetArticleForRead(out ArticleModels articleData, int ID)
        {
            //var context = new SiteContext();
            articleData = context.Articles.Find(ID);

            if (articleData.status == ArticleModels.Status.Failed)
            {
                return false;
            }
            else
            {                
                return true;
            }
        }

        public List<ArticleModels> retrieveArticles(ArticleModels.Status status)
        {
            List<ArticleModels> artList = new List<ArticleModels>();
            foreach (ArticleModels art in context.Articles.ToList())
            {
                if (art.status == status)
                {
                    artList.Add(art);
                }
            }

            return artList;
        }

        public int CountArticles(ArticleModels.Status status)
        {
            int count = (from row in context.Articles
                         where row.status == status
                         select row).Count();

            return count;
        }

        public string DeleteArticle(int articleID, int reportID, out bool isSucceed)
        {
            var articles = context.Articles.ToList();
            int exists = (from row in articles
                          where row.ID == articleID
                          select row).Count();

            if (exists > 0)
            {
                ReportAccess access = new ReportAccess();
                var article = context.Articles.First(i => i.ID == articleID);
                context.Articles.Remove(article);
                context.SaveChanges();
                
                access.DeleteReport(reportID, out isSucceed);                
                return "Article has been deleted";
            }
            else
            {
                isSucceed = false;
                return "Article does not exist";
            }
        }
    }
}