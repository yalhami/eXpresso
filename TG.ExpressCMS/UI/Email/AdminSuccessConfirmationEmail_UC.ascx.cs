using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TG.ExpressCMS.UI.Email
{
    public partial class AdminSuccessConfirmationEmail_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(AdminSuccessConfirmationEmail_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            SaveMessages();
        }

        void AdminSuccessConfirmationEmail_UC_Load(object sender, EventArgs e)
        {
            dvmessages.InnerText = "";
            if (!IsPostBack)
            {
                LoadMessages();
                PerformSettings();
            }
        }
        private void PerformSettings()
        {
            btnSaveUpdate.Attributes.Add("onclick", "HideDivMsg();");
        }

        private void LoadMessages()
        {
            string confirmationresult = UtilitiesManager.ReadFile(Server.MapPath("~/UI/Email/Messages/Confirmation.txt"));
            txtConfirmation.Content = confirmationresult;

            string successresult = UtilitiesManager.ReadFile(Server.MapPath("~/UI/Email/Messages/Success.txt"));
            txtSuccess.Content = successresult;
        }
        private void SaveMessages()
        {
            UtilitiesManager.WriteFile(Server.MapPath("~/UI/Email/Messages/Confirmation.txt"), txtConfirmation.Content, false, false);
            UtilitiesManager.WriteFile(Server.MapPath("~/UI/Email/Messages/Success.txt"), txtSuccess.Content, false, false);
            dvmessages.InnerText = "Saved successfully";
        }
    }

}