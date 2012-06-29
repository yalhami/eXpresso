using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Contact
{
    public partial class ShortCutNewsletter_UC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnSubscribe_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(ExpressoConfig.NewsletterConfigElement.GetNewsletterRegistrationPage + "?" + ConstantsManager.Email + "=" + txtEmailA.Text);
        }
    }
}