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
    public class ForumGroupManager
    {
        public static int Add(ForumGroup obj)
        {
            ForumGroupDataMapper objCaller = new ForumGroupDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(ForumGroup obj)
        {
            ForumGroupDataMapper objCaller = new ForumGroupDataMapper();

            objCaller.Update(obj);
        }
        public static ForumGroup GetByID(int ID)
        {
            ForumGroupDataMapper objCaller = new ForumGroupDataMapper();

            return objCaller.GetByID(ID);
        }
        public static List<ForumGroup> GetAll()
        {
            ForumGroupDataMapper objCaller = new ForumGroupDataMapper();

            return objCaller.GetAll();
        }
        public static void DeleteLogical(int ID)
        {
            ForumGroupDataMapper objCaller = new ForumGroupDataMapper();

            objCaller.DeleteLogical(ID);
        }
        public static void DeletePhysical(int ID)
        {
            ForumGroupDataMapper objCaller = new ForumGroupDataMapper();

            objCaller.DeletePhysical(ID);
        }
    }
}