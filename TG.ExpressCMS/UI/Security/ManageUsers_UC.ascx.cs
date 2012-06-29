using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Security
{
    public partial class ManageUsers_UC : System.Web.UI.UserControl
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
            this.gvUsers.RowCommand += new GridViewCommandEventHandler(gvUsers_RowCommand);
            this.gvUsers.PageIndexChanging += new GridViewPageEventHandler(gvUsers_PageIndexChanging);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);

        }

        void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUsers")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
                upnlControls.Update();
            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CatAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                FillGroup();
                PerformSettings();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControls.Update();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvUsers.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvUsers.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvUsers.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                UsersManager.Delete(_id);

            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
            upnlControls.Update();
            upnlGrid.Update();
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            Users _user = null;
            if (ObjectID <= 0)
            {
                try
                {
                    if (txtConfirmPassword.Text != txtPassword.Text)
                        dvProblems.InnerText = "Password doesn't match";
                    _user = new Users();
                    _user.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType)Convert.ToInt32(ddlType.SelectedValue);
                    _user.Password = EncryptionContext.HashString(txtPassword.Text);
                    _user.Name = txtName.Text;
                    _user.IsActive = chkActive.Checked;
                    _user.Email = txtEmail.Text;

                    UsersManager.Add(_user);

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
                    if (txtConfirmPassword.Text != txtPassword.Text)
                        dvProblems.InnerText = "Password doesn't match";
                    _user = UsersManager.GetByID(ObjectID);
                    _user.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType)Convert.ToInt32(ddlType.SelectedValue);
                    _user.Password = EncryptionContext.HashString(txtPassword.Text);
                    _user.Name = txtName.Text;
                    _user.IsActive = chkActive.Checked;
                    _user.Email = txtEmail.Text;

                    UsersManager.Update(_user);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
            upnlGrid.Update();
            upnlControls.Update();
        }

        void gvCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvUsers.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
                EditMode();
            else
                AddMode();
            upnlControls.Update();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
            upnlControls.Update();
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtEmail.Text = ""; txtName.Text = ""; txtPassword.Text = ""; txtConfirmPassword.Text = "";
            ddlType.SelectedIndex = -1;
            chkActive.Checked = true;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                Users _user = null;
                _user = UsersManager.GetByID(ObjectID);
                if (null == _user)
                    return;
                txtName.Text = _user.Name;
                txtEmail.Text = _user.Email;
                chkActive.Checked = _user.IsActive;
                ddlType.SelectedValue = Convert.ToInt32(_user.Type).ToString();
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvUsers.DataSource = UsersManager.GetAll();
            gvUsers.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
            if (null == SecurityContext.LoggedInUser)
                return;
            if (SecurityContext.LoggedInUser.Type == DataLayer.Enums.RootEnums.UserType.NormalUser)
            {
                ddlType.SelectedValue = Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType.NormalUser).ToString();
                ddlType.Enabled = false;
            }
        }
        private void FillGroup()
        {
            ddlType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType));
            ddlType.DataTextField = "Key"; ddlType.DataValueField = "Value";
            ddlType.DataBind();

            ddlType.Items.Insert(0, new ListItem());
        }
        /// <summary>
        /// Get Cat Status
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        protected string GetStatus(bool IsActive)
        {
            if (IsActive)
            {
                return Resources.ExpressCMS.ResourceManager.GetString("Active");
            }
            else
            {
                return Resources.ExpressCMS.ResourceManager.GetString("InActive");
            }
        }
        protected string GetType(int type)
        {
            if (Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType.NormalUser) == type)
                return Resources.ExpressCMS.ResourceManager.GetString(TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType.NormalUser.ToString());
            else
                return Resources.ExpressCMS.ResourceManager.GetString(TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType.SuperAdmin.ToString());
        }
        #endregion
    }
}