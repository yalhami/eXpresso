using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class EmailSetting
    {
        public string Host
        {
            set;
            get;
        }
        public int Port
        {
            set;
            get;
        }
        public string SenderName
        {
            set;
            get;
        }
        public string SernderAddress
        {
            set;
            get;
        }
        public bool EnableSSL
        {
            set;
            get;
        }
        public string Username
        {
            set;
            get;
        }
        public string Password
        {
            set;
            get;
        }
        public bool UseCredential
        {
            set;
            get;
        }
    }

}
