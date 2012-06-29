using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI
{
    public partial class RandomNewsViewer_UC : System.Web.UI.UserControl
    {
        public int CategoryID
        {
            set
            {
                ViewState["CategoryID"] = value;
            }
            get
            {
                if (ViewState["CategoryID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["CategoryID"].ToString());
                }
            }
        }


        public int ShowFeatured
        {
            set
            {
                ViewState["ShowFeatured"] = value;
            }
            get
            {
                if (ViewState["ShowFeatured"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["ShowFeatured"].ToString());
                }
            }
        }


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

        private Category _Category
        {
            get
            {
                if (CategoryID <= 0)
                    return null;
                if (HttpContext.Current.Session["_Category"] == null)
                {
                    HttpContext.Current.Session["_Category"] = CategoryManager.GetByID(CategoryID);
                    return (Category)HttpContext.Current.Session["_Category"];
                }
                else
                {
                    return (Category)HttpContext.Current.Session["_Category"];
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
                return ResolveUrl("~") + "App_themes/UserSides/images/defimage.png";
        }
        void NewsViewer_UC_Load(object sender, EventArgs e)
        {
            BindDataGrid();
        }
        private void BindDataGrid()
        {
            XmlDocument xDoc = NewsItemManager.GetByCategoryAsRandomWithIsFeatured(CategoryID, ShowFeatured);
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