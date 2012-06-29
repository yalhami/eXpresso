using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class CMSPageManager
    {
        public static int Add(CMSPage obj)
        {
            CMSPageDataMapper objCaller = new CMSPageDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(CMSPage obj)
        {
            CMSPageDataMapper objCaller = new CMSPageDataMapper();

            objCaller.Update(obj);
        }
        public static CMSPage GetByID(int ID)
        {
            CMSPageDataMapper objCaller = new CMSPageDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<CMSPage> GetAll()
        {
            CMSPageDataMapper objCaller = new CMSPageDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            CMSPageDataMapper objCaller = new CMSPageDataMapper();

            objCaller.Delete(ID);
        }
    }
}