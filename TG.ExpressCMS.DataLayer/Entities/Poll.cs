using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Poll
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
        public string Date
        {
            set;
            get;
        }
        public int CreatedBy
        {
            set;
            get;
        }
        public bool IsClosed
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
    }
}