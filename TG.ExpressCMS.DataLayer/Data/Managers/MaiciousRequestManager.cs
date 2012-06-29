using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using TG.ExpressCMS.DataLayer.Entities;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class MaiciousRequestManager
    {
        public static int Add(MaiciousRequest obj)
        {
            MaiciousRequestDataMapper objCaller = new MaiciousRequestDataMapper();

            return objCaller.Add(obj);
        }
        //public static void Update(MaiciousRequest obj)
        //{
        //    MaiciousRequestDataMapper objCaller = new MaiciousRequestDataMapper();

        //    objCaller.Update(obj);
        //}
        //public static MaiciousRequest GetByID(int ID)
        //{
        //    MaiciousRequestDataMapper objCaller = new MaiciousRequestDataMapper();

        //    return objCaller.GetByID(ID);
        //}
        public static IList<MaiciousRequest> GetAll()
        {
            MaiciousRequestDataMapper objCaller = new MaiciousRequestDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            MaiciousRequestDataMapper objCaller = new MaiciousRequestDataMapper();

            objCaller.Delete(ID);
        }
    }
}