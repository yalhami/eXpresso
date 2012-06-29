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

namespace TG.ExpressCMS.UI.Forum
{
    public partial class ForumAdmin_UC : System.Web.UI.UserControl
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
        private int SelectedSearchGroupID
        {
            get
            {
                int forumGroupID = 0;
                int.TryParse(ddlSearchGroup.SelectedValue, out forumGroupID);

                return forumGroupID;
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
            this.gvForum.RowCommand += new GridViewCommandEventHandler(gvForum_RowCommand);
            this.gvForum.PageIndexChanging += new GridViewPageEventHandler(gvForum_PageIndexChanging);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnActive.Click += new ImageClickEventHandler(ibtnActive_Click);
            this.ibtnInActive.Click += new ImageClickEventHandler(ibtnInActive_Click);
        }
        #endregion

        #region ibtnInActive_Click
        void ibtnInActive_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForum.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForum.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForum.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumManager.UpdateActive(_id, false);
            }
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnActive_Click
        void ibtnActive_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForum.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForum.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForum.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumManager.UpdateActive(_id, true);
            }
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnSearch_Click
        void btnSearch_Click(object sender, EventArgs e)
        {
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
                DataLayer.Entities.Forum forum = ForumManager.GetByID(ObjectID);
                if (forum != null)
                {
                    forum.Name = txtName.Text;
                    forum.DetailsHtml = txtDetails.Text;
                    forum.DetailsText = txtDetails.Text;
                    forum.ForumGroupID = Convert.ToInt32(ddlForumGroup.SelectedValue);
                    forum.IsActive = chkIsActive.Checked;
                    ForumManager.Update(forum);

                    dvProblems.InnerText = "Updated Successfully";

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
            gvForum.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvForum_RowCommand
        void gvForum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditForum":
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
            for (int i = 0; i < gvForum.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForum.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForum.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumManager.DeleteLogical(_id);
            }
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
                DataLayer.Entities.Forum forum = new DataLayer.Entities.Forum();
                forum.CreatedBy = SecurityContext.LoggedInUser.ID;
                forum.CreationDate = DateTime.Now;
                forum.DetailsHtml = txtDetails.Text;
                forum.DetailsText = txtDetails.Text;
                forum.ForumGroupID = Convert.ToInt32(ddlForumGroup.SelectedValue);
                forum.ID = 0;
                forum.IsActive = chkIsActive.Checked;
                forum.IsDeleted = false;
                forum.LastForumPostID = 0;
                forum.LastForumThreadID = 0;
                forum.MostAccessForumThreadID = 0;
                forum.Name = txtName.Text;
                forum.NumberForumViews = 0;
                forum.TotalPosts = 0;
                forum.TotalThreads = 0;

                ForumManager.Add(forum);

                dvProblems.InnerText = "Saved Successfully";
                AddMode();
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
            ddlForumGroup.SelectedIndex = -1;
            chkIsActive.Checked = true;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                DataLayer.Entities.Forum forum = ForumManager.GetByID(ObjectID);
                txtName.Text = forum.Name;
                txtDetails.Text = forum.DetailsHtml;
                ddlForumGroup.SelectedValue = forum.ForumGroupID.ToString();
                chkIsActive.Checked = forum.IsActive;
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
            gvForum.DataSource = ForumManager.GetBySearch(txtSearch.Text, SelectedSearchGroupID);
            gvForum.DataBind();
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
            List<ForumGroup> forumGroups = ForumGroupManager.GetAll();
            ddlForumGroup.DataSource = ddlSearchGroup.DataSource = forumGroups;
            ddlForumGroup.DataTextField = ddlSearchGroup.DataTextField = "Name";
            ddlForumGroup.DataValueField = ddlSearchGroup.DataValueField = "ID";
            ddlForumGroup.DataBind();
            ddlSearchGroup.DataBind();
            ddlSearchGroup.Items.Insert(0, new ListItem("", "-1"));
        }
        #endregion

        #region BeginSearchMode
        void BeginSearchMode()
        {
            txtSearch.Text = string.Empty;
            ddlSearchGroup.SelectedIndex = -1;
        }
        #endregion

        #endregion
    }
}