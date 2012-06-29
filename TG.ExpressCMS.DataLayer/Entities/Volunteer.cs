using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Volunteer
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
        public string Email
        {
            set;
            get;
        }
        public string CV
        {
            set;
            get;
        }
        public string Message
        {
            set;
            get;
        }
    }
}