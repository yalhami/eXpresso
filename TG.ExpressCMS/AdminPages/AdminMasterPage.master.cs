using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS
{
    public partial class AdminMasterPage : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(AdminMasterPage_Load);
            
            base.OnInit(e);
            if (SecurityContext.LoggedInUser == null)
                Response.Redirect(("frmlogin.aspx?url=" + Request.Url));
        }

       
        void AdminMasterPage_Load(object sender, EventArgs e)
        {
           
        }
        protected string GetPortalName()
        {
            return CacheContext._DefaultSettings.Name;
        }
       
    }
}