using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Sawtyyat
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
        public string Path
        {
            set;
            get;
        }
        public RootEnums.AudioVideoType Type
        {
            set;
            get;
        }
        public string Details
        {
            set;
            get;
        }
        public string Date
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
    }
}