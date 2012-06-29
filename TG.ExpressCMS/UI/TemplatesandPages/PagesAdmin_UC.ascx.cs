using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.IO;

namespace TG.ExpressCMS.UI.Security
{
    public partial class PagesAdmin_UC : System.Web.UI.UserControl
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
            this.gvPage.RowCommand += new GridViewCommandEventHandler(gvPage_RowCommand);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);
            this.gvPage.RowDataBound += new GridViewRowEventHandler(gvPage_RowDataBound);
            this.gvPage.PageIndexChanging += new GridViewPageEventHandler(gvPages_PageIndexChanging);
        }

        void gvPage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlInputHidden hdnType = (HtmlInputHidden)e.Row.FindControl("hdnType");
                if (null == hdnType)
                    return;
                if (hdnType.Value == string.Empty)
                    return;
                int _status = Convert.ToInt32(hdnType.Value);
                CheckBox chkItem = (CheckBox)e.Row.FindControl("chkItem");
                if (null == chkItem)
                    return;

                LinkButton lbName = (LinkButton)e.Row.FindControl("lblgvDoctorName");
                if (null == lbName)
                    return;
                if (_status == Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.PageType.System))
                {
                    chkItem.Visible = false;
                    lbName.Enabled = false;
                }

            }
        }



        void gvPages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPage.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvPage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPage")
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
                AddMode(); FillDDL();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvPage.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvPage.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvPage.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    continue;
                int _id = Convert.ToInt32(hdnID.Value);

                CMSPageManager.Delete(_id);

            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            CMSPage page = new CMSPage();
            if (ObjectID <= 0)
            {
                try
                {
                    page.Name = txtName.Text;
                    if (!page.Name.Contains(".aspx"))
                    {
                        page.Name += ".aspx";
                    }
                    page.Description = txtDesc.Text;
                    page.Keyword = txtKeywords.Text;
                    page.MetTags = txtMetaTags.Text;
                    page.TemplateName = ddlTemplateName.SelectedValue;
                    page.Type = DataLayer.Enums.RootEnums.PageType.User;
                    page.PageContent = string.Empty;
                    DeletePageforUpdate(page);
                    WriteNewPage(page);
                    CMSPageManager.Add(page);
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
                    page = CMSPageManager.GetByID(ObjectID);
                    if (null == page)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    page.Name = txtName.Text;
                    if (!page.Name.Contains(".aspx"))
                    {
                        page.Name += ".aspx";
                    }
                    page.Description = txtDesc.Text;
                    page.Keyword = txtKeywords.Text;
                    page.TemplateName = ddlTemplateName.SelectedValue;
                    page.MetTags = txtMetaTags.Text;
                    page.Type = DataLayer.Enums.RootEnums.PageType.User;
                    page.PageContent = string.Empty;
                    DeletePageforUpdate(page);
                    WriteNewPage(page);
                    CMSPageManager.Update(page);
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

        void gvPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvPage.SelectedDataKey.Value);
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
            ddlTemplateName.SelectedIndex = -1;
            dvProblems.InnerText = "";
            dvProblems.Style.Add(HtmlTextWriterStyle.Display, "none");
            txtDesc.Text = string.Empty;
            txtKeywords.Text = string.Empty;
            txtMetaTags.Text = string.Empty;

            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                CMSPage page = new CMSPage();
                page = CMSPageManager.GetByID(ObjectID);
                if (null == page)
                    return;

                txtName.Text = page.Name;
                txtMetaTags.Text = page.MetTags;
                txtKeywords.Text = page.Keyword;
                txtDesc.Text = page.Description;
                ddlTemplateName.SelectedValue = page.TemplateName;
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvPage.DataSource = CMSPageManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.PageType.User).ToList();
            gvPage.DataBind();

        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void WriteNewPage(CMSPage _page)
        {
            //Read Sample File
            string samplepagecontent = UtilitiesManager.ReadFile(Server.MapPath("~/UserPages/SamplePage.txt"));
            samplepagecontent = samplepagecontent.Replace("#TemplateName#", _page.TemplateName);

            UtilitiesManager.WriteFile(Server.MapPath("~/UserPages/" + _page.Name), samplepagecontent, false, false);

        }

        private void DeletePageforUpdate(CMSPage _page)
        {
            try
            {
                File.Delete(Server.MapPath("~/UserPages/" + _page.Name));
            }
            catch (Exception ex)
            {
                dvProblems.InnerText = ex.ToString();
            }
        }
        private void FillDDL()
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/UserPages/"), "*.master", SearchOption.AllDirectories);
            IList<string> colFiles = new List<string>();
            for (int i = 0; i < files.Count(); i++)
            {
                colFiles.Add(files[i].Substring(files[i].LastIndexOf('\\') + 1, files[i].Length - files[i].LastIndexOf('\\') - 1));
            }
            ddlTemplateName.DataSource = colFiles;
            ddlTemplateName.DataBind();
            ddlTemplateName.Items.Insert(0, new ListItem());
        }
        #endregion
    }
}