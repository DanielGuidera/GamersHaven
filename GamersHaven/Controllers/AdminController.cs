using GamersHaven.DAL;
using GamersHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamersHaven.Controllers
{
    public class AdminController : Controller
    {
        // GET: Report
        public ActionResult Reports(ReportType.Type type, string message = "", bool isSucceed = false)
        {
            List<string> articleReportHeaders = new List<string> { "Report ID", "Article ID", "Report Type", "Action" };
            ViewData["Headers"] = articleReportHeaders;
            if (message.Equals(""))
            {
                ViewData["MessageReturned"] = false;
            }            
            else
            {
                ViewData["MessageReturned"] = true;
            }
            ViewData["Message"] = message;
            ViewData["IsSucceed"] = isSucceed;
            SiteContext db = new SiteContext();            
            return View("~/Views/Admin/Reports.cshtml", db.Reports.ToList());
        }
        
        public ActionResult DeleteReportedArticle(int articleID, int reportID)
        {
            ArticleAccess access = new ArticleAccess();
            bool isSucceed;
            string message = access.DeleteArticle(articleID, reportID, out isSucceed);
            return Reports(ReportType.Type.Article, message, isSucceed);
        }

        public ActionResult DeleteReport(int reportID)
        {            
            ReportAccess access = new ReportAccess();
            bool isSucceed;
            string message = access.DeleteReport(reportID, out isSucceed);
            return Reports(ReportType.Type.Article, message, isSucceed);
        }
    }
}