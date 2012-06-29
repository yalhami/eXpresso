using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using TG.ExpressCMS.Utilities;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.RSS
{
    public partial class RSSViewer_UC : System.Web.UI.UserControl
    {
        public int XSLID
        {
            set
            {
                ViewState["XSLID"] = value;
            }
            get
            {
                if (ViewState["XSLID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["XSLID"].ToString());
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(RSSViewer_UC_Load);
        }

        void RSSViewer_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetRssFiles();
        }

        private void GetRssFiles()
        {
            XmlDocument xdoc = new XmlDocument();
            XmlElement xRoot = xdoc.CreateElement("Data");
            xdoc.AppendChild(xRoot);


            string[] colFileInfos = Directory.GetFiles(Server.MapPath("~/UI/RSS/Categories"), "*.xml", SearchOption.AllDirectories);
            for (int i = 0; i < colFileInfos.Length; i++)
            {
                XmlElement xRow = xdoc.CreateElement("File");
                xRoot.AppendChild(xRow);
                XmlAttribute xAttpath = xdoc.CreateAttribute("Path");
                xRow.Attributes.Append(xAttpath);

                XmlAttribute xAttname = xdoc.CreateAttribute("Name");
                xRow.Attributes.Append(xAttname);

                xAttname.Value = colFileInfos[i].Substring(colFileInfos[i].LastIndexOf('\\') + 1, colFileInfos[i].Length - colFileInfos[i].LastIndexOf('\\') - 1).Replace("rss", "").Replace("-", "").Replace(".xml", "").Replace("//", "/");
                xAttpath.Value ="change me" + "/UI/RSS/Categories" + colFileInfos[i].Substring(colFileInfos[i].LastIndexOf('\\'), colFileInfos[i].Length - colFileInfos[i].LastIndexOf('\\')).Replace("//", "/");
            }
            XslTemplate xsl = XslTemplateManager.GetByID(XSLID);
            if (null == xsl)
                return;
            dvData.InnerHtml = UtilitiesManager.TransformXMLWithXSLText(xdoc.OuterXml, xsl.Details);
        }
    }
}