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
    }
}