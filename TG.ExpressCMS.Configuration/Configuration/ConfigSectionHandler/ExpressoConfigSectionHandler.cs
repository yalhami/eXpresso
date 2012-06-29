using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TG.ExpressCMS.Configuration
{
    /// <author>Ayman Habeb</author>
    /// <summary>
    /// ExpressoConfigurationSectionHandler
    /// </summary>
    public class ExpressoConfigSectionHandler : ConfigurationSection
    {

        [ConfigurationProperty("GeneralConfig")]
        public GeneralConfigElement General
        {
            get
            {
                return this["GeneralConfig"] as GeneralConfigElement;
            }
        }
        [ConfigurationProperty("NewsConfig")]
        public NewsConfigElement News
        {
            get
            {
                return this["NewsConfig"] as NewsConfigElement;
            }
        }

        [ConfigurationProperty("MenuConfig")]
        public MenusConfigElement Menu
        {
            get
            {
                return this["MenuConfig"] as MenusConfigElement;
            }
        }
        [ConfigurationProperty("NewsletterConfig")]
        public NewsletterConfigElement NewsletterConfig
        {
            get
            {
                return this["NewsletterConfig"] as NewsletterConfigElement;
            }
        }
        [ConfigurationProperty("MarqueeConfig")]
        public MarqueeConfigElement Marquee
        {
            get
            {
                return this["MarqueeConfig"] as MarqueeConfigElement;
            }
        }
        [ConfigurationProperty("SecurityConfig")]
        public SecurityConfigElement SecurityConfig
        {
            get
            {
                return this["SecurityConfig"] as SecurityConfigElement;
            }
        }
        
    }
}