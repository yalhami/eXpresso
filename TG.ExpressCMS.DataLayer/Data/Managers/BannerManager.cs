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
    public class BannerManager
    {
        public static int Add(Banner obj)
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Banner obj)
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            objCaller.Update(obj);
        }
        public static Banner GetByID(int ID)
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            return objCaller.GetByID(ID);
        }
        public static XmlDocument GetByIDasXml(int ID)
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            Banner _news = objCaller.GetByID(ID);
            if (_news == null)
                return null;
            XmlDocument xdoc = new XmlDocument();
            XmlElement xroot = xdoc.CreateElement("Data");
            XmlElement xitem = xdoc.CreateElement("BannerItems");

            xdoc.AppendChild(xroot);
            xroot.AppendChild(xitem);

            XmlAttribute xName, xDetails, xUrl, xCreationdate;

            xName = xdoc.CreateAttribute("NAME");
            
            xDetails = xdoc.CreateAttribute("DETAILS");
            xUrl = xdoc.CreateAttribute("URL");
            xCreationdate = xdoc.CreateAttribute("CREATION_DATE");

            xName.Value = _news.Name;
            
            xDetails.Value = _news.Details;
            xUrl.Value = _news.Url;
            xCreationdate.Value = _news.CrerationDate;

            xitem.Attributes.Append(xName);
            
            xitem.Attributes.Append(xDetails);
            xitem.Attributes.Append(xUrl);
            xitem.Attributes.Append(xCreationdate);

            return xdoc;
        }
        public static IList<Banner> GetAll()
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            return objCaller.GetAll();
        }
        public static IList<Banner> GetAllPublishedBanner()
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            return objCaller.GetAllPublished();
        }
        public static void Delete(int ID)
        {
            BannerDataMapper objCaller = new BannerDataMapper();

            objCaller.Delete(ID);
        }
    }
}