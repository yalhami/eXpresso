using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            TG.ExpressCMS.DataLayer.Entities.MaiciousRequest _req = new DataLayer.Entities.MaiciousRequest();
            if (HttpContext.Current.Request.Url.ToString().Contains("contactus"))
            {
                _req.DateTime = DateTime.Now.ToString("dd/MM/yyyy");
                _req.IPAddress = HttpContext.Current.Request.UserHostAddress + " " + HttpContext.Current.Request.UserHostName;
                _req.Url = HttpContext.Current.Request.Url.ToString();
                    
                MaiciousRequestManager.Add(_req);
            }
            //if (HttpContext.Current.Request.Url.ToString().Contains("/UserPages/NewsDetails.aspx?NewsID="))
            //{
            //    int index = HttpContext.Current.Request.Url.ToString().LastIndexOf("ID=");
            //    string d = (HttpContext.Current.Request.Url.ToString().Substring(index + 2, HttpContext.Current.Request.Url.ToString().Length - index - 2));
            //    d = d.Replace("=", "");
            //    HttpContext.Current.RewritePath("~/News/" + d);
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
          
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}