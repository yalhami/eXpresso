using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;
using System.Globalization;

namespace TG.ExpressCMS.UserPages
{
    public partial class Default : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Default_Load);
        }

        void Default_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.CreateSpecificCulture(CacheContext._DefaultSettings.DefaultLanguageCode);

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.CreateSpecificCulture(CacheContext._DefaultSettings.DefaultLanguageCode);
        }
        protected override void InitializeCulture()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
             System.Globalization.CultureInfo.CreateSpecificCulture(CacheContext._DefaultSettings.DefaultLanguageCode);

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.CreateSpecificCulture(CacheContext._DefaultSettings.DefaultLanguageCode);

            base.InitializeCulture();

        }
    }
}