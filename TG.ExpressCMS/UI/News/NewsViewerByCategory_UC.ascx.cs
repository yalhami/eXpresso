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

namespace TG.ExpressCMS.UI.News
{
    public partial class NewsViewerByCategory_UC : System.Web.UI.UserControl
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
                    return 4;
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
            this.ddlCategories.SelectedIndexChanged += new EventHandler(ddlCategories_SelectedIndexChanged);
        }

        void CustomPager_UC1_NextClick()
        {
            TransformAndGet();


        }

        void CustomPager_UC1_BackClick()
        {
            TransformAndGet();


        }

        void CustomPager_UC1_btnGoClick()
        {
            TransformAndGet();
        }

        void NewsViewer_UC_Load(object sender, EventArgs e)
        {
            divMessages.InnerText = "";
            if (!IsPostBack)
            {
                FillDDL();
                CustomPager_UC1.PageSize = Count;
                TransformAndGet();
            }
        }
        private void TransformAndGet()
        {
            int totalRows = 0;
            XmlDocument xDoc = NewsItemManager.GetByCategoryIDasXML(CategoryID, CustomPager_UC1.From, CustomPager_UC1.To, ref totalRows, "%" + txtKeyword.Text + "%", "1/1/1990", -1, false);
            CustomPager_UC1.TotalRows = totalRows;

            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details);
            dvData.InnerHtml = _html;
            divMessages.InnerText = "";
            if (totalRows == 0)
            {
                divMessages.InnerText = "لم يتم الحصول على أي نتائج لهذا البحث";
                CustomPager_UC1.Visible = false;
            }
            else
            {
                CustomPager_UC1.Visible = true;
                divMessages.InnerText = "";
            }

            if (totalRows < Count)
            {
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategories.SelectedValue != "" && ddlCategories.SelectedIndex > 0)
            {
                lblTitle.InnerText = "دراسات التصنيف";
                txtKeyword.Text = "";
                CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                TransformAndGet();
            }
        }
        private void FillDDL()
        {
            ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.CategoryType.IslamicStudies).ToList();
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();

            ddlCategories.Items.Insert(0, new ListItem("تصنيفات الدراسات...."));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CustomPager_UC1.PageNumber = 1;
            CustomPager_UC1.PageSize = Count;
            TransformAndGet();
        }
    }
}