using System;
using System.Collections.Generic;
 using System.Linq; 
 using System.Text; 
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Settings
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
        public string DefaultUrl
        {
            set;
            get;
        }
        public string DefaultLanguageCode
        {
            set;
            get;
        }
        public bool IsDefault
        {
            set;
            get;
        }
        public string PhysicalPath
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
