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
    public partial class EventAdmin_UC : System.Web.UI.UserControl
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
        private int SelectedSearchCategoryID
        {
            get
            {
                int CategoryID = 0;
                int.TryParse(ddlSearchCategory.SelectedValue, out CategoryID);

                return CategoryID;
            }
        }
        private int SelectedSearchLocationID
        {
            get
            {
                int LocationID = 0;
                int.TryParse(ddlSearchLocation.SelectedValue, out LocationID);

                return LocationID;
            }
        }
        private DateTime? SelectedSearchFromDate
        {
            get
            {
                DateTime? fromDate = null;
                try
                {
                    fromDate = DateTime.ParseExact(txtSearchFrom.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                }

                return fromDate;
            }
        }
        private DateTime? SelectedSearchToDate
        {
            get
            {
                DateTime? toDate = null;
                try
                {
                    toDate = DateTime.ParseExact(txtSearchTo.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                }

                return toDate;
            }
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
          
            base.OnInit(e);
            this.Load += new EventHandler(EventAdmin_UC_Load);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.ibtnAdd.Click += new ImageClickEventHandler(ibtnAdd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.gvEvent.RowCommand += new GridViewCommandEventHandler(gvEvent_RowCommand);
            this.gvEvent.PageIndexChanging += new GridViewPageEventHandler(gvEvent_PageIndexChanging);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
        }
        #endregion

        #region btnSearch_Click
        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
            ExitMode();
            upnlControls.Update();
            upnlGrid.Update();
        }
        #endregion

        #region btnUpdate_Click
        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                try
                {
                    DataLayer.Entities.Event oEvent = EventManager.GetByID(ObjectID);
                    if (oEvent != null)
                    {
                        oEvent.CategoryID = Convert.ToInt32(ddlEventCategory.SelectedValue);
                        oEvent.CreatedBy = SecurityContext.LoggedInUser.ID;
                        oEvent.CreationDate = DateTime.Now;
                        oEvent.DetailsHtml = txtDetails.Content;
                        oEvent.Duration = 0;
                        oEvent.Every = 0;
                        try
                        {
                            oEvent.FromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                        }
                        catch { }
                        try
                        {
                            int FromHours = Convert.ToInt32(txtFromTimeHour.Text);
                            int FromMminute = Convert.ToInt32(txtFromTimeMminute.Text);
                            oEvent.FromDate = new DateTime(oEvent.FromDate.Year, oEvent.FromDate.Month, oEvent.FromDate.Day, FromHours, FromMminute, 0);
                        }
                        catch { }
                        if (chkChangeImage.Checked)
                            oEvent.ImageURL = UtilitiesManager.GetSavedFile(fUploader, true);
                        oEvent.LocationID = Convert.ToInt32(ddlEventLocation.SelectedValue);
                        oEvent.Name = txtName.Text;
                        oEvent.Notify = 0;
                        oEvent.Period = "";
                        oEvent.Reminder = 0;
                        oEvent.RepeatType = 0;
                        try
                        {
                            oEvent.ToDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                        }
                        catch { }
                        try
                        {
                            int ToHours = Convert.ToInt32(txtToTimeHour.Text);
                            int ToMminute = Convert.ToInt32(txtToTimeMminute.Text);
                            oEvent.ToDate = new DateTime(oEvent.ToDate.Year, oEvent.ToDate.Month, oEvent.ToDate.Day, ToHours, ToMminute, 0);
                        }
                        catch { }
                        SetEventRepeat(oEvent);
                        EventManager.Update(oEvent);

                        dvProblems.InnerText = Resources.EventResource.UpdatedSuccessfully;

                        GetEventRepeat(oEvent);

                        BeginSearchMode();
                        BindGrid();
                        upnlSearch.Update();
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

        #region gvEvent_PageIndexChanging
        void gvEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEvent.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        #endregion

        #region gvEvent_RowCommand
        void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditEvent":
                    ObjectID = Convert.ToInt32(e.CommandArgument);
                    EditMode();
                    upnlControls.Update();
                    break;
            }
        }
        #endregion

        #region EventAdmin_UC_Load
        void EventAdmin_UC_Load(object sender, EventArgs e)
        {
            dvProblems.InnerText = string.Empty;
            if (!IsPostBack)
            {
                FillDDL();
                BeginSearchMode();
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
            for (int i = 0; i < gvEvent.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvEvent.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvEvent.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                EventManager.DeleteLogical(_id);
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
                DataLayer.Entities.Event oEvent = new DataLayer.Entities.Event();
                oEvent.CategoryID = Convert.ToInt32(ddlEventCategory.SelectedValue);
                oEvent.CreatedBy = SecurityContext.LoggedInUser.ID;
                oEvent.CreationDate = DateTime.Now;
                oEvent.DetailsHtml = txtDetails.Content;
                oEvent.Duration = 0;
                oEvent.Every = 0;
                try
                {
                    oEvent.FromDate = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    oEvent.FromDate = DateTime.Now;
                }
                try
                {
                    int FromHours = Convert.ToInt32(txtFromTimeHour.Text);
                    int FromMminute = Convert.ToInt32(txtFromTimeMminute.Text);
                    oEvent.FromDate = new DateTime(oEvent.FromDate.Year, oEvent.FromDate.Month, oEvent.FromDate.Day, FromHours, FromMminute, 0);
                }
                catch { }
                oEvent.ImageURL = UtilitiesManager.GetSavedFile(fUploader, true);
                oEvent.IsDeleted = false;
                oEvent.LocationID = Convert.ToInt32(ddlEventLocation.SelectedValue);
                oEvent.Name = txtName.Text;
                oEvent.Notify = 0;
                oEvent.Period = "";
                oEvent.Reminder = 0;
                oEvent.RepeatType = 0;
                try
                {
                    oEvent.ToDate = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                    oEvent.ToDate = DateTime.Now;
                }
                try
                {
                    int ToHours = Convert.ToInt32(txtToTimeHour.Text);
                    int ToMminute = Convert.ToInt32(txtToTimeMminute.Text);
                    oEvent.ToDate = new DateTime(oEvent.ToDate.Year, oEvent.ToDate.Month, oEvent.ToDate.Day, ToHours, ToMminute, 0);
                }
                catch { }
                SetEventRepeat(oEvent);
                EventManager.Add(oEvent);

                dvProblems.InnerText = Resources.EventResource.SavedSuccessfully;
                AddMode();
                BeginSearchMode();
                BindGrid();
                upnlSearch.Update();
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
            txtDetails.Content = string.Empty;
            ddlEventCategory.SelectedIndex = -1;
            ddlEventLocation.SelectedIndex = -1;
            txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFromTimeHour.Text = DateTime.Now.ToString("HH");
            txtFromTimeMminute.Text = DateTime.Now.ToString("mm");
            txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtToTimeHour.Text = DateTime.Now.ToString("HH");
            txtToTimeMminute.Text = DateTime.Now.ToString("mm");
            chkChangeImage.Visible = false;

            BeginRepeatOptions();

            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        #endregion

        #region SetEventRepeat
        void SetEventRepeat(DataLayer.Entities.Event oEvent)
        {
            RootEnums.EventRepeatType EventRepeatType = (RootEnums.EventRepeatType)Convert.ToInt32(ddlRepeatOptions.SelectedValue);
            switch (EventRepeatType)
            {
                case RootEnums.EventRepeatType.DoNotRepeat:
                    oEvent.RepeatType = RootEnums.EventRepeatType.DoNotRepeat;
                    oEvent.Every = 0;
                    oEvent.Period = string.Empty;
                    break;
                case RootEnums.EventRepeatType.Daily:
                    oEvent.RepeatType = RootEnums.EventRepeatType.Daily;
                    oEvent.Every = Convert.ToInt32(txtRepeatDailyEvery.Text);
                    oEvent.Period = string.Empty;
                    break;
                case RootEnums.EventRepeatType.Monthly:
                    oEvent.RepeatType = RootEnums.EventRepeatType.Monthly;
                    oEvent.Every = Convert.ToInt32(txtRepeatMonthlyEvery.Text);
                    oEvent.Period = ddlRepeatMonthlyPeriod.SelectedValue;
                    break;
                case RootEnums.EventRepeatType.Weekly:
                    oEvent.RepeatType = RootEnums.EventRepeatType.Weekly;
                    oEvent.Every = Convert.ToInt32(txtRepeatWeeklyEvery.Text);
                    oEvent.Period = string.Empty;
                    List<int> listDays = new List<int>();
                    for (int i = 0; i < chklRepeatWeeklyDays.Items.Count; i++)
                    {
                        if (chklRepeatWeeklyDays.Items[i].Selected)
                        {
                            listDays.Add(Convert.ToInt32(chklRepeatWeeklyDays.Items[i].Value));
                        }
                    }
                    for (int i = 0; i < listDays.Count; i++)
                    {
                        oEvent.Period += listDays[i];
                        if (i + 1 < listDays.Count)
                            oEvent.Period += ";";
                    }
                    break;
                case RootEnums.EventRepeatType.Yearly:
                    oEvent.RepeatType = RootEnums.EventRepeatType.Yearly;
                    oEvent.Every = Convert.ToInt32(txtRepeatYearlyEvery.Text);
                    oEvent.Period = string.Empty;
                    break;
                default:
                    oEvent.RepeatType = RootEnums.EventRepeatType.DoNotRepeat;
                    oEvent.Every = 0;
                    oEvent.Period = string.Empty;
                    break;
            }
        }
        #endregion

        #region GetEventRepeat
        void GetEventRepeat(DataLayer.Entities.Event oEvent)
        {
            ddlRepeatOptions.SelectedValue = ((int)oEvent.RepeatType).ToString();
            switch (oEvent.RepeatType)
            {
                case RootEnums.EventRepeatType.Daily:
                    txtRepeatDailyEvery.Text = oEvent.Every.ToString();
                    break;
                case RootEnums.EventRepeatType.Monthly:
                    txtRepeatMonthlyEvery.Text = oEvent.Every.ToString();
                    ddlRepeatMonthlyPeriod.SelectedValue = oEvent.Period;
                    break;
                case RootEnums.EventRepeatType.Weekly:
                    txtRepeatWeeklyEvery.Text = oEvent.Every.ToString();
                    List<int> daysOnWeek = new List<int>();
                    if (!string.IsNullOrEmpty(oEvent.Period))
                        daysOnWeek = oEvent.Period.Split(';').Select(p => Convert.ToInt32(p)).ToList();
                    for (int i = 0; i < chklRepeatWeeklyDays.Items.Count; i++)
                    {
                        chklRepeatWeeklyDays.Items[i].Selected = daysOnWeek.Contains(Convert.ToInt32(chklRepeatWeeklyDays.Items[i].Value));
                    }
                    break;
                case RootEnums.EventRepeatType.Yearly:
                    txtRepeatYearlyEvery.Text = oEvent.Every.ToString();
                    break;
            }
            ScriptManager.RegisterStartupScript(upnlControls, upnlControls.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "OnSelectedChangeRepeatOptions();", true);
        }
        #endregion

        #region EditMode
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                DataLayer.Entities.Event oEvent = EventManager.GetByID(ObjectID);
                if (oEvent != null)
                {
                    txtName.Text = oEvent.Name;
                    txtDetails.Content = oEvent.DetailsHtml;
                    ddlEventCategory.SelectedValue = oEvent.CategoryID.ToString();
                    ddlEventLocation.SelectedValue = oEvent.LocationID.ToString();
                    txtFromDate.Text = oEvent.FromDate.ToString("dd/MM/yyyy");
                    txtFromTimeHour.Text = oEvent.FromDate.ToString("HH");
                    txtFromTimeMminute.Text = oEvent.FromDate.ToString("mm");
                    txtToDate.Text = oEvent.ToDate.ToString("dd/MM/yyyy");
                    txtToTimeHour.Text = oEvent.ToDate.ToString("HH");
                    txtToTimeMminute.Text = oEvent.ToDate.ToString("mm");
                    chkChangeImage.Visible = true;
                    chkChangeImage.Checked = false;

                    BeginRepeatOptions();
                    GetEventRepeat(oEvent);

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    plcControls.Visible = true;
                }
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

        #region BeginRepeatOptions
        void BeginRepeatOptions()
        {
            ddlRepeatOptions.SelectedIndex = 0;
            txtRepeatDailyEvery.Text = ajaxRepeatDailyEvery.Minimum.ToString();
            txtRepeatWeeklyEvery.Text = ajaxRepeatWeeklyEvery.Minimum.ToString();
            for (int i = 0; i < chklRepeatWeeklyDays.Items.Count; i++)
            {
                chklRepeatWeeklyDays.Items[i].Selected = false;
            }
            txtRepeatMonthlyEvery.Text = ajaxRepeatMonthlyEvery.Minimum.ToString();
            ddlRepeatMonthlyPeriod.SelectedIndex = 0;
            txtRepeatYearlyEvery.Text = ajaxRepeatYearlyEvery.Minimum.ToString();
        }
        #endregion

        #region BindGrid
        private void BindGrid()
        {
            gvEvent.DataSource = EventManager.GetBySearch(txtSearch.Text, SelectedSearchCategoryID, SelectedSearchLocationID, SelectedSearchFromDate, SelectedSearchToDate);
            gvEvent.DataBind();
        }
        #endregion

        #region FillDDL
        void FillDDL()
        {
            ddlSearchCategory.DataSource = ddlEventCategory.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Event).ToList();
            ddlSearchCategory.DataTextField = ddlEventCategory.DataTextField = "Name";
            ddlSearchCategory.DataValueField = ddlEventCategory.DataValueField = "ID";
            ddlSearchCategory.DataBind();
            ddlEventCategory.DataBind();
            ddlSearchCategory.Items.Insert(0, new ListItem("", "-1"));

            ddlSearchLocation.DataSource = ddlEventLocation.DataSource = EventLocationManager.GetAll();
            ddlSearchLocation.DataTextField = ddlEventLocation.DataTextField = "Name";
            ddlSearchLocation.DataValueField = ddlEventLocation.DataValueField = "ID";
            ddlSearchLocation.DataBind();
            ddlEventLocation.DataBind();
            ddlSearchLocation.Items.Insert(0, new ListItem("", "-1"));

            ddlRepeatOptions.DataSource = UtilitiesManager.GetEnumDataSource(Resources.EventResource.ResourceManager, typeof(RootEnums.EventRepeatType));
            ddlRepeatOptions.DataTextField = "Key";
            ddlRepeatOptions.DataValueField = "Value";
            ddlRepeatOptions.DataBind();

            chklRepeatWeeklyDays.DataSource = UtilitiesManager.GetEnumDataSource(Resources.EventResource.ResourceManager, typeof(DayOfWeek));
            chklRepeatWeeklyDays.DataTextField = "Key";
            chklRepeatWeeklyDays.DataValueField = "Value";
            chklRepeatWeeklyDays.DataBind();

            ddlRepeatMonthlyPeriod.DataSource = UtilitiesManager.GetEnumDataSource(Resources.EventResource.ResourceManager, typeof(RootEnums.EventMonthlyType));
            ddlRepeatMonthlyPeriod.DataTextField = "Key";
            ddlRepeatMonthlyPeriod.DataValueField = "Value";
            ddlRepeatMonthlyPeriod.DataBind();
        }
        #endregion

        #region BeginSearchMode
        void BeginSearchMode()
        {
            txtSearch.Text = string.Empty;
            ddlSearchCategory.SelectedIndex = -1;
            ddlSearchLocation.SelectedIndex = -1;
            txtSearchFrom.Text = string.Empty;
            txtSearchTo.Text = string.Empty;
        }
        #endregion

        #endregion
    }
}