using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Collections;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI
{
    public partial class BannerUserSide_UC : System.Web.UI.UserControl
    {
        public RootEnums.BannerType Type
        {
            set
            {
                ViewState["Type"] = value;
            }
            get
            {
                if (ViewState["Type"] == null)
                {
                    return RootEnums.BannerType.StaticBased;
                }
                else
                {
                    return (RootEnums.BannerType)(Convert.ToInt32(ViewState["Type"]));
                }
            }
        }
        public int CategoryID
        {
            set
            {
                ViewState["CategoryID"] = value;
            }
            get
            {
                if (ViewState["CategoryID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["CategoryID"].ToString());
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(BannerUserSide_UC_Load);
        }

        void BannerUserSide_UC_Load(object sender, EventArgs e)
        {
            GetItemByTypeAndCategory();
        }
        private void GetItemByTypeAndCategory()
        {
            IList<TG.ExpressCMS.DataLayer.Entities.Banner> colBanners = BannerManager.GetAllPublishedBanner().Where(t => t.CategoryID == CategoryID && t.Type == Type).ToList();
            int count = colBanners.Count;

            int rand = new Random().Next(0, count);
            if (colBanners.Count == 0)
            {
                this.Visible = false;
                return;
            }
            if (colBanners[rand] != null)
            {
                dvUserSide.InnerHtml = colBanners[rand].UserSide;
                aLink.HRef = colBanners[rand].Url;
                aLink.Target = "_blank";
            }

        }
        public string GetImageUrl(string image)
        {
            if (image != string.Empty)
                return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath + image;
            else
                return ResolveUrl("~") + "App_themes/UserSides/images/defaultcat.png";
        }
    }
}