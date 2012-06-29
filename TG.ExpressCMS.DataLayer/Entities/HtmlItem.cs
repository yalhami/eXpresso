using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class HtmlItem
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
        public string Details
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public string Hash
        {
            set;
            get;
        }
        public string Date
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.HtmlBlockType Type
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.HtmlBlockStatus Status
        {
            set;
            get;
        }
        public int LanguageID
        {
            set;
            get;
        }
    }
}