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

namespace TG.ExpressCMS.UI.News
{
    public partial class NewsViewer_UC : System.Web.UI.UserControl
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
                    return true;
                }
                else
                {
                    return Convert.ToBoolean(ViewState["ShowPager"].ToString());
                }
            }
        }
        public bool GetRandom
        {
            set
            {
                ViewState["GetRandom"] = value;
            }
            get
            {
                if (ViewState["GetRandom"] == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(ViewState["GetRandom"].ToString());
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
        public bool ShowYears
        {
            set
            {
                ViewState["ShowYears"] = value;
            }
            get
            {
                if (ViewState["ShowYears"] == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(ViewState["ShowYears"].ToString());
                }
            }
        }
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
                    return 2;
                }
                else
                {
                    return Convert.ToInt32(ViewState["Count"].ToString());
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
        public int YearsXSLID
        {
            set
            {
                ViewState["YearsXSLID"] = value;
            }
            get
            {
                if (ViewState["YearsXSLID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["YearsXSLID"].ToString());
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
            CustomPager_UC1.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(CustomPager_UC1_btnGoClick);
            CustomPager_UC1.BackClick += new UI.Controls.CustomPager_UC.btnBack(CustomPager_UC1_BackClick);
            CustomPager_UC1.NextClick += new UI.Controls.CustomPager_UC.btnNext(CustomPager_UC1_NextClick);

        }


        public string GetImageUrl(string image)
        {
            if (image != string.Empty)
                return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath + image;
            else
                return ResolveUrl("~") + "App_themes/UserSides/images/defimage.png";
        }

        void CustomPager_UC1_NextClick()
        {
            BindDataGrid();
        }

        void CustomPager_UC1_BackClick()
        {
            BindDataGrid();
        }

        void CustomPager_UC1_btnGoClick()
        {
            BindDataGrid();
        }

        void NewsViewer_UC_Load(object sender, EventArgs e)
        {
            CustomPager_UC1.Visible = ShowPager;
            CustomPager_UC1.PageSize = Count;
            if (CategoryID == 40)
                BindDataGrid();
            else
                BindDataGrid();
            if (!IsPostBack)
            {

                BindYears();
                dvyears.Visible = ShowYears;
            }

        }
        private void BindYears()
        {
            XmlDocument xdoc = NewsItemManager.GetByCategoryIDandUniqueYears(CategoryID);
            XslTemplate xsl = XslTemplateManager.GetByID(YearsXSLID);
            if (null == xsl)
                return;
            string _html = UtilitiesManager.TransformXMLWithXSLText(xdoc.OuterXml, xsl.Details);

            dvyearsInternal.InnerHtml = _html;
        }
        private void BindDataGrid()
        {
            int totalRows = 0; XmlDocument xDoc = null;
            if (Request.Params["__EVENTTARGET"] == "Years")
            {
                string _year = string.Empty;
                if (Request.Params["__EVENTARGUMENT"] != "All")
                {
                    _year = Request.Params["__EVENTARGUMENT"];
                }
                xDoc = NewsItemManager.GetByCategoryIDasXML(CategoryID, CustomPager_UC1.From, CustomPager_UC1.To, ref totalRows, "%%", "%" + _year + "%", ShowFeatured, GetRandom);
            }
            else
            {
                xDoc = NewsItemManager.GetByCategoryIDasXML(CategoryID, CustomPager_UC1.From, CustomPager_UC1.To, ref totalRows, "%%", "", ShowFeatured, GetRandom);
            }

            CustomPager_UC1.TotalRows = totalRows;
            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddExtensionObject("obj:CategoryViewer", this);
            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details, arguments);

            dvData.InnerHtml = _html;


            if (totalRows == 0)
            {
                dvProblems.InnerText = Resources.ExpressCMS.nofilesfound;
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;

            if (totalRows < Count)
            {
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;

            CustomPager_UC1.Visible = ShowPager;
        }
    }

}