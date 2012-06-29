using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using System.Xml;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Careers
{
    public partial class CareersApplication_UC : System.Web.UI.UserControl
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

            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);

        }


        protected override void CreateChildControls()
        {
            base.CreateChildControls();

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
                AddMode();
                PerformSettings();
                FillOpenCareers();
            }

        }



        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.CareerPosts _careerpost = null;
            if (ObjectID <= 0)
            {
                try
                {
                    _careerpost = new TG.ExpressCMS.DataLayer.Entities.CareerPosts();
                    _careerpost.CVDocument = "";
                    if (fUploaderCV.UploadedFiles.Count > 0)
                        _careerpost.CVDocument = UtilitiesManager.GetSavedFile(fUploaderCV.UploadedFiles[0], true);
                    _careerpost.CVText = txtTextCV.Text;
                    _careerpost.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    _careerpost.Image = "";
                    if (fUploader.UploadedFiles.Count > 0)
                        _careerpost.Image = UtilitiesManager.GetSavedFile(fUploader.UploadedFiles[0], true);
                    _careerpost.JobID = Convert.ToInt32(ddlJobID.SelectedValue);
                    _careerpost.Name = txtName.Text;
                    _careerpost.Phone = txtPhone.Text;
                    _careerpost.Title = "";
                    _careerpost.Experiences = GetXExperienceandEpx().OuterXml;
                    CareerPostsManager.Add(_careerpost);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 4), "alert('" + Resources.ExpressCMS.ResourceManager.GetString("YourAppHadbeenrecievedsuccessfully") + "');", true);

                    dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString("YourAppHadbeenrecievedsuccessfully");
                    AddMode();
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }

            }
        }

        private XmlDocument GetXExperienceandEpx()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement xRoot = xDoc.CreateElement("Data");
            xDoc.AppendChild(xRoot);
            XmlElement xExperiences = xDoc.CreateElement("Experiences");
            xRoot.AppendChild(xExperiences);
            XmlAttribute xEdu = xDoc.CreateAttribute("Data");
            xEdu.Value = txtEducation.Text;
            xExperiences.Attributes.Append(xEdu);

            XmlElement xEducation = xDoc.CreateElement("Education");
            xRoot.AppendChild(xEducation);
            XmlAttribute xExp = xDoc.CreateAttribute("Data");
            xExp.Value = txtEducation.Text;
            xEducation.Attributes.Append(xExp);
            return xDoc;
        }


        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtTextCV.Text = string.Empty;
            txtEducation.Text = string.Empty;
            txtExperiences.Text = string.Empty;
            ddlJobID.SelectedIndex = -1;
        }

        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = true;


        }
        private void FillOpenCareers()
        {
            ddlJobID.DataSource = TG.ExpressCMS.DataLayer.Data.HtmlItemManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.HtmlBlockType.Careers).ToList();
            ddlJobID.DataTextField = "Name";
            ddlJobID.DataValueField = "ID";
            ddlJobID.DataBind();
            ddlJobID.Items.Insert(0, new ListItem());
        }

        #endregion
    }
}