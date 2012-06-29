using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.EmailSender;


namespace TG.ExpressCMS.UI.Contact
{
    public partial class ActivateNewsLetterRegistration_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ActivateNewsLetterRegistration_UC_Load);
        }

        void ActivateNewsLetterRegistration_UC_Load(object sender, EventArgs e)
        {

            dvmsg.InnerText = "";
            if (Request.QueryString[ConstantsManager.ContactGuid] != null)
            {
                string _guid = Request.QueryString[ConstantsManager.ContactGuid].ToString();
                TG.ExpressCMS.DataLayer.Entities.Contact _contact = new DataLayer.Entities.Contact();
                _contact = ContactManager.GetbyGuid(_guid);

                if (null == _contact)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 5), "alert('" + Resources.ExpressCMS.ErrContactNotExist + "');", true);
                    dvmsg.InnerText = Resources.ExpressCMS.ErrContactNotExist;
                    return;
                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 5), "alert('" + Resources.ExpressCMS.ContactActivated + "');", true);
                dvmsg.InnerText = Resources.ExpressCMS.ContactActivated;
                _contact.Status = DataLayer.Enums.RootEnums.ContactStatus.Active;

                EmailSender.EmailSenderSoapClient _emailsender = new EmailSender.EmailSenderSoapClient();
                //EmailSender _emailsender = new EmailSender();
                _emailsender.AddemailtoQueueNow(_contact.ID, _contact.Email, _contact.FirstName, EmailContext.GetSuccessString(_contact.FirstName, _contact.Email), "NoTImeFORLove");
                _emailsender.ProcessAllPendingEmail("NoTImeFORLove");

                ContactManager.Update(_contact);

            }
        }
    }
}