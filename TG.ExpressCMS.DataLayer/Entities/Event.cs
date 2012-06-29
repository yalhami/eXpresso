using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Event
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
        public int LocationID
        {
            set;
            get;
        }
        public string DetailsText
        {
            set;
            get;
        }
        public string DetailsHtml
        {
            set;
            get;
        }
        public DateTime FromDate
        {
            get;
            set;
        }
        public DateTime ToDate
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }
        public RootEnums.EventRepeatType RepeatType
        {
            get;
            set;
        }
        public int Every
        {
            get;
            set;
        }
        public string Period
        {
            get;
            set;
        }
        public int Reminder
        {
            get;
            set;
        }
        public int Notify
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
        public string ImageURL
        {
            get;
            set;
        }
        public int CategoryID
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