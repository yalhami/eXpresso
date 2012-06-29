using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace TG.ExpressCMS.UI.XSL
{
    public partial class XslTemplateAdmin_UC : System.Web.UI.UserControl
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
            this.gvXsl.SelectedIndexChanged += new EventHandler(gvXsl_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(XslAdd_UC_Load);
            this.gvXsl.RowCommand += new GridViewCommandEventHandler(gvXsl_RowCommand);
        }

        void gvXsl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditXsl")
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
            dvProblems.InnerText = "";
            if (!IsPostBack)
            {
                BindGrid();

                PerformSettings();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvXsl.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvXsl.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvXsl.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                XslTemplateManager.Delete(_id);

            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            XslTemplate Xsl = new XslTemplate();
            if (ObjectID <= 0)
            {
                try
                {
                    Xsl.IsDeleted = false;
                    Xsl.Name = txtName.Text;
                    using (StringReader xslStringReader = new StringReader(txtDetails.Content))
                    {
                        //pass xsl text into xmltextreader
                        using (XmlReader styleSheet = new XmlTextReader(xslStringReader))
                        {
                            //create the transformation class
                            XslCompiledTransform xslTrans = new XslCompiledTransform();
                            //load the xsl into the transformer
                            xslTrans.Load(styleSheet);
                            //create a stringwriter for outputting html to



                        }
                    }
                    Xsl.Details = (txtDetails.Content);
                    Xsl.Hash = txtHash.Text;
                    Xsl.CategoryID = -1;
                    XslTemplateManager.Add(Xsl);
                    AddMode();
                }
                catch (Exception ex)
                {
                    dvProblems.Style.Clear();
                    dvProblems.InnerText = ex.ToString();
                }

            }
            else
            {
                try
                {
                    Xsl = XslTemplateManager.GetByID(ObjectID);
                    if (null == Xsl)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    Xsl.IsDeleted = false;
                    Xsl.Name = txtName.Text;
                    using (StringReader xslStringReader = new StringReader(txtDetails.Content))
                    {
                        //pass xsl text into xmltextreader
                        using (XmlReader styleSheet = new XmlTextReader(xslStringReader))
                        {
                            //create the transformation class
                            XslCompiledTransform xslTrans = new XslCompiledTransform();
                            //load the xsl into the transformer
                            xslTrans.Load(styleSheet);
                        }
                    }
                    Xsl.Details = (txtDetails.Content);
                    Xsl.Hash = txtHash.Text;
                    Xsl.CategoryID = -1;
                    XslTemplateManager.Update(Xsl);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.Style.Clear();
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid();
        }

        void gvXsl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvXsl.SelectedDataKey.Value);
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
            txtDetails.Content = "";
            txtHash.Text = "";
            txtName.Text = "";

            dvProblems.InnerText = "";
            txtDetails.ActiveMode = AjaxControlToolkit.HTMLEditor.ActiveModeType.Html;
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                XslTemplate cat = new XslTemplate();
                cat = XslTemplateManager.GetByID(ObjectID);
                if (null == cat)
                    return;

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
            gvXsl.DataSource = XslTemplateManager.GetAll();
            gvXsl.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
            txtDetails.ActiveMode = AjaxControlToolkit.HTMLEditor.ActiveModeType.Html;
        }

        /// <summary>
        /// Get Xsl Status
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        protected string GetType(int catID)
        {
            Category cat = CategoryManager.GetByID(catID);
            if (null == cat)
                return "Uknown XSL XslTemplate";
            if (cat.Type == RootEnums.CategoryType.Menu)
            {
                return Resources.ExpressCMS.ResourceManager.GetString("MenuCategory");
            }
            else
            {
                return Resources.ExpressCMS.ResourceManager.GetString("NewCategory");
            }
        }

        #endregion

    }
}