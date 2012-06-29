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

namespace TG.ExpressCMS.UI.ForumUser
{
    public partial class ForumUserAdmin_UC : System.Web.UI.UserControl
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
        private int SelectedSearchTrusted
        {
            get
            {
                int trusted = 0;
                int.TryParse(ddlSearchTrusted.SelectedValue, out trusted);

                return trusted;
            }
        }
        private int SelectedSearchUserTupe
        {
            get
            {
                int userTupe = 0;
                int.TryParse(ddlSearchUserType.SelectedValue, out userTupe);

                return userTupe;
            }
        }
        private int SelectedSerarchBanned
        {
            get
            {
                int banned = 0;
                int.TryParse(ddlSerarchBanned.SelectedValue, out banned);

                return banned;
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
            this.ibtnBanned.Click += new ImageClickEventHandler(ibtnBanned_Click);
            this.ibtnNotBanned.Click += new ImageClickEventHandler(ibtnNotBanned_Click);
            this.ibtnTrusted.Click += new ImageClickEventHandler(ibtnTrusted_Click);
            this.ibtnNotTrusted.Click += new ImageClickEventHandler(ibtnNotTrusted_Click);
            this.gvForumUser.RowCommand += new GridViewCommandEventHandler(gvForumUser_RowCommand);
            this.gvForumUser.PageIndexChanging += new GridViewPageEventHandler(gvForumUser_PageIndexChanging);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region ibtnNotTrusted_Click
        void ibtnNotTrusted_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForumUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumUser.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumUser.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumUserManager.UpdateTrusted(_id, false);
            }
            gvForumUser.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnTrusted_Click
        void ibtnTrusted_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForumUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumUser.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumUser.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumUserManager.UpdateTrusted(_id, true);
            }
            gvForumUser.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnNotBanned_Click
        void ibtnNotBanned_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForumUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumUser.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumUser.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumUserManager.UpdateBanned(_id, false, DateTime.Now);
            }
            gvForumUser.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnBanned_Click
        void ibtnBanned_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvForumUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumUser.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumUser.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumUserManager.UpdateBanned(_id, true, DateTime.Now);
            }
            gvForumUser.PageIndex = 0;
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnSearch_Click
        void btnSearch_Click(object sender, EventArgs e)
        {
            gvForumUser.PageIndex = 0;
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
                DataLayer.Entities.ForumUser forumUser = ForumUserManager.GetByID(ObjectID);
                if (forumUser != null)
                {
                    try
                    {
                        forumUser.BirthDate = DateTime.ParseExact(txtBirthDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch
                    {
                        forumUser.BirthDate = new DateTime(1980, 1, 1);
                    }
                    forumUser.ForumUserType = (RootEnums.ForumUserType)Convert.ToInt32(ddlUserType.SelectedValue);
                    if (chkChangeImage.Checked)
                        forumUser.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                    if (chkIsBanned.Checked && !forumUser.IsBanned)
                        forumUser.BannedDate = DateTime.Now;
                    forumUser.IsBanned = chkIsBanned.Checked;
                    forumUser.IsTrusted = chkIsTrusted.Checked;
                    forumUser.PostsPerPage = Convert.ToInt32(txtPostsPerPage.Text);
                    forumUser.RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                    forumUser.Signature = txtSignature.Text;
                    forumUser.ThreadsPerPage = Convert.ToInt32(txtThreadsPerPage.Text);
                    forumUser.UserName = txtName.Text;
                    forumUser.UserRateValue = Convert.ToInt32(txtUserRateValue.Text);

                    ForumUserManager.Update(forumUser);

                    dvProblems.InnerText = "Updated Successfully";

                    gvForumUser.PageIndex = 0;
                    BeginSearchMode();
                    BindGrid();
                    upnlSearch.Update();
                    upnlGrid.Update();
                }
            }
        }
        #endregion

        #region gvForumUser_PageIndexChanging
        void gvForumUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvForumUser.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvForumUser_RowCommand
        void gvForumUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditForumUser":
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
            for (int i = 0; i < gvForumUser.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvForumUser.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvForumUser.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ForumUserManager.DeleteLogical(_id);
            }
            gvForumUser.PageIndex = 0;
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
                DataLayer.Entities.ForumUser forumUser = new DataLayer.Entities.ForumUser();

                forumUser.BannedDate = new DateTime(2000, 1, 1);
                try
                {
                    forumUser.BirthDate = DateTime.ParseExact(txtBirthDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    forumUser.BirthDate = new DateTime(1980, 1, 1);
                }
                forumUser.ForumUserType = (RootEnums.ForumUserType)Convert.ToInt32(ddlUserType.SelectedValue);
                forumUser.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                forumUser.IsBanned = chkIsBanned.Checked;
                forumUser.IsDeleted = false;
                forumUser.IsTrusted = chkIsTrusted.Checked;
                forumUser.JoinDate = DateTime.Now;
                forumUser.PostsPerPage = Convert.ToInt32(txtPostsPerPage.Text);
                forumUser.RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                forumUser.Signature = txtSignature.Text;
                forumUser.ThreadsPerPage = Convert.ToInt32(txtThreadsPerPage.Text);
                forumUser.UserID = Convert.ToInt32(ddlSecurityUser.SelectedValue);
                forumUser.UserName = txtName.Text;
                forumUser.UserRateValue = Convert.ToInt32(txtUserRateValue.Text);

                ForumUserManager.Add(forumUser);

                dvProblems.InnerText = "Saved Successfully";
                AddMode();
                gvForumUser.PageIndex = 0;
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
            ddlSecurityUser.SelectedIndex = -1;
            ddlUserType.SelectedIndex = -1;
            ddlRole.SelectedIndex = -1;
            chkIsTrusted.Checked = false;
            chkIsBanned.Checked = false;
            txtPostsPerPage.Text = "5";
            txtThreadsPerPage.Text = "5";
            txtBirthDate.Text = "01/01/1980";
            txtUserRateValue.Text = "0";
            txtSignature.Text = string.Empty;
            chkChangeImage.Visible = false;

            rowSecurityAdd.Visible = true;
            rowSecurityEdit.Visible = false;

            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                DataLayer.Entities.ForumUser forumUser = ForumUserManager.GetByID(ObjectID);
                txtName.Text = forumUser.UserName;
                ddlSecurityUser.SelectedIndex = -1;
                ddlUserType.SelectedValue = ((int)forumUser.ForumUserType).ToString();
                ddlRole.SelectedValue = forumUser.RoleID.ToString();
                chkIsTrusted.Checked = forumUser.IsTrusted;
                chkIsBanned.Checked = forumUser.IsBanned;
                txtPostsPerPage.Text = forumUser.PostsPerPage.ToString();
                txtThreadsPerPage.Text = forumUser.ThreadsPerPage.ToString();
                txtBirthDate.Text = forumUser.BirthDate.ToString("dd/MM/yyyy");
                txtUserRateValue.Text = forumUser.UserRateValue.ToString();
                txtSignature.Text = forumUser.Signature;

                DataLayer.Entities.Users user = DataLayer.Data.UsersManager.GetByID(forumUser.UserID);
                if (user != null)
                {
                    lblSecurityUserID.Text = user.ID.ToString();
                    lblSecurityUserEmailValue.Text = user.Email;
                }
                else
                {
                    lblSecurityUserID.Text = string.Empty;
                    lblSecurityUserEmailValue.Text = string.Empty;
                }

                chkChangeImage.Visible = true;
                chkChangeImage.Checked = false;

                rowSecurityAdd.Visible = false;
                rowSecurityEdit.Visible = true;

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
            gvForumUser.DataSource = ForumUserManager.GetBySearch(txtSearch.Text, (RootEnums.ForumUserTrusted)SelectedSearchTrusted, (RootEnums.ForumUserBanned)SelectedSerarchBanned, (RootEnums.ForumUserType)SelectedSearchUserTupe);
            gvForumUser.DataBind();
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
            ddlUserType.DataSource = ddlSearchUserType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.ForumUserType));
            ddlUserType.DataTextField = ddlSearchUserType.DataTextField = "Key";
            ddlUserType.DataValueField = ddlSearchUserType.DataValueField = "Value";
            ddlUserType.DataBind();
            ddlSearchUserType.DataBind();
            ddlUserType.Items.Insert(0, new ListItem("", ""));
            ddlSearchUserType.Items.Insert(0, new ListItem("", "-1"));

            ddlSearchTrusted.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.ForumUserTrusted));
            ddlSearchTrusted.DataTextField = "Key";
            ddlSearchTrusted.DataValueField = "Value";
            ddlSearchTrusted.DataBind();
            ddlSearchTrusted.Items.Insert(0, new ListItem("", "-1"));

            ddlSerarchBanned.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.ForumUserBanned));
            ddlSerarchBanned.DataTextField = "Key";
            ddlSerarchBanned.DataValueField = "Value";
            ddlSerarchBanned.DataBind();
            ddlSerarchBanned.Items.Insert(0, new ListItem("", "-1"));

            ddlRole.DataSource = DataLayer.Data.RolesManager.GetAll();
            ddlRole.DataTextField = "Name";
            ddlRole.DataValueField = "ID";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("", "0"));
        }
        #endregion

        #region BeginSearchMode
        void BeginSearchMode()
        {
            txtSearch.Text = string.Empty;
            ddlSearchUserType.SelectedIndex = -1;
            ddlSearchTrusted.SelectedIndex = -1;
            ddlSerarchBanned.SelectedIndex = -1;
        }
        #endregion

        #region GetUserType
        public string GetUserType(int UserType)
        {
            string StatusCode = string.Empty;
            try
            {
                StatusCode = Resources.ExpressCMS.ResourceManager.GetString(((RootEnums.ForumUserType)UserType).ToString());
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
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         