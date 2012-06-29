using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TG.ExpressCMS.Configuration
{
    public class MarqueeConfigElement : ConfigurationElement
    {

        [ConfigurationProperty("DefaultDetailsPage", IsRequired = true)]
        public string DefaultDetailsPage
        {
            get
            {
                return this["DefaultDetailsPage"] as string;
            }
        }
    }
}