using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Controls
{
    public partial class DataPager_UC : System.Web.UI.UserControl
    {
        #region Proberties

        public int PageSize
        {
            set
            {
                if (value <= 0)
                    throw new Exception("Page size must be greater than zero");
                ViewState["PageSize"] = value;
            }
            get
            {
                if (ViewState["PageSize"] != null)
                    return Convert.ToInt32(ViewState["PageSize"]);
                else
                    return 10;
            }
        }
        public int CurrentPageNumber
        {
            set
            {
                txtCurrentPage.Text = value.ToString();
            }
            get
            {
                if (txtCurrentPage.Text != "")
                    return Convert.ToInt32(txtCurrentPage.Text);
                else
                    return 0;
            }
        }
        public int TotalPages
        {
            private set
            {
                ViewState["TotalPages"] = value;
            }
            get
            {
                if (ViewState["TotalPages"] != null)
                    return Convert.ToInt32(ViewState["TotalPages"]);
                else
                    return 0;
            }
        }
        public string PagePath
        {
            get
            {
                if (ViewState["PagePath"] != null)
                    return ViewState["PagePath"].ToString();
                else
                    return string.Empty;
            }
            set
            {
                ViewState["PagePath"] = value;
            }
        }

        #endregion

        #region Events

        protected override void OnInit(EventArgs e)
        {
            if (!IsPostBack)
            {
                BeginMode();
            }
            this.ibtnJumptoPage.Click += new ImageClickEventHandler(ibtnJumptoPage_Click);
            base.OnInit(e);
        }

        void ibtnJumptoPage_Click(object sender, ImageClickEventArgs e)
        {
            int jumpPage = 0;
            int.TryParse(txtCurrentPage.Text, out jumpPage);
            if (PagePath.Contains("?"))
                Response.Redirect(PagePath + "&PageNo=" + jumpPage);
            else
                Response.Redirect(PagePath + "?PageNo=" + jumpPage);
        }

        #endregion

        #region Methods

        #region BindPager
        public void BindPager(int TotalResultCount)
        {
            hrefPrevious.HRef = string.Empty;
            hrefNext.HRef = string.Empty;

            if (TotalResultCount < PageSize)
                this.Visible = false;
            else
                this.Visible = true;
            int totalPages = (int)Math.Ceiling((decimal)TotalResultCount / (decimal)PageSize);
            TotalPages = totalPages;
            //numCurrentPage.Maximum = totalPages;

            if (CurrentPageNumber < totalPages)
            {
                if (PagePath.Contains("?"))
                    hrefNext.HRef = PagePath + "&PageNo=" + (CurrentPageNumber + 1);
                else
                    hrefNext.HRef = PagePath + "?PageNo=" + (CurrentPageNumber + 1);
            }

            if (CurrentPageNumber > 1)
            {
                if (PagePath.Contains("?"))
                    hrefPrevious.HRef = PagePath + "&PageNo=" + (CurrentPageNumber - 1);
                else
                    hrefPrevious.HRef = PagePath + "&PageNo=" + (CurrentPageNumber - 1);
            }

            lblTotalPages.Text = totalPages.ToString();
        }
        #endregion

        #region BeginMode
        void BeginMode()
        {
            int CurrentPage = 0;
            int.TryParse(Request.QueryString["PageNo"], out CurrentPage);

            if (CurrentPage < 1)
                CurrentPage = 1;

            CurrentPageNumber = CurrentPage;
        }
        #endregion

        #endregion
    }
}