using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Xml;
using System.Collections;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.Services
{
    /// <summary>
    /// Summary description for RSSUpdater
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RSSUpdater : System.Web.Services.WebService
    {

        [WebMethod]
        [SoapDocumentMethod(OneWay = true)]
        public void UpdateCategoryFile(int catid, string Hash)
        {
            if (Hash != "NoTImeFORLove")
                return;
            Category cat = CategoryManager.GetByID(catid);
            string rssname = cat.Name + "-rss.xml";

            XmlDocument xDoc = new XmlDocument();
            XmlElement rss = xDoc.CreateElement("rss");
            xDoc.AppendChild(rss);
            XmlAttribute xAttVersion = xDoc.CreateAttribute("version");
            xAttVersion.Value = "2";
            rss.Attributes.Append(xAttVersion);
            XmlElement channer = xDoc.CreateElement("channel");
            rss.AppendChild(channer);

            XmlElement title = xDoc.CreateElement("title");
            channer.AppendChild(title);
            title.InnerText = "Chamge me from Web Service";

            XmlElement link = xDoc.CreateElement("link");
            channer.AppendChild(link);
            link.InnerText = "Change em from web service";

            XmlElement description = xDoc.CreateElement("description");
            channer.AppendChild(description);
            description.InnerText = "" + "change me";

            XmlElement language = xDoc.CreateElement("language");
            channer.AppendChild(language);
            language.InnerText = "en-us";

            IList<NewsItem> colItems = NewsItemManager.GetByCategoryID(cat.ID);
            for (int i = 0; i < colItems.Count; i++)
            {
                XmlElement item = xDoc.CreateElement("item");
                channer.AppendChild(item);
                //   item.InnerText = colItems[i].Name;

                XmlElement itemtitle = xDoc.CreateElement("title");
                item.AppendChild(itemtitle);
                itemtitle.InnerText = colItems[i].Name;

                XmlElement itemdescription = xDoc.CreateElement("description");
                item.AppendChild(itemdescription);
                itemdescription.InnerText = colItems[i].Description;

                XmlElement itemlink = xDoc.CreateElement("link");
                itemlink.InnerText = colItems[i].Url;
                item.AppendChild(itemlink);
            }
            try
            {
                xDoc.Save(Server.MapPath("~/UI/RSS/Categories/" + rssname));

            }
            catch (Exception ex)
            {
                UtilitiesManager.WriteFile(ExpressoConfig.GeneralConfigElement.GetPhysicalLoggingPath, ex.ToString(), false, true);
            }

        }
    }
}
