using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;


namespace TG.ExpressCMS.UI.Fatwa
{
    public partial class FatwaRequest_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(FatwaRequest_UC_Load);
            this.btnSend.Click += new EventHandler(btnSend_Click);
        }

        void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                Fatawa _fatwa = new Fatawa();
                int? id = 0;
                _fatwa.Address = "";
                _fatwa.Answer = "";
                _fatwa.AnswerDate = DateTime.Now.ToString("dd/MM/yyyy");
                //_fatwa.AnsweredBy = SecurityContext.LoggedInUser.ID.ToString();
                _fatwa.AnsweredBy = "";
                _fatwa.Email = txtEmail.Text;
                _fatwa.IsDeleted = false;
                _fatwa.Mobile = "";
                _fatwa.Name = txtName.Text;
                _fatwa.Question = txtQuestion.Text;
                _fatwa.QuestionDate = DateTime.Now.ToString("dd/MM/yyyy");
                _fatwa.CategoryID = 0;

                _fatwa.Status = 1;
                FatawaManager.Add(_fatwa);
                dvMessages.InnerText = Resources.ExpressCMS.YourFatwaHadbeenSend;

                AddEmailtoQueue(txtEmail.Text, txtName.Text);
            }
            catch (Exception ex)
            {
                dvMessages.InnerText = ex.Message;
            }

        }
        private void AddEmailtoQueue(string email, string name)
        {
            EmailSender.EmailSenderSoapClient wbClient = new EmailSender.EmailSenderSoapClient();
            //   EmailSender wbClient = new EmailSender();
            wbClient.AddemailtoQueueNow(0, email, name, "<br/>شكرا لك لقد تم استلام طلب الفتوى سيصلك الرد عليها من خلال بريدك الالكتروني قريبا فور الاجابه عنها ان شاء الله", "NoTImeFORLove");
            wbClient.ProcessAllPendingEmail("NoTImeFORLove");
        }
        void FatwaRequest_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
            if (!IsPostBack)
                PerformSettings();
        }

        private void PerformSettings()
        {
            dvMessages.InnerText = "";

            txtEmail.Text = "";
            txtName.Text = "";
            txtQuestion.Text = "";
        }
    }
}