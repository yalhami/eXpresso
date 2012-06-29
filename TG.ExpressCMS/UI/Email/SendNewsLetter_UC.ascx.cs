using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

using System.Collections;
using TG.ExpressCMS.DataLayer.Entities;
using System.Globalization;

namespace TG.ExpressCMS.UI.Contact
{
    public partial class SendNewsLetter_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SendNewsLetter_UC_Load);
            this.btnSend.Click += new EventHandler(btnSend_Click);
        }

        void btnSend_Click(object sender, EventArgs e)
        {
            string colGroupsID = "";
            for (int i = 0; i < chkGroups.Items.Count; i++)
            {
                if (chkGroups.Items[i].Selected)
                    colGroupsID += chkGroups.Items[i].Value + ",";
            }
            if (colGroupsID.LastIndexOf(',') + 1 == colGroupsID.Count())
            {
                colGroupsID = colGroupsID.Remove(colGroupsID.LastIndexOf(','), 1);
            }
            // Create an instance of the WebService
            EmailSender.EmailSenderSoapClient webClient = new EmailSender.EmailSenderSoapClient();
            // EmailSender webClient = new EmailSender();


            //Fire and Ignore web service calling.
            webClient.SendEmail(Convert.ToInt32(ddlEmails.SelectedValue), colGroupsID, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, tmSelector.Hour + ":" + tmSelector.Minute, "NoTImeFORLove");
            //TG.ExpressCMS.Services.EmailSender1 obj = new ExpressCMS.Services.EmailSender1();
            //obj.SendEmail(Convert.ToInt32(ddlEmails.SelectedValue), colGroupsID, DateTime.ParseExact(txtDateFrom.Text, "dd/MM/yyyy", _culInfo).ToString(), tmSelector.Hour + ":" + tmSelector.Minute, "NoTImeFORLove");
            ScriptManager.RegisterStartupScript(upnlall, upnlall.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + "Sending Process Started successfully" + "');", true);
        }

        void SendNewsLetter_UC_Load(object sender, EventArgs e)
        {

            txtDateFrom.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            if (!IsPostBack)
                FillGroups();
        }
        private void FillGroups()
        {
            chkGroups.DataSource = GroupManager.GetAll();
            chkGroups.DataTextField = "Name";
            chkGroups.DataValueField = "ID";
            chkGroups.DataBind();

            ddlEmails.DataTextField = "Name";
            ddlEmails.DataValueField = "ID";
            ddlEmails.DataSource = EmailManager.GetAll().Where(t => t.IsDeleted == false && t.Type == DataLayer.Enums.RootEnums.EmailType.Normal).ToList();
            ddlEmails.DataBind();
            ddlEmails.Items.Insert(0, new ListItem());

        }
    }
}