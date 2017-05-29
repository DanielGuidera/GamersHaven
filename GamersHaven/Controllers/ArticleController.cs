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
        public ActionResult Read(int _ID, string message = "", bool isSucceed = false)
        {
            ArticleModels articleData;

            ArticleAccess access = new ArticleAccess();
            if (access.GetArticleForRead(out articleData, _ID))
            {
                bool isMessage = false;
                ViewData["ArticleInfo"] = articleData;
                ViewData["IsSucceed"] = isSucceed;         
                ViewData["Message"] = message;
                if(message != "")
                {
                    isMessage = true;
                }
                ViewData["IsMessage"] = isMessage;
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
            //ViewData["ReportMessage"] = access.ReportArticle(articleID, reportType);
            bool isSucceed;
            return Read(articleID, access.ReportArticle(articleID, reportType, out isSucceed), isSucceed);
            //return View("ReportMessage");                    
        }        
    }
}