using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI
{
    public partial class Search_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Search_UC_Load);
            this.btnSearch.Click += new ImageClickEventHandler(btnSearch_Click);
        }

        void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (txtKeyword.Text == string.Empty)
                return;
            Session["Keyword"] = txtKeyword.Text;

            Response.Redirect(ConfigContext.GetSearchDetailsPage);
        }

      
        void Search_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtKeyword.Text = string.Empty;      
            }
        }
    }
}