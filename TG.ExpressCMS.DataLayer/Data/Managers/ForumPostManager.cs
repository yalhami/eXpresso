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
    public class ForumPostManager
    {
        public static int Add(ForumPost obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(ForumPost obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            objCaller.Update(obj);
        }
        public static ForumPost GetByID(int ID)
        {
            if (ID <= 0)
                return null;

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByID(ID, 0);
        }
        public static ForumPost GetByIDWithIsDelete(int ID)
        {
            if (ID <= 0)
                return null;

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByID(ID, -1);
        }
        public static List<ForumPost> GetAll()
        {
            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetAll();
        }
        public static List<ForumPost> GetByForumID(int ForumID)
        {
            if (ForumID <= 0)
                return new List<ForumPost>();

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByForumID(ForumID);
        }
        public static List<ForumPost> GetByPublishedForumID(int ForumID)
        {
            if (ForumID <= 0)
                return new List<ForumPost>();

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByPublishedForumID(ForumID, Enums.RootEnums.ForumPostStatus.Active);
        }
        public static List<ForumPost> GetByParentPostID(int ParentPostID)
        {
            if (ParentPostID <= 0)
                return new List<ForumPost>();

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByParentPostID(ParentPostID);
        }
        public static List<ForumPost> GetByThreadID(int ThreadID)
        {
            if (ThreadID <= 0)
                return new List<ForumPost>();

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByThreadID(ThreadID);
        }
        public static List<ForumPost> GetByPublishedThreadID(int ThreadID)
        {
            if (ThreadID <= 0)
                return new List<ForumPost>();

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByPublishedThreadID(ThreadID, Enums.RootEnums.ForumPostStatus.Active);
        }
        public static List<ForumPost> GetByPublishedThreadID(int ThreadID, int PageNumber, int PageSize, ref int ResultCount)
        {
            if (ThreadID <= 0)
                return new List<ForumPost>();

            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetByPublishedThreadIDWithPaging(ThreadID, Enums.RootEnums.ForumPostStatus.Active, PageNumber, PageSize, ref ResultCount);
        }
        public static List<ForumPost> GetBySearch(string keyword, int ForumID, int ThreadID, int ParentPostID, int UserID, Enums.RootEnums.ForumPostStatus ForumPostStatus)
        {
            ForumPostDataMapper objCaller = new ForumPostDataMapper();

            return objCaller.GetBySearch(keyword, ForumID, ThreadID, ParentPostID, UserID, ForumPostStatus);
        }
        public static void UpdateStatus(int ID, Enums.RootEnums.ForumPostStatus ForumPostStatus)
        {
            if (ID <= 0)
                return;
            ForumPostDataMapper objCaller = new ForumPostDataMapper();
            objCaller.UpdateStatus(ID, ForumPostStatus);
        }
        public static void DeleteLogical(int ID)
        {
            if (ID <= 0)
                return;
            ForumPostDataMapper objCaller = new ForumPostDataMapper();
            objCaller.DeleteLogical(ID);
        }
        public static void DeletePhysical(int ID)
        {
            if (ID <= 0)
                return;
            ForumPostDataMapper objCaller = new ForumPostDataMapper();
            objCaller.DeletePhysical(ID);
        }
    }
}