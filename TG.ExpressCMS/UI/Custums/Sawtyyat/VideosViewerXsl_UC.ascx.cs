using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml.Xsl;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI
{

    public partial class VideosViewerXsl_UC : System.Web.UI.UserControl
    {
        public int XSLID
        {
            set
            {
                ViewState["XSLID"] = value;
            }
            get
            {
                if (ViewState["XSLID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["XSLID"].ToString());
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
            this.Load += new EventHandler(GalleryViewerXsl_UC_Load);
            base.OnInit(e);
        }

        void GalleryViewerXsl_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RenderData();
        }
        private void RenderData()
        {
            XmlDocument xDoc = SawtyyatManager.GetAllByTypeAsXml(DataLayer.Enums.RootEnums.AudioVideoType.Video, CategoryID);

            XslTemplate xslTemplate = XslTemplateManager.GetByID(XSLID);
            if (null == xslTemplate)
                return;
            XsltArgumentList arguments = new XsltArgumentList();
            arguments.AddExtensionObject("obj:CategoryViewer", this);

            string _html = UtilitiesManager.TransformXMLWithXSLText(xDoc.OuterXml, xslTemplate.Details, arguments);
            dvdata.InnerHtml = _html;
        }
        /// <summary>
        /// Get Image Url.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string GetImageUrl(string image)
        {
            return ("/Upload/Files/Gallery/" + image);
        }
        public string GetAudVidUrl(string id)
        {
            return "/Userpages/AVDetails.aspx?" + ConstantsManager.AVID + "=" + id;
        }
    }
}