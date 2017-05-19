using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.Models
{
    public class ReportModel
    {
        public int ID { get; set; }
        public int articleID { get; set; }
        public reportType type { get; set; }
        public enum reportType
        {
            Spam,
            Fake,
            Old
        };
    }
}