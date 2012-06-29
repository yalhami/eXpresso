using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.UI.Email
{
    public partial class EmailQueueAdmin_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(EmailQueueAdmin_UC_Load);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.gvEmail.PageIndexChanging += new GridViewPageEventHandler(gvEmail_PageIndexChanging);
            this.ibtntoExcel.Click += new ImageClickEventHandler(ibtntoExcel_Click);
           // this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        void ibtntoExcel_Click(object sender, ImageClickEventArgs e)
        {
            UtilitiesManager.GenerateExcelFiles("EmailHistory", gvEmail);
        }

        void gvEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmail.PageIndex = e.NewPageIndex;
            SearchfromCache();
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void EmailQueueAdmin_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { AddMode(); FillDDL(); Search(); }
        }
        private void Search()
        {
            IList<EmailQueue> colEmailQueue = EmailQueueManager.Search(ddlEmails.SelectedValue, ddlSeliveryStatus.SelectedValue, ddlSendingstatus.SelectedValue, txtDateSearch.Text, txtEmail.Text);
            HttpContext.Current.Session["colEmailQueue"] = colEmailQueue;
            gvEmail.DataSource = colEmailQueue;
            gvEmail.DataBind();
        }
        private void SearchfromCache()
        {
            if (null == HttpContext.Current.Session["colEmailQueue"])
                Search();
            else
            {
                gvEmail.DataSource = (IList<EmailQueue>)HttpContext.Current.Session["colEmailQueue"];
                gvEmail.DataBind();
            }
        }
        private void ShowAll()
        {
            gvEmail.DataSource = EmailQueueManager.GetAll();
            gvEmail.DataBind();
        }
        private void FillDDL()
        {
            ddlEmails.DataTextField = "Name";
            ddlEmails.DataValueField = "ID";
            ddlEmails.DataSource = EmailManager.GetAll();
            ddlEmails.DataBind();

            ddlSeliveryStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(TG.ExpressCMS.DataLayer.Enums.RootEnums.DeliveryStatus));
            ddlSeliveryStatus.DataTextField = "Key";
            ddlSeliveryStatus.DataValueField = "Value";
            ddlSeliveryStatus.DataBind();

            ddlSendingstatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(TG.ExpressCMS.DataLayer.Enums.RootEnums.SendingStatus));
            ddlSendingstatus.DataTextField = "Key";
            ddlSendingstatus.DataValueField = "Value";
            ddlSendingstatus.DataBind();

            ddlEmails.Items.Insert(0, new ListItem());
            ddlSeliveryStatus.Items.Insert(0, new ListItem());
            ddlSendingstatus.Items.Insert(0, new ListItem());
        }
        private void AddMode()
        {
            txtDateSearch.Text = string.Empty;
            txtEmail.Text = string.Empty;
            lblTotalItemsOnQueue.Text = EmailQueueManager.GetCountforPendingEmails().ToString();
        }
        protected string GetSendingStatus(int status)
        {
            if (status == Convert.ToInt32(RootEnums.SendingStatus.Pending))
                return "Pending";
            if (status == Convert.ToInt32(RootEnums.SendingStatus.Sent))
                return "Sent";
            return "";

        }
        protected string GetDeliveryStatus(int deliverystatus)
        {
            if(deliverystatus==Convert.ToInt32(RootEnums.DeliveryStatus.Delivered))
                return "Delivered";
            if (deliverystatus == Convert.ToInt32(RootEnums.DeliveryStatus.Failed))
                return "Failed";
            if (deliverystatus == Convert.ToInt32(RootEnums.DeliveryStatus.Unknown))
                return "Unknown";
            return "";
        }
        protected string GetUser(int userID)
        {
            Users _user = UsersManager.GetByID(userID);
            if (null == _user)
                return "";
            return _user.Name;
        }
    }
}