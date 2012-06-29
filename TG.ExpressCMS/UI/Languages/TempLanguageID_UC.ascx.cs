using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Languages
{
    public partial class TempLanguageID_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(TempLanguageID_UC_Load);
            lblSwitchtoArabic.Click += new EventHandler(lblSwitchtoArabic_Click);
        }

        void lblSwitchtoArabic_Click(object sender, EventArgs e)
        {
            string query = "";
            string name = "";
            if (Request.QueryString["NewsID"] != null)
            {
                int newsid = 0;
                Int32.TryParse(Request.QueryString["NewsID"], out newsid);
                if (newsid == 0)
                {
                    Response.Redirect(GetsetLang(ref name) + "/Userpages/");
                    return;
                }
                NewsItem _item = NewsItemManager.GetByID(newsid);
                if (_item == null)
                {
                    Response.Redirect(GetsetLang(ref name) + "/Userpages/");
                    return;
                }

                NewsItem _item2 = NewsItemManager.GetByID(_item.RefLangID);
                if (_item2 == null)
                {
                    Response.Redirect(GetsetLang(ref name) + "/Userpages/");
                    return;
                }
                Response.Redirect(GetsetLang(ref name) + _item2.Url);
            }
            else

                if (Request.QueryString["MenuID"] != null)
                {
                    int menuid = 0;
                    Int32.TryParse(Request.QueryString["MenuID"], out menuid);
                    if (menuid == 0)
                    {
                        Response.Redirect(GetsetLang(ref name) + "/Userpages/");
                        return;
                    }
                    TG.ExpressCMS.DataLayer.Entities.MenuItem _item = MenuItemManager.GetByID(menuid);
                    if (_item == null)
                    {
                        Response.Redirect(GetsetLang(ref name) + "/Userpages/");
                        return;
                    }
                    TG.ExpressCMS.DataLayer.Entities.MenuItem _item2 = MenuItemManager.GetByID(_item.RefLangID);
                    if (_item2 == null)
                    {
                        Response.Redirect(GetsetLang(ref name) + "/Userpages/");
                        return;
                    }
                    Response.Redirect(GetsetLang(ref name) + _item2.Url);
                }
                else
                // if (Request.Url.Segments[2] != null)
                {
                    string url = (GetsetLang(ref name) + Request.Url.PathAndQuery);
                    url = url.Replace("/ar/", "/");
                    url = url.Replace("//ar/", "/");
                    Response.Redirect(url);
                }
        }

        void TempLanguageID_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = "";
                GetsetLang(ref name);
            }
        }
        private string GetsetLang(ref string name)
        {
            string langName = "";
            string otherVersionUrl = string.Empty;
            if (ExpressoConfig.SecurityConfigElement.ArabicVersionUrl != string.Empty)
            {
                otherVersionUrl = ExpressoConfig.SecurityConfigElement.ArabicVersionUrl;
                langName = "عربي";
            }
            if (ExpressoConfig.SecurityConfigElement.EnglishVersionUrl != string.Empty)
            {
                otherVersionUrl = ExpressoConfig.SecurityConfigElement.EnglishVersionUrl;
                langName = "English";
            }
            lblSwitchtoArabic.Text = langName;
            return otherVersionUrl;
        }
    }
}