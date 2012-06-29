using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Careers
{
    public partial class PostedCareerViewer_UC : System.Web.UI.UserControl
    {
        /// <summary>
        /// Object ID.
        /// </summary>
        private int ObjectID
        {
            set
            {
                ViewState[ConstantsManager.ObjectID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.ObjectID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.ObjectID]);
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// On Intilization.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);

            this.Load += new EventHandler(CatAdd_UC_Load);
            this.gvPostedCareer.RowCommand += new GridViewCommandEventHandler(gvCat_RowCommand);
            this.gvPostedCareer.PageIndexChanging += new GridViewPageEventHandler(gvCat_PageIndexChanging);
            this.ibtntoExcel.Click += new ImageClickEventHandler(ibtntoExcel_Click);
        }

        void ibtntoExcel_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid(1000);
            UtilitiesManager.GenerateExcelFiles("Careers", gvPostedCareer);
        }

        void gvCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPostedCareer.PageIndex = e.NewPageIndex;
            BindGrid(10);
        }

        void gvCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCareerPost")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CatAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(10);
                PerformSettings();
                FillDDL();
               
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvPostedCareer.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvPostedCareer.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvPostedCareer.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                CareerPostsManager.Delete(_id);

            }
            BindGrid(10);
            AddMode();
            plcControls.Visible = false;
        }


        void gvCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvPostedCareer.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
                EditMode();
            else
                AddMode();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtEducation.Content = "";
            txtExperiences.Content = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtTextCV.Content = "";
            dvProblems.InnerText = "";
            dvProblems.Style.Add(HtmlTextWriterStyle.Display, "none");

            // ddlXsls.SelectedIndex = -1;
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                CareerPosts _item = CareerPostsManager.GetByID(ObjectID);

                if (null == _item)
                    return;
                txtEducation.Content = getEducation(_item.Experiences);
                txtExperiences.Content = getExperiences(_item.Experiences);
                txtName.Text = _item.Name;
                txtPhone.Text = _item.Phone;
                 img.ImageUrl = "~/Upload/Files/" + _item.Image;
                ddlJobID.SelectedValue = _item.JobID.ToString();
                hypCV.NavigateUrl = ResolveUrl("~/Upload/Files/" + _item.CVDocument);
                hypCV.Text = "Download";
                plcControls.Visible = true;
            }
        }
        private string getEducation(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            return xdoc.ChildNodes[0].ChildNodes[1].Attributes[0].Value;
        }
        private string getExperiences(string xml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);
            return xdoc.ChildNodes[0].ChildNodes[0].Attributes[0].Value;
        }
        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid(int pageSize)
        {
            gvPostedCareer.PageSize = pageSize;
            gvPostedCareer.DataSource = CareerPostsManager.GetAll();
            gvPostedCareer.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;

        }
        private void FillDDL()
        {
            ddlJobID.DataSource = HtmlItemManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.HtmlBlockType.Careers).ToList();
            ddlJobID.DataTextField = "Name";
            ddlJobID.DataValueField = "ID";
            ddlJobID.DataBind();

            ddlJobID.Items.Insert(0, new ListItem());
        }
        /// <summary>
        /// Get Cat Status
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        protected string GetCareer(int careerID)
        {
            TG.ExpressCMS.DataLayer.Entities.HtmlItem _html = TG.ExpressCMS.DataLayer.Data.HtmlItemManager.GetByID(careerID);
            return _html.Name;
        }
        #endregion
    }
}