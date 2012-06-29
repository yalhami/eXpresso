using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Text;
using System.Collections;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Menus
{
    public partial class SitePath_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SitePath_UC_Load);
        }

        void SitePath_UC_Load(object sender, EventArgs e)
        {
            BindMenuSitePath();
            BindPageSitePath();
            BindNewsSitePath();
        }
        #region "Menu"
        private void BindMenuSitePath()
        {
            StringBuilder _builder = new StringBuilder();
            _builder.Append("<a href='" + ResolveUrl("~/Userpages/") + "'>");
            _builder.Append("" + Resources.ExpressCMS.Home + " >>");
            _builder.Append("</a>");

            if (Request.QueryString["MenuID"] == null)
                return;

            int menuid = 0;
            Int32.TryParse(Request.QueryString["MenuID"], out menuid);

            IList<MenuItem> colMenus = MenuItemManager.GetAll().Where(t => t.ID == menuid).ToList();
            if (colMenus.Count != 0)
            {
                for (int i = 0; i < colMenus.Count; i++)
                {
                    _builder.Append(GetMenu(colMenus[i]));
                    _builder.Append("<a href='" + ResolveUrl("~/Userpages/Menudetails.aspx?MenuID=") + menuid + "'>");
                    _builder.Append(colMenus[i].Name + ">>");
                    _builder.Append("</a>");
                }
            }
            else
            {
                MenuItem _menuItem = MenuItemManager.GetByID(menuid);
                _builder.Append("<a href='" + ResolveUrl("~/Userpages/Menudetails.aspx?MenuID=") + menuid + "'>");
                _builder.Append(_menuItem.Name + " >>");
                _builder.Append("</a>");
            }

            dvInnerHtml.InnerHtml = _builder.ToString();
        }
        StringBuilder _builder = new StringBuilder();
        private string GetMenu(MenuItem _item)
        {

            IList<MenuItem> colMenus = MenuItemManager.GetAll().Where(t => t.ID == _item.MenuID).ToList();
            if (colMenus.Count == 0)
                return _builder.ToString();
            for (int i = colMenus.Count - 1; i >= 0; i--)
            {
                _builder.Insert(0, "<a href='" + ResolveUrl("~/Userpages/Menudetails.aspx?MenuID=") + colMenus[i].ID + "'>" + colMenus[i].Name + ">>");

                _builder.Insert(0, "</a>");

                if (null != colMenus[i])
                    GetMenu(colMenus[i]);
            }
            return _builder.ToString();
        }
        #endregion

        #region "News"
        private void BindNewsSitePath()
        {
            StringBuilder _builder = new StringBuilder();
            _builder.Append("<a href='" + ResolveUrl("~/Userpages/") + "'>");
            _builder.Append("" + Resources.ExpressCMS.Home + " >>");
            _builder.Append("</a>");

            if (Request.QueryString["NewsID"] == null)
                return;

            int newsId = 0;
            Int32.TryParse(Request.QueryString["NewsID"], out newsId);

            NewsItem _News = NewsItemManager.GetByID(newsId);

            //_builder.Append("<a href='" + ResolveUrl("~/Userpages/Category") + "'>");
            //_builder.Append("Home >>");
            //_builder.Append("</a>");

            MenuItem _menuItem = MenuItemManager.GetByID(newsId);
            _builder.Append("<a href='" + ResolveUrl("~/Userpages/NewsDetails.aspx?NewsId=") + newsId + "'>");
            _builder.Append(_News.Name + " >>");
            _builder.Append("</a>");


            dvInnerHtml.InnerHtml = _builder.ToString();
        }

        #endregion

        #region "Page"
        private void BindPageSitePath()
        {
            StringBuilder _builder = new StringBuilder();
            _builder.Append("<a href='" + ResolveUrl("~/Userpages/") + "'>");
            _builder.Append("" + Resources.ExpressCMS.Home + " >>");
            _builder.Append("</a>");


            if (Request.QueryString["MenuID"] != null || Request.QueryString["NewsId"] != null)
                return;

            CMSPage _page = CMSPageManager.GetAll().Where(t => t.Name.ToLower().Contains(Request.Url.Segments[2].ToLower())).FirstOrDefault();
            if (_page == null)
                return;

            _builder.Append("<a href='" + ResolveUrl("~/Userpages/") + _page.Name + "'>");
            _builder.Append(_page.Description + " >>");
            _builder.Append("</a>");


            dvInnerHtml.InnerHtml = _builder.ToString();
        }

        #endregion
    }
}