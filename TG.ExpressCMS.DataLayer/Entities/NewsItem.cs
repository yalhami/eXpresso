using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class NewsItem
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
        public string Description
        {
            set;
            get;
        }
        public string Details
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.NewsItemURLType URlType
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
        public string Guid
        {
            set;
            get;
        }
        public string Url
        {
            set;
            get;
        }
        public string Image
        {
            set;
            get;
        }
        public string CreationDate
        {
            set;
            get;
        }
        public int CreatedBy
        {
            set;
            get;
        }
        public string CreationTime
        {
            set;
            get;
        }
        public string PublishFrom
        {
            set;
            get;
        }
        public string PublishTo
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public bool ShowComments
        {
            set;
            get;
        }
        public int LangID
        {
            set;
            get;
        }
        public string Date
        {
            set;
            get;
        }
        public int OrderNumber
        {
            set;
            get;
        }
        public int RefLangID
        {
            set;
            get;
        }
        public int ViewCount
        {
            set;
            get;
        }
        public bool IsFeatured
        {
            set;
            get;
        }
        public string Keywords
        {
            set;
            get;
        }
       
    }
}