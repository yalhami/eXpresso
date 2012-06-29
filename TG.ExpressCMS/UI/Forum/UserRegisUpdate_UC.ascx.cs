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
    public partial class UserRegisUpdate_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(UserRegisUpdate_UC_Load);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (SecurityContext.LoggedInForumUser == null)
                BeginAddMode();
            else
                BeginEditMode(SecurityContext.LoggedInForumUser);
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.Entities.ForumUser forumUser = SecurityContext.LoggedInForumUser;

                if (forumUser == null)
                    throw new Exception("Error: User not found");

                try
                {
                    forumUser.BirthDate = DateTime.ParseExact(txtBirthDate.SelectedDate.Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    forumUser.BirthDate = new DateTime(1980, 1, 1);
                }
                forumUser.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                forumUser.PostsPerPage = Convert.ToInt32(txtPostsPerPage.Text);
                forumUser.Signature = HttpUtility.HtmlEncode(txtSignature.Text);
                forumUser.ThreadsPerPage = Convert.ToInt32(txtThreadsPerPage.Text);
                forumUser.UserName = HttpUtility.HtmlEncode(txtName.Text);

                ForumUserManager.Update(forumUser);

                SecurityContext.LoggedInForumUser = forumUser;

                dvAddUserSuccessfully.Visible = true;
                dvAddUser.Visible = false;
                dvwelcome.Visible = false;
            }
            catch (Exception ex)
            {
                dvAddUserProblems.InnerText = ex.Message;
                dvAddUserProblems.Visible = true;
            }
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = null;
                if (SecurityContext.LoggedInUser == null)
                {
                    if (UsersManager.GetByEmail(txtEmail.Text) != null)
                        throw new Exception(Resources.ExpressCMS.UserAlreadyDefined);

                    user = new Users();
                    user.Email = HttpUtility.HtmlEncode(txtEmail.Text);
                    user.IsActive = true;
                    user.Name = HttpUtility.HtmlEncode(txtEmail.Text);
                    user.Password = EncryptionContext.HashString(txtPassword.Text);
                    user.Type = RootEnums.UserType.NormalUser;
                    UsersManager.Add(user);

                    SecurityContext.LoggedInUser = user;
                }
                else
                    user = SecurityContext.LoggedInUser;

                if (SecurityContext.LoggedInForumUser != null)
                    throw new Exception("Error: User already exisits");

                DataLayer.Entities.ForumUser forumUser = new DataLayer.Entities.ForumUser();

                forumUser.BannedDate = DateTime.Now;
                try
                {
                    forumUser.BirthDate = DateTime.ParseExact(txtBirthDate.SelectedDate.Value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    forumUser.BirthDate = new DateTime(1980, 1, 1);
                }
                forumUser.ForumUserType = RootEnums.ForumUserType.Normal;
                forumUser.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                forumUser.IsBanned = false;
                forumUser.IsDeleted = false;
                forumUser.IsTrusted = true;
                forumUser.JoinDate = DateTime.Now;
                forumUser.PostsPerPage = Convert.ToInt32(txtPostsPerPage.Text);
                forumUser.RoleID = 0;
                forumUser.Signature = HttpUtility.HtmlEncode(txtSignature.Text);
                forumUser.ThreadsPerPage = Convert.ToInt32(txtThreadsPerPage.Text);
                forumUser.UserName = HttpUtility.HtmlEncode(txtName.Text);
                forumUser.UserRateValue = 0;
                forumUser.UserID = user.ID;
                forumUser.UserName = user.Name;
                forumUser.ForumUserType = RootEnums.ForumUserType.Normal;
                ForumUserManager.Add(forumUser);

              
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "AfterRegisterForumUser('" + ResolveUrl(ConfigContext.GetForumGroupPage) + "','" + Resources.ForumResource.AddUserSuccessfully + "')", true);

                dvAddUserSuccessfully.Visible = true;
                dvAddUser.Visible = false;

                EmailSender.EmailSenderSoapClient _emailsender = new EmailSender.EmailSenderSoapClient();
                _emailsender.AddemailtoQueueNow(0, user.Email, forumUser.UserName, Resources.ForumResource.AddUserSuccessfully, "NoTImeFORLove");
                _emailsender.ProcessAllPendingEmail("NoTImeFORLove");

            }
            catch (Exception ex)
            {
                dvAddUserProblems.InnerText = ex.Message;
                dvAddUserProblems.Visible = true;
            }
        }
        #endregion

        #region UserRegisUpdate_UC_Load
        void UserRegisUpdate_UC_Load(object sender, EventArgs e)
        {
            dvAddUserProblems.Visible = false;
            dvAddUserSuccessfully.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    if (SecurityContext.LoggedInForumUser == null)
                        BeginAddMode();
                    else
                        BeginEditMode(SecurityContext.LoggedInForumUser);

                    dvAddUser.Visible = true;
                }
                catch (Exception ex)
                {
                    dvAddUserProblems.InnerText = ex.Message;
                    dvAddUserProblems.Visible = true;
                    dvAddUser.Visible = false;
                }
            }
        }
        #endregion

        #endregion

        #region Methods

        #region BeginAddMode
        void BeginAddMode()
        {
            dvwelcome.Visible = false;
            btnReset.Visible = false;
            txtName.Text = string.Empty;
            txtPostsPerPage.Text = "5";
            txtThreadsPerPage.Text = "5";
            txtBirthDate.DbSelectedDate = "01/01/1980";
            txtSignature.Text = string.Empty;
            chkChangeImage.Visible = false;
            txtEmail.Text = string.Empty;
            rowSecurity.Visible = SecurityContext.LoggedInUser == null;
            Label1.Text = Resources.ForumResource.lblRegisterUsersForums;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region BeginEditMode
        void BeginEditMode(DataLayer.Entities.ForumUser forumUser)
        {
            dvwelcome.Visible = true;
            if (null != SecurityContext.LoggedInUser)
                lblloggenInUsername.Text = SecurityContext.LoggedInUser.Name;
            Label1.Text = Resources.ForumResource.ProfileSettings;
            txtName.Text = forumUser.UserName;
            txtPostsPerPage.Text = forumUser.PostsPerPage.ToString();
            txtThreadsPerPage.Text = forumUser.ThreadsPerPage.ToString();
            txtBirthDate.DbSelectedDate = forumUser.BirthDate.ToString("dd/MM/yyyy");
            txtSignature.Text = forumUser.Signature;
            chkChangeImage.Checked = false;
            chkChangeImage.Visible = true;
            btnReset.Visible = true;
            rowSecurity.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        #endregion

        #endregion
    }
}