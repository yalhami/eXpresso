using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.IO;

namespace TG.ExpressCMS.UI.CSS
{
    public partial class CSSAdmin_UC : System.Web.UI.UserControl
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
            this.ibtAdd.Click += new ImageClickEventHandler(ibtAdd_Click);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.trCSSFiles.SelectedNodeChanged += new EventHandler(trCSSFiles_SelectedNodeChanged);
            this.Load += new EventHandler(CatAdd_UC_Load);

        }

        void ibtAdd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
            upnlControl.Update();
        }

        void trCSSFiles_SelectedNodeChanged(object sender, EventArgs e)
        {
            ObjectID = 1;
            //Convert.ToInt32(trCSSFiles.SelectedValue);
            EditMode();
            upnlControl.Update();
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
            }
        }


        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trCSSFiles.CheckedNodes.Count; i++)
            {
                File.Delete(trCSSFiles.CheckedNodes[i].Value);
            }
            BindGrid();
            AddMode();
            plccontrol.Visible = false;
            upnlControl.Update();
            upnlGird.Update();
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            string filename = txtName.Text.Replace(" ", "");
            if (!filename.ToLower().Contains(".css"))
                filename += ".css";
            if (ObjectID <= 0)
            {
                try
                {
                    UtilitiesManager.WriteFile(Server.MapPath(ConfigContext.GetCSSFilePath) + filename, txtDetails.Content, false, false);
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
                    UtilitiesManager.WriteFile(Server.MapPath(ConfigContext.GetCSSFilePath) + filename, txtDetails.Content, false, false);

                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
            upnlGird.Update();
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
            plccontrol.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            plccontrol.Visible = true;
            txtDetails.Content = "";
            txtName.Text = "";
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                string filename = "";
                filename = trCSSFiles.SelectedNode.Text;
                string data = UtilitiesManager.ReadFile(trCSSFiles.SelectedValue);
                txtDetails.Content = data;
                txtName.Text = filename;

            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            string[] filescss = Directory.GetFiles(Server.MapPath(ConfigContext.GetCSSFilePath), "*.css");
            trCSSFiles.Nodes.Clear();
            for (int i = 0; i < filescss.Count(); i++)
            {
                TreeNode trnode = new TreeNode(filescss[i].Substring(filescss[i].LastIndexOf('\\') + 1, filescss[i].Length - filescss[i].LastIndexOf('\\') - 1), filescss[i]);
                trCSSFiles.Nodes.Add(trnode);
            }
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plccontrol.Visible = false;
        }

        #endregion
    }
}