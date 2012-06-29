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
    public class NewsItemManager
    {
        public static int Add(NewsItem obj)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(NewsItem obj)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            objCaller.Update(obj);
        }
        public static NewsItem GetByID(int ID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByID(ID);
        }
        public static NewsItem GetByGUID(string GUID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByGUID(GUID);
        }
        public static IList<NewsItem> GetAll()
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetAll();
        }
        public static IList<NewsItem> GetAllofLng()
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetAllForAnotherLang();
        }
        public static IList<NewsItem> GetAllBySearchAndPaging(int from, int to, ref int totalRows, string keyword)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetAlLBySearchAndPaging(from, to, ref totalRows, keyword);
        }

        public static IList<NewsItem> GetAllBySearchAndPagingandDate(int from, int to, ref int totalRows, string keyword, string creationdate, string catid, string orderbyclause)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();
            int _catid = -1;
            if (catid != string.Empty)
                _catid = Convert.ToInt32(catid);
            return objCaller.GetAlLBySearchAndPagingAndCreationDate(from, to, ref totalRows, keyword, creationdate, _catid, orderbyclause);
        }

        public static IList<NewsItem> GetByCategoryID(int catID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByCategoryID(catID);
        }
        public static XmlDocument GetByCategoryIDandUniqueYears(int catID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByCategoryIDAndUniqueYears(catID);
        }
        public static XmlDocument GetNewsByKeywordAsXML(string keyword, int newsID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByKeywordSearchAsXML(keyword, newsID);
        }
        public static XmlDocument GetByCategoryIDasXML(int catID, int count)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByCategoryIDasXML(catID, count);
        }
        public static XmlDocument GetByCategoryAsRandomWithIsFeatured(int catID, int isFeatured)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByCategoryIDasXMLAsRandomWithIsFeatured(catID, isFeatured);
        }
        public static XmlDocument GetByCategoryIDasXML(int catID, int from, int to, ref int TotalRows, string keyword, string date, int isFeatured, bool SelectRandomly)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByCategoryIDasXML(catID, from, to, ref TotalRows, keyword, date, isFeatured, SelectRandomly);
        }
        public static XmlDocument SearchAsXML(string txtKeyword)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.SearchandGetXML(txtKeyword);
        }
        public static XmlDocument GetByIDasXml(int ID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            NewsItem _news = objCaller.GetByID(ID);
            if (_news == null)
                return null;
            XmlDocument xdoc = new XmlDocument();
            XmlElement xroot = xdoc.CreateElement("Data");
            XmlElement xitem = xdoc.CreateElement("NewsItems");

            xdoc.AppendChild(xroot);
            xroot.AppendChild(xitem);

            XmlAttribute xName, xDesc, xDetails, xUrl, xCreationdate, xImage, xTitle, xID;

            xName = xdoc.CreateAttribute("NAME");
            xDesc = xdoc.CreateAttribute("DESCRIPTION");

            xID = xdoc.CreateAttribute("ID");
            xDetails = xdoc.CreateAttribute("DETAILS");
            xImage = xdoc.CreateAttribute("IMAGE");
            xUrl = xdoc.CreateAttribute("URL");
            xCreationdate = xdoc.CreateAttribute("CREATION_DATE");

            xName.Value = _news.Name;
            xDesc.Value = _news.Description;
            xDetails.Value = _news.Details;
            xUrl.Value = _news.Url;
            xCreationdate.Value = _news.CreationDate;
            xImage.Value = _news.Image;
            xID.Value = _news.ID.ToString();


            xitem.Attributes.Append(xName);
            xitem.Attributes.Append(xDesc);
            xitem.Attributes.Append(xID);

            xitem.Attributes.Append(xDetails);
            xitem.Attributes.Append(xUrl);
            xitem.Attributes.Append(xCreationdate);
            xitem.Attributes.Append(xImage);

            return xdoc;
        }
        public static XmlDocument GetByIDasXml(string GUID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            NewsItem _news = objCaller.GetByGUID(GUID);
            if (_news == null)
                return null;
            XmlDocument xdoc = new XmlDocument();
            XmlElement xroot = xdoc.CreateElement("Data");
            XmlElement xitem = xdoc.CreateElement("NewsItems");

            xdoc.AppendChild(xroot);
            xroot.AppendChild(xitem);

            XmlAttribute xName, xDesc, xDetails, xUrl, xCreationdate, xImage, xGUID, xID;

            xName = xdoc.CreateAttribute("NAME");
            xDesc = xdoc.CreateAttribute("DESCRIPTION");

            xID = xdoc.CreateAttribute("ID");
            xDetails = xdoc.CreateAttribute("DETAILS");
            xImage = xdoc.CreateAttribute("IMAGE");
            xUrl = xdoc.CreateAttribute("URL");
            xCreationdate = xdoc.CreateAttribute("CREATION_DATE");
            xGUID = xdoc.CreateAttribute("GUID");

            xName.Value = _news.Name;
            xDesc.Value = _news.Description;
            xDetails.Value = _news.Details;
            xUrl.Value = _news.Url;
            xCreationdate.Value = _news.CreationDate;
            xImage.Value = _news.Image;
            xID.Value = _news.ID.ToString();
            xGUID.Value = _news.Guid.ToString();

            xitem.Attributes.Append(xName);
            xitem.Attributes.Append(xDesc);
            xitem.Attributes.Append(xID);
            xitem.Attributes.Append(xGUID);
            xitem.Attributes.Append(xDetails);
            xitem.Attributes.Append(xUrl);
            xitem.Attributes.Append(xCreationdate);
            xitem.Attributes.Append(xImage);

            return xdoc;
        }
        public static XmlDocument GetByCategoryAndDateYear(int catId, string year)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            return objCaller.GetByCategoryIDasXML(catId, 100000);

        }

        public static void Delete(int ID)
        {
            NewsItemDataMapper objCaller = new NewsItemDataMapper();

            objCaller.Delete(ID);
        }
    }
}