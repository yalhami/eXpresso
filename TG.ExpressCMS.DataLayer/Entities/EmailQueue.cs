using System;
using System.Collections.Generic;
 using System.Linq; 
 using System.Text; 
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class EmailQueue
    {
        public int ID
        {
            set;
            get;
        }
        public string ReciverAddress
        {
            set;
            get;
        }
        public string RecieverName
        {
            set;
            get;
        }
        public string SenderAddress
        {
            set;
            get;
        }
        public string SenderName
        {
            set;
            get;
        }
        public int ContactID
        {
            set;
            get;
        }
        public string ScheduleDate
        {
            set;
            get;
        }
        public string ScheduleTime
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.SendingStatus SendingStatus
        {
            set;
            get;
        }
        public string SentDate
        {
            set;
            get;
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.DeliveryStatus DeliveryStatus
        {
            set;
            get;
        }
        public int MailID
        {
            set;
            get;
        }
        public int SentBy
        {
            set;
            get;
        }
    }
}
 