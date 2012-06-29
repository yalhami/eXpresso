using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Custums.Volunteer
{
    public partial class BecomeVolunteerUserSide_UC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TG.ExpressCMS.UI.Custums.Volunteer.VolunteerDALDataContext dx = new TG.ExpressCMS.UI.Custums.Volunteer.VolunteerDALDataContext();
            int? id=0;
            dx.InsertVolunteer(ref id, txtName.Text, txtEmail.Text, txtMessage.Text,  UtilitiesManager.GetSavedFile(fbupload, true));
            dvMessages.InnerText = "Your application had been recived we will contact you soon.";
        }
    }
}