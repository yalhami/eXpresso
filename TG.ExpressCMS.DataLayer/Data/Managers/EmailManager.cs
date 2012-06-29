using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class EmailManager
    {
        public static int Add(Email obj)
        {
            EmailDataMapper objCaller = new EmailDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Email obj)
        {
            EmailDataMapper objCaller = new EmailDataMapper();

            objCaller.Update(obj);
        }
        public static Email GetByID(int ID)
        {
            EmailDataMapper objCaller = new EmailDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Email> GetAll()
        {
            EmailDataMapper objCaller = new EmailDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            EmailDataMapper objCaller = new EmailDataMapper();

            objCaller.Delete(ID);
        }
    }
}