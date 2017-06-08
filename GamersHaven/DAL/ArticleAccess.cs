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


            if (articleData == null || articleData.status == ArticleModels.Status.Failed)
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
        public string ApproveArticle(string userName, int articleID, out bool isSuccessful)
        {
            var articles = context.Articles.ToList();
            int exists = (from row in articles
                          where row.ID == articleID
                          select row).Count();
            
            if (exists > 0)
            {
                ApprovalAccess access = new ApprovalAccess();
                UserAccess userAccess = new UserAccess();
                var userID = userAccess.GetUserIDFromUserName(userName);
                var approvalExists = access.ApprovalExists(userID, articleID);
                if(!approvalExists)
                {
                    var article = context.Articles.First(i => i.ID == articleID);
                    if (article.approvals < 10)
                    {
                        article.approvals += 1;
                        context.SaveChanges();
                        if (article.approvals == 10)
                        {
                            ManageArticleStatus(article, ArticleModels.Status.Approved);
                        }
                        isSuccessful = true;
                        access.LogApproval(userID, articleID);
                        return "Approval Added";
                    }
                    else
                    {
                        isSuccessful = false;
                        return "Article has already been approved";
                    }
                }
                else
                {
                    isSuccessful = false;
                    return "You have already approved this article";
                }
                
            }
            else
            {
                isSuccessful = false;
                return "Article no longer exists";
            }
        }

        private void ManageArticleStatus(ArticleModels article, ArticleModels.Status newStatus)
        {
            article.status = newStatus;
            context.SaveChanges();
        }       
    }
}