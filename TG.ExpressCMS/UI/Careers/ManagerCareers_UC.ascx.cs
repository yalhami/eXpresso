using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.UI.Careers
{
    public partial class ManagerCareers_UC : System.Web.UI.UserControl
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
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.gvCareer.SelectedIndexChanged += new EventHandler(gvXsl_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(XslAdd_UC_Load);
            this.gvCareer.RowCommand += new GridViewCommandEventHandler(gvXsl_RowCommand);
        }

        void gvXsl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCareer")
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
        void XslAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                FillStatusDDL();
                
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvCareer.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvCareer.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvCareer.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                HtmlItemManager.Delete(_id);

            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            HtmlItem html = new HtmlItem();
            if (ObjectID <= 0)
            {
                try
                {
                    html.IsDeleted = false;
                    html.Name = txtName.Text;
                    html.Details = (txtDetails.Content);
                    html.Hash = txtHash.Text;
                    html.Type = DataLayer.Enums.RootEnums.HtmlBlockType.Careers;
                    html.Status =(RootEnums.HtmlBlockStatus) Convert.ToInt32(ddlStatus.SelectedValue);
                    html.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    HtmlItemManager.Add(html);
                    AddMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }

            }
            else
            {
                try
                {
                    html = HtmlItemManager.GetByID(ObjectID);
                    if (null == html)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    html.IsDeleted = false;
                    html.Name = txtName.Text;
                    html.Details = (txtDetails.Content);
                    html.Hash = txtHash.Text;
                    html.Type = DataLayer.Enums.RootEnums.HtmlBlockType.Careers;
                    html.Status = (RootEnums.HtmlBlockStatus)Convert.ToInt32(ddlStatus.SelectedValue);
                    html.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    HtmlItemManager.Update(html);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
        }

        void gvXsl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvCareer.SelectedDataKey.Value);
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
            ddlStatus.SelectedIndex = -1;
            plcControls.Visible = true;
            txtDetails.Content = "";
            txtHash.Text = "";
            txtName.Text = "";
            dvProblems.InnerText = "";
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                HtmlItem cat = new HtmlItem();
                cat = HtmlItemManager.GetByID(ObjectID);
                if (null == cat)
                    return;
                ddlStatus.SelectedValue = Convert.ToInt32(cat.Status).ToString();
                txtName.Text = cat.Name;
                txtHash.Text = cat.Hash;
                txtDetails.Content = cat.Details;

                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvCareer.DataSource = HtmlItemManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.HtmlBlockType.Careers).ToList();
            gvCareer.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void FillStatusDDL()
        {
            ddlStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.HtmlBlockStatus));
            ddlStatus.DataTextField = "Key";
            ddlStatus.DataValueField = "Value";
            ddlStatus.DataBind();

            ddlStatus.Items.Insert(0, new ListItem());
        }
        #endregion

    }
}