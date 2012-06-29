using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Enums;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using System.Configuration;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.Event
{
    public partial class EventLocationAdmin_UC : System.Web.UI.UserControl
    {
        #region Global
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
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.Load += new EventHandler(EventLocationAdmin_UC_Load);
            this.gvEventLocation.RowCommand += new GridViewCommandEventHandler(gvEventLocation_RowCommand);
            this.gvEventLocation.PageIndexChanging += new GridViewPageEventHandler(gvEventLocation_PageIndexChanging);
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                try
                {
                    EventLocation eventLocation = EventLocationManager.GetByID(ObjectID);
                    if (eventLocation != null)
                    {
                        eventLocation.Name = txtName.Text;
                        EventLocationManager.Update(eventLocation);

                        BindGrid();
                    }
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = Resources.EventResource.ResourceManager.GetString(ex.Message);
                }
                upnlGrid.Update();
            }
        }
        #endregion

        #region gvEventLocation_PageIndexChanging
        void gvEventLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventLocation.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvEventLocation_RowCommand
        void gvEventLocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEventLocation")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
                upnlControls.Update();
            }
        }
        #endregion

        #region EventLocationAdmin_UC_Load
        void EventLocationAdmin_UC_Load(object sender, EventArgs e)
        {
            dvProblems.InnerText = string.Empty;
            if (!IsPostBack)
            {
                BindGrid();
                ExitMode();
            }
        }
        #endregion

        #region ibtnAdd_Click
        void ibtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControls.Update();
        }
        #endregion

        #region ibtnDelete_Click
        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvEventLocation.Rows.Count; i++)
            {
                try
                {
                    CheckBox chkItem = (CheckBox)gvEventLocation.Rows[i].FindControl("chkItem");
                    if (null == chkItem)
                        continue;
                    if (!chkItem.Checked)
                        continue;
                    HtmlInputHidden hdnID = (HtmlInputHidden)gvEventLocation.Rows[i].FindControl("hdnID");
                    if (null == hdnID)
                        return;
                    int _id = Convert.ToInt32(hdnID.Value);

                    EventLocationManager.DeleteLogical(_id);
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = Resources.EventResource.ResourceManager.GetString(ex.Message) + Environment.NewLine;
                }
            }
            BindGrid();
            ExitMode();
            upnlControls.Update();
        }
        #endregion

        #region btnSave_Click
        void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                EventLocation eventLocation = new EventLocation();
                eventLocation.IsDeleted = false;
                eventLocation.Name = txtName.Text;

                EventLocationManager.Add(eventLocation);

                dvProblems.InnerText = Resources.EventResource.SavedSuccessfully;
                AddMode();
                BindGrid();
            }
            catch (Exception ex)
            {
                dvProblems.InnerText = Resources.EventResource.ResourceManager.GetString(ex.Message);
            }
            upnlGrid.Update();
        }
        #endregion

        #region btnReset_Click
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                EditMode();
            }
            else
                AddMode();
        }
        #endregion

        #region btnExit_Click
        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }
        #endregion

        #endregion

        #region Methods

        #region AddMode
        private void AddMode()
        {
            plcControls.Visible = true;
            txtName.Text = string.Empty;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                EventLocation eventLocation = EventLocationManager.GetByID(ObjectID);
                txtName.Text = eventLocation.Name;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                plcControls.Visible = true;
            }
        }
        #endregion

        #region ExitMode
        private void ExitMode()
        {
            ObjectID = 0;
            plcControls.Visible = false;
        }
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            gvEventLocation.DataSource = EventLocationManager.GetAll();
            gvEventLocation.DataBind();
        }
        #endregion

        #endregion
    }
}