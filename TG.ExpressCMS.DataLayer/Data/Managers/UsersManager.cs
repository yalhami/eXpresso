using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class UsersManager
    {
        public static int Add(Users obj)
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Users obj)
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            objCaller.Update(obj);
        }
        public static Users GetByID(int ID)
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            return objCaller.GetByID(ID);
        }
        public static bool ValidateUserPermssion(string pageName, int roleID)
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            return objCaller.ValidateUserPermission(pageName, roleID);
        }
        public static Users GetByEmail(string email)
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            return objCaller.GetByEmail(email);
        }
        public static IList<Users> GetAll()
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            UsersDataMapper objCaller = new UsersDataMapper();

            objCaller.Delete(ID);
        }
    }
}