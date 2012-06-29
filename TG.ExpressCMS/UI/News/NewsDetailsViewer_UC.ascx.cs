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
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.News
{
    public partial class NewsDetailsViewer_UC : System.Web.UI.UserControl
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
            this.Load += new EventHandler(NewsViewer_UC_Load);
        }
        public string GetImageUrl(string image)
        {
            if (image != string.Empty)
                return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath + image;
            else
                return ResolveUrl("~") + "App_themes/UserSides/images/defaultcat.png";
        }
        void NewsViewer_UC_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[ConstantsManager.NewsGUID] == null)
                return;
            //int _newsID = 0; Int32.TryParse(Request.QueryString[ConstantsManager.NewsGUID], out _newsID);
            //if (_newsID == 0)
            //    return;
            string guid = Request.QueryString[ConstantsManager.NewsGUID].ToString();
            XmlDocument xDoc = NewsItemManager.GetByIDasXml(guid);
            if (null == xDoc)
                return;
            NewsItem _news = NewsItemManager.GetByGUID(guid);
            if (null != _news)
                this.Page.Title = _news.Name;
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
            if (_news.ShowComments)
            {
                CommentsUserSide_UC1.ObjectID = _news.ID;
                CommentsUserSide_UC1.ObjectType = (DataLayer.Enums.RootEnums.ObjectType.News);
                CommentsUserSide_UC1.DataBind();
                CommentsUserSide_UC1.BindComments();
                CommentsUserSide_UC1.Visible = true;
            }
            else
            {
                CommentsUserSide_UC1.Visible = false;
            }
            this.Page.Header.Title = _news.Name;
        }

    }
}