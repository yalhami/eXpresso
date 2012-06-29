using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using System.Text;
using System.IO;
using System.Xml.Xsl;
using System.Xml.XPath;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.UI.Categories
{
    public partial class CategoryViewer_UC : System.Web.UI.UserControl
    {

        public int Count
        {
            set
            {
                ViewState["Count"] = value;
            }
            get
            {
                if (ViewState["Count"] == null)
                {
                    return 10;
                }
                else
                {
                    return Convert.ToInt32(ViewState["Count"].ToString());
                }
            }
        }
        public bool ShowPager
        {
            set
            {
                ViewState["ShowPager"] = value;
            }
            get
            {
                if (ViewState["ShowPager"] == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(ViewState["ShowPager"].ToString());
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
        public int Type
        {
            set
            {
                ViewState["Type"] = value;
            }
            get
            {
                if (ViewState["Type"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["Type"].ToString());
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(CategoryViewer_UC_Load);
            CustomPager_UC1.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(CustomPager_UC1_btnGoClick);
            CustomPager_UC1.BackClick += new UI.Controls.CustomPager_UC.btnBack(CustomPager_UC1_BackClick);
            CustomPager_UC1.NextClick += new UI.Controls.CustomPager_UC.btnNext(CustomPager_UC1_NextClick);
        }

        void CustomPager_UC1_NextClick()
        {
            LoadCategories();
        }

        void CustomPager_UC1_BackClick()
        {
            LoadCategories();

        }

        void CustomPager_UC1_btnGoClick()
        {
            LoadCategories();
        }

        void CategoryViewer_UC_Load(object sender, EventArgs e)
        {
            CustomPager_UC1.Visible = ShowPager;
            if (!IsPostBack)
            {
                CustomPager_UC1.PageSize = Count;
                LoadCategories();
            }
        }
        private void LoadCategories()
        {
            int totalrows = 0;
            XmlDocument xDoc = CategoryManager.GetAllasXml(Convert.ToInt32(Type), 0, 30, ref totalrows);
            CustomPager_UC1.TotalRows = totalrows;
            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddExtensionObject("obj:CategoryViewer", this);

            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details, arguments);
            dvCategories.InnerHtml = _html;

            if (totalrows == 0)
            {
                divMessages.InnerText = Resources.ExpressCMS.nofilesfound;
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;

            if (totalrows < Count)
            {
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;
            CustomPager_UC1.Visible = ShowPager;
        }


        public string GetCategoryUrl(int id)
        {
            switch (Type)
            {
                case (1):
                    return ResolveUrl(ExpressoConfig.NewsConfigElement.GetDefaultNewsViewerPage) + ConstantsManager.Category + "=" + id;
                case (4):
                    return ResolveUrl("~/UserPages/GalleryViewer.aspx?") + ConstantsManager.CategoryID + "=" + id;
                case (99):
                    return ResolveUrl("~/UserPages/GalleryViewer.aspx?") + ConstantsManager.CategoryID + "=" + id;

                default:
                    break;
            }
            return "";

        }
        public string GetImageUrl(string image)
        {
            if (image != string.Empty)
                return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath + image;
            else
                return ResolveUrl("~") + "App_themes/UserSides/images/defaultcat.png";
        }
    }
}