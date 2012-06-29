using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.Utilities
{
    public static class ForumUtilities
    {
        public static string GetForumUserImage(string UserImagePath)
        {
            if (string.IsNullOrEmpty(UserImagePath))
                return "~/Images/UserDefault.png";
            return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath.Replace("~", "") + UserImagePath;
        }

        private static string GetForumUserProfileURL
        {
            get
            {
                return "~/UserPages/ForumUserProfile.aspx";
            }
        }

        public static string GetForumProfile(int UserId)
        {
            return GetForumUserProfileURL + "?UserID=" + UserId;
        }
    }
}