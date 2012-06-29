using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.DataLayer.Enums;
using System.Configuration;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using System.Collections;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Configuration;
using System.IO;

namespace TG.ExpressCMS.UI.Menus
{
    public partial class MenuAdmins_UC : System.Web.UI.UserControl
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
            trMenuItems.SelectedNodeChanged += new EventHandler(trMenuItems_SelectedNodeChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(MenuItemsAdd_UC_Load);
            this.ddlMenuType.SelectedIndexChanged += new EventHandler(ddlMenuType_SelectedIndexChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            ddlMenuCategories.SelectedIndexChanged += new EventHandler(ddlMenuCategories_SelectedIndexChanged);
            this.ibtnGenerateXmlFiles.Click += new ImageClickEventHandler(ibtnGenerateXmlFiles_Click);
        }

        void ibtnGenerateXmlFiles_Click(object sender, ImageClickEventArgs e)
        {
            string[] files = Directory.GetFiles(Server.MapPath("~/UserPages/Generatedpages"), "*.xml", SearchOption.AllDirectories);
            IList<string> colFiles = new List<string>();
            for (int i = 0; i < files.Count(); i++)
            {
                File.Delete(files[i]);
            }
            dvProblems.InnerText = "Menu generated successfully.";
        }



        void trMenuItems_SelectedNodeChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(trMenuItems.SelectedValue);
            EditMode();

        }



        void ddlMenuCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ViewState["CatID"] = ddlMenuCategories.SelectedValue;

                AddMode();
                BindGrid(string.Empty);

                ddlCategories.SelectedValue = (ViewState["CatID"].ToString());
                ddlCategories.Enabled = false;

                ddlParentMenu.DataSource = MenuItemManager.GetAll().Where(t => t.IsDeleted == false && t.CategoryId == Convert.ToInt32(ddlMenuCategories.SelectedValue)).ToList();
                ddlParentMenu.DataTextField = "Name";
                ddlParentMenu.DataValueField = "ID";
                ddlParentMenu.DataBind();

                ddlParentMenu.Items.Insert(0, new ListItem("Add as Primary Item", "0"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(txtSearch.Text);

            AddMode();
            plcControls.Visible = false;

        }



        void ddlMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int result = 0;
            Int32.TryParse(ddlMenuType.SelectedValue, out result);
            if (result > 0)
            {
                if ((TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype)(result) != RootEnums.MenuItemURLtype.External)
                {
                    trDetails.Visible = true;
                    //  trURL.Visible = false;
                    txtURL.Text = ConfigurationManager.AppSettings["DefMenuDetailsPage"];
                    trURL.Visible = false;
                }
                else
                {
                    //trURL.Visible = true;
                    trDetails.Visible = false;
                    txtURL.Text = "";
                    trURL.Visible = true;
                }
            }
        }


