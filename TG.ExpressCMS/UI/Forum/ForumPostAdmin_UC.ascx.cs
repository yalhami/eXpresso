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

namespace TG.ExpressCMS.UI.ForumPost
{
    public partial class ForumPostAdmin_UC : System.Web.UI.UserControl
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
                if (forumID == 0)
                    return -1;

                return forumID;
            }
        }
        private int SelectedSearchThreadID
        {
            get
            {
                int threadID = 0;
                int.TryParse(ddlSearchThread.SelectedValue, out threadID);
                if (threadID == 0)
                    return -1;

                return threadID;
            }
        }
        private int SelectedSearchPostID
        {
            get
            {
                int postID = 0;
                int.TryParse(ddlSearchParentPost.SelectedValue, out postID);
                if (postID == 0)
                    return -1;

                return postID;
            }
        }
        private int SelectedSearchUserID
        {
            get
            {
                int userID = 0;
                int.TryParse(ddlSearchUser.SelectedValue, out userID);
                if (userID == 0)
                    return -1;

                return userID;
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
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnApproved.Click += new ImageClickEventHandler(ibtnApproved_Click);
            this.ibtnDisApproved.Click += new ImageClickEventHandler(ibtnDisApproved_Click);
            this.gvForumPost.RowCommand += new GridViewCommandEventHandler(gvForumPost_RowCommand);
            this.gvForumPost.PageIndexChanging += new GridViewPageEventHandler(gvForumPost_PageIndexChanging);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region ibtnDisApproved_Click
        void ibtnDisApproved_Click(object sender, ImageClickEventArgs e)
        {
            string postIds = string.Empty;
            for (int i = 0; i < gvForumPost.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumPost.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumPost.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumPostManager.UpdateStatus(_id, RootEnums.ForumPostStatus.InActive);

                if (i > 0)
                    postIds += ";" + _id;
                else
                    postIds = _id.ToString();
            }

            if (!string.IsNullOrEmpty(postIds))
                ScriptManager.RegisterStartupScript(upnlGrid, upnlGrid.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumAndThreadForPosts('" + postIds + "');", true);

            gvForumPost.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnApproved_Click
        void ibtnApproved_Click(object sender, ImageClickEventArgs e)
        {
            string postIds = string.Empty;
            for (int i = 0; i < gvForumPost.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumPost.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumPost.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumPostManager.UpdateStatus(_id, RootEnums.ForumPostStatus.Active);

                if (i > 0)
                    postIds += ";" + _id;
                else
                    postIds = _id.ToString();
            }

            if (!string.IsNullOrEmpty(postIds))
                ScriptManager.RegisterStartupScript(upnlGrid, upnlGrid.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumAndThreadForPosts('" + postIds + "');", true);

            gvForumPost.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnSearch_Click
        void btnSearch_Click(object sender, EventArgs e)
        {
            gvForumPost.PageIndex = 0;
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
                DataLayer.Entities.ForumPost forumPost = ForumPostManager.GetByID(ObjectID);
                if (forumPost != null)
                {
                    forumPost.Name = txtName.Text;
                    forumPost.DetailsHtml = txtDetails.Text;
                    forumPost.DetailsText = txtDetails.Text;
                    forumPost.Status = (RootEnums.ForumPostStatus)Convert.ToInt32(ddlStatus.SelectedValue);
                    ForumPostManager.Update(forumPost);

                    dvProblems.InnerText = "Updated Successfully";

                    ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumAndThreadNumbers('" + forumPost.ForumID + "','" + forumPost.ForumThreadID + "');", true);

                    gvForumPost.PageIndex = 0;
                    BeginSearchMode();
                    BindGrid();
                    upnlSearch.Update();
                    upnlGrid.Update();
                }
            }
        }
        #endregion

        #region gvForumPost_PageIndexChanging
        void gvForumPost_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvForumPost.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvForumPost_RowCommand
        void gvForumPost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditForumPost":
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

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            string postIds = string.Empty;
            for (int i = 0; i < gvForumPost.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumPost.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumPost.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumPostManager.DeleteLogical(_id);

                if (i > 0)
                    postIds += ";" + _id;
                else
                    postIds = _id.ToString();
            }
            if (!string.IsNullOrEmpty(postIds))
                ScriptManager.RegisterStartupScript(upnlGrid, upnlGrid.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumAndThreadForPosts('" + postIds + "');", true);

            gvForumPost.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                EditMode();
            }
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

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                DataLayer.Entities.ForumPost forumPost = ForumPostManager.GetByID(ObjectID);
                txtName.Text = forumPost.Name;
                txtDetails.Text = forumPost.DetailsHtml;
                ddlStatus.SelectedValue = ((int)forumPost.Status).ToString();

                DataLayer.Entities.Forum forum = ForumManager.GetByID(forumPost.ForumID);
                if (forum != null)
                    lblForumValue.Text = forum.Name;
                else
                    lblForumValue.Text = string.Empty;

                DataLayer.Entities.ForumThread forumThread = ForumThreadManager.GetByID(forumPost.ForumThreadID);
                if (forumThread != null)
                    lblThreadValue.Text = forumThread.Name;
                else
                    lblThreadValue.Text = string.Empty;

                if (forumPost.ParentPostID > 0)
                {
                    DataLayer.Entities.ForumPost forumParentPost = ForumPostManager.GetByID(forumPost.ParentPostID);
                    if (forumParentPost != null)
                        lblParentPostValue.Text = forumParentPost.Name;
                    else
                        lblParentPostValue.Text = string.Empty;
                }
                else
                    lblParentPostValue.Text = string.Empty;

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
            gvForumPost.DataSource = ForumPostManager.GetBySearch(txtSearch.Text, SelectedSearchForumID, SelectedSearchThreadID, SelectedSearchPostID, SelectedSearchUserID, (RootEnums.ForumPostStatus)SelectedSearchStatus);
            gvForumPost.DataBind();
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
            ddlStatus.DataSource = ddlSearchStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.ForumPostStatus));
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
            ddlSearchThread.SelectedIndex = -1;
            ddlSearchParentPost.SelectedIndex = -1;
            ddlSearchStatus.SelectedIndex = -1;
        }
        #endregion

        #region GetPostStatus
        public string GetPostStatus(int PostStatus)
        {
            string StatusCode = string.Empty;
            try
            {
                StatusCode = Resources.ExpressCMS.ResourceManager.GetString(((RootEnums.ForumPostStatus)PostStatus).ToString());
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