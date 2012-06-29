using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using System.IO;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.TemplatesandPages
{
    public partial class PagesTemplatesEditor_UC : System.Web.UI.UserControl
    {
        private string FilePath
        {
            set
            {
                ViewState["FilePath"] = value;
            }
            get
            {
                if (null != ViewState["FilePath"])
                {
                    return ViewState["FilePath"].ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(PagesTemplatesEditor_UC_Load);
            this.chkEditTemplates.CheckedChanged += new EventHandler(chkEditTemplates_CheckedChanged);
            this.ddlBlocks.SelectedIndexChanged += new EventHandler(ddlBlocks_SelectedIndexChanged);

            this.ddlTemplates.SelectedIndexChanged += new EventHandler(ddlTemplates_SelectedIndexChanged);
            this.ddlPages.SelectedIndexChanged += new EventHandler(ddlPages_SelectedIndexChanged);

            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CMSPage _page = CMSPageManager.GetByID(Convert.ToInt32(ViewState["PageID"]));
                if (null == _page)
                    return;
                _page.PageContent = txtDetails.Text;
                CMSPageManager.Update(_page);

                UtilitiesManager.WriteFile(FilePath, txtDetails.Text, false, false);

                ScriptManager.RegisterStartupScript(upnlAll, upnlAll.GetType(), Guid.NewGuid().ToString().Substring(0, 5), "alert('Saved Successfully');", true);
            }
            catch (Exception ex)
            {
                dvproblems.InnerText = ex.ToString(); 
            }          
        }

        void btnReset_Click(object sender, EventArgs e)
        {
            txtDetails.Text = UtilitiesManager.ReadFile(FilePath);
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plControls.Visible = false;
        }

        void ddlTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTemplates.SelectedValue == "")
                return;
            FilePath = ddlTemplates.SelectedValue;
            string data = UtilitiesManager.ReadFile(FilePath);
            txtDetails.Text = data;

        }

        void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPages.SelectedItem == null)
                return;
            FilePath = Server.MapPath("~/UserPages/") + ddlPages.SelectedItem.Text;
            string data = UtilitiesManager.ReadFile(FilePath);
            txtDetails.Text = data;
            ViewState["PageID"] = ddlPages.SelectedValue;
        }

        void ddlBlocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBlocks.SelectedValue == "")
                return;
            int blockid = Convert.ToInt32(ddlBlocks.SelectedValue);
            Blocks _block = BlocksManager.GetByID(blockid);
            if (_block.UseCategory)
                trCategories.Visible = true;
            if (_block.UseHtml)
                trHTMLs.Visible = true;
            if (_block.UseXSL)
                trXSLs.Visible = true;
            dvRegisterTag.Text = _block.RegisterTag;

        }

        void chkEditTemplates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditTemplates.Checked)
            {
                trTemplates.Visible = true;
                trPages.Visible = false;
            }
            else
            {
                trTemplates.Visible = false;
                trPages.Visible = true;
            }
        }

        void PagesTemplatesEditor_UC_Load(object sender, EventArgs e)
        {
            dvproblems.InnerText = string.Empty;
            if (!IsPostBack)
            {
                PerformSetting();
                FillDDL();
                AddMode();
            }
        }
        private void PerformSetting()
        {
            trPages.Visible = true;
            trTemplates.Visible = false;

            trXSLs.Visible = false;
            trCategories.Visible = false;
            trHTMLs.Visible = false;
        }

        private void FillDDL()
        {
            ddlBlocks.DataSource = BlocksManager.GetAll();
            ddlBlocks.DataTextField = "Name";
            ddlBlocks.DataValueField = "ID";
            ddlBlocks.DataBind();

            IList<Category> colCategory = CategoryManager.GetAll();
            for (int i = 0; i < colCategory.Count; i++)
            {
                ListItem lstItem = new ListItem(colCategory[i].Name + ":" + colCategory[i].ID, colCategory[i].ID.ToString());
                ddlCategories.Items.Add(lstItem);
            }

            ddlHTML.DataSource = HtmlItemManager.GetAll();
            ddlHTML.DataTextField = "Hash";
            ddlHTML.DataValueField = "ID";
            ddlHTML.DataBind();

            ddlPages.DataSource = CMSPageManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.PageType.User).ToList();
            ddlPages.DataTextField = "Name";
            ddlPages.DataValueField = "ID";
            ddlPages.DataBind();

            IList<XslTemplate> colxsl = XslTemplateManager.GetAll();

            for (int i = 0; i < colxsl.Count; i++)
            {
                ListItem lstItem = new ListItem(colxsl[i].Name + ":" + colxsl[i].ID, colxsl[i].ID.ToString());
                ddlXSLs.Items.Add(lstItem);
            }

            string[] colMasters = Directory.GetFiles(Server.MapPath("~/UserPages/"), "*.master");

            for (int i = 0; i < colMasters.Count(); i++)
            {
                string newfilename = colMasters[i].Substring(colMasters[i].LastIndexOf('\\') + 1, colMasters[i].Length - colMasters[i].LastIndexOf('\\') - 1);
                ListItem x = new ListItem();
                x.Value = colMasters[i];
                x.Text = newfilename;
                ddlTemplates.Items.Add(x);
            }
            ddlTemplates.Items.Insert(0, new ListItem());
            ddlPages.Items.Insert(0, new ListItem());
            ddlHTML.Items.Insert(0, new ListItem());
            ddlCategories.Items.Insert(0, new ListItem());
            ddlBlocks.Items.Insert(0, new ListItem());
        }
        private void AddMode()
        {
            ddlBlocks.SelectedIndex = -1;
            ddlCategories.SelectedIndex = -1;
            ddlHTML.SelectedIndex = -1;
            ddlPages.SelectedIndex = -1;
            ddlTemplates.SelectedIndex = -1;

            txtDetails.Text = string.Empty;
        }
    }
}











