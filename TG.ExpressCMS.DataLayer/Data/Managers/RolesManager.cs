using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class RolesManager
    {
        public static int Add(Roles obj)
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Roles obj)
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            objCaller.Update(obj);
        }
        public static Roles GetByID(int ID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Roles> GetAll()
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            return objCaller.GetAll();
        }

        public static IList<Roles> GetByUserID(int userID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            return objCaller.GetRolesByUserID(userID);
        }
        public static IList<Roles> GetByPageID(int pageID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            return objCaller.GetRolesByPage(pageID);
        }
        public static void Delete(int ID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();

            objCaller.Delete(ID);
        }
        public static void AssignRoletoUser(int userID, int roleID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();
            objCaller.AddRolestoUser(userID, roleID);
        }
        public static void AssignRoletoPage(int pageID, int roleID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();
            objCaller.AddRolestoPage(pageID, roleID);
        }
        public static void DeleteUserRole(int userID, int roleID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();
            objCaller.DeleteUserRole(userID, roleID);
        }
        public static void DeletePageRole(int pageID, int roleID)
        {
            RolesDataMapper objCaller = new RolesDataMapper();
            objCaller.DeletePageRole(pageID, roleID);
        }
    }
}