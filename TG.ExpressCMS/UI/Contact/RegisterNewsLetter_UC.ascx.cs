using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Contact
{
    public partial class RegisterNewsLetter_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ContactUs_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            TG.ExpressCMS.DataLayer.Entities.Contact _contact = new TG.ExpressCMS.DataLayer.Entities.Contact();
            _contact = ContactManager.GetByEmail(txtEmail.Text);
            if (null != _contact)
            {
                dvMessage.InnerText = Resources.ExpressCMS.YouEmailAlreadyregistered;
                return;
            }
            _contact = new DataLayer.Entities.Contact();
            _contact.Country = HttpUtility.HtmlEncode(txtCountry.Text);
            _contact.Email = HttpUtility.HtmlEncode(txtEmail.Text);
            _contact.Notes = HttpUtility.HtmlEncode(txtDescription.Text);
            _contact.FirstName = HttpUtility.HtmlEncode(txtName.Text);
            _contact.SurName = HttpUtility.HtmlEncode(txtSurname.Text);
            _contact.Phone2 = "";
            _contact.ZipCode = "";
            _contact.Company = "";
            _contact.Guid = Guid.NewGuid().ToString();
            _contact.Mobile = HttpUtility.HtmlEncode(txtPhone.Text);
            _contact.IsDeleted = false;
            _contact.Status = TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus.InActive;

            ContactManager.Add(_contact);
            ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + Resources.ExpressCMS.YouHadbeenRegisteredSuccessfully + "');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + Resources.ExpressCMS.YouHadbeenRegisteredSuccessfully + "');", true);
            if (_contact.ID > 0)
            {
                ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), "SSSd", "alert('" + Resources.ExpressCMS.ResourceManager.GetString("NewsLetterSuccessSubscribtion") + "');", true);
                EmailSender.EmailSenderSoapClient emailSender = new EmailSender.EmailSenderSoapClient();
                //    EmailSender emailSender = new EmailSender();
                emailSender.AddemailtoQueueNow(_contact.ID, _contact.Email, _contact.FullName, EmailContext.GetConfirmationText(_contact.FirstName, _contact.Email), "NoTImeFORLove");

                emailSender.ProcessAllPendingEmail("NoTImeFORLove");
                dvMessage.InnerText = Resources.ExpressCMS.YouHadbeenRegisteredSuccessfully;
                ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + Resources.ExpressCMS.YouHadbeenRegisteredSuccessfully + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), "SSSd1", "alert('" + Resources.ExpressCMS.ResourceManager.GetString("NewsLetterFailedSubscribtion") + "');", true);
            }

            AddMode();

            dvMessage.InnerText = Resources.ExpressCMS.ResourceManager.GetString("NewsLetterSuccessSubscribtion");
        }

        private void AddMode()
        {
            txtCompany.Text = "";
            txtName.Text = "";

            txtPhone.Text = "";
            txtSurname.Text = "";

            txtDescription.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
        }

        void ContactUs_UC_Load(object sender, EventArgs e)
        {
            dvMessage.InnerText = "";
            dvMessage.InnerHtml = "";
            if (Request.QueryString[ConstantsManager.Email] != null)
                txtEmail.Text = HttpUtility.HtmlEncode(Request.QueryString[ConstantsManager.Email]);

        }
    }
}