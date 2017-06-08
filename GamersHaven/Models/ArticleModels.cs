using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.Models
{
    public class ArticleModels
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string blurb { get; set; }
        public string link { get; set; }
        public Status status { get; set; }
        public bool reported { get; set; }
        public int approvals { get; set; }
        public enum Status
        {
            Approved,
            Pending,
            Failed
        };        
    }
}