using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace TG.ExpressCMS.Configuration
{
   
    public class ExpressoConfigurationManager
    {
        #region Members

        /// <summary>
        /// singleton object of config section handler
        /// </summary>
        public static ExpressoConfigSectionHandler _ExpressoConfigSectionHandler;


        #endregion

        #region Constants
        /// <summary>
        /// Config Section name
        /// </summary>
        private static readonly string Expresso_CONFIG_SECTION_NAME = "ExpressoConfiguration";
        #endregion

        #region Constructors
        /// <summary>
        /// Static Constructor
        /// </summary>
        static ExpressoConfigurationManager()
        {
            string message = string.Empty;
            string messageFormat = string.Empty;

            try
            {
                //Get config section
                _ExpressoConfigSectionHandler = ConfigurationManager.GetSection(Expresso_CONFIG_SECTION_NAME) as ExpressoConfigSectionHandler;
            }
            catch (Exception ex)
            {
                message = string.Format(messageFormat, "Unhandled Exception occured While Loading Settings Configuration");
                throw new ConfigurationErrorsException(message, ex);
            }
        }
        #endregion
    }
}