using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace TG.ExpressCMS
{
    public partial class frmTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
            MailMessage mail = new MailMessage();
            mail.Body = "hsdfsdf sdf sdfsdfsdf sdf sdfsd fdsf i";
            mail.Subject = "hifsadfa dsaf sdf sd";
            mail.To.Add(new MailAddress("yalhami@gmail.com"));
            mail.From = new MailAddress("test@mushtaraka.com.sa");
            //client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            //client.Credentials = CredentialCache.DefaultCredentials;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
        }
    }
}