using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Data;
using System.Globalization;

namespace TG.ExpressCMS.UI
{
    public partial class GeneralSettings_UC : System.Web.UI.UserControl
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
            this.gvSetting.SelectedIndexChanged += new EventHandler(gvSetting_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(SettingsAdd_UC_Load);
            this.gvSetting.RowCommand += new GridViewCommandEventHandler(gvSetting_RowCommand);
            this.gvSetting.PageIndexChanging += new GridViewPageEventHandler(gvSetting_PageIndexChanging);
        }

        void gvSetting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSetting.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvSetting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSetting")
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
        void SettingsAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                PerformSettings();
                AddMode();
                FillDDL();
            }
            dvProblems.InnerText = "";
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvSetting.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvSetting.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvSetting.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);
                TG.ExpressCMS.DataLayer.Entities.Settings _Settings = SettingsManager.GetByID(_id);
                _Settings.IsDeleted = true;
                SettingsManager.Update(_Settings);
            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.Settings _Settings = new TG.ExpressCMS.DataLayer.Entities.Settings();
            if (ObjectID <= 0)
            {
                try
                {

                    _Settings.Name = txtName.Text;
                    _Settings.DefaultLanguageCode = ddlCulturecodes.SelectedValue;
                    _Settings.DefaultUrl = txtDefURL.Text;
                    _Settings.IsDefault = chkdefault.Checked;
                    _Settings.IsDeleted = false;
                    _Settings.PhysicalPath = txtphaddress.Text;
                    CheckDefault(_Settings);
                    SettingsManager.Add(_Settings);
                    AddMode();
                    dvProblems.InnerText = "Saved Successfully";
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
                    _Settings = SettingsManager.GetByID(ObjectID);
                    if (null == _Settings)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }

                    _Settings.Name = txtName.Text;
                    _Settings.DefaultLanguageCode = ddlCulturecodes.SelectedValue;
                    _Settings.DefaultUrl = txtDefURL.Text;
                    _Settings.IsDefault = chkdefault.Checked;
                    _Settings.IsDeleted = false;
                    _Settings.PhysicalPath = txtphaddress.Text;
                    CheckDefault(_Settings);
                    SettingsManager.Update(_Settings);
                    EditMode();
                    dvProblems.InnerText = "Saved Successfully";
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            CacheContext.ClearCache();
            BindGrid();
        }
        private void CheckDefault(TG.ExpressCMS.DataLayer.Entities.Settings _setting)
        {
            if (_setting.IsDefault)
            {
                TG.ExpressCMS.DataLayer.Entities.Settings _def = SettingsManager.GetDefault();
                if (null == _def)
                    return;
                _def.IsDefault = false;
                SettingsManager.Update(_def);
            }
        }

        void gvSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvSetting.SelectedDataKey.Value);
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

            txtphaddress.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDefURL.Text = string.Empty;
            ddlCulturecodes.SelectedIndex = -1;
            chkdefault.Checked = false;
            txtName.Text = "";
            dvProblems.Visible = true;
            dvProblems.Style.Clear();
            dvProblems.InnerText = "";

            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Settings _Settings = new TG.ExpressCMS.DataLayer.Entities.Settings();
                _Settings = SettingsManager.GetByID(ObjectID);
                if (null == _Settings)
                    return;

                ddlCulturecodes.SelectedValue = _Settings.DefaultLanguageCode;
                txtDefURL.Text = _Settings.DefaultUrl;
                txtphaddress.Text = _Settings.PhysicalPath;
                chkdefault.Checked = _Settings.IsDefault;
                txtName.Text = _Settings.Name;

                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvSetting.DataSource = SettingsManager.GetAll().Where(t => t.IsDeleted == false).ToList();
            gvSetting.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;

        }
        protected string GetIfDefault(bool isDef)
        {
            return isDef.ToString();
        }
        private void FillDDL()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            ddlCulturecodes.DataSource = cultures.OrderBy(t => t.DisplayName).ToList();
            ddlCulturecodes.DataTextField = "DisplayName";
            ddlCulturecodes.DataValueField = "Name";
            ddlCulturecodes.DataBind();

            ddlCulturecodes.Items.Insert(0, new ListItem("", ""));
        }
        #endregion
    }
}