using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class ForumThread
    {
        public ForumThread()
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
        public int ForumID
        {
            get;
            set;
        }
        public DateTime CreationDate
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public int NumberThreadViews
        {
            get;
            set;
        }
        public Enums.RootEnums.ForumThreadStatus Status
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int TotalPosts
        {
            get;
            set;
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
        public int LastPostID
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