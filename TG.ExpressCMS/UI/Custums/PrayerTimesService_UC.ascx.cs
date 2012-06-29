using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Custums
{
    public partial class PrayerTimesService_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ScriptManager currentScriptManager = ScriptManager.GetCurrent(this.Page);
            ServiceReference sReference = new ServiceReference();
            sReference.Path = "~/Services/PrayerTimes/PrayerTimesWebService.asmx";
            sReference.InlineScript = true;
            currentScriptManager.Services.Add(sReference);
        }
    }
}