using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class CategoryManager
    {
        public static int Add(Category obj)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Category obj)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            objCaller.Update(obj);
        }
        public static Category GetByID(int ID)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            return objCaller.GetByID(ID);
        }

        public static IList<Category> GetByHash(string hash)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();
            return objCaller.GetByHashCode(hash);
        }

        public static IList<Category> GetByLanguageID(int langID)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();
            return objCaller.GetByLanguageID(langID);
        }

        public static IList<Category> GetAll()
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            return objCaller.GetAll();
        }
        public static XmlDocument GetAllasXml(int count, int type)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            return objCaller.GetAllXml(count, type);
        }
        public static XmlDocument GetAllasXml(int type, int from, int to, ref int totalrows)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            return objCaller.GetAllXml(from, to, ref totalrows, type);
        }
        public static void Delete(int ID)
        {
            CategoryDataMapper objCaller = new CategoryDataMapper();

            objCaller.Delete(ID);
        }
    }
}