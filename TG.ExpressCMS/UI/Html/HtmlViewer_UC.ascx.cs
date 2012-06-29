using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Html
{
    public partial class HtmlViewer_UC : System.Web.UI.UserControl
    {
        public string HashName
        {
            set
            {
                ViewState["HashName"] = value;
            }
            get
            {
                if (ViewState["HashName"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return ViewState["HashName"].ToString();
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(HtmlViewer_UC_Load);
        }

        void HtmlViewer_UC_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
                GetHtmlCodeByHashName();
        }

        private void GetHtmlCodeByHashName()
        {
            HtmlItem _htmlItem = HtmlItemManager.GetByHashName(HashName);
            if (null != _htmlItem)
                dvData.InnerHtml = _htmlItem.Details;
        }
    }
}