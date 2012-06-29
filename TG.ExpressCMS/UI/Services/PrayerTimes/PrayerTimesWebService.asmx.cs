using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.IO;
using System.Web.Script.Services;

namespace TGExpressCMSServices
{
    /// <summary>
    /// Summary description for PrayerTimesWebService
    /// </summary>
    [WebService(Namespace = "TGExpressCMSServices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PrayerTimesWebService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, XmlSerializeString = true)]
        public string ExecutePrayerTimes(string xslID)
        {

            try
            {
                int _xslID = 0;
                int.TryParse(xslID, out _xslID);

                // Create a new Page and add the control to it.
                Page page = new Page();
                Control ucPrayerTimes = page.LoadControl("~/Services/PrayerTimes/PrayerTimes_UC.ascx");
                ucPrayerTimes.ID = "PrayerTimes_UC.ascx" + xslID;

                page.Controls.Add(ucPrayerTimes);
                ((TG.ExpressCMS.UI.Custums.PrayerTimes_UC)ucPrayerTimes).GetDailyXmlFile(_xslID);

                // Render the page and capture the resulting HTML.
                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(page, writer, false);

                // Return that HTML, as a string.
                return writer.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
