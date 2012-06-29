using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TG.ExpressCMS.Configuration
{ 
    public class GeneralConfigElement : ConfigurationElement
    {
      
        [ConfigurationProperty("PhysicalPath", IsRequired = true)]
        public string PhysicalPath
        {
            get
            {
                return this["PhysicalPath"] as string;
            }
        }
        [ConfigurationProperty("UploadPath", IsRequired = true)]
        public string UploadPath
        {
            get
            {
                return this["UploadPath"] as string;
            }
        }
        [ConfigurationProperty("SettingsPath", IsRequired = true)]
        public string SettingsPath
        {
            get
            {
                return this["SettingsPath"] as string;
            }
        }      
        [ConfigurationProperty("LoggingPath", IsRequired = true)]
        public string LoggingPath
        {
            get
            {
                return this["LoggingPath"] as string;
            }
        }
     
        [ConfigurationProperty("ShowPagesBuilder", IsRequired = true)]
        public string ShowPagesBuilder
        {
            get
            {
                return this["ShowPagesBuilder"] as string;
            }
        }
     
    }
}