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
    public class ForumThreadManager
    {
        public static int Add(ForumThread obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(ForumThread obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            objCaller.Update(obj);
        }
        public static ForumThread GetByID(int ID)
        {
            if (ID <= 0)
                return null;

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            return objCaller.GetByID(ID, 0);
        }
        public static ForumThread GetByIDWithIsDelete(int ID)
        {
            if (ID <= 0)
                return null;

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            return objCaller.GetByID(ID, -1);
        }
        public static ForumThread GetByPublishedID(int ID)
        {
            if (ID <= 0)
                return null;

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            return objCaller.GetByPublishedID(ID, Enums.RootEnums.ForumThreadStatus.Active);
        }
        public static List<ForumThread> GetAll()
        {
            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            return objCaller.GetAll();
        }
        public static List<ForumThread> GetByForumID(int ForumID)
        {
            if (ForumID <= 0)
                return new List<ForumThread>();

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            return objCaller.GetByForumID(ForumID);
        }
        public static List<ForumThread> GetByPublishedForumID(int ForumID)
        {
            if (ForumID <= 0)
                return new List<ForumThread>();

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            return objCaller.GetByPublishedForumID(ForumID, Enums.RootEnums.ForumThreadStatus.Active);
        }
        public static List<ForumThread> GetByPublishedForumID(int ForumID, int PageNumber, int PageSize, ref int ResultCount)
        {
            if (ForumID <= 0)
                return new List<ForumThread>();

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            return objCaller.GetByPublishedForumIDWithPaging(ForumID, Enums.RootEnums.ForumThreadStatus.Active, PageNumber, PageSize, ref ResultCount);
        }
        public static List<ForumThread> GetBySearch(string keyword, int ForumID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus)
        {
            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();

            return objCaller.GetBySearch(keyword, ForumID, ForumThreadStatus);
        }
        public static void UpdateStatus(int ID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus)
        {
            if (ID <= 0)
                return;

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            objCaller.UpdateStatus(ID, ForumThreadStatus);
        }
        public static void UpdateNumberViews(int ID)
        {
            if (ID <= 0)
                return;

            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            objCaller.UpdateNumberViews(ID);
        }
        public static void DeleteLogical(int ID)
        {
            if (ID <= 0)
                return;
            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            objCaller.DeleteLogical(ID);
        }
        public static void DeletePhysical(int ID)
        {
            if (ID <= 0)
                return;
            ForumThreadDataMapper objCaller = new ForumThreadDataMapper();
            objCaller.DeletePhysical(ID);
        }
    }
}