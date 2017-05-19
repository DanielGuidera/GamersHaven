using GamersHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.DAL
{
    public class ReportAccess
    {
        private SiteContext context = new SiteContext();
        
        public string ReportArticle(int articleID, ReportModel.reportType reportType)
        {
            var reports = GetReports();
            int exists = (from row in reports
                where row.articleID == articleID 
                && row.type == reportType         
                select row).Count();

            if(exists < 1)
            {
                int lastID;
                if (reports.Count > 0)
                {
                    lastID = reports.Max(x => x.ID);
                }
                else
                {
                    lastID = 0;
                }

                ReportModel newReport = new ReportModel();
                newReport.ID = lastID + 1;
                newReport.articleID = articleID;
                newReport.type = reportType;
                context.Reports.Add(newReport);
                context.SaveChanges();

                return "Article has been reported. Category: "+ reportType + "";
            }
            else
            {
                return "Article has already been reported for category of " + reportType + "";
            }         
        }

        private List<ReportModel> GetReports()
        {
            return context.Reports.ToList();
        }
    }
}