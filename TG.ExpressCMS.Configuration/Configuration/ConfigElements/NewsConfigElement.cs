using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace TG.ExpressCMS.Configuration
{
    public class NewsConfigElement : ConfigurationElement
    {

        [ConfigurationProperty("DefaultDetailsPage", IsRequired = true)]
        public string DefaultDetailsPage
        {
            get
            {
                return this["DefaultDetailsPage"] as string;
            }
        }
        [ConfigurationProperty("DefaultNewsViewerPage", IsRequired = true)]
        public string DefaultNewsViewerPage
        {
            get
            {
                return this["DefaultNewsViewerPage"] as string;
            }
        }
        [ConfigurationProperty("OrderNewsBy", IsRequired = true)]
        public string OrderNewsBy
        {
            get
            {
                return this["OrderNewsBy"] as string;
            }
        }
    }
}