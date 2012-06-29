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

namespace TG.ExpressCMS.UI.Menus
{
    public partial class MenuDetailsViewer_UC : System.Web.UI.UserControl
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
            if (Request.QueryString[ConstantsManager.MenuID] == null)
                return;
            
            int _menuID = 0;

            Int32.TryParse(Request.QueryString[ConstantsManager.MenuID], out _menuID);
            if (_menuID == 0)
                return;
            XmlDocument xDoc = MenuItemManager.GetByIDasXml(_menuID);
            if (null == xDoc)
                return;
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