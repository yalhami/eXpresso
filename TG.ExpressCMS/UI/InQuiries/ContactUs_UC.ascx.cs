using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.InQuiries
{
    public partial class ContactUs_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ContactUs_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (NoBot2.IsValid())
            {

                if (cu.Checked)
                {

                    string result = string.Empty;
                    InQuiry _quiry = new InQuiry();
                    _quiry.Country = HttpUtility.HtmlEncode(txtCountry.Text);
                    _quiry.Email = HttpUtility.HtmlEncode(txtEmail.Text);
                    _quiry.Description = HttpUtility.HtmlEncode(txtDescription.Text);
                    _quiry.Name = HttpUtility.HtmlEncode(txtName.Text);
                    _quiry.Phone = HttpUtility.HtmlEncode(txtPhone.Text);
                    _quiry.IsDeleted = false;
                    _quiry.Status = DataLayer.Enums.RootEnums.InQuiryStatus.Pending;

                    InQuiryManager.Add(_quiry);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + Resources.ExpressCMS.SuccessfullySent + "');", true);
                    if (_quiry.ID > 0)
                        dvMessage.InnerText = Resources.ExpressCMS.ResourceManager.GetString("SuccessfullySent");
                    else
                        dvMessage.InnerText = Resources.ExpressCMS.ResourceManager.GetString("FormSubmitFailed");
                }
                else
                    if (fa.Checked)
                    {
                        try
                        {
                            Fatawa _fatwa = new Fatawa();
                            int? id = 0;
                            _fatwa.Address = "";
                            _fatwa.Answer = "";
                            _fatwa.AnswerDate = DateTime.Now.ToShortDateString();
                            //_fatwa.AnsweredBy = SecurityContext.LoggedInUser.ID.ToString();
                            _fatwa.AnsweredBy = "";
                            _fatwa.Email = txtEmail.Text;
                            _fatwa.IsDeleted = false;
                            _fatwa.Mobile = "";
                            _fatwa.Name = txtName.Text;
                            _fatwa.Question = txtDescription.Text;
                            _fatwa.QuestionDate = DateTime.Now.ToString("dd/MM/yyyy");
                            _fatwa.CategoryID = -1;

                            _fatwa.Status = 0;
                            FatawaManager.Add(_fatwa);
                            AddEmailtoQueue(txtEmail.Text, txtName.Text);

                            dvMessage.InnerText = Resources.ExpressCMS.YourFatwaHadbeenSend;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + Resources.ExpressCMS.YourFatwaHadbeenSend + "');", true);
                        }
                        catch (Exception ex)
                        {
                            dvMessage.InnerText = ex.Message;
                        }

                    }
                ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), Guid.NewGuid().ToString().Substring(0, 6), "alert('" + dvMessage.InnerText + "');", true);

                AddMode();
            }
        }

        void ContactUs_UC_Load(object sender, EventArgs e)
        {
            //    AjaxPro.Utility.RegisterTypeForAjax(typeof(ContactUs_UC), this.Page);
            dvMessage.InnerText = "";
            dvMessage.InnerHtml = "";

        }
        private void AddMode()
        {
            txtCountry.Text = "";
            txtDescription.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";

        }

        private void AddEmailtoQueue(string email, string name)
        {
            EmailSender.EmailSenderSoapClient wbClient = new EmailSender.EmailSenderSoapClient();
            //   EmailSender wbClient = new EmailSender();
            wbClient.AddemailtoQueueNow(0, email, name, "<br/>شكرا لك لقد تم استلام طلب الفتوى سيصلك الرد عليها من خلال بريدك الالكتروني قريبا فور الاجابه عنها ان شاء الله", "NoTImeFORLove");
            wbClient.ProcessAllPendingEmail("NoTImeFORLove");
        }
    }
}