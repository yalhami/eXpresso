using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class ForumGroup
    {
        public ForumGroup()
        {
            CreationDate = DateTime.Now;
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
        public int OrderID
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
        public bool IsDeleted
        {
            get;
            set;
        }
    }
}