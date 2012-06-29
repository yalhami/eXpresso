using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Blocks
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
        public bool UseCategory
        {
            set;
            get;
        }
        public bool UseXSL
        {
            set;
            get;
        }
        public string RegisterTag
        {
            set;
            get;
        }
        public bool UseHtml
        {
            set;
            get;
        }
    }
}