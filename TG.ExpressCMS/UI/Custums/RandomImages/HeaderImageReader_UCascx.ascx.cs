using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;

namespace TG.ExpressCMS.UI.Custums.RandomImages
{
    public partial class HeaderImageReader_UCascx : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(HeaderImageReader_UCascx_Load);
        }

        void HeaderImageReader_UCascx_Load(object sender, EventArgs e)
        {
            ReadRandomImage();
        }
        private void ReadRandomImage()
        {
            try
            {
                string[] colFileInfo = Directory.GetFiles(Server.MapPath("~/Upload/UserUploads/HeaderImages/"));
                if (null == colFileInfo)
                {
                    setDefaultImage();
                    return;
                }
                int count = colFileInfo.Count();
                int rand = new Random().Next(0, count);
                if (null == colFileInfo[rand])
                {
                    setDefaultImage();
                    return;
                }
                img.ImageUrl = "~/Upload/UserUploads/HeaderImages/" + colFileInfo[rand].Substring(colFileInfo[rand].LastIndexOf('\\') + 1, colFileInfo[rand].Length - colFileInfo[rand].LastIndexOf('\\') - 1);

            }
            catch (Exception ex)
            {
            }
        }

        private void setDefaultImage()
        {
            img.ImageUrl = "~/Upload/UserUploads/HeaderImages/profile.jpg";
        }

    }
}