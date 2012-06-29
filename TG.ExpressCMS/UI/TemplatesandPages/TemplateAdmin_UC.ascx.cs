using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.TemplatesandPages
{
    public partial class TemplateAdmin_UC : System.Web.UI.UserControl
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
            this.ibtnadd.Click += new ImageClickEventHandler(ibtAdd_Click);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.trmasterPages.SelectedNodeChanged += new EventHandler(trCSSFiles_SelectedNodeChanged);
            this.Load += new EventHandler(CatAdd_UC_Load);

        }

        void ibtAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();

        }

        void trCSSFiles_SelectedNodeChanged(object sender, EventArgs e)
        {
            //Convert.ToInt32(trCSSFiles.SelectedValue);
            //AddMode();

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
                BindTreeNodes();
                FillCssFiles();
            }
        }


        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trmasterPages.CheckedNodes.Count; i++)
            {
                File.Delete(trmasterPages.CheckedNodes[i].Value);
            }
            BindTreeNodes();
            AddMode();
            plcControls.Visible = false;

        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            string filename = txtName.Text.Replace(" ", "");
            if (!filename.ToLower().Contains(".master"))
                filename += ".master";
            if (ObjectID <= 0)
            {
                try
                {
                    string data = UtilitiesManager.ReadFile(Server.MapPath("~/UserPages/SampleMasterPage.txt"));
                    string fullfilename = "";
                    for (int i = 0; i < chkCSSFiles.Items.Count; i++)
                    {
                        fullfilename += "<link href=\"../../UI/CSS/CSSFiles/" + chkCSSFiles.Items[i].Text + " rel=\"stylesheet\" type=\"text/css\" />";
                    }
                    data = data.Replace("#CSSFILES#", fullfilename);
                    UtilitiesManager.WriteFile(Server.MapPath("~/UserPages/") + filename, data, false, false);

                    AddMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }

            }
          
            BindTreeNodes();

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

            txtName.Text = "";
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                string filename = "";
                filename = trmasterPages.SelectedNode.Text;
                string data = UtilitiesManager.ReadFile(trmasterPages.SelectedValue);
                txtName.Text = filename;

            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void FillCssFiles()
        {
            string[] filescss = Directory.GetFiles(Server.MapPath(ConfigContext.GetCSSFilePath), "*.css");
            chkCSSFiles.Items.Clear();
            for (int i = 0; i < filescss.Count(); i++)
            {
                ListItem trnode = new ListItem();
                trnode.Text = filescss[i].Substring(filescss[i].LastIndexOf('\\') + 1, filescss[i].Length - filescss[i].LastIndexOf('\\') - 1);
                trnode.Value = filescss[i];
                chkCSSFiles.Items.Add(trnode);

            }
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void BindTreeNodes()
        {
            string[] filemasters = Directory.GetFiles(Server.MapPath("~/UserPages/"), "*.master", SearchOption.AllDirectories);
            trmasterPages.Nodes.Clear();
            for (int i = 0; i < filemasters.Count(); i++)
            {
                TreeNode trnode = new TreeNode();
                trnode.Text = filemasters[i].Substring(filemasters[i].LastIndexOf('\\') + 1, filemasters[i].Length - filemasters[i].LastIndexOf('\\') - 1);
                trnode.Value = filemasters[i];
                trmasterPages.Nodes.Add(trnode);
            }
        }
        #endregion
    }
}