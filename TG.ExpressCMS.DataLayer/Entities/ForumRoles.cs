using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class ForumRoles
    {
        public int ID
        {
            set;
            get;
        }
        public int ForumID
        {
            set;
            get;
        }
        public int RoleID
        {
            set;
            get;
        }
        public int UserID
        {
            set;
            get;
        }
    }
}