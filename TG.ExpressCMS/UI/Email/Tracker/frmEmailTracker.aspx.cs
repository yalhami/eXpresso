using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Email.Tracker
{
    public partial class frmEmailTracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[ConstantsManager.ContactGuid] != null)
            {
                string id = Request.QueryString[ConstantsManager.MailDelivered];
                int _id = 0; Int32.TryParse(id, out _id);
                EmailQueue emailQueue = EmailQueueManager.GetByID(_id);
                emailQueue.DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Delivered;
                EmailQueueManager.Update(emailQueue);
            }
        }
    }
}