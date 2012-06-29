using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class PollDetails
    {
        public int PollID
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public int Count
        {
            set;
            get;
        }
        public int ID
        {
            set;
            get;
        }
    }
}