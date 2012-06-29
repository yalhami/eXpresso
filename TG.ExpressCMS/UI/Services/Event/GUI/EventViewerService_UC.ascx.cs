using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Services
{
    public partial class EventViewerService_UC : UserControl
    {
        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        #endregion

        #region Methods

        #region LoadEvents
        public void LoadEvents(DateTime EventDateTime, int CategoryID)
        {
            DateTime dateTime = EventDateTime;
            DateTime dateTimeTo = EventDateTime;

            List<DataLayer.Entities.Event> colEvents = EventManager.GetBySearch(string.Empty, CategoryID, -1, dateTime, dateTimeTo);
            IList<DataLayer.Entities.Event> result = new List<DataLayer.Entities.Event>();
            foreach (DataLayer.Entities.Event tempEvent in colEvents)
            {
                if (EventManager.ValidAddEvent(tempEvent, dateTime))
                {
                    result.Add(tempEvent);
                }
            }
            if (result.Count > 0)
            {
                dlsEvent.Visible = true;
                dlsEvent.DataSource = result;
                dlsEvent.DataBind();
                dvNoRecords.Visible = false;
            }
            else
            {
                dlsEvent.Visible = false;
                dvNoRecords.Visible = true;
                dvNoRecords.InnerHtml = Resources.EventResource.NoEventsThisDay;
            }
        }
        #endregion

        #region GetURLDetails
        protected string GetURLDetails(int EventID)
        {
            return UtilitiesManager.GetEventDetailsURL(EventID);
        }
        #endregion

        #region GetDate
        protected string GetDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy");
        }
        #endregion

        #region GetTime
        protected string GetTime(DateTime dateTime)
        {
            return dateTime.ToString("hh:mm tt");
        }
        #endregion

        #region GetEventTitle
        protected string GetEventTitle(string title)
        {
            return title;
        }
        #endregion

        #endregion
    }
}