using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class BlocksManager
    {
        public static int Add(Blocks obj)
        {
            BlocksDataMapper objCaller = new BlocksDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Blocks obj)
        {
            BlocksDataMapper objCaller = new BlocksDataMapper();

            objCaller.Update(obj);
        }
        public static Blocks GetByID(int ID)
        {
            BlocksDataMapper objCaller = new BlocksDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Blocks> GetAll()
        {
            BlocksDataMapper objCaller = new BlocksDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            BlocksDataMapper objCaller = new BlocksDataMapper();

            objCaller.Delete(ID);
        }
    }
}