using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class MenuItemManager
    {
        public static int Add(MenuItem obj)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(MenuItem obj)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            objCaller.Update(obj);
        }
        public static MenuItem GetByID(int ID)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetByID(ID);
        }
        public static XmlDocument GetByIDasXml(int ID)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            MenuItem _news = objCaller.GetByID(ID);
            if (null == _news)
                return null;
            XmlDocument xdoc = new XmlDocument();
            XmlElement xroot = xdoc.CreateElement("Data");
            XmlElement xitem = xdoc.CreateElement("MenuItems");

            xdoc.AppendChild(xroot);
            xroot.AppendChild(xitem);

            XmlAttribute xName, xDesc, xId, xDetails, xUrl, xCreationdate, xImage;

            xName = xdoc.CreateAttribute("NAME");
            xDesc = xdoc.CreateAttribute("DESCRIPTION");
            xDetails = xdoc.CreateAttribute("DETAILS");
            xUrl = xdoc.CreateAttribute("URL");
            xCreationdate = xdoc.CreateAttribute("CREATION_DATE");
            xImage = xdoc.CreateAttribute("IMAGE");
            xId = xdoc.CreateAttribute("ID");

            xName.Value = _news.Name;
            xDesc.Value = _news.Description;
            xDetails.Value = _news.Details;
            xUrl.Value = _news.Url;
            xCreationdate.Value = _news.CreationDate;
            xImage.Value = _news.Image;
            xId.Value = _news.ID.ToString();
            xitem.Attributes.Append(xName);
            xitem.Attributes.Append(xDesc);
            xitem.Attributes.Append(xDetails);
            xitem.Attributes.Append(xUrl);
            xitem.Attributes.Append(xCreationdate);
            xitem.Attributes.Append(xImage);
            xitem.Attributes.Append(xId);
            return xdoc;
        }
        public static IList<MenuItem> GetAll()
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetAll();
        }
        public static IList<MenuItem> GetAllofLangauge()
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetAllforLang();
        }
        /// <summary>
        /// Search for published menu item
        /// </summary>
        /// <param name="catid">-1 tp ignore else it search for it</param>
        /// <param name="keyword">'%%' to ignore else it search for it using like</param>
        /// <returns></returns>
        public static IList<MenuItem> GetAllBySearchandPublished(int catid, string keyword, int menuID)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetAllPublishedSearch(keyword, catid, menuID);
        }
        public static IList<MenuItem> GetAllBySearchandPublishedforAdmin(int catid, string keyword, int menuID)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetAllPublishedSearchforAdmin(keyword, catid, menuID);
        }
        public static IList<MenuItem> GetAllPagingSearch(int from, int to, ref int totalRows, string keyword)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetAllPaging(from, to, ref totalRows, keyword);
        }

        public static IList<MenuItem> GetAllByCategoryandLang(int langid, string hash)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.GetAllByCategoryandLang(hash, langid);
        }
        public static IList<MenuItem> Search(string keyword)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            return objCaller.Search(keyword);
        }

        public static void Delete(int ID)
        {
            MenuItemDataMapper objCaller = new MenuItemDataMapper();

            objCaller.Delete(ID);
        }
    }
}