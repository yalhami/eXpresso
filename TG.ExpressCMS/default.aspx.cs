using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS
{
    public partial class _default : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Load += new EventHandler(_default_Load);
        }

        void _default_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Userpages/");
        }
    }
}