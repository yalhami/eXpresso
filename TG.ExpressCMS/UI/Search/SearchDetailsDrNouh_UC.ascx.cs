using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI
{
    public partial class SearchDetailsDrNouh_UC : System.Web.UI.UserControl
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
            this.ucMenuPager.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(ucMenuPager_btnGoClick);
            this.ucMenuPager.BackClick += new UI.Controls.CustomPager_UC.btnBack(ucMenuPager_BackClick);
            this.ucMenuPager.NextClick += new UI.Controls.CustomPager_UC.btnNext(ucMenuPager_NextClick);

            this.ucNewsPager.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(ucNewsPager_btnGoClick);
            this.ucNewsPager.NextClick += new UI.Controls.CustomPager_UC.btnNext(ucNewsPager_NextClick);
            this.ucNewsPager.BackClick += new UI.Controls.CustomPager_UC.btnBack(ucNewsPager_BackClick);

            this.ucFatwaPager.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(ucFatwaPager_btnGoClick);
            this.ucFatwaPager.NextClick += new UI.Controls.CustomPager_UC.btnNext(ucFatwaPager_NextClick);
            this.ucFatwaPager.BackClick += new UI.Controls.CustomPager_UC.btnBack(ucFatwaPager_BackClick);

            this.ucAudVid.NextClick += new UI.Controls.CustomPager_UC.btnNext(ucAudVid_NextClick);
            this.ucAudVid.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(ucAudVid_btnGoClick);
            this.ucAudVid.BackClick += new UI.Controls.CustomPager_UC.btnBack(ucAudVid_BackClick);
        }

        void ucAudVid_btnGoClick()
        {
            MakeSearch();
        }

        void ucAudVid_BackClick()
        {
            MakeSearch();
        }

        void ucAudVid_NextClick()
        {
            MakeSearch();
        }

        void ucFatwaPager_NextClick()
        {
            MakeSearch();
        }

        void ucFatwaPager_BackClick()
        {
            MakeSearch();
        }

        void ucFatwaPager_btnGoClick()
        {
            MakeSearch();
        }

        void ucNewsPager_BackClick()
        {
            MakeSearch();
        }

        void ucNewsPager_NextClick()
        {
            MakeSearch();
        }

        void ucNewsPager_btnGoClick()
        {
            MakeSearch();
        }

        void ucMenuPager_NextClick()
        {
            MakeSearch();
        }

        void ucMenuPager_BackClick()
        {
            MakeSearch();
        }

        void ucMenuPager_btnGoClick()
        {
            MakeSearch();
        }

        void SearchDetails_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Keyword"] = "";
                ucMenuPager.PageSize = PageSize;
                ucNewsPager.PageSize = PageSize;
                ucAudVid.PageSize = PageSize;
                ucFatwaPager.PageSize = PageSize;
            }
            MakeSearch();
        }
        protected string MakeStringShorter(string data)
        {
            if (data.Length > 120)
                return data.Substring(0, 118) + "........";
            else
                return data + "......";
        }
        private void MakeSearch()
        {

            dvMenuResult.InnerText = ""; NoResultNees.InnerText = ""; dvFatawaMessages.InnerText = "";

            if (null == Session["Keyword"] && null == ViewState["Keyword"])
                return;
            string keyword = "";
            if (null != Session["Keyword"])
            {
                keyword = Session["Keyword"].ToString();
                ViewState["Keyword"] = null;
            }
            if (null != ViewState["Keyword"])
                keyword = ViewState["Keyword"].ToString();

            Session["Keyword"] = null;

            ViewState["Keyword"] = keyword;

            int totalRows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> colmenus = TG.ExpressCMS.DataLayer.Data.MenuItemManager.GetAllPagingSearch(ucMenuPager.From, ucMenuPager.To, ref totalRows, "%" + keyword + "%");
            ucMenuPager.TotalRows = totalRows;

            dtMenus.DataSource = colmenus;
            dtMenus.DataBind();

            if (totalRows < ucMenuPager.PageSize)
                ucMenuPager.Visible = false;
            else
                ucMenuPager.Visible = true;

            int totalRows2 = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.NewsItem> colNews = TG.ExpressCMS.DataLayer.Data.NewsItemManager.GetAllBySearchAndPaging(ucNewsPager.From, ucNewsPager.To, ref totalRows2, "%" + keyword + "%");
            dtNews.DataSource = colNews;
            dtNews.DataBind();


            ucNewsPager.TotalRows = totalRows2;

            if (totalRows2 < ucNewsPager.PageSize)
            {
                ucNewsPager.Visible = false;
            }
            else
                ucNewsPager.Visible = true;

            if (colmenus.Count == 0)
            {
                dvMenuResult.InnerText = Resources.ExpressCMS.ResourceManager.GetString("Noresultformenus");
                pnlMenus.Visible = false;
            }
            else
            {
                pnlMenus.Visible = true;
            }
            
            if (colNews.Count == 0)
            {
                NoResultNees.InnerText = Resources.ExpressCMS.ResourceManager.GetString("Noresultfornews");
                pnlNews.Visible = false;
            }
            else
            {
                pnlNews.Visible = true;
            }


            int totRows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.Fatawa> colFatawa = TG.ExpressCMS.DataLayer.Data.FatawaManager.GetAllByCategoryPaging(ucFatwaPager.From, ucFatwaPager.To, ref totRows, -1, 1, "%" + keyword + "%");
            ucFatwaPager.TotalRows = totRows;

            dtFatawa.DataSource = colFatawa;
            dtFatawa.DataBind();

            if (totRows < ucFatwaPager.PageSize)
                ucFatwaPager.Visible = false;
            else
                ucFatwaPager.Visible = true;
            if (totRows == 0)
            {
                dvFatawaMessages.InnerText = Resources.ExpressCMS.NofatawaFound;
                pnlFatawa.Visible = false;
            }
            else
            {
                dvFatawaMessages.InnerText = "";
                pnlFatawa.Visible = true;
            }

            #region Audios Videos
            int totalAudios = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colAudios = TG.ExpressCMS.DataLayer.Data.SawtyyatManager.GetAllByType(DataLayer.Enums.RootEnums.AudioVideoType.Both, ucAudVid.From, ucAudVid.To, ref totalAudios, keyword, -1);
            ucAudVid.TotalRows = totalAudios;

            dtAudVid.DataSource = colAudios;
            dtAudVid.DataBind();

            if (totalAudios < ucAudVid.PageSize)
                ucAudVid.Visible = false;
            else
                ucAudVid.Visible = true;
            if (totalAudios == 0)
            {
                dvAudVidMessages.InnerText = Resources.ExpressCMS.NoresultforAudiosVideos;
                pnlAudVide.Visible = false;
            }
            else
            {
                pnlAudVide.Visible = true;
                dvAudVidMessages.InnerText = "";
            }
            #endregion

        }
        protected string GetFatawaUrl(string id)
        {
            return "~/UserPages/FatwaDetails.aspx?Fatwaid=" + id;
        }
        protected string GetAudVidUrl(string id)
        {
            return "~/Userpages/AVDetails.aspx?" + ConstantsManager.AVID + "=" + id;
        }
        protected string GetType(int type)
        {

            if (type == 1)
                return "المرئيات";
            else
                return "الصوتيات";
        }
    }
}