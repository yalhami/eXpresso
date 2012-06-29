using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class InQuiry
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
        public string Description
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }
        public string Phone
        {
            set;
            get;
        }
        public string Country
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.InQuiryStatus Status
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
    }
}