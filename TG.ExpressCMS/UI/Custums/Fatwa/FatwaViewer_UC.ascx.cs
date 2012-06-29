using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Fatwa
{
    public partial class FatwaViewer_UC : System.Web.UI.UserControl
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
                    return 1;
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
            this.Load += new EventHandler(FatwaViewer_UC_Load);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.CustomPager_UC1.NextClick += new UI.Controls.CustomPager_UC.btnNext(CustomPager_UC1_NextClick);
            this.CustomPager_UC1.BackClick += new UI.Controls.CustomPager_UC.btnBack(CustomPager_UC1_BackClick);
            this.CustomPager_UC1.btnGoClick += new UI.Controls.CustomPager_UC.btnGo(CustomPager_UC1_btnGoClick);
        }

        void CustomPager_UC1_btnGoClick()
        {
            if (ddlCategories.SelectedValue == "" && ddlCategories.SelectedValue == string.Empty && txtKeyword.Text == string.Empty)
                BindDataList();
            if (ddlCategories.SelectedValue != string.Empty && txtKeyword.Text == string.Empty)
                ddlPostBack();
            if (ddlCategories.SelectedValue != string.Empty && txtKeyword.Text != string.Empty)
                Search();
        }

        void CustomPager_UC1_BackClick()
        {
            if (ddlCategories.SelectedValue == "" && ddlCategories.SelectedValue == string.Empty && txtKeyword.Text == string.Empty)
                BindDataList();
            if (ddlCategories.SelectedValue != string.Empty && txtKeyword.Text == string.Empty)
                ddlPostBack();
            if (ddlCategories.SelectedValue != string.Empty && txtKeyword.Text != string.Empty)
                Search();
        }

        void CustomPager_UC1_NextClick()
        {
            if (ddlCategories.SelectedValue == "" && ddlCategories.SelectedValue == string.Empty && txtKeyword.Text == string.Empty)
                BindDataList();
            if (ddlCategories.SelectedValue != string.Empty && txtKeyword.Text == string.Empty)
                ddlPostBack();
            if (ddlCategories.SelectedValue != string.Empty && txtKeyword.Text != string.Empty)
                Search();
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            int catid = -1;
            Int32.TryParse(ddlCategories.SelectedValue, out catid);
            if (catid == 0)
                catid = -1;
            int totalrows = 0;
            IList<Fatawa> colFatawa = FatawaManager.GetAllByCategoryPaging(CustomPager_UC1.From, CustomPager_UC1.To, ref totalrows, catid, 1, "%" + txtKeyword.Text + "%");
            if (colFatawa == null || colFatawa.Count == 0)
            {
                dvMessages.InnerText = "لم يتم الحصول على نتائج ,يرجى مراجعة حقول البحث";
                dtlstFatawa.DataSource = "";
                dtlstFatawa.DataBind();
                return;
            }
            ddlCategories.SelectedIndex = -1;
            dtlstFatawa.DataSource = colFatawa;
            dtlstFatawa.DataBind();
            CustomPager_UC1.TotalRows = totalrows;
            if (totalrows < PageSize)
                CustomPager_UC1.Visible = false;
            else
                CustomPager_UC1.Visible = true;
        }


        void FatwaViewer_UC_Load(object sender, EventArgs e)
        {
            dvMessages.InnerText = "";
            if (!IsPostBack)
            {
                CustomPager_UC1.PageSize = PageSize;
                FillDDL();
                BindDataList();
            }
        }
        private void FillDDL()
        {
            ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.CategoryType.Fatawa).ToList();
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();

            ddlCategories.Items.Insert(0, new ListItem("تصنيفات التفسير الاحلام....", ""));
        }
        private void BindDataList()
        {
            int trows = 0;
            int catid = -1;
            Int32.TryParse(ddlCategories.SelectedValue, out catid);
            //  IList<Fatawa> colfatwa = FatawaManager.GetAllByCategoryPaging(CustomPager_UC1.From, CustomPager_UC1.To, ref trows, catid, 1, "");
            //colfatwa = new List<Fatawa>();
            //if (colfatwa.Count == 0)
            dvMessages.InnerText = " يرجى اختيار تصنيف تفسير الاحلام";
            //dtlstFatawa.DataSource = colfatwa;
            // dtlstFatawa.DataBind();
            CustomPager_UC1.TotalRows = trows;
            if (trows < PageSize)
                CustomPager_UC1.Visible = false;
            else
                CustomPager_UC1.Visible = true;
        }
        protected string MakeStringShorter(string _data)
        {
            if (_data.Length > 200)
                return _data.Substring(0, 200) + ".....";
            else
                return _data + ".....";
        }

        protected string GetDetailsUrl(string id)
        {
            return ResolveUrl(ConfigContext.GetFatwaDetailsPage) + "?" + ConstantsManager.FatwaID + "=" + id;
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPostBack();

        }
        private void ddlPostBack()
        {
            if (ddlCategories.SelectedValue == "")
            {
                BindDataList();
                return;
            }
            int trows = 0;
            int catid = 0;
            Int32.TryParse(ddlCategories.SelectedValue, out catid);
            txtKeyword.Text = "";
            lblTitle.InnerText = "تفسير الاحلام التصنيف";
            IList<Fatawa> colFatawa = FatawaManager.GetAllByCategoryPaging(CustomPager_UC1.From, CustomPager_UC1.To, ref trows, catid, 1, "");
            if (colFatawa == null || colFatawa.Count == 0)
            {
                dvMessages.InnerText = "لايوجد تفسير الاحلام في هذا التصنيف";
            }
            dtlstFatawa.DataSource = colFatawa;
            dtlstFatawa.DataBind();
            CustomPager_UC1.TotalRows = trows;
            if (trows < PageSize)
                CustomPager_UC1.Visible = false;
            else
                CustomPager_UC1.Visible = true;
        }
    }
}