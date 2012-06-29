using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class ForumPost
    {
        public ForumPost()
        {
            UserSummary = new ForumUserSummary();
        }
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
        public int ForumThreadID
        {
            set;
            get;
        }
        public int ForumID
        {
            set;
            get;
        }
        public int ParentPostID
        {
            set;
            get;
        }
        public DateTime CreationDate
        {
            set;
            get;
        }
        public int CreatedBy
        {
            set;
            get;
        }
        public string DetailsText
        {
            set;
            get;
        }
        public string DetailsHtml
        {
            set;
            get;
        }
        public Enums.RootEnums.ForumPostStatus Status
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public ForumUserSummary UserSummary
        {
            get;
            internal set;
        }
    }
}