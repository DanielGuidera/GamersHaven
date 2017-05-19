using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamersHaven.Models;
using GamersHaven.DAL;

namespace GamersHaven.Controllers
{
    public class ArticleController : Controller
    {        
        // GET: Article
        public ActionResult Read(int _ID)
        {
            ArticleModels articleData;

            ArticleAccess access = new ArticleAccess();
            if (access.GetArticleForRead(out articleData, _ID))
            {
                ViewData["ArticleInfo"] = articleData;
                return View("Article");
            }
            else
            {
                return View("Error");
            }            
        }

        public ActionResult Report(int articleID, ReportModel.reportType reportType)
        {
            ReportAccess access = new ReportAccess();
            ViewData["ReportMessage"] = access.ReportArticle(articleID, reportType);
            
            return View("ReportMessage");                    
        }        
    }
}