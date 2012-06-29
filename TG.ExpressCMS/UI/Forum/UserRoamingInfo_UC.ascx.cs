using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI
{
    public partial class UserRoamingInfo_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(UserRoamingInfo_UC_Load);
            this.lblLogut.Click += new EventHandler(lblLogut_Click);
            lblloggenInUsername.Click += new EventHandler(lblloggenInUsername_Click);
        }

        void lblloggenInUsername_Click(object sender, EventArgs e)
        {
            Response.Redirect(ForumUtilities.GetForumProfile(SecurityContext.LoggedInUser.ID));
        }

        void lblLogut_Click(object sender, EventArgs e)
        {
            SecurityContext.LogOut();
            Response.Redirect(ConfigContext.GetForumGroupPage);
        }

        void UserRoamingInfo_UC_Load(object sender, EventArgs e)
        {
            if (null != SecurityContext.LoggedInUser)
            {
                lblloggenInUsername.Text = SecurityContext.LoggedInForumUser.UserName;
                dvLoggedIn.Visible = true;
                dvNotLoggedIn.Visible = false;
            }
            else
            {
                dvLoggedIn.Visible = false;
                dvNotLoggedIn.Visible = true;
            }
        }
    }
}