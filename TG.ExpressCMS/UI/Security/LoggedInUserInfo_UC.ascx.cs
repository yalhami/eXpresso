using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.Security
{
    public partial class LoggedInUserInfo_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(LoggedInUserInfo_UC_Load);
            this.lbtnlogout.Click += new EventHandler(lbtnlogout_Click);
            this.lbSwitchtoLanguageVersion.Click += new EventHandler(lbSwitchtoLanguageVersion_Click);
            this.lbtUsername.Click += new EventHandler(lbtUsername_Click);

        }
        protected string GetOtherLangUrl(ref string langName)
        {
            string otherVersionUrl = string.Empty;
            if (ExpressoConfig.SecurityConfigElement.ArabicVersionUrl != string.Empty)
            {
                otherVersionUrl = ExpressoConfig.SecurityConfigElement.ArabicVersionUrl;
                langName = "Arabic";
            }
            if (ExpressoConfig.SecurityConfigElement.EnglishVersionUrl != string.Empty)
            {
                otherVersionUrl = ExpressoConfig.SecurityConfigElement.EnglishVersionUrl;
                langName = "English";
            }
            return otherVersionUrl;
        }
        void lbtUsername_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConfigContext.GetUserInformationPage);
        }

        void lbtnlogout_Click(object sender, EventArgs e)
        {
            SecurityContext.LoggedInUser = null;
            SecurityContext.LoggedInUserRoles = null;
            Response.Redirect(ConfigContext.GetLoginPage);
        }

        void LoggedInUserInfo_UC_Load(object sender, EventArgs e)
        {
            if (SecurityContext.LoggedInUser == null)
                this.Visible = false;
            else
                this.Visible = true;
            if (!IsPostBack)
            {
                string langName = string.Empty;
                string otherVersionUrl = GetOtherLangUrl(ref langName);
                lbSwitchtoLanguageVersion.Text = "Switch to " + langName;
            }
            if (SecurityContext.LoggedInUser != null)
                lbtUsername.Text = "Welcome " + SecurityContext.LoggedInUser.Name;
        }
        void lbSwitchtoLanguageVersion_Click(object sender, EventArgs e)
        {
            string name = "";
            string otherVersionUrl = GetOtherLangUrl(ref name);
            Response.Redirect(otherVersionUrl + "/Adminpages/frmlogin.aspx?LoggedInUser=" + SecurityContext.LoggedInUser.ID + "&url=" + Request.Url.PathAndQuery.Replace("/ar/", "/"));
        }

    }
}