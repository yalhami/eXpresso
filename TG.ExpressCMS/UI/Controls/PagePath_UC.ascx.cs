using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Controls
{
    public partial class PagePath_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        public void BindPath(List<PagePath> allPaths)
        {
            if (allPaths.Count > 0)
            {
                allPaths[allPaths.Count - 1].Url = string.Empty;
            }

            dlPath.DataSource = allPaths;
            dlPath.DataBind();
        }
    }
}