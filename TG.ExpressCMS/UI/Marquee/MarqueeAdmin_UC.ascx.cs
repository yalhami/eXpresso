using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Enums;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using System.Configuration;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.Configuration;

namespace TG.ExpressCMS.UI.Marquee
{
    public partial class MarqueeAdmin_UC : System.Web.UI.UserControl
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
            this.gvMarquee.SelectedIndexChanged += new EventHandler(gvMarquee_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(marqueeItemsAdd_UC_Load);
            this.gvMarquee.RowCommand += new GridViewCommandEventHandler(gvMarquee_RowCommand);
            this.ddlMarqueeType.SelectedIndexChanged += new EventHandler(ddlMarqueeType_SelectedIndexChanged);
            this.gvMarquee.PageIndexChanging += new GridViewPageEventHandler(gvMarquee_PageIndexChanging);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(txtSearch.Text);
            upnlGrid.Update();
            AddMode();
            plcControls.Visible = false;
            upnlControls.Update();
        }

        void gvMarquee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMarquee.PageIndex = e.NewPageIndex;
            BindGrid(string.Empty);
        }

        void ddlMarqueeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result = 0;
            Int32.TryParse(ddlMarqueeType.SelectedValue, out result);
            if (result > 0)
            {
                if ((TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType)(result) == RootEnums.MarqueeItemURLType.External)
                {
                    trURL.Visible = true;
                    trDetails.Visible = false;
                }
                if ((TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType)(result) == RootEnums.MarqueeItemURLType.Internal)
                {
                    trURL.Visible = false;
                    trDetails.Visible = true;
                }
                if ((TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType)(result) == RootEnums.MarqueeItemURLType.TextOnly)
                {
                    trURL.Visible = false;
                    trDetails.Visible = false;
                    txtURL.Text = "#";
                }
            }
        }

        void gvMarquee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditmarqueeItems")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
                upnlControls.Update();


            }
        }

        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void marqueeItemsAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(string.Empty);
                FillDDL();
                AddMode();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControls.Update();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvMarquee.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvMarquee.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvMarquee.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                MarqueeItemsManager.Delete(_id);

            }
            BindGrid(string.Empty);
            AddMode();
            plcControls.Visible = false;
            upnlGrid.Update();
            upnlControls.Update();
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            MarqueeItems marqueeItems = new MarqueeItems();
            if (ObjectID <= 0)
            {
                try
                {
                    marqueeItems.Name = txtName.Text;

                    marqueeItems.Details = txtDetails.Text;
                    marqueeItems.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);

                    marqueeItems.Details = txtDetails.Text;
                    marqueeItems.IsDeleted = false;
                    marqueeItems.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                    marqueeItems.UrlType = (TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType)Convert.ToInt32(ddlMarqueeType.SelectedValue);
                    marqueeItems.Text = txtText.Text;

                    marqueeItems.Url = string.Empty;
                    MarqueeItemsManager.Add(marqueeItems);
                    if (marqueeItems.UrlType == RootEnums.MarqueeItemURLType.External || marqueeItems.UrlType == RootEnums.MarqueeItemURLType.TextOnly)
                    {
                        marqueeItems.Url = txtURL.Text;
                    }
                    else
                        marqueeItems.Url = ResolveUrl(ExpressoConfig.MarqueeConfigElement.GetDefaultDetailsPage) + ConstantsManager.MarqueeID + "=" + marqueeItems.ID.ToString();
                    MarqueeItemsManager.Update(marqueeItems);
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
                    marqueeItems = MarqueeItemsManager.GetByID(ObjectID);
                    if (null == marqueeItems)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    marqueeItems.Name = txtName.Text;
                    marqueeItems.Text = txtText.Text;
                    marqueeItems.Details = txtDetails.Text;
                    marqueeItems.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                    marqueeItems.Url = txtURL.Text;
                    marqueeItems.IsDeleted = false;
                    marqueeItems.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                    marqueeItems.UrlType = (TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType)Convert.ToInt32(ddlMarqueeType.SelectedValue);
                    if (marqueeItems.UrlType == RootEnums.MarqueeItemURLType.External || marqueeItems.UrlType == RootEnums.MarqueeItemURLType.TextOnly)
                    {
                        marqueeItems.Url = txtURL.Text;
                    }
                    else
                        marqueeItems.Url = ResolveUrl(ExpressoConfig.MarqueeConfigElement.GetDefaultDetailsPage) + ConstantsManager.MarqueeID + "=" + marqueeItems.ID.ToString();
                    MarqueeItemsManager.Update(marqueeItems);
                    EditMode();
                    upnlGrid.Update();
                    dvProblems.InnerText = "Saved Successfully";
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid(string.Empty);
        }

        void gvMarquee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvMarquee.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
            {
                EditMode();
            }
            else
                AddMode();
            upnlControls.Update();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtURL.Text = "";
            txtName.Text = "";
            txtDetails.Text = "";
            txtText.Text = "";
            dvProblems.InnerText = "";
            dvProblems.Style.Add(HtmlTextWriterStyle.Display, "none");
            trURL.Visible = false;
            trDetails.Visible = true;
            ddlCategories.SelectedIndex = -1;
            txtURL.Text = ConfigurationManager.AppSettings["DefMarqueeDetailsPage"];
            ddlMarqueeType.SelectedValue = Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType.Internal).ToString();
            upnlGrid.Update();
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                MarqueeItems marqueeItems = new MarqueeItems();
                marqueeItems = MarqueeItemsManager.GetByID(ObjectID);
                if (null == marqueeItems)
                    return;
                txtDetails.Text = marqueeItems.Details;
                txtName.Text = marqueeItems.Name;
                txtText.Text = marqueeItems.Text;
                if (marqueeItems.UrlType == RootEnums.MarqueeItemURLType.External)
                {
                    txtURL.Text = marqueeItems.Url;
                    trDetails.Visible
                        = false;
                    trURL.Visible = true;
                }
                else
                {
                    txtURL.Text = marqueeItems.Url;
                    trDetails.Visible
                       = true;
                    trURL.Visible = false;
                }
                ddlMarqueeType.SelectedValue = Convert.ToInt32(marqueeItems.UrlType).ToString();
                ddlCategories.SelectedValue = marqueeItems.CategoryID.ToString();
                plcControls.Visible = true;

            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid(string keyword)
        {
            if (keyword == string.Empty)
            {
                gvMarquee.DataSource = MarqueeItemsManager.GetAll();
                gvMarquee.DataBind();
            }
            else
            {
                gvMarquee.DataSource = MarqueeItemsManager.GetAll().Where(t => t.Name.ToLower().Contains(txtSearch.Text.ToLower()) || t.Details.ToLower().Contains(txtSearch.Text.ToLower()) || t.Details.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                gvMarquee.DataBind();
            }
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
            ddlMarqueeType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.MarqueeItemURLType));
            ddlMarqueeType.DataTextField = "Key";
            ddlMarqueeType.DataValueField = "Value";
            ddlMarqueeType.DataBind();

            ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Marquee).ToList();
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();

            ddlCategories.Items.Insert(0, new ListItem("", ""));
            ddlMarqueeType.Items.Insert(0, new ListItem("", ""));
        }

        #endregion
    }
}