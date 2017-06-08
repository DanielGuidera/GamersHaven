using GamersHaven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.DAL
{
    public class ApprovalAccess
    {
        private SiteContext context = new SiteContext();

        public void LogApproval(string userID, int articleID)
        {
            var approvals = context.Approvals.ToList();

            int lastID;
            if (approvals.Count > 0)
            {
                lastID = approvals.Max(x => x.ID);
            }
            else
            {
                lastID = 0;
            }

            ApprovalsModel newApproval = new ApprovalsModel();
            newApproval.ID = lastID + 1;
            newApproval.userID = userID;
            newApproval.articleID = articleID;
            context.Approvals.Add(newApproval);
            context.SaveChanges();
        }

        public bool ApprovalExists(string userID, int articleID)
        {
            var approvals = context.Approvals.ToList();
            int exists = (from row in approvals
                          where row.articleID == articleID
                          && row.userID == userID
                          select row).Count();

            if(exists == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}