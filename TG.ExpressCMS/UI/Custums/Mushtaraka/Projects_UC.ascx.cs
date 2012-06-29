using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Linq;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.IO;



namespace TG.ExpressCMS
{
    public partial class Projects_UC : System.Web.UI.UserControl
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
            this.gvCat.SelectedIndexChanged += new EventHandler(gvCat_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);
            this.gvCat.RowCommand += new GridViewCommandEventHandler(gvCat_RowCommand);
            this.gvCat.PageIndexChanging += new GridViewPageEventHandler(gvCat_PageIndexChanging);


        }



        void gvCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCat.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvCat_RowCommand(object sender, GridViewCommandEventArgs e)
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

                AddMode();
                ReadQueryString();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvCat.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvCat.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvCat.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);
                Category _cat = CategoryManager.GetByID(_id);
                try
                {
                    CategoryManager.Delete(_id);


                    if (_cat.Type == RootEnums.CategoryType.News)
                        if (File.Exists(Server.MapPath("~/UI/RSS/Categories/" + _cat.Name)))
                        {
                            File.Delete(Server.MapPath("~/UI/RSS/Categories/" + _cat.Name));
                        }

                    BindGrid();
                    AddMode();
                    plcControls.Visible = false;
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.Message;
                }
            }
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            Category Cat = new Category();
            if (ObjectID <= 0)
            {
                try
                {
                    Cat.IsDeleted = false;
                    Cat.Name = txtName.Text;
                    Cat.Type = TG.ExpressCMS.DataLayer.Enums.RootEnums.CategoryType.Projects;
                    Cat.Description = txtDesc.Content;
                    Cat.XslID = -1;
                    Cat.Attributes = string.Empty;
                    Cat.Image = string.Empty;
                    Cat.Hash = "";
                    Cat.LanguageID = 1;//Convert.ToInt32(ddlLanguages.SelectedValue);
                    CategoryManager.Add(Cat);
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
                    Cat = CategoryManager.GetByID(ObjectID);
                    if (null == Cat)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    Cat.IsDeleted = false;
                    Cat.Name = txtName.Text;
                    Cat.Type = TG.ExpressCMS.DataLayer.Enums.RootEnums.CategoryType.Projects;
                    Cat.Description = txtDesc.Content;
                    Cat.XslID = -1;
                    Cat.Hash = "";
                    Cat.Attributes = string.Empty;
                    Cat.Image = string.Empty;
                    Cat.LanguageID = 1;//Convert.ToInt32(ddlLanguages.SelectedValue);
                    CategoryManager.Update(Cat);
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

        void gvCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvCat.SelectedDataKey.Value);
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

            txtDesc.Content = "";
            txtName.Text = "";

            dvProblems.InnerText = "";
            dvProblems.Style.Add(HtmlTextWriterStyle.Display, "none");
            //   ddlLanguages.SelectedIndex = -1;


            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                Category cat = new Category();
                cat = CategoryManager.GetByID(ObjectID);
                if (null == cat)
                    return;

                txtName.Text = cat.Name;
                txtDesc.Content = cat.Description;

                // ddlLanguages.SelectedValue = cat.LanguageID.ToString();
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvCat.DataSource = CategoryManager.GetAll().Where(t => t.Type == (RootEnums.CategoryType.Projects)).ToList();
            gvCat.DataBind();
        }
        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;

        }
        /// <summary>
        /// Get Cat Status
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        protected string GetType(int _type)
        {
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Menu)
            {
                return Resources.ExpressCMS.ResourceManager.GetString("MenuCategory");
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.News)
            {
                return Resources.ExpressCMS.ResourceManager.GetString("NewCategory");
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Banner)
            {
                return "Banner";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Event)
            {
                return "Event";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Fatawa)
            {
                return "Fatawa";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Gallery)
            {
                return "Gallery";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.IslamicStudies)
            {
                return "Islamic Studies";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Marquee)
            {
                return "Marquee";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Sawtyyat)
            {
                return "Sawtyyat";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Videos)
            {
                return "Videos";
            }
            if (((RootEnums.CategoryType)Convert.ToInt32(_type)) == RootEnums.CategoryType.Projects)
            {
                return "Projects";
            }
            return "";
        }
        private void ReadQueryString()
        {
            if (Request.QueryString[ConstantsManager.Type] != null)
            {
                int type = 0;
                Int32.TryParse(Request.QueryString[ConstantsManager.Type], out type);
                if (type == 0)
                    return;
                gvCat.DataSource = CategoryManager.GetAll().Where(t => t.Type == (RootEnums.CategoryType)type).ToList();
                gvCat.DataBind();



            }
        }
        #endregion

    }
}