        /// <summary>
        /// Load Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MenuItemsAdd_UC_Load(object sender, EventArgs e)
        {
            dvProblems.InnerText = "";
            SetEditorPaths();
            if (!IsPostBack)
            {
                FillDDL(true);

                AddMode();

                if (Request.QueryString["MenuID"] != null)
                {
                    plcGridView.Visible = false;
                    plcControls.Visible = true;
                    dvCustom.Style.Add(HtmlTextWriterStyle.Display, "none");
                    //dvcustom2.Style.Add(HtmlTextWriterStyle.Display, "none");
                    //   dvcustom2.Visible = false;

                    ddlMenuCategories.SelectedIndex = 1;
                    int id = 0;
                    Int32.TryParse(Request.QueryString["MenuID"], out id);
                    ObjectID = id;
                    EditMode();
                }
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < trMenuItems.CheckedNodes.Count; i++)
            {
                MenuItemManager.Delete(Convert.ToInt32(trMenuItems.CheckedNodes[i].Value));
            }
            BindGrid(string.Empty);
            AddMode();
            plcControls.Visible = false;
        }



        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            int catid = 0;
            TG.ExpressCMS.DataLayer.Entities.MenuItem menuItems = new TG.ExpressCMS.DataLayer.Entities.MenuItem();
            if (ObjectID <= 0)
            {
                try
                {
                    menuItems.Name = txtName.Text;
                    menuItems.Description = txtDesc.Text;
                    menuItems.Details = txtDetails.Text;


                    int mappedlangID = 0;
                    Int32.TryParse(ddlMappedLanguageID.SelectedValue, out mappedlangID);
                    menuItems.RefLangID = mappedlangID;

                    int.TryParse(ddlCategories.SelectedValue, out catid);

                    menuItems.CategoryId = Convert.ToInt32(ddlMenuCategories.SelectedValue);
                    if (txtOrderNumber.Text.Length > 0)
                        menuItems.OrderNumber = Convert.ToInt32(txtOrderNumber.Text);
                    menuItems.LangID = 1;// Convert.ToInt32(ddlLanguages.SelectedValue);
                    menuItems.CreationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    menuItems.CreationTime = DateTime.Now.ToString("dd/MM/yyyy");
                    menuItems.CreatedBy = SecurityContext.LoggedInUser.ID;
                    menuItems.IsDeleted = false;

                    menuItems.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                    menuItems.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype)Convert.ToInt32(ddlMenuType.SelectedValue);
                    // menuItems.PublishFrom = txtPublishFrom.SelectedDate.Value.ToShortDateString();
                    //   menuItems.PublishTo = txtDateTo.SelectedDate.Value.ToShortDateString();
                    menuItems.MenuID = Convert.ToInt32(ddlParentMenu.SelectedValue);
                    menuItems.Url = string.Empty;

                    if (rdblstIsPublished.SelectedValue == "1")
                        menuItems.IsPublished = true;
                    else
                        menuItems.IsPublished = false;


                    MenuItemManager.Add(menuItems);

                    if (ddlMenuType.SelectedValue == Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype.External).ToString())
                        menuItems.Url = txtURL.Text;
                    else
                        menuItems.Url = ResolveUrl(ExpressoConfig.MenuConfigElement.GetDefaultDetailsPage) + ConstantsManager.MenuID + "=" + menuItems.ID;

