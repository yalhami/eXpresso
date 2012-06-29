using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class ProductManager
    {
        public static int Add(Product obj)
        {
            ProductDataMapper objCaller = new ProductDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Product obj)
        {
            ProductDataMapper objCaller = new ProductDataMapper();

            objCaller.Update(obj);
        }
        public static Product GetByID(int ID)
        {
            ProductDataMapper objCaller = new ProductDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Product> GetByCategoryID(int ID)
        {
            ProductDataMapper objCaller = new ProductDataMapper();

            return objCaller.GetByCategoryID(ID);
        }
        public static IList<Product> GetAll()
        {
            ProductDataMapper objCaller = new ProductDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            ProductDataMapper objCaller = new ProductDataMapper();

            objCaller.Delete(ID);
        }
    }
}