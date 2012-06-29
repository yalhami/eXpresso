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
    public class ForumManager
    {
        public static int Add(Forum obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumDataMapper objCaller = new ForumDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Forum obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            ForumDataMapper objCaller = new ForumDataMapper();

            objCaller.Update(obj);
        }
        public static void UpdateActive(int objID, bool IsActive)
        {
            if (objID <= 0)
                return;

            ForumDataMapper objCaller = new ForumDataMapper();

            objCaller.UpdateActive(objID, IsActive);
        }
        public static void UpdateNumberViews(int objID)
        {
            if (objID <= 0)
                return;
            ForumDataMapper objCaller = new ForumDataMapper();
            objCaller.UpdateNumberViews(objID);
        }
        public static Forum GetByID(int ID)
        {
            if (ID <= 0)
                return null;

            ForumDataMapper objCaller = new ForumDataMapper();

            return objCaller.GetByID(ID);
        }
        public static Forum GetPublishedByID(int ID)
        {
            if (ID <= 0)
                return null;

            ForumDataMapper objCaller = new ForumDataMapper();

            return objCaller.GetPublishedByID(ID, true);
        }
        public static List<Forum> GetAll()
        {
            ForumDataMapper objCaller = new ForumDataMapper();

            return objCaller.GetAll();
        }
        public static List<Forum> GetByGroupID(int GroupID)
        {
            if (GroupID <= 0)
                return new List<Forum>();

            ForumDataMapper objCaller = new ForumDataMapper();

            return objCaller.GetByGroupID(GroupID);
        }
        public static List<Forum> GetBySearch(string Keyword, int GroupID)
        {
            ForumDataMapper objCaller = new ForumDataMapper();

            return objCaller.GetBySearch(Keyword, GroupID);
        }
        public static void DeleteLogical(int ID)
        {
            if (ID <= 0)
                return;
            ForumDataMapper objCaller = new ForumDataMapper();
            objCaller.DeleteLogical(ID);
        }
        public static void DeletePhysical(int ID)
        {
            if (ID <= 0)
                return;
            ForumDataMapper objCaller = new ForumDataMapper();
            objCaller.DeletePhysical(ID);
        }
    }
}