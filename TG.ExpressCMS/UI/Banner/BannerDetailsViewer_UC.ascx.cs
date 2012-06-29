using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Xml.Xsl;

namespace TG.ExpressCMS.UI.Banner
{
    public partial class BannerDetailsViewer_UC : System.Web.UI.UserControl
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
            this.Load += new EventHandler(BannerViewer_UC_Load);
        }

        void BannerViewer_UC_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[ConstantsManager.BannerID] == null)
                return;
            int _BannerID = 0; Int32.TryParse(Request.QueryString[ConstantsManager.BannerID], out _BannerID);
            if (_BannerID == 0)
                return;
            XmlDocument xDoc = BannerManager.GetByIDasXml(_BannerID);
            if (null == xDoc)
                return;
            TG.ExpressCMS.DataLayer.Entities.Banner _banner = BannerManager.GetByID(_BannerID);
            if (null != _banner)
                this.Page.Title = _banner.Name;
            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddExtensionObject("obj:CategoryViewer", this);

            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details, arguments);
            dvData.InnerHtml = _html;

        }

    }
}