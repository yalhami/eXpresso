using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class HtmlItemManager
    {
        public static int Add(HtmlItem obj)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(HtmlItem obj)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            objCaller.Update(obj);
        }
        public static HtmlItem GetByID(int ID)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            return objCaller.GetByID(ID);
        }
        public static HtmlItem GetByHashName(string hashName)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            return objCaller.GetByHashName(hashName);
        }
        public static HtmlItem GetByHashNameandLangID(string hashName, int langID)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            return objCaller.GetByHashNameandLangID(hashName, langID);
        }
        public static IList<HtmlItem> GetAll()
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            return objCaller.GetAll();
        }
        public static IList<HtmlItem> Search(string keyword)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            return objCaller.Search(keyword);
        }
        public static void Delete(int ID)
        {
            HtmlItemDataMapper objCaller = new HtmlItemDataMapper();

            objCaller.Delete(ID);
        }
    }
}