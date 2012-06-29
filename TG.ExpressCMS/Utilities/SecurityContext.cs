using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.Utilities
{
    public static class SecurityContext
    {
        public static Users LoggedInUser
        {
            get
            {
                if (HttpContext.Current.Session[ConstantsManager.LoggedInUser] != null)
                {
                    return (Users)HttpContext.Current.Session[ConstantsManager.LoggedInUser];
                }
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[ConstantsManager.LoggedInUser] = value;
            }
        }
        public static IList<Roles> LoggedInUserRoles
        {
            get
            {
                if (HttpContext.Current.Session[ConstantsManager.LoggedInUserRoles] != null)
                {
                    return (IList<Roles>)HttpContext.Current.Session[ConstantsManager.LoggedInUserRoles];
                }
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session[ConstantsManager.LoggedInUserRoles] = value;
            }
        }
        public static void LogOut()
        {
            SecurityContext.LoggedInUser = null; SecurityContext.LoggedInUserRoles = null;
        }
          public static ForumUser LoggedInForumUser
        {
            get
            {
                Users user = SecurityContext.LoggedInUser;
                if (user != null)
                {
                    ForumUser forumUser = (ForumUser)HttpContext.Current.Session[ConstantsManager.LoggedInForumUser];
                    if (forumUser != null && forumUser.UserID == user.ID)
                    {
                        return forumUser;
                    }
                    else
                    {
                        forumUser = DataLayer.Data.ForumUserManager.GetByUserID(user.ID);
                        if (forumUser != null)
                            HttpContext.Current.Session[ConstantsManager.LoggedInForumUser] = forumUser;
                        return forumUser;
                    }
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[ConstantsManager.LoggedInUserRoles] = value;
            }
        }
           public static bool CheckAccessAddPost()
        {
            return SecurityContext.LoggedInForumUser != null;
        }
        public static bool CheckAccessAddThread()
        {
            IList<Roles> userRoles = SecurityContext.LoggedInUserRoles;
            DataLayer.Entities.ForumUser forumUser = SecurityContext.LoggedInForumUser;
            //if (forumUser == null || forumUser.IsBanned || userRoles == null || userRoles.Where(r => r.ID == (int)RootEnums.UserRoles.AddThread).FirstOrDefault() == null)
            return SecurityContext.LoggedInForumUser != null;
        }   
      
    }
}