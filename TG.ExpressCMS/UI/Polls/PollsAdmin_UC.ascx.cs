using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.UI.HtmlControls;

namespace TG.ExpressCMS.UI
{
    public partial class PollsAdmin_UC : System.Web.UI.UserControl
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
        private int DetObjectID
        {
            set
            {
                ViewState[ConstantsManager.DetObjectID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.DetObjectID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.DetObjectID]);
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
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.gvPolls.SelectedIndexChanged += new EventHandler(gvPolls_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(PollAdd_UC_Load);
            this.gvPolls.RowCommand += new GridViewCommandEventHandler(gvPolls_RowCommand);
            this.gvPolls.PageIndexChanging += new GridViewPageEventHandler(gvPolls_PageIndexChanging);


            this.btnExitPollDet.Click += new EventHandler(btnExitDet_Click);
            this.btnResetPollDetails.Click += new EventHandler(btnResetDet_Click);

            this.btnSavePollDet.Click += new EventHandler(btnSaveUpdateDet_Click);
            this.ibtnDeletePollDet.Click += new ImageClickEventHandler(ibtnDeleteDet_Click);
            this.ibtnAddPollDet.Click += new ImageClickEventHandler(ibtnaddDet_Click);

            this.gvPollDetails.RowCommand += new GridViewCommandEventHandler(gvPollDetails_RowCommand);
            this.gvPollDetails.PageIndexChanging += new GridViewPageEventHandler(gvPollDetails_PageIndexChanging);
        }

        void gvPolls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPolls.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvPolls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPoll")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PollAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                PerformPoll();
                AddMode();
            }
            dvProblems.InnerText = "";
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvPolls.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvPolls.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvPolls.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);
                Poll _Poll = PollManager.GetByID(_id);
                _Poll.IsDeleted = true;
                PollManager.Update(_Poll);
            }
            BindGrid();
            AddMode();

            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            Poll _Poll = new TG.ExpressCMS.DataLayer.Entities.Poll();
            if (ObjectID <= 0)
            {
                try
                {
                    _Poll.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    _Poll.CreatedBy = SecurityContext.LoggedInUser.ID;
                    _Poll.IsClosed = chkClosed.Checked;
                    _Poll.IsDeleted = false;
                    _Poll.Name = txtName.Text;
                    PollManager.Add(_Poll);
                    AddMode();
                    dvProblems.InnerText = "Saved Successfully";
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }

            }
            else
            {
                try
                {

                    _Poll = PollManager.GetByID(ObjectID);

                    _Poll.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    _Poll.CreatedBy = SecurityContext.LoggedInUser.ID;
                    _Poll.IsClosed = chkClosed.Checked;
                    _Poll.IsDeleted = false;
                    _Poll.Name = txtName.Text;
                    if (null == _Poll)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    PollManager.Update(_Poll);
                    EditMode();
                    dvProblems.InnerText = "Saved Successfully";
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
            BindGridDet();
        }

        void gvPolls_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvPolls.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
                EditMode();
            else
                AddMode();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtName.Text = "";
            dvProblems.Visible = true;
            dvProblems.Style.Clear();
            dvProblems.InnerText = "";
            txtDate.Text = DateTime.Today.ToShortDateString();
            chkClosed.Checked = false;
            ObjectID = 0;
            ClearPollDetails();

        }
        private void ClearPollDetails()
        {
            gvPollDetails.DataSource = new List<PollDetails>();
            gvPollDetails.DataBind();
            AddModeDet();
            upnlPollDetails.Update();
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Poll _Poll = new TG.ExpressCMS.DataLayer.Entities.Poll();
                _Poll = PollManager.GetByID(ObjectID);
                if (null == _Poll)
                    return;
                txtDate.Text = _Poll.Date;

                txtName.Text = _Poll.Name;
                chkClosed.Checked = _Poll.IsClosed;
                plcControls.Visible = true;
                BindGridDet();
                upnlPollDetails.Update();
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvPolls.DataSource = PollManager.GetAll().Where(t => t.IsDeleted == false).ToList();
            gvPolls.DataBind();


        }
        /// <summary>
        /// Performs Poll.
        /// </summary>
        private void PerformPoll()
        {
            plcControls.Visible = false;

        }
        protected string GetClosedStatus(bool IsClosed)
        {
            return IsClosed.ToString();
        }

        #endregion

        void gvPollDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPollDetails.PageIndex = e.NewPageIndex;
            BindGridDet();
        }

        void gvPollDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPollDetails")
            {
                DetObjectID = Convert.ToInt32(e.CommandArgument);
                EditModeDet();
            }
        }



        void ibtnaddDet_Click(object sender, ImageClickEventArgs e)
        {
            AddModeDet();
        }

        void ibtnDeleteDet_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvPollDetails.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvPollDetails.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvPollDetails.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                PollDetailsManager.Delete(_id);
            }
            BindGridDet();
            AddModeDet();
            plcControls.Visible = false;
            Session["_poll"] = null;
        }

        void btnSaveUpdateDet_Click(object sender, EventArgs e)
        {

            PollDetails _PollDetails = new TG.ExpressCMS.DataLayer.Entities.PollDetails();
            if (DetObjectID <= 0)
            {
                try
                {
                    _PollDetails.PollID = ObjectID;
                    _PollDetails.Name = txtPollDetailsName.Text;
                    _PollDetails.Count = 1;
                    PollDetailsManager.Add(_PollDetails);
                    AddModeDet();
                    dvPolldet.InnerText = "Saved Successfully";
                    Session["_poll"] = null;
                }
                catch (Exception ex)
                {
                    dvPolldet.InnerText = ex.ToString();
                }

            }
            else
            {
                try
                {

                    _PollDetails = PollDetailsManager.GetByID(ObjectID);
                    _PollDetails.PollID = ObjectID;

                    _PollDetails.Name = txtPollDetailsName.Text;
                    if (null == _PollDetails)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    PollDetailsManager.Update(_PollDetails);
                    EditModeDet();
                    dvPolldet.InnerText = "Saved Successfully";
                    Session["_poll"] = null;
                }
                catch (Exception ex)
                {
                    dvPolldet.InnerText = ex.ToString();
                }
            }
            BindGridDet();
        }

        void gvPollDetailss_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetObjectID = Convert.ToInt32(gvPollDetails.SelectedDataKey.Value);
            EditModeDet();
        }

        void btnResetDet_Click(object sender, EventArgs e)
        {
            if (DetObjectID > 0)
                EditModeDet();
            else
                AddModeDet();
        }

        void btnExitDet_Click(object sender, EventArgs e)
        {
            plcControlsDetails.Visible = false;
        }

        #region "Methods"
        private void AddModeDet()
        {
            plcControlsDetails.Visible = true;
            dvPolldet.Visible = true;
            dvPolldet.Style.Clear();
            dvPolldet.InnerText = "";
            txtPollDetailsName.Text = string.Empty;
            DetObjectID = 0;
        }
        private void EditModeDet()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.PollDetails _PollDetails = new TG.ExpressCMS.DataLayer.Entities.PollDetails();
                _PollDetails = PollDetailsManager.GetByID(DetObjectID);
                if (null == _PollDetails)
                    return;
                txtPollDetailsName.Text = _PollDetails.Name;

                plcControlsDetails.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGridDet()
        {
            gvPollDetails.DataSource = PollDetailsManager.GetByPollID(ObjectID);
            gvPollDetails.DataBind();
        }

        #endregion
    }
}