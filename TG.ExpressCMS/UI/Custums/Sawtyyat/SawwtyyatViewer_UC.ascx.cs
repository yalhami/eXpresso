using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.Utilities;
using System.IO;

namespace TG.ExpressCMS.UI.Custums.Sawtyyat
{
    public partial class SawwtyyatViewer_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SawwtyyatViewer_UC_Load);
            this.ddlfileType.SelectedIndexChanged += new EventHandler(ddlfileType_SelectedIndexChanged);
            // this.dtlstVideosAudios.ItemDataBound += new DataListItemEventHandler(dtlstVideosAudios_ItemDataBound);
            this.DataList1.ItemDataBound += new DataListItemEventHandler(DataList1_ItemDataBound);

            this.ddlVideosCategories.SelectedIndexChanged += new EventHandler(ddlVideosCategories_SelectedIndexChanged);
            this.ddlAudioCategories.SelectedIndexChanged += new EventHandler(ddlAudioCategories_SelectedIndexChanged);
            this.dtlstVideosAudios.ItemCommand += new DataListCommandEventHandler(dtlstVideosAudios_ItemCommand);

            ucAudios.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(ucAudios_btnGoClick);
            ucAudios.NextClick += new UI.Controls.CustomPager_UC.btnNext(ucAudios_NextClick);
            ucAudios.BackClick += new UI.Controls.CustomPager_UC.btnBack(ucAudios_BackClick);

            ucVideosPager.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(ucVideosPager_btnGoClick);
            ucVideosPager.NextClick += new UI.Controls.CustomPager_UC.btnNext(ucVideosPager_NextClick);
            ucVideosPager.BackClick += new UI.Controls.CustomPager_UC.btnBack(ucVideosPager_BackClick);
        }

        void dtlstVideosAudios_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "PlPa")
            {
                HtmlGenericControl div = (HtmlGenericControl)this.FindControl("dvVoice");
                HtmlGenericControl dvName = (HtmlGenericControl)this.FindControl("dvName");
                StreamReader _reader = new StreamReader(Server.MapPath("~/UI/Custums/Sawtyyat/ref.txt"));
                string data = _reader.ReadToEnd();
                data = data.Replace("XXX", CacheContext._DefaultSettings.DefaultUrl + "/Upload/Files/" + e.CommandArgument.ToString().Replace("mp3", "m3u"));
                div.InnerHtml = data;
                if (e.CommandSource.GetType().Name == "ImageButton")
                {
                    dvName.InnerText = (e.CommandSource as ImageButton).ToolTip;
                }
                else
                    dvName.InnerText = (e.CommandSource as LinkButton).ToolTip;
            }
        }

        void ucVideosPager_BackClick()
        {
            BindDtListVideos();
        }
        void ucVideosPager_NextClick()
        {
            BindDtListVideos();
        }

        void ucVideosPager_btnGoClick()
        {
            BindDtListVideos();
        }

        void ucAudios_BackClick()
        {
            BindDtList();
        }

        void ucAudios_NextClick()
        {
            BindDtList();
        }

        void ucAudios_btnGoClick()
        {
            BindDtList();
        }

        void ddlAudioCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAudioCategories.SelectedValue == "")
            {
                dvMessages.InnerText = "لم يتم الحصول على نتائج ,يرجى مراجعة حقول البحث";
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                return;
            }
            int totalrows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colSawtyyat = SawtyyatManager.GetAllByType((RootEnums.AudioVideoType)Convert.ToInt32(RootEnums.AudioVideoType.Audio), ucAudios.From, ucAudios.To, ref totalrows, "%%", Convert.ToInt32(ddlAudioCategories.SelectedValue));
            ucAudios.TotalRows = totalrows;
            if (colSawtyyat == null || colSawtyyat.Count == 0)
            {
                dvMessages.InnerText = "لم يتم الحصول على نتائج ,يرجى مراجعة حقول البحث";
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                return;
            }

            dtlstVideosAudios.DataSource = colSawtyyat;
            dtlstVideosAudios.DataBind();
            dvAudios.Visible = true;
            dvvideos.Visible = false;
        }

        void ddlVideosCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVideosCategories.SelectedValue == "")
            {
                dvMessages.InnerText = "لم يتم الحصول على نتائج ,يرجى مراجعة حقول البحث";
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                return;
            }
            int totalrows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colSawtyyat = SawtyyatManager.GetAllByType((RootEnums.AudioVideoType)Convert.ToInt32(RootEnums.AudioVideoType.Video), ucVideosPager.From, ucVideosPager.To, ref totalrows, "%%", Convert.ToInt32(ddlVideosCategories.SelectedValue));
            ucVideosPager.TotalRows = totalrows;
            if (colSawtyyat == null || colSawtyyat.Count == 0)
            {
                dvMessages.InnerText = "لم يتم الحصول على نتائج ,يرجى مراجعة حقول البحث";
                DataList1.DataSource = "";
                DataList1.DataBind();
                return;
            }

            DataList1.DataSource = colSawtyyat;
            DataList1.DataBind();
        }

        void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl ll = (HtmlGenericControl)e.Item.FindControl("embedInner");
                HiddenField hdnpath = (HiddenField)e.Item.FindControl("hdnPath");
                if (null == ll || hdnpath == null)
                    return;
                ll.InnerHtml = hdnpath.Value;
            }
        }

        void dtlstVideosAudios_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    LinkButton ll = (LinkButton)e.Item.FindControl("HyperLink1");
            //    if (null == ll)
            //        return;

            //}
        }

        void ddlfileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = -1;
            Int32.TryParse(ddlfileType.SelectedValue, out type);
            if (type < 0) return;
            if (type == Convert.ToInt32(RootEnums.AudioVideoType.Audio))
            {
                BindDtList();
                dvAudios.Visible = true;
                dvvideos.Visible = false;
            }
            else
            {
                BindDtListVideos();
                dvAudios.Visible = false;
                dvvideos.Visible = true;
            }
        }

        void SawwtyyatViewer_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
            if (!IsPostBack)
            {
                dvvideos.Visible = false;
                dvAudios.Visible = true;
                ucAudios.PageSize = 20;
                ucVideosPager.PageSize = 4;
                FillDDL();
                //       BindDtList();
                dvMessages.InnerText = "يرجى اختيار النوع";
                ucAudios.Visible = false;
                ucVideosPager.Visible = false;
                dvMessages.Style.Add(HtmlTextWriterStyle.Display, "block");
                dvMessages.Visible = true;
            }
        }

        private void FillDDL()
        {
            ddlfileType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.AudioVideoType));
            ddlfileType.DataTextField = "Key";
            ddlfileType.DataValueField = "Value";
            ddlfileType.DataBind();
            ddlfileType.Items.Remove(ddlfileType.Items.FindByValue("-1"));
            ddlVideosCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Videos).ToList();
            ddlVideosCategories.DataTextField = "Name";
            ddlVideosCategories.DataValueField = "ID";
            ddlVideosCategories.DataBind();

            ddlAudioCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Sawtyyat).ToList();
            ddlAudioCategories.DataTextField = "Name";
            ddlAudioCategories.DataValueField = "ID";
            ddlAudioCategories.DataBind();

            ddlAudioCategories.Items.Insert(0, new ListItem("يرجى اختيار التصنيف....", ""));
            ddlVideosCategories.Items.Insert(0, new ListItem("يرجى اختيار التصنيف....", ""));
            ddlfileType.Items.Insert(0, new ListItem("يرجى اختيار النوع....", ""));

        }

        private void BindDtList()
        {
            ucVideosPager.Visible = false;

            if (ddlfileType.SelectedValue == "")
            {
                if (!IsPostBack)
                {
                    dvMessages.InnerText = "يرجى اختيار النوع";
                }
                return;
            }
            int totalrows = 0;
            if (ddlAudioCategories.SelectedValue == "")
            {
                //if (!IsPostBack)
                {
                    dvMessages.InnerText = "يرجى اختيار التصنيف";
                }
                //else
                //{
                //    dvMessages.InnerText = "لم يتم ايجاد نتائج يرجى مراجعة حقول البحث";
                //}
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                ucAudios.TotalRows = 0;
                ucAudios.Visible = false;
                return;
            }
            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colSawtyyat = SawtyyatManager.GetAllByType((RootEnums.AudioVideoType)Convert.ToInt32(RootEnums.AudioVideoType.Audio), ucAudios.From, ucAudios.To, ref totalrows, "%%", Convert.ToInt32(ddlAudioCategories.SelectedValue));

            ucAudios.TotalRows = totalrows;
            if (colSawtyyat == null || colSawtyyat.Count == 0)
            {
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                return;
            }

            dtlstVideosAudios.DataSource = colSawtyyat;
            dtlstVideosAudios.DataBind();
            if (totalrows > ucAudios.PageSize)
                ucAudios.Visible = true;
            else
                ucAudios.Visible = false;
        }
        private void BindDtListVideos()
        {
            ucAudios.Visible = false;
            if (ddlfileType.SelectedValue == "")
                return;
            int totalrows = 0;
            if (ddlVideosCategories.SelectedValue == "")
            {
               // if (!IsPostBack)
               // {
                    dvMessages.InnerText = "يرجى اختيار التصنيف";

                //}
                //else
                //{
                //    dvMessages.InnerText = "لم يتم ايجاد نتائج يرجى مراجعة حقول البحث";
                //}
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                ucAudios.TotalRows = 0;
                ucAudios.Visible = false;
                return;
            }
            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colSawtyyat = SawtyyatManager.GetAllByType((RootEnums.AudioVideoType)Convert.ToInt32(RootEnums.AudioVideoType.Video), ucVideosPager.From, ucVideosPager.To, ref totalrows, "%%", Convert.ToInt32(ddlVideosCategories.SelectedValue));
            ucVideosPager.TotalRows = totalrows;
            if (colSawtyyat == null || colSawtyyat.Count == 0)
            {
               // if (!IsPostBack)
                {
                    dvMessages.InnerText = "يرجى اختيار التصنيف";
                }
                //else
                //{
                //    dvMessages.InnerText = "لم يتم ايجاد نتائج يرجى مراجعة حقول البحث";
                //}
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                return;
            }

            DataList1.DataSource = colSawtyyat;
            DataList1.DataBind();

            if (totalrows > ucVideosPager.PageSize)
                ucVideosPager.Visible = true;
            else
                ucVideosPager.Visible = false;
        }
        protected string GetDownLoadUrl(string fileName)
        {
            return "~" + "/UI/Custums/Sawtyyat/DownloadSawtyyat.ashx?FileName=" + fileName;
        }
        protected string GetDownLoadUrl2(string fileName)
        {
            return "~" + "/UI/Custums/Sawtyyat/Handler1.ashx?FileName=" + fileName;
        }
        protected void Unnamed30_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            if (ddlfileType.SelectedValue == "")
                return;
            int totalrows = 0;
            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colSawtyyat = null;
            if (ddlVideosCategories.SelectedValue == "")
                colSawtyyat = SawtyyatManager.GetAllByType((RootEnums.AudioVideoType)Convert.ToInt32(RootEnums.AudioVideoType.Video), ucVideosPager.From, ucVideosPager.To, ref totalrows, lb.CommandArgument, -1);
            else
                colSawtyyat = SawtyyatManager.GetAllByType((RootEnums.AudioVideoType)Convert.ToInt32(RootEnums.AudioVideoType.Video), ucVideosPager.From, ucVideosPager.To, ref totalrows, lb.CommandArgument, Convert.ToInt32(ddlVideosCategories.SelectedValue));
            ucVideosPager.TotalRows = totalrows;
            if (colSawtyyat == null || colSawtyyat.Count == 0)
            {
                dvMessages.InnerText = "لم يتم الحصول على نتائج ,يرجى مراجعة حقول البحث";
                dtlstVideosAudios.DataSource = "";
                dtlstVideosAudios.DataBind();
                return;
            }

            DataList1.DataSource = colSawtyyat;
            DataList1.DataBind();
        }
    }
}