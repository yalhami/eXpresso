using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Enums;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using System.Configuration;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.ForumThread
{
    public partial class ForumThreadAdmin_UC : System.Web.UI.UserControl
    {
        #region Global
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
        private int SelectedSearchForumID
        {
            get
            {
                int forumID = 0;
                int.TryParse(ddlSearchForum.SelectedValue, out forumID);

                return forumID;
            }
        }
        private int SelectedSearchStatus
        {
            get
            {
                int status = 0;
                int.TryParse(ddlSearchStatus.SelectedValue, out status);

                return status;
            }
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ForumAdmin_UC_Load);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnApproved.Click += new ImageClickEventHandler(ibtnApproved_Click);
            this.ibtnDisApproved.Click += new ImageClickEventHandler(ibtnDisApproved_Click);
            this.gvForumThread.RowCommand += new GridViewCommandEventHandler(gvForum_RowCommand);
            this.gvForumThread.PageIndexChanging += new GridViewPageEventHandler(gvForum_PageIndexChanging);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region ibtnDisApproved_Click
        void ibtnDisApproved_Click(object sender, ImageClickEventArgs e)
        {
            string threadIds = string.Empty;
            for (int i = 0; i < gvForumThread.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumThread.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumThread.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumThreadManager.UpdateStatus(_id, RootEnums.ForumThreadStatus.InActive);

                if (i > 0)
                    threadIds += ";" + _id;
                else
                    threadIds = _id.ToString();
            }

            if (!string.IsNullOrEmpty(threadIds))
                ScriptManager.RegisterStartupScript(upnlGrid, upnlGrid.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumForThreads('" + threadIds + "');", true);

            gvForumThread.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnApproved_Click
        void ibtnApproved_Click(object sender, ImageClickEventArgs e)
        {
            string threadIds = string.Empty;
            for (int i = 0; i < gvForumThread.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumThread.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumThread.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumThreadManager.UpdateStatus(_id, RootEnums.ForumThreadStatus.Active);

                if (i > 0)
                    threadIds += ";" + _id;
                else
                    threadIds = _id.ToString();
            }

            if (!string.IsNullOrEmpty(threadIds))
                ScriptManager.RegisterStartupScript(upnlGrid, upnlGrid.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumForThreads('" + threadIds + "');", true);

            gvForumThread.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnSearch_Click
        void btnSearch_Click(object sender, EventArgs e)
        {
            gvForumThread.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
            upnlGrid.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                DataLayer.Entities.ForumThread forumThread = ForumThreadManager.GetByID(ObjectID);
                if (forumThread != null)
                {
                    forumThread.Name = txtName.Text;
                    forumThread.DetailsHtml = txtDetails.Text;
                    forumThread.DetailsText = txtDetails.Text;
                    forumThread.ForumID = Convert.ToInt32(ddlForum.SelectedValue);
                    forumThread.Status = (RootEnums.ForumThreadStatus)Convert.ToInt32(ddlStatus.SelectedValue);
                    ForumThreadManager.Update(forumThread);

                    ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumForThreads('" + forumThread.ID + "');", true);

                    dvProblems.InnerText = "Updated Successfully";

                    gvForumThread.PageIndex = 0;
                    BeginSearchMode();
                    BindGrid();
                    upnlSearch.Update();
                    upnlGrid.Update();
                }
            }
        }
        #endregion

        #region gvForum_PageIndexChanging
        void gvForum_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvForumThread.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvForum_RowCommand
        void gvForum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditForumThread":
                    ObjectID = Convert.ToInt32(e.CommandArgument);
                    EditMode();
                    upnlControls.Update();
                    break;
            }
        }
        #endregion

        #region ForumAdmin_UC_Load
        void ForumAdmin_UC_Load(object sender, EventArgs e)
        {
            dvProblems.InnerText = string.Empty;
            if (!IsPostBack)
            {
                FillDDL();
                BeginSearchMode();
                ExitMode();
            }
            ScriptManager CurrentScriptManager = ScriptManager.GetCurrent(this.Page);
            CurrentScriptManager.Services.Add(new ServiceReference("~/Services/ForumService.asmx"));
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            string threadIds = string.Empty;
            for (int i = 0; i < gvForumThread.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumThread.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumThread.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumThreadManager.DeleteLogical(_id);

                if (i > 0)
                    threadIds += ";" + _id;
                else
                    threadIds = _id.ToString();
            }

            if (!string.IsNullOrEmpty(threadIds))
                ScriptManager.RegisterStartupScript(upnlGrid, upnlGrid.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumForThreads('" + threadIds + "');", true);

            gvForumThread.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.Entities.ForumThread forumThread = new DataLayer.Entities.ForumThread();
                forumThread.CreatedBy = SecurityContext.LoggedInUser.ID;
                forumThread.CreationDate = DateTime.Now;
                forumThread.DetailsHtml = txtDetails.Text;
                forumThread.DetailsText = txtDetails.Text;
                forumThread.ForumID = Convert.ToInt32(ddlForum.SelectedValue);
                forumThread.IsDeleted = false;
                forumThread.LastPostID = 0;
                forumThread.Name = txtName.Text;
                forumThread.NumberThreadViews = 0;
                forumThread.Status = (RootEnums.ForumThreadStatus)Convert.ToInt32(ddlStatus.SelectedValue);
                forumThread.TotalPosts = 0;

                ForumThreadManager.Add(forumThread);

                ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumForThreads('" + forumThread.ID + "');", true);

                dvProblems.InnerText = "Saved Successfully";
                AddMode();
                gvForumThread.PageIndex = 0;
                BeginSearchMode();
                BindGrid();
                upnlSearch.Update();
            }
            catch (Exception ex)
            {
                dvProblems.InnerText = ex.ToString();
            }
            upnlGrid.Update();
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                EditMode();
            }
            else
                AddMode();
        }
        #endregion

        #region btnExit_Click
        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }
        #endregion

        #endregion

        #region Methods

        #region AddMode
        private void AddMode()
        {
            plcControls.Visible = true;
            txtName.Text = string.Empty;
            txtDetails.Text = string.Empty;
            ddlForum.SelectedIndex = -1;
            ddlStatus.SelectedIndex = -1;

            ddlForum.Enabled = true;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                DataLayer.Entities.ForumThread forumThread = ForumThreadManager.GetByID(ObjectID);
                txtName.Text = forumThread.Name;
                txtDetails.Text = forumThread.DetailsHtml;
                ddlForum.SelectedValue = forumThread.ForumID.ToString();
                ddlStatus.SelectedValue = ((int)forumThread.Status).ToString();

                ddlForum.Enabled = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                plcControls.Visible = true;
            }
        }
        #endregion

        #region ExitMode
        private void ExitMode()
        {
            ObjectID = 0;
            plcControls.Visible = false;
        }
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            gvForumThread.DataSource = ForumThreadManager.GetBySearch(txtSearch.Text, SelectedSearchForumID, (RootEnums.ForumThreadStatus)SelectedSearchStatus);
            gvForumThread.DataBind();
        }
        #endregion

        #region PerformSettings
        private void PerformSettings()
        {

        }
        #endregion

        #region FillDDL
        void FillDDL()
        {
            List<DataLayer.Entities.Forum> forums = ForumManager.GetAll();
            ddlForum.DataSource = ddlSearchForum.DataSource = forums;
            ddlForum.DataTextField = ddlSearchForum.DataTextField = "Name";
            ddlForum.DataValueField = ddlSearchForum.DataValueField = "ID";
            ddlForum.DataBind();
            ddlSearchForum.DataBind();
            ddlSearchForum.Items.Insert(0, new ListItem("", "-1"));

            ddlStatus.DataSource = ddlSearchStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.ForumThreadStatus));
            ddlStatus.DataTextField = ddlSearchStatus.DataTextField = "Key";
            ddlStatus.DataValueField = ddlSearchStatus.DataValueField = "Value";
            ddlStatus.DataBind();
            ddlSearchStatus.DataBind();
            ddlSearchStatus.Items.Insert(0, new ListItem("", "-1"));
        }
        #endregion

        #region BeginSearchMode
        void BeginSearchMode()
        {
            txtSearch.Text = string.Empty;
            ddlSearchForum.SelectedIndex = -1;
            ddlSearchStatus.SelectedIndex = -1;
        }
        #endregion

        #region GetThreadStatus
        public string GetThreadStatus(int ThreadStatus)
        {
            string StatusCode = string.Empty;
            try
            {
                StatusCode = Resources.ExpressCMS.ResourceManager.GetString(((RootEnums.ForumThreadStatus)ThreadStatus).ToString());
            }
            catch
            {
                StatusCode = string.Empty;
            }
            return StatusCode;
        }
        #endregion

        #endregion
    }
}