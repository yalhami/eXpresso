using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.AdminPages
{
    public partial class frmUsersRoles : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (SecurityContext.LoggedInUser == null)
                Response.Redirect(ConfigContext.GetNonAuthorizedPage);

            if (SecurityContext.LoggedInUser.Type != DataLayer.Enums.RootEnums.UserType.SuperAdmin)
                Response.Redirect(ConfigContext.GetNonAuthorizedPage);
        }
    }
}