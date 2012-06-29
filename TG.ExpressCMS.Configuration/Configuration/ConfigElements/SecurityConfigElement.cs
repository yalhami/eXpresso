using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TG.ExpressCMS.Configuration
{
    public class SecurityConfigElement : ConfigurationElement
    {

        [ConfigurationProperty("ArabicVersionUrl", IsRequired = true)]
        public string ArabicVersionUrl
        {
            get
            {
                return this["ArabicVersionUrl"] as string;
            }
        }
        [ConfigurationProperty("EnglishVersionUrl", IsRequired = true)]
        public string EnglishVersionUrl
        {
            get
            {
                return this["EnglishVersionUrl"] as string;
            }
        }
    }
}