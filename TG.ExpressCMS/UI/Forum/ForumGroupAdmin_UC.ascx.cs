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
    public partial class ForumGroupAdmin_UC : System.Web.UI.UserControl
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
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            //this.gvForumGroup.SelectedIndexChanged += new EventHandler(gvForumGroup_SelectedIndexChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.Load += new EventHandler(ForumGroupAdmin_UC_Load);
            this.gvForumGroup.RowCommand += new GridViewCommandEventHandler(gvForumGroup_RowCommand);
            this.gvForumGroup.PageIndexChanging += new GridViewPageEventHandler(gvForumGroup_PageIndexChanging);
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                ForumGroup forumGroup = ForumGroupManager.GetByID(ObjectID);
                if (forumGroup != null)
                {
                    forumGroup.Name = txtName.Text;
                    ForumGroupManager.Update(forumGroup);

                    BindGrid();
                    upnlGrid.Update();
                }
            }
        }
        #endregion

        #region gvForumGroup_PageIndexChanging
        void gvForumGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvForumGroup.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvForumGroup_RowCommand
        void gvForumGroup_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditForumGroup")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
                upnlControls.Update();
            }
        }
        #endregion

        #region ForumGroupAdmin_UC_Load
        void ForumGroupAdmin_UC_Load(object sender, EventArgs e)
        {
            dvProblems.InnerText = string.Empty;
            if (!IsPostBack)
            {
                BindGrid();
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
            for (int i = 0; i < gvForumGroup.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumGroup.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumGroup.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumGroupManager.DeleteLogical(_id);
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
                ForumGroup forumGroup = new ForumGroup();
                forumGroup.Name = txtName.Text;
                forumGroup.CreatedBy = SecurityContext.LoggedInUser.ID;
                forumGroup.CreationDate = DateTime.Now;
                forumGroup.IsDeleted = false;
                forumGroup.OrderID = 0;

                ForumGroupManager.Add(forumGroup);

                dvProblems.InnerText = "Saved Successfully";
                AddMode();
                BindGrid();
            }
            catch (Exception ex)
            {
                dvProblems.InnerText = ex.ToString();
            }
            upnlGrid.Update();
        }
        #endregion

        #region gvForumGroup_SelectedIndexChanged
        void gvForumGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ObjectID = Convert.ToInt32(gvForumGroup.SelectedDataKey.Value);
                EditMode();
            }
            catch { }
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
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                ForumGroup forumGroup = ForumGroupManager.GetByID(ObjectID);
                txtName.Text = forumGroup.Name;
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
            gvForumGroup.DataSource = ForumGroupManager.GetAll();
            gvForumGroup.DataBind();
        }
        #endregion

        #region PerformSettings
        private void PerformSettings()
        {

        }
        #endregion

        #endregion
    }
}