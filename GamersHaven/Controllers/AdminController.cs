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
        public ActionResult Reports(ReportType.Type type)
        {            
            SiteContext db = new SiteContext();            
            return View(db.Reports.ToList());
        }
        
        public void DeleteReportedArticle()
        {

        }

        public ActionResult DeleteReport(int reportID)
        {
            ReportAccess access = new ReportAccess();
            ViewData["ReportMessage"] = access.DeleteReport(reportID);
            return View("~/Views/Article/ReportMessage.cshtml");
        }
    }
}