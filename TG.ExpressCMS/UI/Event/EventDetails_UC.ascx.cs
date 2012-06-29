using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Event
{
    public partial class EventDetails_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(EventDetails_UC_Load);
            base.OnInit(e);
        }
        #endregion

        #region EventDetails_UC_Load
        protected void EventDetails_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int EventID = 0;
                int.TryParse(Request.QueryString["EventID"], out EventID);
                BindEvent(EventID);
            }
        }
        #endregion

        #endregion

        #region Methods

        private void BindEvent(int EventID)
        {
            if (EventID <= 0)
            {
                plcEvent.Visible = false;
                return;
            }

            DataLayer.Entities.Event oEvent = EventManager.GetByID(EventID);
            if (oEvent == null)
            {
                plcEvent.Visible = false;
                return;
            }

            dvimage.Visible = !string.IsNullOrEmpty(oEvent.ImageURL);
            imgEvent.ImageUrl = oEvent.ImageURL;
            dvEventName.InnerText = oEvent.Name;
            dvStartDate.InnerText = oEvent.FromDate.ToString("dd/MM/yyyy");
            dvStartTime.InnerText = oEvent.FromDate.ToString("hh:mm tt");
            dvEndDate.InnerText = oEvent.ToDate.ToString("dd/MM/yyyy");
            dvEndTime.InnerText = oEvent.ToDate.ToString("hh:mm tt");
            dvEventDetails.InnerHtml = oEvent.DetailsHtml;


            EventLocation _eventloc = EventLocationManager.GetByID(oEvent.LocationID);
            if (null != _eventloc)
            {
                dvLocation.InnerText = _eventloc.Name;
            }
            plcEvent.Visible = true;
        }

        #endregion
    }
}