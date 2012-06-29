using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using System.Threading;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UserPages
{
    public partial class UserSide : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(UserSide_Load);

        }

        void UserSide_Load(object sender, EventArgs e)
        {
            //   this.Page.Title = GetPageTitle();
        }
        protected string GetPageTitle()
        {
            string defsitename = CacheContext._DefaultSettings.Name;
            if (Request.QueryString.Count == 0)
                return defsitename;
            if (null == Request.QueryString[0])
                return defsitename;


            string url = Request.Url.Query;
            if (url.Contains("MenuID"))
            {
                int queryStringQuery = 0;

                Int32.TryParse(Request.QueryString[0], out queryStringQuery);
                if (queryStringQuery == 0)
                    return defsitename;

                TG.ExpressCMS.DataLayer.Entities.MenuItem _menuItem = MenuItemManager.GetByID(queryStringQuery);
                if (null == _menuItem)
                    return defsitename;
                defsitename = defsitename + " | " + _menuItem.Name;
            }
            if (url.Contains(Utilities.ConstantsManager.NewsGUID))
            {
                TG.ExpressCMS.DataLayer.Entities.NewsItem _newsItem = NewsItemManager.GetByGUID(Request.QueryString[0].ToString());
                if (null == _newsItem)
                    return defsitename;
                defsitename = defsitename + " | " + _newsItem.Name;
            }
            return defsitename;
        }
        protected string GetHijriDate()
        {
            System.Globalization.DateTimeFormatInfo hijridate = new System.Globalization.CultureInfo("ar-JO").DateTimeFormat;
            hijridate.Calendar = new System.Globalization.HijriCalendar();
            hijridate.ShortDatePattern = "dd MMMM yyyy";
            hijridate.MonthDayPattern = "MMMM";
            return DateTime.Now.ToString("d", hijridate);
        }
        protected string GetArabicGlobalizedDate()
        {
            System.Globalization.DateTimeFormatInfo hijridate = new System.Globalization.CultureInfo("ar-JO").DateTimeFormat;
            hijridate.Calendar = new System.Globalization.HijriCalendar();
            hijridate.ShortDatePattern = "dd MMMM yyyy";
            hijridate.MonthDayPattern = "MMMM";
            return DateTime.Now.ToString("d", hijridate);
        }

    }
}