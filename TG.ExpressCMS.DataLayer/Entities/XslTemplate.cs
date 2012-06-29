using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class XslTemplate
    {
        public int ID
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public string Details
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public string Hash
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
    }
}