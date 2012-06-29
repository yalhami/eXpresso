using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Collections;
using System.Globalization;

using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.EmailSender;



namespace TG.ExpressCMS.UI.Security
{
    public partial class LoginUserSide_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Login_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            btnSend.Click += new EventHandler(btnSend_Click);
        }

        void btnSend_Click(object sender, EventArgs e)
        {
            Users _user = UsersManager.GetByEmail(txtEmail.Text);
            if (null == _user)
            {
                ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), Guid.NewGuid().ToString().Substring(0, 5), "alert('" + Resources.ExpressCMS.UserNotFound + "');", true);
                return;
            }
            string passw = Guid.NewGuid().ToString().Substring(0, 4);
            _user.Password = EncryptionContext.HashString(passw);
            UsersManager.Update(_user);
            AddEmailtoQueue(txtEmail.Text, txtEmail.Text, passw);
            mpeShowResult.Show();
            ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), Guid.NewGuid().ToString().Substring(0, 5), "alert('" + Resources.ExpressCMS.YourPasswordHadSentSuccess + "');", true);
            txtEmail.Text = "";
        }
        private void AddEmailtoQueue(string email, string name, string password)
        {
            EmailSender.EmailSenderSoapClient wbClient = new EmailSender.EmailSenderSoapClient();
                 wbClient.AddemailtoQueueNow2(CacheContext._DefaultSettings.Name, email, name, UtilitiesManager.ReadFile(Server.MapPath("~/Settings/ForgetPasswordEmailTemplate.txt")) + " <br/>" + password, "NoTImeFORLove");
             wbClient.ProcessAllPendingEmail("NoTImeFORLove");
        }
        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            Users _user = UsersManager.GetByEmail(txtUsername.Text);

            if (_user == null)
            {
                dvMessages.InnerText = Resources.ForumResource.ErrorUsernotfound;
                return;
            }
            if (!_user.IsActive)
            {
                dvMessages.InnerText = Resources.ForumResource.ErrorUsernotfound;
                return;
            }
            if (_user.Password == EncryptionContext.HashString(txtPassword.Text))
            {
                IList<Roles> colUserRoles = RolesManager.GetByUserID(_user.ID);
                SecurityContext.LoggedInUserRoles = colUserRoles;

                SecurityContext.LoggedInUser = _user;
                if (Request.QueryString["url"] == null)
                {
                    switch (SecurityContext.LoggedInUser.Type)
                    {
                        case TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType.SuperAdmin:
                            Response.Redirect(ConfigContext.GetAdminLandingPage);
                            break;
                        case TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType.NormalUser:
                            Response.Redirect("~/UserPages/ForumGroupViewer.aspx");
                            break;
                        default:
                            break;
                    }

                }
                else
                    Response.Redirect(Request.QueryString["url"]);
            }
            else
            {
                dvMessages.InnerText = Resources.ExpressCMS.UsernameOrPasswordIsWrong;
            }
        }

        void Login_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = string.Empty;
            if (!IsPostBack)
            {
                txtPassword.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtUsername.Attributes.Add("onfocus", "ClearBoxs(" + txtUsername.ClientID + ");");
                txtPassword.Attributes.Add("onfocus", "ClearBoxs(" + txtPassword.ClientID + ");");
            }

        }
    }
}