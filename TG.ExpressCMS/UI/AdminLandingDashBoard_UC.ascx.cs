using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using System.IO;
using System.Xml.Xsl;

namespace TG.ExpressCMS.UI
{
    public partial class AdminLandingDashBoard_UC : System.Web.UI.UserControl
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
        public string XmlFilePath
        {
            set
            {
                ViewState["XmlFilePath"] = value;
            }
            get
            {
                if (null != ViewState["XmlFilePath"])
                {
                    return Convert.ToString(ViewState["XmlFilePath"]);
                }
                else
                {
                    return "XmlDashBoard.xml";
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            XmlDocument xDoc = new XmlDocument();
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddExtensionObject("obj:CategoryViewer", this);

            StreamReader _reader = new StreamReader(Server.MapPath("~/AdminPages/" + XmlFilePath));
            string _xml = _reader.ReadToEnd();

            xDoc.LoadXml(_xml);
            _reader.Close();
            _reader.Dispose();

            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details, arguments);

            dvdata.InnerHtml = _html;
        }
        public string GetPendingFatawaCount()
        {
            IList<Fatawa> colFatawa = FatawaManager.GetPendingFatwa();
            return colFatawa.Count.ToString();
        }
        public string GetContactUsInQuiry()
        {
            IList<InQuiry> colInquiry = InQuiryManager.GetAll().Where(t => t.Status == DataLayer.Enums.RootEnums.InQuiryStatus.Pending).ToList();
            return colInquiry.Count.ToString();
        }
        public string GrtPendingComments()
        {
            IList<TG.ExpressCMS.DataLayer.Entities.Comment> colComments = CommentManager.GetPendingComments();
            if (null != colComments)
                return colComments.Count.ToString();
            else
                return "0";
        }
    }
}