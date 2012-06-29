using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TG.ExpressCMS.Configuration
{
    public class NewsletterConfigElement : ConfigurationElement
    {

        [ConfigurationProperty("SMTPPath", IsRequired = true)]
        public string SMTPPath
        {
            get
            {
                return this["SMTPPath"] as string;
            }
        }
        [ConfigurationProperty("TrackingPath", IsRequired = true)]
        public string TrackingPath
        {
            get
            {
                return this["TrackingPath"] as string;
            }
        }

        [ConfigurationProperty("ActivationPage", IsRequired = true)]
        public string ActivationPage
        {
            get
            {
                return this["ActivationPage"] as string;
            }
        }
        [ConfigurationProperty("NewsletterRegistrationPage", IsRequired = true)]
        public string NewsletterRegistrationPage
        {
            get
            {
                return this["NewsletterRegistrationPage"] as string;
            }
        }
    }
}