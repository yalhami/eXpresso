using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using System.Configuration;
using System.Text;
using System.IO;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Xsl;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Web.UI;


namespace TG.ExpressCMS
{
    public class PageContext : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            bool hasaccess = false;
            if (SecurityContext.LoggedInUser == null)
                Response.Redirect(ConfigContext.GetNonAuthorizedPage);
            if (SecurityContext.LoggedInUser.Type == DataLayer.Enums.RootEnums.UserType.SuperAdmin)
                return;
            string pagename = string.Empty;
            pagename = Request.Url.Segments[Request.Url.Segments.Count() - 1];
            hasaccess = UsersManager.ValidateUserPermssion(pagename, SecurityContext.LoggedInUser.ID);
            if (!hasaccess)
                Response.Redirect(ConfigContext.GetNonAuthorizedPage);
        }
    }
}