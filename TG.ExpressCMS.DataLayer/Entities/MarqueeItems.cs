using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class MarqueeItems
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
        public int CategoryID
        {
            set;
            get;
        }
        public string Url
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType UrlType
        {
            set;
            get;
        }
        public string Text
        {
            set;
            get;
        }
        public string Image
        {
            set;
            get;
        }
    }
}