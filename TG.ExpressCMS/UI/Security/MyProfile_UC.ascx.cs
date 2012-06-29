using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Security
{
    public partial class MyProfile_UC : System.Web.UI.UserControl
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(MyProfile_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                dvMessages.InnerText = "Password not match";
                return;
            }
            Users _user = UsersManager.GetByID(ObjectID);
            _user.Name = txtName.Text;
            _user.Email = txtEmail.Text;
            _user.Password = EncryptionContext.HashString(txtPassword.Text);
            UsersManager.Update(_user);

            ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), "", "javascript::alert('Information changed successfully');", true);
            SecurityContext.LogOut();

            Response.Redirect(ConfigContext.GetLoginPage);
            dvMessages.InnerText = "Profile Information Updated.";
        }

        void MyProfile_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
            if (!IsPostBack)
            {
                if (Request.QueryString[ConstantsManager.UserID] != null)
                {
                    int userid = Convert.ToInt32(Request.QueryString[ConstantsManager.UserID]);
                    ObjectID = userid;
                }
                else
                    ObjectID = SecurityContext.LoggedInUser.ID;
                EditMode();
                FillUserRoles();
            }
        }
        void EditMode()
        {
            Users _user = UsersManager.GetByID(ObjectID);
            txtEmail.Text = _user.Email;
            txtName.Text = _user.Name;
        }
        void FillUserRoles()
        {
            dvSuperadmin.InnerText = "";
            if (SecurityContext.LoggedInUser == null) return;
            if (SecurityContext.LoggedInUser.Type == DataLayer.Enums.RootEnums.UserType.SuperAdmin)
            {
                dvSuperadmin.InnerText = "Your Are Super Admin, You have the Super Power.";
                lstmyRoles.Visible = false;
                return;
            }
            else
            {
                lstmyRoles.Visible = true;
                lstmyRoles.DataSource = SecurityContext.LoggedInUserRoles;
                lstmyRoles.DataTextField = "Name";
                lstmyRoles.DataValueField = "ID";
                lstmyRoles.DataBind();
            }
        }

    }
}