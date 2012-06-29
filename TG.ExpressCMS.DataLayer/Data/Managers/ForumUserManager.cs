using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class ForumUserManager
    {
        public static int Add(ForumUser obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            return objCaller.Add(obj);
        }
        public static void Update(ForumUser obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            objCaller.Update(obj);
        }
        public static void UpdateTrusted(int objID, bool IsTrusted)
        {
            if (objID <= 0)
                return;

            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            objCaller.UpdateTrusted(objID, IsTrusted);
        }
        public static void UpdateBanned(int objID, bool IsBanned, DateTime BannedDate)
        {
            if (objID <= 0)
                return;

            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            objCaller.UpdateBanned(objID, IsBanned, BannedDate);
        }
        public static ForumUser GetByID(int ID)
        {
            if (ID <= 0)
                return null;

            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            return objCaller.GetByID(ID);
        }
        public static List<ForumUser> GetAll()
        {
            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            return objCaller.GetAll();
        }
        public static List<ForumUser> GetBySearch(string keyword, Enums.RootEnums.ForumUserTrusted ForumUserTrusted, Enums.RootEnums.ForumUserBanned ForumUserBanned, Enums.RootEnums.ForumUserType ForumUserType)
        {
            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            return objCaller.GetBySearch(keyword, ForumUserTrusted, ForumUserBanned, ForumUserType);
        }
        public static ForumUser GetByUserID(int UserID)
        {
            if (UserID <= 0)
                return null;

            ForumUserDataMapper objCaller = new ForumUserDataMapper();

            return objCaller.GetByUserID(UserID);
        }
        public static void DeleteLogical(int ID)
        {
            if (ID <= 0)
                return;

            ForumUser forumUser = GetByID(ID);
            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            objCaller.DeleteLogical(ID);

            if (forumUser != null)
                UsersManager.Delete(forumUser.UserID);
        }
        public static void DeletePhysical(int ID)
        {
            if (ID <= 0)
                return;

            ForumUser forumUser = GetByID(ID);
            ForumUserDataMapper objCaller = new ForumUserDataMapper();
            objCaller.DeletePhysical(ID);

            if (forumUser != null)
                UsersManager.Delete(forumUser.UserID);
        }
    }
}