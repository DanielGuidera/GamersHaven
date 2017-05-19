using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersHaven.Models
{
    public class AccountModel
    {        
        public int ID { get; set; }
        public string fristName { get; set; }
        public string lastName { get; set; }        
        public AccountStatus accountStatus { get; set; }         
        public enum AccountStatus
        {
            Active,
            Inactive,
            Banned,
            Deleted
        }

        public AccountModel GetAccountInfo()
        {
            throw new NotImplementedException();
        }
    }
}