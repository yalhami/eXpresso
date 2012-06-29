using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.DataLayer.Enums;
using System.Configuration;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

using System.IO;
using TG.ExpressCMS.Configuration;
using System.Globalization;

namespace TG.ExpressCMS.UI.News
{
    public partial class NewsAdmin_UC : System.Web.UI.UserControl
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
            this.gvNews.SelectedIndexChanged += new EventHandler(gvNews_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(newsItemsAdd_UC_Load);
            this.gvNews.RowCommand += new GridViewCommandEventHandler(gvNews_RowCommand);
            this.ddlNewsType.SelectedIndexChanged += new EventHandler(ddlNewsType_SelectedIndexChanged);
            this.gvNews.PageIndexChanging += new GridViewPageEventHandler(gvNews_PageIndexChanging);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.ibtntoExcel.Click += new ImageClickEventHandler(ibtntoExcel_Click);
            this.rdblater.CheckedChanged += new EventHandler(rdblater_CheckedChanged);
            this.rdbNow.CheckedChanged += new EventHandler(rdbNow_CheckedChanged);
            this.rdbUnpublish.CheckedChanged += new EventHandler(rdbUnpublish_CheckedChanged);
            this.ibtnPublish.Click += new ImageClickEventHandler(ibtnPublish_Click);
            this.btnGenerateKeywords.Click += new EventHandler(btnGenerateKeywords_Click);

        }

        void btnGenerateKeywords_Click(object sender, EventArgs e)
        {
            string[] keywords = txtName.Text.Split(' ');
            chklstkeywrds.DataSource = keywords;
            chklstkeywrds.DataBind();
        }

        void ibtnPublish_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvNews.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvNews.Rows[i].FindControl("chkItemUnique");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvNews.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                NewsItem _news = NewsItemManager.GetByID(_id);
                if (_news == null)
                    continue;

                _news.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                _news.PublishTo = new DateTime(1992, 1, 1).ToString("dd/MM/yyyy");

