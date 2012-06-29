using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;

namespace TG.ExpressCMS.UI.Contact
{
    public partial class ContactsAdmin_UC : System.Web.UI.UserControl
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
            this.gvContact.SelectedIndexChanged += new EventHandler(gvCat_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);
            this.gvContact.RowCommand += new GridViewCommandEventHandler(gvCat_RowCommand);
            this.ibtntoExcel.Click += new ImageClickEventHandler(ibtntoExcel_Click);
            this.gvContact.PageIndexChanging += new GridViewPageEventHandler(gvContact_PageIndexChanging);
        }

        void gvContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContact.PageIndex = e.NewPageIndex;
            BindGrid(10);
        }

        void ibtntoExcel_Click(object sender, ImageClickEventArgs e)
        {
            BindGrid(10000);
            UtilitiesManager.GenerateExcelFiles("Contacts", gvContact);
        }

        void gvCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditContact")
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
        void CatAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(10);
                FillGroup();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControls.Update();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvContact.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvContact.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvContact.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                ContactManager.Delete(_id);

            }
            BindGrid(10);
            AddMode();
            plcControls.Visible = false;
            upnlControls.Update();
            upnlGird.Update();
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.Contact _quiry = null;
            if (ObjectID <= 0)
            {
                try
                {
                    _quiry = new TG.ExpressCMS.DataLayer.Entities.Contact();
                    _quiry.Country = HttpUtility.HtmlEncode(txtCountry.Text);
                    _quiry.Email = HttpUtility.HtmlEncode(txtEmail.Text);
                    _quiry.Notes = HttpUtility.HtmlEncode(txtDescription.Text);
                    _quiry.FirstName = HttpUtility.HtmlEncode(txtName.Text);
                    _quiry.SurName = HttpUtility.HtmlEncode(txtSurname.Text);
                    _quiry.Phone2 = HttpUtility.HtmlEncode(txtPhone.Text);
                    _quiry.ZipCode = HttpUtility.HtmlEncode(txtZipCode.Text);
                    _quiry.Company = HttpUtility.HtmlEncode(txtCompany.Text);
                    _quiry.Guid = Guid.NewGuid().ToString();
                    _quiry.Mobile = HttpUtility.HtmlEncode(txtMobile.Text);
                    _quiry.IsDeleted = false;

                    if (rdbInActive.Checked)
                        _quiry.Status = TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus.InActive;
                    else
                        _quiry.Status = TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus.Active;
                    ContactManager.Add(_quiry);
                    ContactManager.DeleteContactsFromGroups(_quiry.ID);
                    for (int i = 0; i < chkGroups.Items.Count; i++)
                    {
                        if (chkGroups.Items[i].Selected)
                            ContactManager.AssignContacttoGroup(_quiry.ID, Convert.ToInt32(chkGroups.Items[i].Value));
                    }
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
                    _quiry = ContactManager.GetByID(ObjectID);
                    if (null == _quiry)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    _quiry.Country = HttpUtility.HtmlEncode(txtCountry.Text);
                    _quiry.Email = HttpUtility.HtmlEncode(txtEmail.Text);
                    _quiry.Notes = HttpUtility.HtmlEncode(txtDescription.Text);
                    _quiry.FirstName = HttpUtility.HtmlEncode(txtName.Text);
                    _quiry.SurName = HttpUtility.HtmlEncode(txtSurname.Text);
                    _quiry.Phone2 = HttpUtility.HtmlEncode(txtPhone.Text);
                    _quiry.ZipCode = HttpUtility.HtmlEncode(txtZipCode.Text);
                    _quiry.Company = HttpUtility.HtmlEncode(txtCompany.Text);
                    _quiry.Guid = Guid.NewGuid().ToString();
                    _quiry.Mobile = HttpUtility.HtmlEncode(txtMobile.Text);
                    _quiry.IsDeleted = false;
                    if (rdbInActive.Checked)
                        _quiry.Status = TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus.InActive;
                    else
                        _quiry.Status = TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus.Active;

                    ContactManager.Update(_quiry);
                    ContactManager.DeleteContactsFromGroups(_quiry.ID);
                    for (int i = 0; i < chkGroups.Items.Count; i++)
                    {
                        if (chkGroups.Items[i].Selected)
                            ContactManager.AssignContacttoGroup(_quiry.ID, Convert.ToInt32(chkGroups.Items[i].Value));
                    }
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid(10);
            upnlGird.Update();
            upnlControls.Update();
        }

        void gvCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvContact.SelectedDataKey.Value);
            EditMode();
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
                EditMode();
            else
                AddMode();
            upnlControls.Update();
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
            upnlControls.Update();
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtZipCode.Text = "";
            txtSurname.Text = "";
            txtPhone.Text = "";
            txtName.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtDescription.Text = "";
            txtCountry.Text = "";
            txtCompany.Text = "";
            ObjectID = 0;
            rdbActive.Checked = false;
            rdbInActive.Checked = false;
            for (int i = 0; i < chkGroups.Items.Count; i++)
            {
                chkGroups.Items[i].Selected = false;
            }
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Contact cat = null;
                cat = ContactManager.GetByID(ObjectID);
                if (null == cat)
                    return;
                plcControls.Visible = true;
                txtName.Text = cat.FirstName;
                txtSurname.Text = cat.SurName;
                txtCompany.Text = cat.Company;
                txtCountry.Text = cat.Country;
                txtDescription.Text = cat.Notes;
                txtEmail.Text = cat.Email;
                txtMobile.Text = cat.Mobile;
                txtPhone.Text = cat.Phone2;
                txtZipCode.Text = cat.ZipCode;
                if (cat.Status == RootEnums.ContactStatus.Active)
                {
                    rdbActive.Checked = true;
                    rdbInActive.Checked = false;
                }
                else
                {
                    rdbActive.Checked = false;
                    rdbInActive.Checked = true;
                }

                IList<int> colgroups = ContactManager.GetGroupsByContactId(cat.ID);

                for (int k = 0; k < chkGroups.Items.Count; k++)
                {
                    chkGroups.Items[k].Selected = false;
                }

                for (int i = 0; i < chkGroups.Items.Count; i++)
                {
                    for (int k = 0; k < colgroups.Count; k++)
                    {
                        if (Convert.ToInt32(chkGroups.Items[i].Value) == colgroups[k])
                        {
                            chkGroups.Items[i].Selected = true;
                        }
                    }
                }
               
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid(int pagesize)
        {
            gvContact.PageSize = pagesize;
            gvContact.DataSource = ContactManager.GetAll();
            gvContact.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void FillGroup()
        {
            chkGroups.DataSource = GroupManager.GetAll();
            chkGroups.DataTextField = "Name";
            chkGroups.DataValueField = "ID";
            chkGroups.DataBind();
        }
        /// <summary>
        /// Get Cat Status
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        protected string GetStatus(int _status)
        {
            if (((RootEnums.ContactStatus)Convert.ToInt32(_status)) == RootEnums.ContactStatus.Active)
            {
                return Resources.ExpressCMS.ResourceManager.GetString("Active");
            }
            else
            {
                return Resources.ExpressCMS.ResourceManager.GetString("InActive");
            }
        }
        protected string GetName(string fname, string sname)
        {
            return fname + " " + sname;
        }
        #endregion
    }
}