using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class CMSPage
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
        public string Keyword
        {
            set;
            get;
        }
        public string MetTags
        {
            set;
            get;
        }
        public string TemplateName
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.PageType Type
        {
            set;
            get;
        }
        public string PageContent
        {
            set;
            get;
        }
    }
}