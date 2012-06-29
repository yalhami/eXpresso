using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class FatawaManager
    {
        public static int Add(Fatawa obj)
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Fatawa obj)
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            objCaller.Update(obj);
        }
        public static Fatawa GetByID(int ID)
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Fatawa> Search(string keyword, int catid)
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            return objCaller.Search(keyword, catid);
        }
        public static IList<Fatawa> GetPendingFatwa()
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            return objCaller.GetPendingFatwa();
        }
        public static IList<Fatawa> GetAll()
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            return objCaller.GetAll();
        }
        public static IList<Fatawa> GetAllByCategoryPaging(int from, int to, ref int totalrows, int catid, int status, string keyword)
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            return objCaller.GetAllByCategoryByPaging(catid, from, to, ref totalrows, status, keyword);
        }
        public static void Delete(int ID)
        {
            FatawaDataMapper objCaller = new FatawaDataMapper();

            objCaller.Delete(ID);
        }
    }
}