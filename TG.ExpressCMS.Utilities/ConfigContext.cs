using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.Utilities
{
    public static class ConfigContext
    {
        public static string GetLoginPage
        {
            get
            {
                return "~/AdminPages/frmlogin.aspx";
            }
        }
        public static string GetGalleryUploadPath
        {
            get
            {
                return ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + "\\Gallery\\";
            }
        }

        public static string GetAdminLandingPage
        {
            get
            {
                return "~/AdminPages/frmAdminLanding.aspx";
            }
        }
        public static string GetNonAuthorizedPage
        {
            get
            {
                return "~/AdminPages/frmNotAuthorized.aspx";
            }
        }

        public static string GetUserInformationPage
        {
            get
            {
                return "~/AdminPages/frmMyProfile.aspx";
            }
        }

        public static string GetCSSFilePath
        {
            get
            {
                return "~/UI/CSS/CSSFiles/";
            }
        }


        public static string NewsletterActivationPagePath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["NewsletterActivationPagePath"];
            }
        }
        public static string GetBannerDetailsPage
        {
            get
            {
                return "~/UserPages/BannerDetails.aspx";
            }
        }
        public static string GetSearchDetailsPage
        {
            get
            {
                return "~/UserPages/SearchDetails.aspx";
            }
        }
        public static string GetForumPage
        {
            get
            {
                //return "~/frmForumView.aspx";
                return "~/UserPages/ForumDetails.aspx";
            }
        }
        public static string GetFatwaDetailsPage
        {
            get
            {
                return "~/UserPages/FatwaDetails.aspx";
            }
        }

        public static string GetForumThreadPage
        {
            get
            {
                //return "~/frmThreadView.aspx";
                return "~/UserPages/ForumThreadDetails.aspx";
            }
        }

        public static string GetAddPostPage
        {
            get
            {
                //return "~/frmAddPost.aspx";
                return "~/UserPages/ForumAddPost.aspx";
            }
        }

        public static string GetEventDetails
        {
            get
            {
                //return "~/frmEventDetails.aspx";
                return "~/UserPages/EventDetails.aspx";
            }
        }

        public static string GetRegistrationForumURL
        {
            get
            {
                return "~/UserPages/ForumRegistration.aspx";
                //return "~/UserPages/EventDetails.aspx";
            }
        }
        public static string GetLoginURL
        {
            get
            {
                return "~/UserPages/LoginUsers.aspx";
                //return "~/UserPages/EventDetails.aspx";
            }
        }
        public static string UserSideLogin
        {
            get
            {
                return "~/UserPages/LoginUsers.aspx";
            }
        }
        public static string GetForumGroupPage
        {
            get
            {
                return "~/UserPages/ForumGroupViewer.aspx";
            }
        }
    }
}
