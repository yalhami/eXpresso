using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class CareerPosts
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
        public int JobID
        {
            set;
            get;
        }
        public string Date
        {
            set;
            get;
        }
        public string Experiences
        {
            set;
            get;
        }
        public string CVDocument
        {
            set;
            get;
        }
        public string CVText
        {
            set;
            get;
        }
        public string Image
        {
            set;
            get;
        }
        public string Phone
        {
            set;
            get;
        }
        public string Title
        {
            set;
            get;
        }
    }
}