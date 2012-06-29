using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Users
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
        public string Password
        {
            set;
            get;
        }
        public bool IsActive
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType Type
        {
            set;
            get;
        }
    }
}