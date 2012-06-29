using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Comment
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
        public string Subject
        {
            set;
            get;
        }
        public string Company
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }
        public string Country
        {
            set;
            get;
        }
        public int ObjectID
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.ObjectType ObjectType
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentType Type
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentStatus Status
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public string IntialValue
        {
            set;
            get;
        }
        public string ModifiedValue
        {
            set;
            get;
        }
        public string IPAddress
        {
            set;
            get;
        }
    }
}