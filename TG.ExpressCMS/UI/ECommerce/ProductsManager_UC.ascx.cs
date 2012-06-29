using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Entities;
using System.Web.UI.HtmlControls;

namespace TG.ExpressCMS.UI.ECommerce
{
    public partial class ProductsManager_UC : System.Web.UI.UserControl
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
            this.gvProduct.SelectedIndexChanged += new EventHandler(gvProduct_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);
            this.gvProduct.RowCommand += new GridViewCommandEventHandler(gvProduct_RowCommand);
            this.gvProduct.PageIndexChanging += new GridViewPageEventHandler(gvProduct_PageIndexChanging);

            ddlSearchProduct.SelectedIndexChanged += new EventHandler(ddlSearchProduct_SelectedIndexChanged);
        }

        void ddlSearchProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchProduct.SelectedValue == string.Empty)
                return;
            BindGrid();
        }

        void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduct.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCat")
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
                BindGrid();
                PerformSettings();
                FillDDL();
                AddMode();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvProduct.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvProduct.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvProduct.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);
                Product _cat = ProductManager.GetByID(_id);
            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            Product pro = new Product();
            if (ObjectID <= 0)
            {
                try
                {
                    pro.IsDeleted = false;
                    pro.IsDeleted = false;
                    pro.Name = txtName.Text;
                    pro.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    pro.Discount = Convert.ToDouble(txtDscount.Text);
                    pro.ExpiryDate = rtExpiryDate.SelectedDate.Value.ToShortDateString();
                    pro.Height = 0;
                    pro.PrivatePrice = Convert.ToDouble(txtPrivatePrice.Text);
                    pro.ProducingDate = dtProductionDate.SelectedDate.Value.ToShortDateString();
                    pro.Provider = 0;
                    pro.PublicPrice = Convert.ToDouble(txtPublicprice.Text);
                    pro.Quantity = 0;
                    pro.Serial = txtSerial.Text;
                    pro.Tax = Convert.ToDouble(txtTax.Text);
                    pro.Value = txtValue.Text;
                    pro.Weight = 0;
                    ProductManager.Add(pro);
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
                    pro = ProductManager.GetByID(ObjectID);
                    if (null == pro)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    pro.IsDeleted = false;
                    pro.Name = txtName.Text;
                    pro.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                    pro.Discount = Convert.ToDouble(txtDscount.Text);
                    pro.ExpiryDate = rtExpiryDate.SelectedDate.Value.ToShortDateString();
                    pro.Height = 0;
                    pro.PrivatePrice = Convert.ToDouble(txtPrivatePrice.Text);
                    pro.ProducingDate = dtProductionDate.SelectedDate.Value.ToShortDateString();
                    pro.Provider = 0;
                    pro.PublicPrice = Convert.ToDouble(txtPublicprice.Text);
                    pro.Quantity = 0;
                    pro.Serial = txtSerial.Text;
                    pro.Tax = Convert.ToDouble(txtTax.Text);
                    pro.Value = txtValue.Text;
                    pro.Weight = 0;

                    ProductManager.Update(pro);
                    EditMode();
                    dvProblems.InnerText = "Saved Successfully";
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
        }

        void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvProduct.SelectedDataKey.Value);
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

            txtName.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtValue.Text = string.Empty;
            txtPrivatePrice.Text = string.Empty;
            txtPublicprice.Text = string.Empty;
            ddlCategory.SelectedIndex = -1;
            dtProductionDate.Clear();
            txtTax.Text = string.Empty;
            txtDscount.Text = string.Empty;
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                Product _pro = new Product();
                _pro = ProductManager.GetByID(ObjectID);
                if (null == _pro)
                    return;

                txtName.Text = _pro.Name;
                txtSerial.Text = _pro.Serial;
                txtValue.Text = _pro.Value;
                txtPrivatePrice.Text = _pro.PrivatePrice.ToString();
                txtPublicprice.Text = _pro.PublicPrice.ToString();
                ddlCategory.SelectedValue = _pro.CategoryID.ToString();
                dtProductionDate.DbSelectedDate = _pro.ProducingDate;
                txtTax.Text = _pro.Tax.ToString();
                txtDscount.Text = _pro.Discount.ToString();

                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            if (ddlSearchProduct.SelectedValue != string.Empty)
                gvProduct.DataSource = ProductManager.GetByCategoryID(Convert.ToInt32(ddlSearchProduct.SelectedValue));
            else
                gvProduct.DataSource = ProductManager.GetAll();
            gvProduct.DataBind();
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
            ddlCategory.DataSource = CategoryManager.GetAll().Where(t => t.IsDeleted == false && t.Type == RootEnums.CategoryType.ECommerce).ToList();
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();


            ddlCategory.Items.Insert(0, new ListItem());


        }
        #endregion
    }
}