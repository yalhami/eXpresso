using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class ForumUser
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
        public int RoleID
        {
            set;
            get;
        }
        public bool IsTrusted
        {
            set;
            get;
        }
        public bool IsBanned
        {
            set;
            get;
        }
        public DateTime BannedDate
        {
            set;
            get;
        }
        public string UserName
        {
            set;
            get;
        }
        public DateTime BirthDate
        {
            set;
            get;
        }
        public DateTime JoinDate
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
        public int PostsPerPage
        {
            get;
            set;
        }
        public int ThreadsPerPage
        {
            get;
            set;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.ForumUserType ForumUserType
        {
            get;
            set;
        }
        public int UserRateValue
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}