using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class MenuItem
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
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype Type
        {
            set;
            get;
        }
        public int CategoryId
        {
            set;
            get;
        }
        public string Url
        {
            set;
            get;
        }
        public int OrderNumber
        {
            set;
            get;
        }
        public int MenuID
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
        public int LangID
        {
            set;
            get;
        }
        public int RefLangID
        {
            set;
            get;
        }
        public bool IsPublished
        {
            set;
            get;
        }
    }
}