                    menuItems.Url = menuItems.Url.Replace("/ar/", "/");
                    MenuItemManager.Update(menuItems);
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
                    menuItems = MenuItemManager.GetByID(ObjectID);
                    if (null == menuItems)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    menuItems.LangID = 1;// Convert.ToInt32(ddlLanguages.SelectedValue);
                    menuItems.Name = txtName.Text;
                    menuItems.Description = txtDesc.Text;
                    menuItems.Details = txtDetails.Text;
                    int.TryParse(ddlCategories.SelectedValue, out catid);
                    menuItems.CategoryId = Convert.ToInt32(ddlMenuCategories.SelectedValue);
                    menuItems.Url = txtURL.Text;
                    if (txtOrderNumber.Text.Length > 0)
                        menuItems.OrderNumber = Convert.ToInt32(txtOrderNumber.Text);
                    menuItems.IsDeleted = false;
                    if (chkChangeimage.Checked)
                        menuItems.Image = UtilitiesManager.GetSavedFile(fUploader, true);
                    menuItems.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype)Convert.ToInt32(ddlMenuType.SelectedValue);
                    // menuItems.PublishFrom = txtPublishFrom.SelectedDate.Value.ToString("dd/MM/yyyy");
                    // menuItems.PublishTo = txtDateTo.SelectedDate.Value.ToString("dd/MM/yyyy");

                    if (rdblstIsPublished.SelectedValue == "1")
                        menuItems.IsPublished = true;
                    else
                        menuItems.IsPublished = false;

                    int mappedlangID = 0;
                    Int32.TryParse(ddlMappedLanguageID.SelectedValue, out mappedlangID);
                    menuItems.RefLangID = mappedlangID;

                    menuItems.MenuID = Convert.ToInt32(ddlParentMenu.SelectedValue);
                    menuItems.Url = "";
                    if (ddlMenuType.SelectedValue == Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype.External).ToString())
                        menuItems.Url = txtURL.Text;
                    else
                        menuItems.Url = ResolveUrl(ExpressoConfig.MenuConfigElement.GetDefaultDetailsPage) + ConstantsManager.MenuID + "=" + menuItems.ID;
                    menuItems.Url = menuItems.Url.Replace("/ar/", "/");
                    MenuItemManager.Update(menuItems);
                    EditMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            BindGrid(string.Empty);
            RefillMenus();
        }

        void gvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(trMenuItems.SelectedValue);
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
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            if (ddlMenuCategories.SelectedIndex > 0)
            {
                ddlCategories.Enabled = true;
                ddlMappedLanguageID.SelectedIndex = -1;
                chkChangeimage.Visible = false;
                plcControls.Visible = true;
                txtURL.Text = "";
                txtName.Text = "";
                //  ddlLanguages.SelectedIndex = -1;
                txtDetails.Text = "";
                txtDesc.Text = "";
                //txtDateTo.Clear();
                //  txtPublishFrom.DbSelectedDate = DateTime.Now.ToString("dd/MM/yyyy");
                ddlCategories.SelectedIndex = -1;
                txtURL.Text = ExpressoConfig.MenuConfigElement.GetDefaultDetailsPage;
                ddlMenuType.SelectedValue = Convert.ToInt32(TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype.Internal).ToString();
                trURL.Visible = false;
                trDetails.Visible = true;
                plcControls.Visible = true;
                plcGridView.Visible = true;
                ddlCategories.SelectedIndex = -1;
                ddlParentMenu.SelectedIndex = -1;
                rdblstIsPublished.SelectedValue = "1";
                chkChangeimage.Checked = false;
                chkChangeimage.Visible = false;
            }
            else
            {
                plcControls.Visible = false;
                plcGridView.Visible = false;

            }
            imguploaded.ImageUrl = GetArticleImage("");
            ObjectID = 0;
        }
        private void SetEditorPaths()
        {
            txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityFlashGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityMediaGalleryPath("~/Upload/UserUploads/");
            //txtDetails.SetSecurityImageBrowserPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityImageGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityFilesGalleryPath("~/Upload/UserUploads/");
            txtDetails.SetSecurityMaxImageSize(102400);
            txtDetails.SetSecurityMaxFlashSize(102400);
            txtDetails.SetSecurityMaxDocumentSize(102400);

            txtDetails.EnableClientScript = true;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                chkChangeimage.Checked = false;
                ddlCategories.Enabled = true;
                chkChangeimage.Visible = true;
                TG.ExpressCMS.DataLayer.Entities.MenuItem MenuItems = new TG.ExpressCMS.DataLayer.Entities.MenuItem();
                MenuItems = MenuItemManager.GetByID(ObjectID);
                if (null == MenuItems)
                    return;
                imguploaded.ImageUrl = imguploaded.ImageUrl = GetArticleImage(MenuItems.Image);
                TG.ExpressCMS.DataLayer.Entities.MenuItem mItem = MenuItemManager.GetByID(MenuItems.MenuID);
                GetArticleImage(MenuItems.Image);
                //   txtPublishFrom.DbSelectedDate = MenuItems.PublishFrom;
                // txtDateTo.DbSelectedDate = MenuItems.PublishTo;
                txtDesc.Text = MenuItems.Description;
                txtDetails.Text = MenuItems.Details;
                txtName.Text = MenuItems.Name;
                txtURL.Text = MenuItems.Url;
                if (MenuItems.RefLangID != 0)
                    ddlMappedLanguageID.SelectedValue = MenuItems.RefLangID.ToString();
                //   ddlLanguages.SelectedValue = MenuItems.LangID.ToString();
                txtOrderNumber.Text = MenuItems.OrderNumber.ToString();
                ddlMenuType.SelectedValue = Convert.ToInt32(MenuItems.Type).ToString();
                ddlCategories.SelectedValue = MenuItems.CategoryId.ToString();
                if (MenuItems.Type == RootEnums.MenuItemURLtype.External)
                {
                    trDetails.Visible = false;
                    trURL.Visible = true;
                }
                else
                {
                    trDetails.Visible = true;
                    trURL.Visible = false;
                }
                rdblstIsPublished.SelectedIndex = -1;
                rdblstIsPublished.SelectedValue = Convert.ToInt32(MenuItems.IsPublished).ToString();

                if (mItem != null)
                    ddlParentMenu.SelectedValue = mItem.ID.ToString();


                plcControls.Visible = true;

            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid(string keyword)
        {
            trMenuItems.Nodes.Clear();
            if (keyword == string.Empty)
            {
                IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> colParentMenus = MenuItemManager.GetAll().Where(t => t.MenuID == 0 && t.CategoryId == Convert.ToInt32(ddlMenuCategories.SelectedValue)).ToList();
                for (int i = 0; i < colParentMenus.Count; i++)
                {
                    TreeNode node = RecursionFill(colParentMenus[i]);
                    trMenuItems.Nodes.Add(node);
                }

                trMenuItems.DataBind();
            }
            else
            {
                IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> colParentMenus = MenuItemManager.Search(txtSearch.Text);
                for (int i = 0; i < colParentMenus.Count; i++)
                {
                    TreeNode node = RecursionFill(colParentMenus[i]);
                    trMenuItems.Nodes.Add(node);
                }

                trMenuItems.DataBind();
            }
        }
        private TreeNode RecursionFill(TG.ExpressCMS.DataLayer.Entities.MenuItem menuItem)
        {
            string imageurl = "";
            DateTime dtfrom = DateTime.Now;
            DateTime dtto = DateTime.Now;

            DateTime.TryParse(menuItem.PublishFrom, out dtfrom); DateTime.TryParse(menuItem.PublishTo, out dtto);
            if (menuItem.IsPublished)
            {
                imageurl = ResolveUrl("~/App_themes/AdminSide/Images/camera_test.png");
            }
            else
            {
                imageurl = ResolveUrl("~/App_themes/AdminSide/Images/dialog-error.png");
            }

            TreeNode newNode = new TreeNode(menuItem.Name, menuItem.ID.ToString(), imageurl);
            IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> colChildMenus = MenuItemManager.GetAllBySearchandPublishedforAdmin(Convert.ToInt32(ddlMenuCategories.SelectedValue), "%%", menuItem.ID);
            foreach (TG.ExpressCMS.DataLayer.Entities.MenuItem item in colChildMenus)
            {
                newNode.ChildNodes.Add(RecursionFill(item));
            }
            return newNode;
        }

        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;
        }
        private void FillDDL(bool fillall)
        {
            ddlMenuCategories.DataSource = ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Menu).ToList();
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlMenuCategories.DataTextField = "Name";
            ddlMenuCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlMenuCategories.DataBind();
            ddlMenuCategories.Items.Insert(0, new ListItem("", ""));

            if (fillall)
            {
                ddlMenuType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.MenuItemURLtype));
                ddlMenuType.DataTextField = "Key";
                ddlMenuType.DataValueField = "Value";
                ddlMenuType.DataBind();



                ddlMappedLanguageID.DataSource = MenuItemManager.GetAllofLangauge().Where(t => t.IsDeleted == false).ToList();
                ddlMappedLanguageID.DataTextField = "Name";
                ddlMappedLanguageID.DataValueField = "ID";
                ddlMappedLanguageID.DataBind();

                ddlMappedLanguageID.Items.Insert(0, new ListItem("Please Select Item", "0"));
                //ddlLanguages.Items.Insert(0, new ListItem("", ""));
                ddlParentMenu.Items.Insert(0, new ListItem("Add it as Primary Menu", "0"));
                ddlCategories.Items.Insert(0, new ListItem("", ""));

                ddlMenuType.Items.Insert(0, new ListItem("", ""));
                return;
            }
        }
        private void RefillMenus()
        {
            //if (ViewState["CatID"] != null)
            //    ddlParentMenu.DataSource = MenuItemManager.GetAllBySearchandPublished(Convert.ToInt32(ViewState["CatID"]), "%%", -1);
            //else
            ddlParentMenu.DataSource = MenuItemManager.GetAll().Where(t => t.IsDeleted == false && t.CategoryId == Convert.ToInt32(ViewState["CatID"])).ToList();
            ddlParentMenu.DataTextField = "Name";
            ddlParentMenu.DataValueField = "ID";
            ddlParentMenu.DataBind();

            ddlParentMenu.Items.Insert(0, new ListItem("Add as Primary", "0"));
        }
        public string GetArticleImage(string image)
        {
            if (image != string.Empty)
                return ExpressoConfig.GeneralConfigElement.GetVirtualUploadPath + image;
            else
                return ResolveUrl("~") + "App_themes/UserSides/images/defImage.png";
        }
        #endregion
    }
}