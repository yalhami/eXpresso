using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Category
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
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.CategoryType Type
        {
            set;
            get;
        }
        public string Attributes
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public int XslID
        {
            set;
            get;
        }
        public string Image
        {
            set;
            get;
        }
        public int LanguageID
        {
            set;
            get;
        }
        public string Hash
        {
            set;
            get;
        }
    }
}