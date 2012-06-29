using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace TG.ExpressCMS.UI.Custums.Sawtyyat
{
    public partial class SawwtyyatAdmin_UC : System.Web.UI.UserControl
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
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SawwtyyatAdmin_UC_Load);
            this.btnExit.Click += new EventHandler(btnExit_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ddlType.SelectedIndexChanged += new EventHandler(ddlType_SelectedIndexChanged);
            this.gvSawtyyat.PageIndexChanging += new GridViewPageEventHandler(gvSawtyyat_PageIndexChanging);
            this.gvSawtyyat.RowCommand += new GridViewCommandEventHandler(gvSawtyyat_RowCommand);
            this.gvSawtyyat.SelectedIndexChanged += new EventHandler(gvSawtyyat_SelectedIndexChanged);
            this.gvSawtyyat.RowEditing += new GridViewEditEventHandler(gvSawtyyat_RowEditing);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
        }

        void gvSawtyyat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                ObjectID = Convert.ToInt32(e.CommandArgument);
                EditMode();
            }
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGirdView();
            plcControls.Visible = false;
        }

        void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = 0;
            Int32.TryParse(ddlType.SelectedValue, out type);
            if (type == Convert.ToInt32(RootEnums.AudioVideoType.Audio))
            {
                Fillcatswithaudios();
                trFile.Visible = true;

                lblDetails.Text = "Details";
            }
            else
            {
                FillCatswithVideo();
                trFile.Visible = false;

                lblDetails.Text = "Embed Code";
            }
            ddlSearchtype.SelectedValue = type.ToString();
            BindGirdView();
        }

        void gvSawtyyat_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        void gvSawtyyat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSawtyyat.PageIndex = e.NewPageIndex;
            BindGirdView();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvSawtyyat.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvSawtyyat.Rows[i].FindControl("chkItemUnique");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvSawtyyat.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                SawtyyatManager.Delete(_id);
            }
            BindGirdView();
            AddMode();
            plcControls.Visible = false;
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void gvSawtyyat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectID = Convert.ToInt32(gvSawtyyat.SelectedDataKey.Value);
            EditMode();
        }



        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                TG.ExpressCMS.DataLayer.Entities.Sawtyyat _sawtyyat = new DataLayer.Entities.Sawtyyat();
                if (ObjectID <= 0)
                {
                    _sawtyyat.Type = (RootEnums.AudioVideoType)Convert.ToInt32(ddlType.SelectedValue);
                    if (_sawtyyat.Type == RootEnums.AudioVideoType.Audio)
                    {
                        for (int i = 0; i < fUploader.UploadedFiles.Count; i++)
                        {

                            if (fUploader.UploadedFiles.Count > 1)
                                _sawtyyat.Name = fUploader.UploadedFiles[i].GetNameWithoutExtension();
                            else
                                _sawtyyat.Name = txtName.Text;
                            _sawtyyat.Path = UtilitiesManager.GetSavedFile(fUploader.UploadedFiles[i], false);
                            _sawtyyat.Details = txtDetails.Text;
                            _sawtyyat.Date = DateTime.Now.ToString("dd/MM/yyyy");
                            _sawtyyat.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                            SawtyyatManager.Add(_sawtyyat);
                            writeFile(_sawtyyat.Path);
                        }
                    }
                    else
                    {
                        _sawtyyat.Name = txtName.Text;
                        _sawtyyat.Path = txtDetails.Text;
                        string vidid = _sawtyyat.Path.Substring(_sawtyyat.Path.IndexOf("/embed/"), 18).Replace("/embed/", "");

                        _sawtyyat.Details = "http://img.youtube.com/vi/" + vidid + "/default.jpg";
                        _sawtyyat.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        _sawtyyat.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                        SawtyyatManager.Add(_sawtyyat);
                    }
                    AddMode();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "HDKD", "alert('" + "Saved Successfully" + "');", true);
                }
                else
                {
                    _sawtyyat = SawtyyatManager.GetByID(ObjectID);
                    if (null == _sawtyyat)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    if (_sawtyyat.Type == RootEnums.AudioVideoType.Audio)
                    {

                        //  for (int i = 0; i < fUploader.UploadedFiles.Count; i++)
                        {
                            _sawtyyat.Type = (RootEnums.AudioVideoType)Convert.ToInt32(ddlType.SelectedValue);
                            _sawtyyat.Name = txtName.Text;
                            if (fUploader.UploadedFiles.Count > 0)
                                _sawtyyat.Path = UtilitiesManager.GetSavedFile(fUploader.UploadedFiles[0], false);
                            writeFile(_sawtyyat.Path);
                            _sawtyyat.Details = txtDetails.Text;
                            //   _sawtyyat.Date = DateTime.Now.ToString("dd/MM/yyyy");
                            _sawtyyat.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                            SawtyyatManager.Update(_sawtyyat);

                        } EditMode();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "HDKD", "alert('" + "Saved Successfully" + "');", true);
                    }
                    else
                    {
                        _sawtyyat.Name = txtName.Text;
                        _sawtyyat.Path = txtDetails.Text;
                        string vidid = _sawtyyat.Path.Substring(_sawtyyat.Path.IndexOf("/embed/"), 18).Replace("/embed/", "");

                        _sawtyyat.Details = "http://img.youtube.com/vi/" + vidid + "/default.jpg";
                        _sawtyyat.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        writeFile(_sawtyyat.Path);
                        _sawtyyat.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                        SawtyyatManager.Update(_sawtyyat);
                        EditMode();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "HDKD", "alert('" + "Saved Successfully" + "');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                dvProblems.InnerText = ex.ToString();
            }

            BindGirdView();
        }
        private void writeFile(string filename)
        {
            FileStream _file = File.Create(Server.MapPath("~/Upload/Files/" + filename.Replace(".mp3", "") + ".m3u"));
            _file.Write(Encoding.ASCII.GetBytes(CacheContext._DefaultSettings.DefaultUrl + "/Upload/Files/" + filename), 0, Encoding.ASCII.GetBytes(CacheContext._DefaultSettings.DefaultUrl + "/Upload/Files/" + filename).Count());
            _file.Close();
            _file.Dispose();
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

        void SawwtyyatAdmin_UC_Load(object sender, EventArgs e)
        {
            dvProblems.InnerText = "";
            if (!IsPostBack)
            {
                FillDDL();
                AddMode();
                BindGirdView();
                ddlCategory.SelectedIndex = -1;
                ddlSearchtype.SelectedIndex = -1;
                ddlType.SelectedIndex = -1;
            }
        }
        private void FillDDL()
        {
            ddlSearchtype.DataSource = ddlType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.AudioVideoType));
            ddlSearchtype.DataTextField = ddlType.DataTextField = "Key";
            ddlSearchtype.DataValueField = ddlType.DataValueField = "Value";
            ddlType.DataBind();
            ddlSearchtype.DataBind();
            Fillcatswithaudios();

        }
        private void Fillcatswithaudios()
        {
            ddlCategory.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Sawtyyat).ToList();
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }
        private void FillCatswithVideo()
        {
            ddlCategory.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.Videos).ToList();
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }
        private void BindGirdView()
        {

            IList<TG.ExpressCMS.DataLayer.Entities.Sawtyyat> colSawtyyat = new List<TG.ExpressCMS.DataLayer.Entities.Sawtyyat>();
            int type = 0;
            Int32.TryParse(ddlSearchtype.SelectedValue, out type);
            if (type == Convert.ToInt32(RootEnums.AudioVideoType.Audio))
            {
                colSawtyyat = SawtyyatManager.GetAllByType(RootEnums.AudioVideoType.Audio);
            }
            else
            {
                colSawtyyat = SawtyyatManager.GetAllByType(RootEnums.AudioVideoType.Video);
            }
            gvSawtyyat.DataSource = colSawtyyat;
            gvSawtyyat.DataBind();
        }
        private void AddMode()
        {
            txtDetails.Text = "";
            txtName.Text = "";
            ddlType.SelectedIndex = -1;
            ddlCategory.SelectedIndex = -1;
            plcControls.Visible = true;
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Sawtyyat _sawtyat = SawtyyatManager.GetByID(ObjectID);
                if (null == _sawtyat)
                    return;
                txtDetails.Text = _sawtyat.Details;
                if (_sawtyat.Type == RootEnums.AudioVideoType.Audio)
                {
                    Fillcatswithaudios();
                    trFile.Visible = true;
                }
                else
                {
                    FillCatswithVideo();
                    trFile.Visible = false;
                    txtDetails.Text = _sawtyat.Path;
                }


                txtName.Text = _sawtyat.Name;
                ddlType.SelectedValue = Convert.ToInt32(_sawtyat.Type).ToString();
                ddlCategory.SelectedValue = _sawtyat.CategoryID.ToString();

                plcControls.Visible = true;
            }
        }
    }
}