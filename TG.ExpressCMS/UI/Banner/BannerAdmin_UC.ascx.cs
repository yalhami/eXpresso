using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI
{
    public partial class BannerAdmin_UC : System.Web.UI.UserControl
    {
        /// <summary>
        /// Object ID.
        /// </summary>
        private int ObjectID
        {
            set
            {
                ViewState[ConstantsManager.ObjectID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.ObjectID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.ObjectID]);
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// On Intilization.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.gvBanners.SelectedIndexChanged += new EventHandler(gvXsl_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(BannerAdd_UC_Load);
            this.gvBanners.RowCommand += new GridViewCommandEventHandler(gvXsl_RowCommand);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            rdblstTypes.SelectedIndexChanged += new EventHandler(rdblstTypes_SelectedIndexChanged);
            this.ddlUrlType.SelectedIndexChanged += new EventHandler(ddlUrlType_SelectedIndexChanged);
            this.gvBanners.PageIndexChanging += new GridViewPageEventHandler(gvBanners_PageIndexChanging);
        }

        void gvBanners_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBanners.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void ddlUrlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlUrlType.SelectedValue) == Convert.ToInt32(RootEnums.UrlType.External))
            {
                trDetails.Visible = false;
            }
            else
                trDetails.Visible = true;
        }

        void rdblstTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(rdblstTypes.SelectedValue) == Convert.ToInt32(RootEnums.BannerType.StaticBased))
            {
                txtCount.Text = "999999";
                txtCount.Enabled = false;
            }
            else
            {
                txtCount.Text = "";
                txtCount.Enabled = true;
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void gvXsl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBanners")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BannerAdd_UC_Load(object sender, EventArgs e)
        {
            SetEditorPaths();
            if (!IsPostBack)
            {
                BindGrid();
                AddMode();
                plcControls.Visible = false;
                FillDDL();
                PerformSettings();
            }
        }
        private void SetEditorPaths()
        {
            //txtUserSide.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtUserSide.SetSecurityFlashGalleryPath("~/Upload/UserUploads/");
            //txtUserSide.SetSecurityGalleryPath("~/Upload/UserUploads/");
            //txtUserSide.SetSecurityMediaGalleryPath("~/Upload/UserUploads/");
            ////   txtDetails.SetSecurityImageBrowserPath("~/Upload/UserUploads/");
            //txtUserSide.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtUserSide.SetSecurityFilesGalleryPath("~/Upload/UserUploads/");
            //txtUserSide.SetSecurityMaxImageSize(102400);
            //txtUserSide.SetSecurityMaxFlashSize(102400);
            //txtUserSide.SetSecurityMaxDocumentSize(102400);
            //txtUserSide.EnableClientScript = true;

            //txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityFlashGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityMediaGalleryPath("~/Upload/UserUploads/");
            ////   txtDetails.SetSecurityImageBrowserPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityFilesGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityMaxImageSize(102400);
            //txtDetails.SetSecurityMaxFlashSize(102400);
            //txtDetails.SetSecurityMaxDocumentSize(102400);

            //txtDetails.EnableClientScript = true;
        }
        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvBanners.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvBanners.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvBanners.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                BannerManager.Delete(_id);
            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.Banner banner = new TG.ExpressCMS.DataLayer.Entities.Banner();
            if (ObjectID <= 0)
            {
                try
                {
                    banner.Name = txtName.Text;
                    banner.Details = (txtDetails.Content);
                    banner.Hash = txtHash.Text;

                    banner.Status = DataLayer.Enums.RootEnums.BannerStatus.Active;
                    banner.CrerationDate = DateTime.Now.ToString("dd/MM/yyy");
                    banner.CreatedBy = SecurityContext.LoggedInUser.ID.ToString();
                    //banner.CreatedBy = "0";
                    int bannerid = -1;
                    Int32.TryParse(ddlCategories.SelectedValue, out bannerid);
                    banner.CategoryID = bannerid;
                    banner.PublishFrom = txtPublishFrom.SelectedDate.Value.ToString("dd/MM/yyyy");
                    banner.PublishTo = txtDateTo.SelectedDate.Value.ToString("dd/MM/yyyy");
                    banner.UrlType = (RootEnums.UrlType)Convert.ToInt32(ddlUrlType.SelectedValue);
                    banner.Url = "";
                    if (banner.UrlType == RootEnums.UrlType.External)
                        banner.Url = txtUrl.Text;
                    //    if (chkUpdateImage.Checked)
                    banner.UserSide = txtUserSide.Content;
                    banner.Type = RootEnums.BannerType.StaticBased;
                    banner.TotalCount = 999999;
                    banner.TotalPassed = 0;
                    BannerManager.Add(banner);
                    if (banner.UrlType == RootEnums.UrlType.Internal)
                    {
                        banner.Url = ResolveUrl(ConfigContext.GetBannerDetailsPage) + "?" + ConstantsManager.BannerID + "=" + banner.ID;
                        BannerManager.Update(banner);
                    }
                    AddMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }

            }
            else
            {
                try
                {
                    banner = BannerManager.GetByID(ObjectID);
                    if (null == banner)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    banner.Name = txtName.Text;
                    banner.Details = (txtDetails.Content);
                    banner.Hash = txtHash.Text;
                    banner.UserSide = txtUserSide.Content;
                    banner.Status = DataLayer.Enums.RootEnums.BannerStatus.Active;
                    banner.CrerationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    banner.CreatedBy = SecurityContext.LoggedInUser.ID.ToString();
                    //banner.CreatedBy = "0";
                    int bannerid = -1;
                    Int32.TryParse(ddlCategories.SelectedValue, out bannerid);
                    banner.CategoryID = bannerid;
                    banner.PublishFrom = txtPublishFrom.SelectedDate.Value.ToString("dd/MM/yyyy");
                    banner.PublishTo = txtDateTo.SelectedDate.Value.ToString("dd/MM/yyyy");

                    banner.UrlType = (RootEnums.UrlType)Convert.ToInt32(ddlUrlType.SelectedValue);
                    if (banner.UrlType == RootEnums.UrlType.Internal)
                    {
                        banner.Url = ResolveUrl(ConfigContext.GetBannerDetailsPage) + "?" + ConstantsManager.BannerID + "=" + banner.ID;
                    }
                    else
                        banner.Url = txtUrl.Text;
                    banner.Type = RootEnums.BannerType.StaticBased;
                    banner.TotalCount = 999999;
                    banner.TotalPassed = 0;

                    BannerManager.Update(banner);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
        }
        protected string GetImageUrl(string image)
        {
            return "~/Upload/Files/" + image;
        }
        protected string GetCategoryName(string id)
        {
            if (id == string.Empty)
                return "";
            IDictionary<string, string> colcats = null;
            string result = "";
            if (Session["TempCat"] == null)
                colcats = new Dictionary<string, string>();
            else
                colcats = (IDictionary<string, string>)Session["TempCat"];
            if (!colcats.ContainsKey("Session" + id))
            {
                int _id = Convert.ToInt32(id);
                Category _cat = CategoryManager.GetByID(_id);

                if (null == _cat)
                    return "undefined";

                colcats.Add("Session" + id, _cat.Name);
                result = _cat.Name;
                Session["TempCat"] = colcats;
            }
            else
                result = colcats["Session" + id];


            return result;
        }
        void gvXsl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvBanners.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
                EditMode();
            else
                AddMode();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtDetails.Content = "";
            ddlCategories.SelectedIndex = -1;
            txtDateTo.Clear();
            txtUserSide.Content = "";
            txtPublishFrom.Clear();
            txtHash.Text = "";
            rdblstTypes.SelectedIndex = -1;
            txtCount.Text = string.Empty;
            txtName.Text = "";
            ddlUrlType.SelectedIndex = -1;
            txtUrl.Text = "";
            trDetails.Visible = true;
            ddlUrlType.SelectedValue = Convert.ToInt32(RootEnums.UrlType.Internal).ToString();
            dvProblems.InnerText = "";
            txtPublishFrom.SelectedDate = DateTime.Now.Date;
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {

                TG.ExpressCMS.DataLayer.Entities.Banner banner = new TG.ExpressCMS.DataLayer.Entities.Banner();
                banner = BannerManager.GetByID(ObjectID);
                if (null == banner)
                    return;

                txtName.Text = banner.Name;
                txtHash.Text = banner.Hash;
                txtUserSide.Content = banner.UserSide;
                txtCount.Text = banner.TotalCount.ToString();
                rdblstTypes.SelectedValue = Convert.ToInt32(banner.Type).ToString();
                txtDetails.Content = banner.Details;
                txtPublishFrom.DbSelectedDate = banner.PublishFrom;
                txtDateTo.DbSelectedDate = banner.PublishTo;
                if (banner.UrlType == (RootEnums.UrlType.External))
                {
                    trDetails.Visible = false;
                }
                else
                    trDetails.Visible = true;
                ddlUrlType.SelectedValue = Convert.ToInt32(banner.UrlType).ToString();
                txtUrl.Text = banner.Url;
                ddlCategories.SelectedValue = banner.CategoryID.ToString();
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            if (txtSearch.Text == string.Empty)
                gvBanners.DataSource = BannerManager.GetAll();
            else
                gvBanners.DataSource = BannerManager.GetAll().Where(t => t.Name.Contains(txtSearch.Text)).ToList();
            gvBanners.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;

            //txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityFlashGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityMediaGalleryPath("~/Upload/UserUploads/");
            ////   txtDetails.SetSecurityImageBrowserPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityFilesGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityMaxImageSize(102400);
            //txtDetails.SetSecurityMaxFlashSize(102400);
            //txtDetails.SetSecurityMaxDocumentSize(102400);

            //txtDetails.EnableClientScript = true;
        }
        private void FillDDL()
        {
            ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Banner).ToList();
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();

            ddlUrlType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.UrlType));
            ddlUrlType.DataTextField = "Key";
            ddlUrlType.DataValueField = "Value";
            ddlUrlType.DataBind();

            ddlCategories.Items.Insert(0, new ListItem("", ""));
            ddlUrlType.Items.Insert(0, new ListItem("", ""));
            ddlUrlType.SelectedValue = Convert.ToInt32(RootEnums.UrlType.Internal).ToString();
        }
        #endregion
    }
}