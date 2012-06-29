using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class ForumUserSummary
    {
        public int ID
        {
            set;
            get;
        }
        public int UserID
        {
            set;
            get;
        }
        public string UserName
        {
            set;
            get;
        }
        public string Image
        {
            set;
            get;
        }
        public string Signature
        {
            set;
            get;
        }
        public int UserRateValue
        {
            get;
            set;
        }
    }
}