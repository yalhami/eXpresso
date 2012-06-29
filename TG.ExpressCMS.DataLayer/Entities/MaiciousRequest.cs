using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class MaiciousRequest
    {
        public int ID
        {
            set;
            get;
        }
        public string IPAddress
        {
            set;
            get;
        }
        public string Url
        {
            set;
            get;
        }
        public string DateTime
        {
            set;
            get;
        }
    }
}