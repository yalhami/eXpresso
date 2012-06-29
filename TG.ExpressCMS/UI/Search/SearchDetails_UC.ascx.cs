using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI
{
    public partial class SearchDetails_UC : System.Web.UI.UserControl
    {
        public int PageSize
        {
            set
            {
                ViewState["PageSize"] = value;
            }
            get
            {
                if (ViewState["PageSize"] == null)
                {
                    return 6;
                }
                else
                {
                    return Convert.ToInt32(ViewState["PageSize"].ToString());
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SearchDetails_UC_Load);
        }

        void SearchDetails_UC_Load(object sender, EventArgs e)
        {
            ucMenuPager.PageSize = PageSize;
            ucNewsPager.PageSize = PageSize;
            dvMenuResult.InnerText = ""; NoResultNees.InnerText = "";

            if (null == Session["Keyword"])
                return;
            string keyword = Session["Keyword"].ToString();
            Session["Keyword"] = null;

            int totalRows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> colmenus = TG.ExpressCMS.DataLayer.Data.MenuItemManager.GetAllPagingSearch(ucMenuPager.From, ucMenuPager.To, ref totalRows, "%" + keyword + "%");
            ucMenuPager.TotalRows = totalRows;

            dtMenus.DataSource = colmenus;
            dtMenus.DataBind();

            if (totalRows < ucMenuPager.TotalPages)
                ucMenuPager.Visible = false;
            else
                ucMenuPager.Visible = true;

            int totalRows2 = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.NewsItem> colNews = TG.ExpressCMS.DataLayer.Data.NewsItemManager.GetAllBySearchAndPaging(ucNewsPager.From, ucNewsPager.To, ref totalRows2, "%" + keyword + "%");
            dtNews.DataSource = colNews;
            dtNews.DataBind();


            ucNewsPager.TotalRows = totalRows2;

            if (totalRows2 < ucNewsPager.TotalRows)
            {
                ucNewsPager.Visible = false;
            }
            else
                ucNewsPager.Visible = true;

            if (colmenus.Count == 0)
                dvMenuResult.InnerText = Resources.ExpressCMS.ResourceManager.GetString("Noresultformenus");
            if (colNews.Count == 0)
                NoResultNees.InnerText = Resources.ExpressCMS.ResourceManager.GetString("Noresultfornews");
        }
        protected string MakeStringShorter(string data)
        {
            if (data.Length > 120)
                return data.Substring(0, 118);
            else
                return data;
        }
    }
}