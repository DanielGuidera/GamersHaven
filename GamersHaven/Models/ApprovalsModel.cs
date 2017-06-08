using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.Models
{
    public class ApprovalsModel
    {
        public int ID { get; set; }
        public int articleID { get; set; }
        public string userID { get; set; }        
    }
}