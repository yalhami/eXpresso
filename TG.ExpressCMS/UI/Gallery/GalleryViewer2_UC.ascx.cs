using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Gallery
{
    public partial class GalleryViewer2_UC : System.Web.UI.UserControl
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
        public int PageSize
        {
            set
            {
                ViewState["PageSize"] = value;
            }
            get
            {
                if (ViewState["PageSize"] == null)
                {
                    return 8;
                }
                else
                {
                    return Convert.ToInt32(ViewState["PageSize"].ToString());
                }
            }
        }
        private int PageNumber
        {
            set
            {
                ViewState["PageNumber"] = value;
            }
            get
            {
                if (ViewState["PageNumber"] == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["PageNumber"].ToString());
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(GalleryViewer_UC_Load);


            if (Request.QueryString[ConstantsManager.CategoryID] != null)
            {
                int catid = 0;
                Int32.TryParse(Request.QueryString[ConstantsManager.CategoryID], out catid);
                CategoryID = catid;
            }
            CustomPager_UC1.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(CustomPager_UC1_btnGoClick);
            CustomPager_UC1.BackClick += new UI.Controls.CustomPager_UC.btnBack(CustomPager_UC1_BackClick);
            CustomPager_UC1.NextClick += new UI.Controls.CustomPager_UC.btnNext(CustomPager_UC1_NextClick);
        }

        void CustomPager_UC1_NextClick()
        {
            BindDataList();
        }

        void CustomPager_UC1_BackClick()
        {
            BindDataList();

        }

        void CustomPager_UC1_btnGoClick()
        {
            BindDataList();
        }

        void GalleryViewer_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
            if (!IsPostBack)
            {
                BindCategoryInfo();
                CustomPager_UC1.PageSize = PageSize;
                BindDataList();
            }
        }

        private void BindDataList()
        {

            int totalrows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.Gallery> colGalleries = GalleryManager.GetPagesItems(CustomPager_UC1.From, CustomPager_UC1.To, ref totalrows, CategoryID);
            CustomPager_UC1.TotalRows = totalrows;

            dlPhotogallery.DataSource = colGalleries;
            dlPhotogallery.DataBind();

            if (totalrows == 0)
            {
                dvMessages.InnerText = Resources.ExpressCMS.nofilesfound;
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;

            if (totalrows < PageSize)
            {
                CustomPager_UC1.Visible = false;
            }
            else
                CustomPager_UC1.Visible = true;
            if (null != colGalleries && colGalleries.Count > 0)
                imgbig.ImageUrl = GetFullPath(colGalleries[0].Path, "image");
        }
        private void BindCategoryInfo()
        {
            Category _cat = CategoryManager.GetByID(CategoryID);
            if (null == _cat)
                return;
            lblGalleryViewer.Text = "";
            lblGalleryViewer.Text = _cat.Name;
            dvDetails.InnerHtml = _cat.Description;
        }
        protected string GetFullPath(string path, string type)
        {
            if (type.ToLower() == "image")
                return ("~/Upload/Files/Gallery/Thumb-" + path);
            if (type.ToLower() == "document")
                return ("~/App_Themes/AdminSide2/Images/document-open.png");
            if (type.ToLower() == "full")
                return ("~/Upload/Files/Gallery/" + path);
            return "";
        }
        protected string GetDocumentDownLoad(string path, string type)
        {
            if (type.ToLower() == "document")
            {
                return "~/UI/Gallery/Download.ashx?ImageName=" + path;
            }
            else
                return "";
        }
    }
}