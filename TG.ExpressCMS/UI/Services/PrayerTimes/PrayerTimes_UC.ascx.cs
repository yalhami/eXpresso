using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Xml.Xsl;
using System.Text;
using System.IO;
using System.Xml.XPath;
using System.Globalization;

namespace TG.ExpressCMS.UI.Custums
{
    public partial class PrayerTimes_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(PrayerTimes_UC_Load);
        }

        void PrayerTimes_UC_Load(object sender, EventArgs e)
        {

        }
        public void GetDailyXmlFile(int xslIId)
        {
            WebClient webCli = new WebClient();
            string xmlData = "";
            if (!Directory.Exists(Server.MapPath("~/Services/PrayerTimes/" + DateTime.Now.Day + DateTime.Now.Month + ".xml")))
            {
                xmlData = webCli.DownloadString("http://www.islamicfinder.org/prayer_service.php?country=jordan&city=amman&state=11&zipcode=&latitude=31.9500&longitude=35.9333&timezone=2&HanfiShafi=1&pmethod=4&fajrTwilight1=10&fajrTwilight2=10&ishaTwilight=10&ishaInterval=30&dhuhrInterval=1&maghribInterval=1&dayLight=1&simpleFormat=xml");
                xmlData = xmlData.Substring(3, xmlData.Length - 3);

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xmlData);
                xDoc.Save(Server.MapPath("~/Services/PrayerTimes/" + DateTime.Now.Day + DateTime.Now.Month + ".xml"));
            }
            else
            {
                StreamReader reader = new StreamReader(Server.MapPath("~/Services/PrayerTimes/" + DateTime.Now.Day + DateTime.Now.Month + ".xml"));
                xmlData = reader.ReadToEnd();
            }
            XslTemplate _xslTemplate = new XslTemplate();

            _xslTemplate = XslTemplateManager.GetByID(xslIId);
            if (null == _xslTemplate)
                return;
            string html = TransformXMLWithXSLText(xmlData, _xslTemplate.Details);
            dvdate.InnerHtml = html;
        }

        public string TransformXMLWithXSLText(string xmlText, string xslText)
        {
            try
            {
                //check that there is some xml
                if (string.IsNullOrEmpty(xmlText)) return "";
                //check that there is some xsl
                if (string.IsNullOrEmpty(xslText)) return "";
                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("obj:CategoryViewer", this);
                //create a stringbuilder object to hold outputted html
                var sb = new StringBuilder();
                //load a string reader from the xml data
                using (StringReader xmlStringReader = new StringReader(xmlText))
                {
                    //create an xpath document from the xml data
                    XPathDocument xPathDoc = new XPathDocument(xmlStringReader);
                    //create a string reader for the xsl data
                    using (StringReader xslStringReader = new StringReader(xslText))
                    {
                        //pass xsl text into xmltextreader
                        using (XmlReader styleSheet = new XmlTextReader(xslStringReader))
                        {
                            //create the transformation class
                            XslCompiledTransform xslTrans = new XslCompiledTransform();

                            //load the xsl into the transformer
                            xslTrans.Load(styleSheet);
                            //create a stringwriter for outputting html to
                            using (StringWriter sw = new StringWriter(sb))
                            {
                                //do the actual transform of Xml
                                xslTrans.Transform(xPathDoc, arguments, sw);
                            }
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                dvdate.InnerText = e.ToString();
            }
            return "";
        }
        public string GetDay()
        {
            CultureInfo _cul = new CultureInfo("ar-JO");
            return DateTime.Now.ToString("dddd", _cul);
        }

    }
}