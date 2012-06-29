using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class GroupManager
    {
        public static int Add(Group obj)
        {
            GroupDataMapper objCaller = new GroupDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Group obj)
        {
            GroupDataMapper objCaller = new GroupDataMapper();

            objCaller.Update(obj);
        }
        public static Group GetByID(int ID)
        {
            GroupDataMapper objCaller = new GroupDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Group> GetAll()
        {
            GroupDataMapper objCaller = new GroupDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            GroupDataMapper objCaller = new GroupDataMapper();

            objCaller.Delete(ID);
        }
    }
}