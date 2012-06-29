using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Contact
    {
        public int ID
        {
            set;
            get;
        }
        public string FirstName
        {
            set;
            get;
        }
        public string SurName
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }
        public string Mobile
        {
            set;
            get;
        }
        public string Phone2
        {
            set;
            get;
        }
        public string ZipCode
        {
            set;
            get;
        }
        public string Guid
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus Status
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public string Country
        {
            set;
            get;
        }
        public string Company
        {
            set;
            get;
        }
        public string Notes
        {
            set;
            get;
        }
        public  string FullName
        {
            get
            {
                return FirstName + " " + SurName;
            }
        }
    }
}