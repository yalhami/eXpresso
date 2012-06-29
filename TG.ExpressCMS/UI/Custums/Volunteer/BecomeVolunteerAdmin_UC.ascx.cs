using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Custums.Volunteer
{
    public partial class BecomeVolunteer_UC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string GetCV(string cv)
        {
            return "~/upload/Files/" + cv;
        }
    }
}