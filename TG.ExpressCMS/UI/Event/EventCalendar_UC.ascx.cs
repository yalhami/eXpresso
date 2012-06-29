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
    public partial class EventCalendar_UC : System.Web.UI.UserControl
    {
        #region Global Members
        public int CategoryID
        {
            get;
            set;
        }
        List<DataLayer.Entities.Event> events
        {
            get;
            set;
        }
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            RegisterService();
            this.Load += new EventHandler(EventCalendar_UC_Load);
            this.cldEvent.DayRender += new DayRenderEventHandler(cldEvent_DayRender);
            base.OnInit(e);
        }
        #endregion

        #region cldEvent_DayRender
        protected void cldEvent_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
            e.Cell.Attributes.Add("onclick", "ShowCalendarEvents('" + e.Day.Date.Year + "','" + e.Day.Date.Month + "','" + e.Day.Date.Day + "','" + CategoryID + "','" + dvEventloading.ClientID + "','" + pnlEventData.ClientID + "','" + lbtnEvent.ClientID + "','" + pnlEvent.ClientID + "');return false;");

            if (events == null || events.Count <= 0)
                return;

            TableCell oTableCell = e.Cell;
            LiteralControl lControl = (LiteralControl)e.Cell.Controls[0];
            oTableCell.Controls.Clear();
            oTableCell.Controls.Add(lControl);
            foreach (DataLayer.Entities.Event oEvent in events)
            {
                if (EventManager.ValidAddEvent(oEvent, e.Day.Date))
                {
                    oTableCell.BackColor = System.Drawing.Color.FromName(hdColor.Value);
                    e.Cell.Style.Add(HtmlTextWriterStyle.Cursor, "Pointer");
                    string toolTip = oTableCell.ToolTip;
                    if (string.IsNullOrEmpty(toolTip))
                    {
                        toolTip = oEvent.Name;
                    }
                    else
                    {
                        toolTip += Environment.NewLine + oEvent.Name;

                    }

                    oTableCell.ToolTip = toolTip;
                }
            }
        }
        #endregion

        #region EventCalendar_UC_Load
        protected void EventCalendar_UC_Load(object sender, EventArgs e)
        {
            events = EventManager.GetByCategoryID(CategoryID);
        }
        #endregion

        #endregion

        #region Method

        #region RegisterService
        private void RegisterService()
        {
            ScriptManager CurrentScriptManager = ScriptManager.GetCurrent(this.Page);
            CurrentScriptManager.Services.Add(new ServiceReference("~/Services/Event/EventWebService.asmx"));
        }
        #endregion

        #endregion
    }
}