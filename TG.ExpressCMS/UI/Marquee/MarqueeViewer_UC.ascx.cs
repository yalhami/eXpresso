using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using System.Collections;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.Marquee
{
    public partial class MarqueeViewer_UC : System.Web.UI.UserControl
    {
        public enum MarqueeDirection
        {
            Right = 1, Left = 2, Up = 3, Down = 4
        }
        public MarqueeDirection Direction
        {
            set
            {
                ViewState["Direction"] = value;
            }
            get
            {
                if (ViewState["Direction"] == null)
                {
                    return MarqueeDirection.Left;
                }
                else
                {
                    return (MarqueeDirection)Convert.ToInt32(Enum.Parse(typeof(MarqueeDirection), (ViewState["Direction"].ToString()), true));
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
        public int ImageSeperatorWidth
        {
            set
            {
                ViewState["ImageSeperatorWidth"] = value;
            }
            get
            {
                if (ViewState["ImageSeperatorWidth"] == null)
                {
                    return 15;
                }
                else
                {
                    return Convert.ToInt32(ViewState["ImageSeperatorWidth"].ToString());
                }
            }
        }
        public int ImageSeperatorHeight
        {
            set
            {
                ViewState["ImageSeperatorHeight"] = value;
            }
            get
            {
                if (ViewState["ImageSeperatorHeight"] == null)
                {
                    return 15;
                }
                else
                {
                    return Convert.ToInt32(ViewState["ImageSeperatorHeight"].ToString());
                }
            }
        }
        public int Speed
        {
            set
            {
                ViewState["Speed"] = value;
            }
            get
            {
                if (ViewState["Speed"] == null)
                {
                    return 3;
                }
                else
                {
                    return Convert.ToInt32(ViewState["Speed"].ToString());
                }
            }
        }
        public string Width
        {
            set
            {
                ViewState["Width"] = value;
            }
            get
            {
                if (ViewState["Width"] == null)
                {
                    return "100%";
                }
                else
                {
                    return (ViewState["Width"].ToString());
                }
            }
        }
        public string Height
        {
            set
            {
                ViewState["Height"] = value;
            }
            get
            {
                if (ViewState["Height"] == null)
                {
                    return "40";
                }
                else
                {
                    return (ViewState["Height"].ToString());
                }
            }
        }
        public string CssClass
        {
            set
            {
                ViewState["CssClass"] = value;
            }
            get
            {
                if (ViewState["CssClass"] == null)
                {
                    return "";
                }
                else
                {
                    return (ViewState["CssClass"].ToString());
                }
            }
        }

        private Category _Category
        {
            get
            {
                if (CategoryID <= 0)
                    return null;
                if (HttpContext.Current.Session["_Category"] == null)
                {
                    HttpContext.Current.Session["_Category"] = CategoryManager.GetByID(CategoryID);
                    return (Category)HttpContext.Current.Session["_Category"];
                }
                else
                {
                    return (Category)HttpContext.Current.Session["_Category"];
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.Load += new EventHandler(MarqueeViewer_UC_Load);
        }

        void MarqueeViewer_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderMarquee();
            }
        }

        private void RenderMarquee()
        {
            IList<MarqueeItems> colMarqueeItems = MarqueeItemsManager.GetbyCategoryID(CategoryID);
            if (null == colMarqueeItems)
                return;
            HtmlGenericControl genericControls = new HtmlGenericControl("Marquee");
            genericControls.Attributes.Add("class", CssClass);
            genericControls.Attributes.Add("scrollAmount", Speed.ToString());
            genericControls.Attributes.Add("behavior", "scroll");
            genericControls.Attributes.Add("direction", Direction.ToString());
            genericControls.Attributes.Add("Width", Width);
            genericControls.Attributes.Add("Height", Height);
            genericControls.Attributes.Add("onMouseover", "stop()");

            genericControls.Attributes.Add("onMouseout", "start()");
            string _innerHtml = "<div class=\"marqueeTop\">";
            foreach (MarqueeItems item in colMarqueeItems)
            {
                if (_Category.Image != "")
                    _innerHtml += GetEntityMarquee(item) + GetImageSeperator(item);
                else
                    _innerHtml += GetEntityMarquee1(item);
            }
            genericControls.InnerHtml = _innerHtml + "</div>";

            dvData.Controls.Add(genericControls);
        }

        private string GetEntityMarquee1(MarqueeItems _marqueeItems)
        {
            string _item = string.Empty;

            _item += "<a href=" + _marqueeItems.Url + ">" + _marqueeItems.Text + " | </a>";

            return _item;
        }
       
        private string GetEntityMarquee(MarqueeItems _marqueeItems)
        {
            string _item = string.Empty;

            _item += "<a href=" + _marqueeItems.Url + ">" + _marqueeItems.Text + "</a>";

            return _item;
        }

        private string GetImageSeperator(MarqueeItems _marqueeItems)
        {
            string _item = string.Empty;

            _item += "<img src=" + GetFullImagePath(_Category.Image) + " width=" + ImageSeperatorWidth + " Height=" + ImageSeperatorHeight + "/>";

            return _item;
        }

        private string GetFullImagePath(string imageURL)
        {
            return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath.Replace("~", "") + imageURL;
        }
    }
}