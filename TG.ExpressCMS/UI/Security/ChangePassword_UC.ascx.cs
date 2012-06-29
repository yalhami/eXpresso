using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Security
{
    public partial class ChangePassword_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ChangePassword_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
                return;
            if (SecurityContext.LoggedInUser == null)
                return;
            Users _user = UsersManager.GetByID(SecurityContext.LoggedInUser.ID);
            _user.Password = EncryptionContext.HashString(txtConfirmPassword.Text);
            
            UsersManager.Update(_user);
            dvMessages.InnerText = "Profile Information Updated.";
        }

        void ChangePassword_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
            if (IsPostBack)
            {
                txtConfirmPassword.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }
    }
}