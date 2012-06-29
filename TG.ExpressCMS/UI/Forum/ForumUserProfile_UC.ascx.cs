using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Enums;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using System.Configuration;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Forum
{
    public partial class ForumUserProfile_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ForumUserProfile_UC_Load);
        }
        #endregion

        #region ForumUserProfile_UC_Load
        void ForumUserProfile_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = 0;
                int.TryParse(Request.QueryString["UserID"], out userId);
                BeginEditMode(userId);
            }
        }
        #endregion

        #endregion

        #region Methods

        #region BeginEditMode
        void BeginEditMode(int userId)
        {
            DataLayer.Entities.ForumUser forumUser = ForumUserManager.GetByUserID(userId);
            if (forumUser != null)
            {
                lblNameValue.Text = forumUser.UserName;
                lblBirthDateValue.Text = forumUser.BirthDate.ToString("dd/MM/yyyy");
                lblSignatureValue.Text = forumUser.Signature;
                imgForumValue.ImageUrl = ForumUtilities.GetForumUserImage(forumUser.Image);
                TG.ExpressCMS.DataLayer.Entities.Users _user = UsersManager.GetByID(forumUser.UserID);
                if (null != _user)
                    lblEmailValue.Text = _user.Email;
                plcForumUser.Visible = true;
            }
            else
            {
                plcForumUser.Visible = false;
            }
        }
        #endregion

        #endregion
    }
}