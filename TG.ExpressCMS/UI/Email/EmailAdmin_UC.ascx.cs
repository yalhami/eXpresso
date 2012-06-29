using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;

namespace TG.ExpressCMS.UI.Email
{
    public partial class EmailAdmin_UC : System.Web.UI.UserControl
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

            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(_emailAdd_UC_Load);
            this.gvEmail.RowCommand += new GridViewCommandEventHandler(gv_email_RowCommand);
            this.ibtntoExcel.Click += new ImageClickEventHandler(ibtntoExcel_Click);
            this.gvEmail.PageIndexChanging += new GridViewPageEventHandler(gvEmail_PageIndexChanging);
        }

        void gvEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmail.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void ibtntoExcel_Click(object sender, ImageClickEventArgs e)
        {
            UtilitiesManager.GenerateExcelFiles("Emails", gvEmail);
        }

        void gv_email_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMail")
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
        void _emailAdd_UC_Load(object sender, EventArgs e)
        {
            SetEditorPaths();
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvEmail.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvEmail.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvEmail.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                EmailManager.Delete(_id);

            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.Email _email = new TG.ExpressCMS.DataLayer.Entities.Email();
            if (ObjectID <= 0)
            {
                try
                {
                    _email.IsDeleted = false;
                    _email.Name = txtName.Text;
                    _email.Details = txtDetails.Content;
                    _email.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    _email.Type = DataLayer.Enums.RootEnums.EmailType.Normal;
                    EmailManager.Add(_email);
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
                    _email = EmailManager.GetByID(ObjectID);
                    if (null == _email)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    _email.IsDeleted = false;
                    _email.Name = txtName.Text;
                    _email.Details = txtDetails.Content;
                    _email.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    _email.Type = DataLayer.Enums.RootEnums.EmailType.Normal;
                    EmailManager.Update(_email);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
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
            txtDetails.Content = "";
            txtName.Text = "";
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Email cat = new TG.ExpressCMS.DataLayer.Entities.Email();
                cat = EmailManager.GetByID(ObjectID);
                if (null == cat)
                    return;
                txtName.Text = cat.Name;
                txtDetails.Content = cat.Details;
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvEmail.DataSource = EmailManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.EmailType.Normal).ToList();
            gvEmail.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void SetEditorPaths()
        {
            //txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityFlashGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityMediaGalleryPath("~/Upload/UserUploads/");
            ////   txtDetails.SetSecurityImageBrowserPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityFilesGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityMaxImageSize(102400);
            //txtDetails.SetSecurityMaxFlashSize(102400);
            //txtDetails.SetSecurityMaxDocumentSize(102400);

            //txtDetails.EnableClientScript = true;
        }
        #endregion
    }
}