using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Forum
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
        public int ForumGroupID
        {
            set;
            get;
        }
        public bool IsActive
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
        public int TotalPosts
        {
            get;
            set;
        }
        public int TotalThreads
        {
            get;
            set;
        }
        public int LastForumPostID
        {
            get;
            set;
        }
        public int LastForumThreadID
        {
            get;
            set;
        }
        public int MostAccessForumThreadID
        {
            get;
            set;
        }
        public int NumberForumViews
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public string LastThreadName
        {
            get;
            internal set;
        }
        public string ForumGroupName
        {
            get;
            internal set;
        }
    }
}