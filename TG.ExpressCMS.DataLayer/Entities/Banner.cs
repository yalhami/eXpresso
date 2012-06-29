using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Banner
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
        public string Hash
        {
            set;
            get;
        }
        public string Details
        {
            set;
            get;
        }
        public string CrerationDate
        {
            set;
            get;
        }
        public string CreatedBy
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
        public int CategoryID
        {
            set;
            get;
        }
        public RootEnums.BannerStatus Status
        {
            set;
            get;
        }
        public RootEnums.BannerType Type
        {
            set;
            get;
        }
        public int TotalCount
        {
            set;
            get;
        }

        public int TotalPassed
        {
            set;
            get;
        }
        public string Url
        {
            set;
            get;
        }
        public RootEnums.UrlType UrlType
        {
            set;
            get;
        }
        public string UserSide
        {
            set;
            get;
        }
    }
}