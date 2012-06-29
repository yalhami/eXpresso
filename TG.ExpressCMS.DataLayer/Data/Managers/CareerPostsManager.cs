using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class CareerPostsManager
    {
        public static int Add(CareerPosts obj)
        {
            CareerPostsDataMapper objCaller = new CareerPostsDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(CareerPosts obj)
        {
            CareerPostsDataMapper objCaller = new CareerPostsDataMapper();

            objCaller.Update(obj);
        }
        public static CareerPosts GetByID(int ID)
        {
            CareerPostsDataMapper objCaller = new CareerPostsDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<CareerPosts> GetAll()
        {
            CareerPostsDataMapper objCaller = new CareerPostsDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            CareerPostsDataMapper objCaller = new CareerPostsDataMapper();

            objCaller.Delete(ID);
        }
    }
}