using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.Xml;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml.Xsl;

namespace TG.ExpressCMS.UI
{
    public partial class RelatedNews_UC : System.Web.UI.UserControl
    {
        public int XSLID
        {
            set
            {
                ViewState["XSLID"] = value;
            }
            get
            {
                if (null != ViewState["XSLID"])
                {
                    return Convert.ToInt32(ViewState["XSLID"]);
                }
                else
                {
                    return -1;
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(RelatedNews_UC_Load);
        }

        void RelatedNews_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderRelatedNews();
            }
        }

        private void RenderRelatedNews()
        {
            if (Request.QueryString[ConstantsManager.NewsGUID] == null)
                return;
            //int _newsID = 0; Int32.TryParse(Request.QueryString[ConstantsManager.NewsID], out _newsID);
            //if (_newsID == 0)
            //    return;
            string guid = Request.QueryString[ConstantsManager.NewsGUID].ToString();

            NewsItem _news = NewsItemManager.GetByGUID(guid);
            if (null == _news)
                return;


            XmlDocument xDoc = NewsItemManager.GetNewsByKeywordAsXML(_news.Keywords, _news.ID);

            if (null == xDoc)
                return;


            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddExtensionObject("obj:CategoryViewer", this);
            _news.Keywords = "";
            _news.ViewCount++;
            NewsItemManager.Update(_news);
            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details, arguments);
            dvData.InnerHtml = _html;

        }
    }
}