using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Entities;
using System.Web.UI.HtmlControls;

namespace TG.ExpressCMS.UI
{
    public partial class HtmlAdmin_UC : System.Web.UI.UserControl
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
            this.gvHtml.SelectedIndexChanged += new EventHandler(gvXsl_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(XslAdd_UC_Load);
            this.gvHtml.RowCommand += new GridViewCommandEventHandler(gvXsl_RowCommand);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            this.gvHtml.PageIndexChanging += new GridViewPageEventHandler(gvHtml_PageIndexChanging);
            this.btnShowall.Click += new EventHandler(btnShowall_Click);
        }

        void btnShowall_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            gvHtml.DataSource = HtmlItemManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.HtmlBlockType.HTML).ToList();
            gvHtml.DataBind();
        }

        void gvHtml_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHtml.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void gvXsl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditHtml")
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
        void XslAdd_UC_Load(object sender, EventArgs e)
        {
            SetEditorPaths();
            if (!IsPostBack)
            {
                BindGrid();
                AddMode();
                plcControls.Visible = false;
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvHtml.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvHtml.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvHtml.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                HtmlItemManager.Delete(_id);

            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            HtmlItem html = new HtmlItem();
            if (ObjectID <= 0)
            {
                try
                {
                    html.IsDeleted = false;
                    html.Name = txtName.Text;
                    html.Details = (txtDetails.Text);
                    html.Hash = txtHash.Text;
                    html.Type = DataLayer.Enums.RootEnums.HtmlBlockType.HTML;
                    html.Status = DataLayer.Enums.RootEnums.HtmlBlockStatus.Visible;
                    html.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    HtmlItemManager.Add(html);
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
                    html = HtmlItemManager.GetByID(ObjectID);
                    if (null == html)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    html.IsDeleted = false;
                    html.Name = txtName.Text;
                    html.Details = (txtDetails.Text);
                    html.Hash = txtHash.Text;
                    html.Type = DataLayer.Enums.RootEnums.HtmlBlockType.HTML;
                    html.Status = DataLayer.Enums.RootEnums.HtmlBlockStatus.Visible;
                    html.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    HtmlItemManager.Update(html);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
        }

        void gvXsl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvHtml.SelectedDataKey.Value);
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
            txtDetails.Text = "";
            txtHash.Text = "";
            txtName.Text = "";
            dvProblems.InnerText = "";
            ObjectID = 0;
        }

        private void EditMode()
        {
            if (ObjectID > 0)
            {
                HtmlItem cat = new HtmlItem();
                cat = HtmlItemManager.GetByID(ObjectID);
                if (null == cat)
                    return;

                txtName.Text = cat.Name;
                txtHash.Text = cat.Hash;
                txtDetails.Text = cat.Details;

                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            if (txtSearch.Text == string.Empty)
                gvHtml.DataSource = HtmlItemManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.HtmlBlockType.HTML).ToList();
            else
                gvHtml.DataSource = HtmlItemManager.Search(txtSearch.Text).Where(t => t.Type == DataLayer.Enums.RootEnums.HtmlBlockType.HTML).ToList();
            gvHtml.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void SetEditorPaths()
        {
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
        #endregion

    }
}