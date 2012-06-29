using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using System.Xml;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Marquee
{
    public partial class MarqueeDetailsViewer_UC : System.Web.UI.UserControl
    {
        public int XslID
        {
            set
            {
                ViewState["XslID"] = value;
            }
            get
            {
                if (ViewState["XslID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["XslID"].ToString());
                }
            }
        }
       
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(NewsViewer_UC_Load);
        }

        void NewsViewer_UC_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MarqueeID"] == null)
                return;
            int _marqueeID = Convert.ToInt32(Request.QueryString["MarqueeID"]);
            XmlDocument xDoc = MarqueeItemsManager.GetByIDasXml(_marqueeID);
            if (XslID == null) return;
            XslTemplate xslTemplate = XslTemplateManager.GetByID(XslID);
            if (null == xslTemplate)
                return;
            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details);
            dvData.InnerHtml = _html;
        }
    }
}