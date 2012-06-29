using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Data;
using System.IO;

namespace TG.ExpressCMS.UI.Custums
{
    public partial class AudiosVideosDetails_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(AudiosVideosDetails_UC_Load);
            this.lbListen.Click += new EventHandler(lbListen_Click);
            base.OnInit(e);
        }

        void lbListen_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[ConstantsManager.AVID] == null)
            {
                dvMessages.InnerText = Resources.ExpressCMS.nofilesfound;
                return;
            }
            int id = 0;
            Int32.TryParse(Request.QueryString[ConstantsManager.AVID], out id);
            TG.ExpressCMS.DataLayer.Entities.Sawtyyat _audvid = SawtyyatManager.GetByID(id);

            if (null == _audvid)
            {
                dvMessages.InnerText = Resources.ExpressCMS.nofilesfound;
                return;
            }


            StreamReader _reader = new StreamReader(Server.MapPath("~/UI/Custums/Sawtyyat/ref.txt"));
            string data = _reader.ReadToEnd();
            data = data.Replace("XXX", CacheContext._DefaultSettings.DefaultUrl + "/Upload/Files/" + _audvid.Path.ToString().Replace("mp3", "m3u"));
            dvPlayNow.InnerHtml = data;

        }

        void AudiosVideosDetails_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";

            if (Request.QueryString[ConstantsManager.AVID] == null)
            {
                dvMessages.InnerText = Resources.ExpressCMS.nofilesfound;
                return;
            }
            int id = 0;
            Int32.TryParse(Request.QueryString[ConstantsManager.AVID], out id);
            TG.ExpressCMS.DataLayer.Entities.Sawtyyat _audvid = SawtyyatManager.GetByID(id);

            if (null == _audvid)
            {
                dvMessages.InnerText = Resources.ExpressCMS.nofilesfound;
                return;
            }

            lblAudVidDetails.Text = _audvid.Name;
            switch (_audvid.Type)
            {
                case TG.ExpressCMS.DataLayer.Enums.RootEnums.AudioVideoType.Audio:
                    pnlAudio.Visible = true;
                    pnlVideo.Visible = false;
                    lblFileName.Text = lblFileName.ToolTip = _audvid.Name;
                    //hypDownload.NavigateUrl = GetDownLoadUrl(_audvid.Path);
                    //HyperLink1.NavigateUrl = GetDownLoadUrl2(_audvid.Path);


                    break;
                case TG.ExpressCMS.DataLayer.Enums.RootEnums.AudioVideoType.Video:
                    pnlAudio.Visible = false;
                    pnlVideo.Visible = true;
                    _audvid.Path = _audvid.Path.Replace("220", "450");
                    _audvid.Path = _audvid.Path.Replace("240", "500");
                    _audvid.Path = _audvid.Path.Replace("210", "450");
                    embedInner.InnerHtml = _audvid.Path;
                    lblFileName2.Text = lblFileName2.ToolTip = _audvid.Name;
                    break;
                default:
                    pnlAudio.Visible = false;
                    pnlVideo.Visible = false;
                    break;
            }
        }
        protected string GetDownLoadUrl(string fileName)
        {
            return "~" + "/UI/Custums/Sawtyyat/DownloadSawtyyat.ashx?FileName=" + fileName;
        }
        protected string GetDownLoadUrl2(string fileName)
        {
            return "~" + "/UI/Custums/Sawtyyat/Handler1.ashx?FileName=" + fileName;
        }
    }
}