                NewsItemManager.Update(_news);
            }
            BindGrid(10);
            AddMode();

            plcControls.Visible = false;
            upnlGrid.Update();
            upnlControls.Update();
        }

        void rdbUnpublish_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUnpublish.Checked)
            {
                trDatesFrom.Visible = false;
                trDatesto.Visible = false;
            }
            else
            {
                trDatesFrom.Visible = true;
                trDatesto.Visible = true;
            }
        }

        void rdbNow_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNow.Checked)
            {
                trDatesFrom.Visible = false;
                trDatesto.Visible = false;
            }
            else
            {
                trDatesFrom.Visible = true;
                trDatesto.Visible = true;
            }
        }

        void rdblater_CheckedChanged(object sender, EventArgs e)
        {
            if (rdblater.Checked)
            {
                trDatesFrom.Visible = true;
                trDatesto.Visible = true;
            }
            else
            {
                trDatesFrom.Visible = false;
                trDatesto.Visible = false;
            }
        }


        void ibtntoExcel_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid(10000);
            UtilitiesManager.GenerateExcelFiles("News", gvNews);
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(10);
            upnlGrid.Update();
            AddMode();
            plcControls.Visible = false;
            upnlControls.Update();
        }

        void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            BindGrid(10);
        }

        void ddlNewsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result = 0;
            Int32.TryParse(ddlNewsType.SelectedValue, out result);
            if (result > 0)
            {
                if ((TG.ExpressCMS.DataLayer.Enums.RootEnums.NewsItemURLType)(result) != RootEnums.NewsItemURLType.External)
                {

                    trdetails.Visible = true;

                    rfvURL.Enabled = false;
                }
                else
                {

                    trdetails.Visible = false;
                    trURL.Visible = true;
                    rfvURL.Enabled = true;
                }
            }
        }

        void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditnewsItems")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
                upnlControls.Update();
            }
            if (e.CommandName == "ibtnIsFeatured")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                NewsItem _news = NewsItemManager.GetByID(ObjectID);
                if (null == _news)
                    return;
                ImageButton ibtn = (ImageButton)e.CommandSource;

                if (_news.IsFeatured)
                {
                    _news.IsFeatured = false;
                    ibtn.ImageUrl = "~/App_themes/AdminSide/images/startw.gif";
                }
                else
                {
                    _news.IsFeatured = true;
                    ibtn.ImageUrl = "~/App_themes/AdminSide/images/starfilled.png";
                }
                NewsItemManager.Update(_news);
            }
            if (e.CommandName == "pub")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                ImageButton ibtn = (ImageButton)e.CommandSource;
                NewsItem _news = NewsItemManager.GetByID(ObjectID);
                if (null == _news)
                    return;
                if (ibtn.ToolTip == "Unpublish")
                {
                    _news.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                    _news.PublishTo = new DateTime(1994, 1, 1).ToString("dd/MM/yyyy");
                    ibtn.ImageUrl = GetImageUrl(_news.PublishFrom, _news.PublishTo);
                    ibtn.ToolTip = GetToolTip(_news.PublishFrom, _news.PublishTo);
                }
                else
                {
                    _news.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                    _news.PublishTo = new DateTime(2025, 1, 1).ToString("dd/MM/yyyy");
                    ibtn.ImageUrl = GetImageUrl(_news.PublishFrom, _news.PublishTo);
                    ibtn.ToolTip = GetToolTip(_news.PublishFrom, _news.PublishTo);
                }
                NewsItemManager.Update(_news);
            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void newsItemsAdd_UC_Load(object sender, EventArgs e)
        {
            SetEditorPaths();
            if (!IsPostBack)
            {
                //  BindGrid();
                FillDDL();
                ExitMode();

            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControls.Update();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvNews.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvNews.Rows[i].FindControl("chkItemUnique");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvNews.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                NewsItemManager.Delete(_id);

            }
            BindGrid(10);
            AddMode();

            plcControls.Visible = false;
            upnlGrid.Update();
            upnlControls.Update();
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            NewsItem newsItems = new NewsItem();
            int ordernumber = 0;
            Int32.TryParse(txtOrderNumber.Text, out ordernumber);
            if (ObjectID <= 0)
            {
                try
                {
                    newsItems.Name = txtName.Text.Replace(":", "").Replace("=", "");
                    newsItems.Description = txtDesc.Text;
                    newsItems.IsFeatured = chkIsFeatured.Checked;
                    newsItems.Details = txtDetails.Text;
                    newsItems.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                    newsItems.Url = "";
                    newsItems.LangID = 0;
                    newsItems.CreationDate = UtilitiesManager.GetFormattedDate();
                    newsItems.Date = UtilitiesManager.GetFormattedDate(dtDate.SelectedDate.Value);
                    newsItems.CreationTime = UtilitiesManager.GetFormattedTime();
                    newsItems.CreatedBy = SecurityContext.LoggedInUser.ID;
                    newsItems.IsDeleted = false;
                    newsItems.OrderNumber = ordernumber;

                    int mappedlangID = 0;
                    Int32.TryParse(ddlMappedLanguageID.SelectedValue, out mappedlangID);
                    newsItems.RefLangID = mappedlangID;
                    string guid = Guid.NewGuid().ToString().Replace("-", "");
                    newsItems.Guid = guid.Substring(0, 8);
                    newsItems.Image = UtilitiesManager.GetSavedFile(fUploader, true, true);
                    newsItems.URlType = (TG.ExpressCMS.DataLayer.Enums.RootEnums.NewsItemURLType)Convert.ToInt32(ddlNewsType.SelectedValue);
                    if (rdblater.Checked)
                    {
                        newsItems.PublishFrom = UtilitiesManager.GetFormattedDate(txtPublishFrom.SelectedDate.Value);
                        newsItems.PublishTo = UtilitiesManager.GetFormattedDate(txtDateTo.SelectedDate.Value);
                    }
                    else
                        if (rdbNow.Checked)
                        {
                            newsItems.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                            newsItems.PublishTo = new DateTime(1992, 1, 1).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            newsItems.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                            newsItems.PublishTo = new DateTime(1994, 1, 1).ToString("dd/MM/yyyy");
                        }
                    newsItems.ShowComments = chkShowComments.Checked;
                    if (newsItems.URlType == RootEnums.NewsItemURLType.External)
                        newsItems.Url = txtURL.Text;

                    string keywords = "";

                    for (int i = 0; i < chklstkeywrds.Items.Count; i++)
                    {
                        if (chklstkeywrds.Items[i].Selected)
                            keywords += chklstkeywrds.Items[i].Text;
                    }
                    newsItems.Keywords = keywords.Replace("ال", "").Replace(".", "");

                    NewsItemManager.Add(newsItems);
                    if (newsItems.URlType == RootEnums.NewsItemURLType.Internal)
                    {
                        newsItems.Url = ResolveUrl(ExpressoConfig.NewsConfigElement.GetDefaultDetailsPage) + ConstantsManager.NewsID + "=" + newsItems.ID;
                        NewsItemManager.Update(newsItems);
                    }
                    AddMode();
                    dvProblems.InnerText = "Saved Successfully";
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
                    newsItems = NewsItemManager.GetByID(ObjectID);
                    if (null == newsItems)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    newsItems.Name = txtName.Text;
                    newsItems.Description = txtDesc.Text;
                    newsItems.Details = txtDetails.Text;
                    newsItems.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                    newsItems.IsFeatured = chkIsFeatured.Checked;
                    newsItems.Guid = newsItems.Guid;
                    newsItems.OrderNumber = ordernumber;
                    newsItems.IsDeleted = false;

                    int mappedlangID = 0;
                    Int32.TryParse(ddlMappedLanguageID.SelectedValue, out mappedlangID);
                    newsItems.RefLangID = mappedlangID;

                    if (chkUpdateImage.Checked)
                        newsItems.Image = UtilitiesManager.GetSavedFile(fUploader, true, true);
                    newsItems.URlType = (TG.ExpressCMS.DataLayer.Enums.RootEnums.NewsItemURLType)Convert.ToInt32(ddlNewsType.SelectedValue);
                    if (rdblater.Checked)
                    {
                        newsItems.PublishFrom = UtilitiesManager.GetFormattedDate(txtPublishFrom.SelectedDate.Value);
                        newsItems.PublishTo = UtilitiesManager.GetFormattedDate(txtDateTo.SelectedDate.Value);
                    }
                    else
                        if (rdbNow.Checked)
                        {
                            newsItems.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                            newsItems.PublishTo = new DateTime(1992, 1, 1).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            newsItems.PublishFrom = new DateTime(1993, 1, 1).ToString("dd/MM/yyyy");
                            newsItems.PublishTo = new DateTime(1994, 1, 1).ToString("dd/MM/yyyy");
                        }
                    newsItems.Date = UtilitiesManager.GetFormattedDate(dtDate.SelectedDate.Value);
                    newsItems.ShowComments = chkShowComments.Checked;
                    if (newsItems.URlType == RootEnums.NewsItemURLType.Internal)
                    {
                        newsItems.Url = ResolveUrl(ExpressoConfig.NewsConfigElement.GetDefaultDetailsPage) + ConstantsManager.NewsID + "=" + newsItems.ID;
                    }
                    else
                        newsItems.Url = txtURL.Text;

                    string keywords = "";

                    for (int i = 0; i < chklstkeywrds.Items.Count; i++)
                    {
                        if (chklstkeywrds.Items[i].Selected)
                            keywords += chklstkeywrds.Items[i].Text;
                    }
                    newsItems.Keywords = keywords.Replace("ال", "").Replace(".", "");

                    NewsItemManager.Update(newsItems);
                    EditMode();
                    dvProblems.InnerText = "Saved Successfully";
                    upnlGrid.Update();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid(10);
            //RSSUpdater updater = new RSSUpdater();
            //updater.UpdateCategoryFile(newsItems.CategoryID);
        }

        void gvNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvNews.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                EditMode();

            }
            else
                AddMode();
            upnlControls.Update();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            chkIsFeatured.Checked = false;
            imguploaded.ImageUrl = GetArticleImage("");
            plcControls.Visible = true;
            txtURL.Text = "";

            txtName.Text = "";
            dtDate.Clear();
            chkUpdateImage.Visible = false;
            txtDetails.Text = "";
            txtDesc.Text = "";
            txtOrderNumber.Text = "0";
            ddlMappedLanguageID.SelectedIndex = -1;
            rfvURL.Enabled = false;
            txtURL.Text = "";
            trURL.Visible = true;
            dvProblems.InnerText = "";
            dvProblems.Style.Add(HtmlTextWriterStyle.Display, "none");
            txtDateTo.Clear();
            txtPublishFrom.Clear();
            trdetails.Visible = true;
            chkShowComments.Checked = false;
            ddlCategories.SelectedIndex = -1;
            rdblater.Checked = false;
            rdbNow.Checked = true;
            rdbUnpublish.Checked = false;
            trDatesFrom.Visible = false;
            trDatesto.Visible = false;
            chklstkeywrds.DataSource = "";
            chklstkeywrds.DataBind();
            ddlNewsType.SelectedValue = Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.NewsItemURLType.Internal).ToString();
            dtDate.DbSelectedDate = UtilitiesManager.GetFormattedDate(DateTime.Now);
            upnlGrid.Update();
            ObjectID = 0; 
        }
        private void SetEditorPaths()
        {
            txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityFlashGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityMediaGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityImageBrowserPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityFilesGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityMaxImageSize(102400);
            txtDetails.SetSecurityMaxFlashSize(102400);
            txtDetails.SetSecurityMaxDocumentSize(102400);

            txtDetails.EnableClientScript = true;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                imguploaded.Visible = true;

                chkUpdateImage.Checked = false;
                NewsItem newsItems = new NewsItem();
                newsItems = NewsItemManager.GetByID(ObjectID);
                if (null == newsItems)
                    return;
                chkIsFeatured.Checked = newsItems.IsFeatured;
                txtOrderNumber.Text = newsItems.OrderNumber.ToString();
                txtPublishFrom.DbSelectedDate = newsItems.PublishFrom;
                if (newsItems.RefLangID != 0)
                    ddlMappedLanguageID.SelectedValue = newsItems.RefLangID.ToString();
                txtDateTo.DbSelectedDate = newsItems.PublishTo;
                txtDesc.Text = newsItems.Description;
                txtDetails.Text = newsItems.Details;
                txtName.Text = newsItems.Name;
                chkUpdateImage.Visible = true;
                dtDate.DbSelectedDate = newsItems.Date;
                txtURL.Text = newsItems.Url;
                chkShowComments.Checked = newsItems.ShowComments;
                ddlNewsType.SelectedValue = Convert.ToInt32(newsItems.URlType).ToString();
                ddlCategories.SelectedValue = newsItems.CategoryID.ToString();
                plcControls.Visible = true;
                if (newsItems.URlType == RootEnums.NewsItemURLType.External)
                {
                    rfvURL.Enabled = true;
                    trdetails.Visible = false;
                }
                else
                {
                    rfvURL.Enabled = false;
                    trdetails.Visible = true;
                }
                if (UtilitiesManager.GetFormattedDateasDate(newsItems.PublishTo) < UtilitiesManager.GetFormattedDateasDate(newsItems.PublishFrom))
                {
                    trDatesto.Visible = false;
                    trDatesFrom.Visible = false;
                    rdbNow.Checked = true;
                    rdblater.Checked = false;
                    rdbUnpublish.Checked = false;
                }
                else
                    if (UtilitiesManager.GetFormattedDateasDate(newsItems.PublishTo) > UtilitiesManager.GetFormattedDateasDate(newsItems.PublishFrom) && UtilitiesManager.GetFormattedDateasDate(newsItems.PublishTo) <= UtilitiesManager.GetFormattedDateasDate(DateTime.Now.ToShortDateString()))
                    {
                        rdbUnpublish.Checked = true;
                        trDatesto.Visible = false;
                        trDatesFrom.Visible = false;
                        rdbNow.Checked = true;
                        rdblater.Checked = false;
                    }
                    else
                    {
                        rdbUnpublish.Checked = false;
                        trDatesto.Visible = true;
                        trDatesFrom.Visible = true;
                        rdbNow.Checked = false;
                        rdblater.Checked = true;
                    }

                imguploaded.ImageUrl = GetArticleImage(newsItems.Image);


                chklstkeywrds.DataSource = "";
                chklstkeywrds.DataBind();

                trURL.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid(int pageSize)
        {
            int temp = 0;
            gvNews.PageSize = pageSize;
            gvNews.DataSource = NewsItemManager.GetAllBySearchAndPagingandDate(0, 10000, ref temp, "%" + txtSearch.Text + "%", UtilitiesManager.GetFormattedDate(dtSearch.SelectedDate.GetValueOrDefault(new DateTime(1990, 1, 1))), ddlSearchCategories.SelectedValue, ExpressoConfig.NewsConfigElement.OrderNewsBy);
            gvNews.DataBind();

        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void FillDDL()
        {
            ddlNewsType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.NewsItemURLType));
            ddlNewsType.DataTextField = "Key";
            ddlNewsType.DataValueField = "Value";
            ddlNewsType.DataBind();

            ddlSearchCategories.DataSource = ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.News || t.Type == RootEnums.CategoryType.IslamicStudies).ToList();
            ddlSearchCategories.DataTextField = ddlCategories.DataTextField = "Name";
            ddlSearchCategories.DataValueField = ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlSearchCategories.DataBind();

            ddlMappedLanguageID.DataSource = NewsItemManager.GetAllofLng();
            ddlMappedLanguageID.DataTextField = "Name";
            ddlMappedLanguageID.DataValueField = "ID";
            ddlMappedLanguageID.DataBind();


            ddlCategories.Items.Insert(0, new ListItem("", ""));
            ddlSearchCategories.Items.Insert(0, new ListItem("", ""));
            ddlNewsType.Items.Insert(0, new ListItem("", ""));
            ddlMappedLanguageID.Items.Insert(0, new ListItem("", ""));
        }
        protected string GetCategory(string id)
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
        protected string GetImageUrl(string from, string to)
        {
            if (to == "")
                return ResolveUrl("~/App_themes/AdminSide/Images/4.png");

            DateTime dtfrom = DateTime.Now;
            DateTime dtto = DateTime.Now;

            dtfrom = UtilitiesManager.GetFormattedDateasDate(from);
            dtto = UtilitiesManager.GetFormattedDateasDate(to);
            if (dtfrom > dtto)
            {
                return ResolveUrl("~/App_themes/AdminSide/Images/camera_test.png");
            }
            if (dtto > DateTime.Now)
            {
                return ResolveUrl("~/App_themes/AdminSide/Images/camera_test.png");
            }
            else
            {
                return ResolveUrl("~/App_themes/AdminSide/Images/dialog-error.png");
            }
        }
        public string GetArticleImage(string image)
        {
            if (image != string.Empty)
                return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath + image;
            else
                return ResolveUrl("~") + "App_themes/UserSides/images/defImage.png";
        }
        protected string GetToolTip(string from, string to)
        {
            if (to == "")
                return "Unpublish";

            DateTime dtfrom = DateTime.Now;
            DateTime dtto = DateTime.Now;
            dtfrom = UtilitiesManager.GetFormattedDateasDate(from);
            dtto = UtilitiesManager.GetFormattedDateasDate(to);
            if (dtfrom > dtto)
            {
                return "Unpublish";
            }
            if (dtto > DateTime.Now)
            {
                return "Unpublish";
            }
            else
            {
                return "Publish";
            }


        }
        private void ExitMode()
        {
            AddMode();
            plcControls.Visible = false;
            upnlControls.Update();
        }
        protected string GetImageUrl(bool boolean)
        {
            if (!boolean)
                return "~/App_themes/AdminSide/images/startw.gif";
            else
                return "~/App_themes/AdminSide/images/starfilled.png";
        }
        #endregion
    }
}