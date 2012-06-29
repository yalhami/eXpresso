using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TG.ExpressCMS.Configuration
{
    public static class ExpressoConfig
    {
        #region General Config Element
        public static class GeneralConfigElement
        {
            public static string GetPhysicalPath
            {
                get
                {
                  //  if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.PhysicalPath != "")
                        return HttpContext.Current.Server.MapPath("~/")+"\\"+ ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.PhysicalPath;
                    //else
                      //  return "";
                }
            }
            public static string GetPhysicalUploadPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.UploadPath != "")
                        return GetPhysicalPath + ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.UploadPath;
                    else
                        return "";
                }
            }
            public static string GetVirtualUploadPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.UploadPath != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.UploadPath.Replace("\\", "/");
                    else
                        return "/upload/File/";
                }
            }
            public static string GetVirtualSettingsPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.SettingsPath != "")
                        return "~" + ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.SettingsPath.Replace("\\", "/");
                    else
                        return "";
                }
            }
            public static string GetPhysicalSettingsPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.SettingsPath != "")
                        return GetPhysicalPath + ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.SettingsPath;
                    else
                        return "";
                }
            }
            public static string GetVirtualLoggingPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.LoggingPath != "")
                        return "~" + ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.LoggingPath.Replace("\\", "/");
                    else
                        return "";
                }
            }
            public static string GetPhysicalLoggingPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.LoggingPath != "")
                        return GetPhysicalPath + ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.LoggingPath;
                    else
                        return "";
                }
            }

            public static bool ShowPagesBuilder
            {
                get
                {
                    bool result = false;
                    bool.TryParse(ExpressoConfigurationManager._ExpressoConfigSectionHandler.General.ShowPagesBuilder, out result);
                    return result;
                }
            }

        }
        #endregion
        #region News Config Element
        public static class NewsConfigElement
        {
            public static string GetDefaultDetailsPage
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.News.DefaultDetailsPage != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.News.DefaultDetailsPage;
                    else
                        return "";
                }
            }
            public static string GetDefaultNewsViewerPage
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.News.DefaultNewsViewerPage != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.News.DefaultNewsViewerPage;
                    else
                        return "";
                }
            }
            public static string OrderNewsBy
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.News.OrderNewsBy != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.News.OrderNewsBy;
                    else
                        return "OrderNumber";
                }
            }
        }
        #endregion
        #region Menu Config Element
        public static class MenuConfigElement
        {
            public static string GetDefaultDetailsPage
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.Menu.DefaultDetailsPage != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.Menu.DefaultDetailsPage;
                    else
                        return "";
                }
            }
        }
        #endregion
        #region Marquee Config Element
        public static class MarqueeConfigElement
        {
            public static string GetDefaultDetailsPage
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.Marquee.DefaultDetailsPage != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.Marquee.DefaultDetailsPage;
                    else
                        return "";
                }
            }
        }
        #endregion
        #region Newsletter Config Element
        public static class NewsletterConfigElement
        {
            public static string GetSmtpPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.SMTPPath != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.SMTPPath;
                    else
                        return "";
                }
            }
            public static string GetTrackingPath
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.TrackingPath != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.TrackingPath;
                    else
                        return "";
                }
            }
            public static string GetActivationPage
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.ActivationPage != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.ActivationPage;
                    else
                        return "";
                }
            }
            public static string GetNewsletterRegistrationPage
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.NewsletterRegistrationPage != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.NewsletterConfig.NewsletterRegistrationPage;
                    else
                        return "";
                }
            }
        }
        #endregion
        #region Security Config Element
        public static class SecurityConfigElement
        {
            public static string EnglishVersionUrl
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.SecurityConfig.EnglishVersionUrl != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.SecurityConfig.EnglishVersionUrl;
                    else
                        return "";
                }
            }
            public static string ArabicVersionUrl
            {
                get
                {
                    if (ExpressoConfigurationManager._ExpressoConfigSectionHandler.SecurityConfig.ArabicVersionUrl != "")
                        return ExpressoConfigurationManager._ExpressoConfigSectionHandler.SecurityConfig.ArabicVersionUrl;
                    else
                        return "";
                }
            }
        }
        #endregion
    }
}
