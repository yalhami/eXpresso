using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;

namespace TG.ExpressCMS.UI.Gallery
{
    public partial class GalleryAdmin_UC : System.Web.UI.UserControl
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
            this.gvGallery.SelectedIndexChanged += new EventHandler(gvGallery_SelectedIndexChanged);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(galleryItemsAdd_UC_Load);
            this.gvGallery.RowCommand += new GridViewCommandEventHandler(gvGallery_RowCommand);

            this.gvGallery.PageIndexChanging += new GridViewPageEventHandler(gvGallery_PageIndexChanging);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);

        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid(txtSearch.Text);

            plcControls.Visible = false;

        }

        void gvGallery_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGallery.PageIndex = e.NewPageIndex;
            BindGrid(string.Empty);
        }



        void gvGallery_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditgalleryItems")
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
        void galleryItemsAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(string.Empty);
                FillDDL();
                AddMode();
                plcControls.Visible = false;
                ddlGalleryType.SelectedIndex = 1;
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            bool write = false;
            XmlElement _root = xDoc.CreateElement("slideshow");
            for (int i = 0; i < gvGallery.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvGallery.Rows[i].FindControl("chkItemUnique");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvGallery.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);
                TG.ExpressCMS.DataLayer.Entities.Gallery gallery = GalleryManager.GetByID(_id);
                if (null != gallery)
                {
                    try
                    {
                        GalleryManager.Delete(_id);
                        File.Delete(Server.MapPath("~/Upload/Files/Gallery/" + gallery.Path));
                        if (gallery.Type == RootEnums.GalleryType.Image)
                        {
                            File.Delete(Server.MapPath("~/Upload/Files/Gallery/Thumb-" + gallery.Path));
                            if (gallery.CategoryID == 55 || gallery.CategoryID == 54)
                            {
                                WriteXML(xDoc, _root, gallery.CategoryID);
                                write = true;

                                if (write)
                                    if (gallery.CategoryID == 55)
                                        xDoc.Save(Server.MapPath("~/Userpages/images.xml"));
                                    else
                                        if (gallery.CategoryID == 54)
                                            xDoc.Save(Server.MapPath("~/Userpages/data.xml"));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dvProblems.InnerText = e.ToString();
                        break;
                    }

                }


            }

            BindGrid(string.Empty);
            AddMode();

            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.Gallery galleryItems = new TG.ExpressCMS.DataLayer.Entities.Gallery();

            XmlDocument xDoc = new XmlDocument();
            bool write = false;
            XmlElement _root = xDoc.CreateElement("slideshow");
            if (ObjectID <= 0)
            {
                try
                {

                    for (int i = 0; i < fUploader.UploadedFiles.Count; i++)
                    {
                        galleryItems.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                        galleryItems.CreatedBy = SecurityContext.LoggedInUser.ID;
                        galleryItems.Date = txtDate.Text;
                        galleryItems.Description = txtDesc.Text;
                        galleryItems.IsArchieved = false;
                        galleryItems.IsDeleted = false;

                        // galleryItems.Name = fUploader.UploadedFiles[i].GetNameWithoutExtension();
                        if (i > 0)
                            galleryItems.Name = txtName.Text + "_" + i.ToString();
                        else
                            galleryItems.Name = txtName.Text;
                        galleryItems.Tags = txtTags.Text;
                        galleryItems.Type = (RootEnums.GalleryType)Convert.ToInt32(ddlGalleryType.SelectedValue);
                        if (galleryItems.Type == RootEnums.GalleryType.Image)
                            galleryItems.Path = UtilitiesManager.GetSavedFileforGallery(fUploader.UploadedFiles[i], true, true);
                        else
                            galleryItems.Path = UtilitiesManager.GetSavedFile(fUploader.UploadedFiles[i], true);
                        galleryItems.Url = txtUrl.Text;

                        GalleryManager.Add(galleryItems);

                    }
                    if (galleryItems.CategoryID == 55 || galleryItems.CategoryID == 54)
                    {
                        WriteXML(xDoc, _root, galleryItems.CategoryID);
                        write = true;
                    }
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
                    galleryItems = GalleryManager.GetByID(ObjectID);
                    if (null == galleryItems)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }

                    galleryItems.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);

                    galleryItems.Description = txtDesc.Text;

                    galleryItems.Name = txtName.Text;

                    galleryItems.Tags = txtTags.Text;
                    galleryItems.Type = (RootEnums.GalleryType)Convert.ToInt32(ddlGalleryType.SelectedValue);
                    galleryItems.Url = txtUrl.Text;
                    if (fUploader.UploadedFiles.Count > 0)
                        galleryItems.Path = UtilitiesManager.GetSavedFileforGallery(fUploader.UploadedFiles[0], true, true);

                    GalleryManager.Update(galleryItems);


                    if (galleryItems.CategoryID == 55 || galleryItems.CategoryID == 54)
                    {
                        WriteXML(xDoc, _root, galleryItems.CategoryID);
                        write = true;
                    }
                    EditMode();
                    dvProblems.InnerText = "Saved Successfully";
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }
            if (write)
                if (galleryItems.CategoryID == 55)
                    xDoc.Save(Server.MapPath("~/Userpages/images.xml"));
                else
                    if (galleryItems.CategoryID == 54)
                        xDoc.Save(Server.MapPath("~/Userpages/data.xml"));

            BindGrid(string.Empty);
        }

        void gvGallery_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvGallery.SelectedDataKey.Value);
            EditMode();
        }
        private void WriteXML(XmlDocument xDoc, XmlElement _root, int catid)
        {
            //XmlDocument xDoc = new XmlDocument();
            //XmlElement _root = xDoc.CreateElement("slideshow");

            IList<TG.ExpressCMS.DataLayer.Entities.Gallery> colGalleries = GalleryManager.GetByCategory(catid);
            for (int i = 0; i < colGalleries.Count; i++)
            {

                XmlElement _photo = xDoc.CreateElement("photo");
                _root.AppendChild(_photo);

                XmlAttribute _image = xDoc.CreateAttribute("image");
                _image.Value = "../upload/files/gallery/" + colGalleries[i].Path;
                _photo.Attributes.Append(_image);

                XmlAttribute _bigimage = xDoc.CreateAttribute("bigimage");
                _bigimage.Value = "../upload/files/gallery/" + colGalleries[i].Path;
                _photo.Attributes.Append(_bigimage);

                XmlAttribute _target = xDoc.CreateAttribute("target");
                _target.Value = "_blank";
                _photo.Attributes.Append(_target);

                XmlAttribute _lightboxinfo = xDoc.CreateAttribute("lightboxinfo");
                if (colGalleries[i].Description != null)
                    _lightboxinfo.Value = colGalleries[i].Description;
                else
                    _lightboxinfo.Value = "";
                _photo.Attributes.Append(_lightboxinfo);

                XmlAttribute _url = xDoc.CreateAttribute("url");
                _url.Value = colGalleries[i].Url;
                _photo.Attributes.Append(_url);

            }
            xDoc.AppendChild(_root);
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
            plcControls.Visible = true;
            txtTags.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtName.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtDate.Text = string.Empty;
            ddlGalleryType.SelectedIndex = -1;
            ddlCategories.SelectedIndex = -1;
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Gallery galleryItems = new TG.ExpressCMS.DataLayer.Entities.Gallery();
                galleryItems = GalleryManager.GetByID(ObjectID);
                if (null == galleryItems)
                    return;
                txtDate.Text = galleryItems.Date;
                txtDesc.Text = galleryItems.Description;
                txtName.Text = galleryItems.Name;
                txtTags.Text = galleryItems.Tags;
                txtUrl.Text = galleryItems.Url;
                ddlCategories.SelectedValue = galleryItems.CategoryID.ToString();
                ddlGalleryType.SelectedValue = Convert.ToInt32(galleryItems.Type).ToString();
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid(string keyword)
        {
            int catid = 0;
            Int32.TryParse(ddlSearchCategories.SelectedValue, out catid);
            if (keyword == string.Empty)
            {
                gvGallery.DataSource = GalleryManager.GetByCategory(catid);
                gvGallery.DataBind();
            }
            else
            {
                gvGallery.DataSource = GalleryManager.GetByCategory(catid).Where(t => t.Description.Contains(keyword) || t.Name.Contains(keyword)).ToList();
                gvGallery.DataBind();
            }
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
            ddlGalleryType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.GalleryType));
            ddlGalleryType.DataTextField = "Key";
            ddlGalleryType.DataValueField = "Value";
            ddlGalleryType.DataBind();

            ddlSearchCategories.DataSource = ddlCategories.DataSource = CategoryManager.GetAll().Where(t => (t.Type == RootEnums.CategoryType.Gallery || t.Type == RootEnums.CategoryType.Projects) && t.IsDeleted == false).ToList();
            ddlSearchCategories.DataTextField = ddlCategories.DataTextField = "Name";
            ddlSearchCategories.DataValueField = ddlCategories.DataValueField = "ID";
            ddlSearchCategories.DataBind(); ddlCategories.DataBind();

            ddlCategories.Items.Insert(0, new ListItem("", ""));
            ddlSearchCategories.Items.Insert(0, new ListItem("", ""));
            ddlGalleryType.Items.Insert(0, new ListItem("", ""));
        }
        protected string GetImageUrl(string image)
        {
            return "~/Upload/Files/Gallery/Thumb-" + image;
        }
        #endregion
    }
}