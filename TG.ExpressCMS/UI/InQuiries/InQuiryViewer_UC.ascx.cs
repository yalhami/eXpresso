using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Entities;
using System.Net.Mail;
using System.Net;
using System.Text;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.InQuiries
{
    public partial class InQuiryViewer_UC : System.Web.UI.UserControl
    {
        /// <summary>
        /// Object ID.
        /// </summary>
        private int ObjectID
        {
            set
            {
                ViewState[ConstantsManager.ObjectID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.ObjectID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.ObjectID]);
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// On Intilization.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnExit.Click += new EventHandler(btnExit_Click);

            this.gvComment.SelectedIndexChanged += new EventHandler(gvComment_SelectedIndexChanged);

            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);

            this.Load += new EventHandler(marqueeItemsAdd_UC_Load);
            this.gvComment.RowCommand += new GridViewCommandEventHandler(gvComment_RowCommand);

            this.gvComment.PageIndexChanging += new GridViewPageEventHandler(gvComment_PageIndexChanging);
            this.chkshowReviewed.CheckedChanged += new EventHandler(chkshowReviewed_CheckedChanged);
            this.ibtntoExcel.Click += new ImageClickEventHandler(ibtntoExcel_Click);
            this.btnReply.Click += new EventHandler(btnReply_Click);

        }

        void btnReply_Click(object sender, EventArgs e)
        {
            EmailSender.EmailSenderSoapClient webClient = new EmailSender.EmailSenderSoapClient();

            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.InQuiry inQuiries = TG.ExpressCMS.DataLayer.Data.InQuiryManager.GetByID(ObjectID);

                if (null == inQuiries)
                    return;

                EmailSenderInteral.AddemailtoQueueNow(0, inQuiries.Email, inQuiries.Name, txtReply.Content, "NoTImeFORLove");
                EmailSenderInteral.ProcessAllPendingEmail("NoTImeFORLove");
                ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), Guid.NewGuid().ToString().Substring(0, 5), "alert('" + Resources.ExpressCMS.YourReplyhadbeenQueued + "');", true);
            }
        }

        void ibtntoExcel_Click(object sender, ImageClickEventArgs e)
        {
            UtilitiesManager.GenerateExcelFiles("InQuiryviewer", gvComment);
        }

        void gvComment_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            gvComment.PageIndex = e.NewSelectedIndex;
            BindGrid();
        }

        void chkshowReviewed_CheckedChanged(object sender, EventArgs e)
        {
            BindGrid();
        }


        void gvComment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComment.PageIndex = e.NewPageIndex;
            BindGrid();
        }


        void gvComment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditInQuiry")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
                upnall.Update();
            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void marqueeItemsAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
             

            }
        }


        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvComment.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvComment.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvComment.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                InQuiryManager.Delete(_id);

            }
            BindGrid();

            plControls.Visible = false;
            upnlgrid.Update();
            upnall.Update();
        }


        void gvComment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvComment.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                EditMode();
            }

            upnall.Update();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plControls.Visible = false;
        }

        #region "Methods"

        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.InQuiry inQuiries = TG.ExpressCMS.DataLayer.Data.InQuiryManager.GetByID(ObjectID);

                if (null == inQuiries)
                    return;
                txtCountry.Text = inQuiries.Country;
                txtDescription.Text = inQuiries.Description;
                txtEmail.Text = inQuiries.Email;
                txtName.Text = inQuiries.Name;
                txtPhone.Text = inQuiries.Phone;
                txtCountry.Enabled = false;
                txtDescription.Enabled = false;
                txtEmail.Enabled = false;
                txtName.Enabled = false;
                txtPhone.Enabled = false;
                plControls.Visible = true;
                hyp1.NavigateUrl = "mailto:" + txtEmail.Text;
                inQuiries.Status = DataLayer.Enums.RootEnums.InQuiryStatus.Reviewed;
                InQuiryManager.Update(inQuiries);

            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            if (chkshowReviewed.Checked)
            {
                gvComment.DataSource = TG.ExpressCMS.DataLayer.Data.InQuiryManager.GetAll();
                gvComment.DataBind();
            }
            else
            {
                gvComment.DataSource = TG.ExpressCMS.DataLayer.Data.InQuiryManager.GetAll().Where(t => t.Status == DataLayer.Enums.RootEnums.InQuiryStatus.Pending).ToList();
                gvComment.DataBind();
            }
        }

        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plControls.Visible = false;
        }
        protected string GetStatus(int status)
        {
            if (Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.InQuiryStatus.Pending) == status)
                return Resources.ExpressCMS.ResourceManager.GetString(TG.ExpressCMS.DataLayer.Enums.RootEnums.InQuiryStatus.Pending.ToString());
            else
                return Resources.ExpressCMS.ResourceManager.GetString(TG.ExpressCMS.DataLayer.Enums.RootEnums.InQuiryStatus.Reviewed.ToString());

        }
        #endregion
    }
}