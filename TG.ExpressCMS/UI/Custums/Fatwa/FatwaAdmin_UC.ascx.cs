using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Linq;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Enums;



namespace TG.ExpressCMS.UI.Fatwa
{
    public partial class FatwaAdmin_UC : System.Web.UI.UserControl
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

            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ibtnadd.Click += new ImageClickEventHandler(ibtnadd_Click);
            this.Load += new EventHandler(CatAdd_UC_Load);
            this.gvFatwa.RowCommand += new GridViewCommandEventHandler(gvCat_RowCommand);
            this.gvFatwa.PageIndexChanging += new GridViewPageEventHandler(gvCat_PageIndexChanging);

            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.gvFatwa.RowEditing += new GridViewEditEventHandler(gvFatwa_RowEditing);

        }



        void gvFatwa_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            int catid = 0;

            Int32.TryParse(ddlCategory.SelectedValue, out catid);
            string keyword = string.Empty;
            if (txtKeyword.Text != string.Empty)
                keyword += "%" + txtKeyword.Text + "%";

            IList<Fatawa> colFatawa = null;
            int status = 0;
            Int32.TryParse(ddlStatusSearch.SelectedValue, out status);
            if (Convert.ToInt32(RootEnums.FatawaStatus.Pending) == status)
            {
                colFatawa = FatawaManager.Search(keyword, catid).Where(t => t.Status == 0).ToList();
            }
            else
                colFatawa = FatawaManager.Search(keyword, catid).Where(t => t.Status == 1).ToList(); ;
            AddMode(); plcControls.Visible = false;
            if (colFatawa == null || colFatawa.Count == 0)
            {
                colFatawa = new List<Fatawa>();
                //dvProblems.InnerText = "لا يوجد نتائج لهذا البحث";
                gvFatwa.DataSource = colFatawa;
                gvFatwa.DataBind();
                return;
            }

            gvFatwa.DataSource = colFatawa;
            gvFatwa.DataBind();
        }
        void gvCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFatwa.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gvCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
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
            dvProblems.InnerText = "";
            if (!IsPostBack)
            {
                BindGrid();
                PerformSettings();
                AddMode();
                FillDDL();
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
            AddMode();
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvFatwa.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvFatwa.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvFatwa.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                FatawaManager.Delete(_id);
            }
            BindGrid();
            AddMode();
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (ObjectID <= 0)
            {
                try
                {
                    Fatawa _fatwa = new Fatawa();

                    _fatwa.Address = "";
                    _fatwa.Answer = txtAnswer.Text;
                    _fatwa.AnswerDate = DateTime.Now.ToString("dd/MM/yyyy");
                    _fatwa.AnsweredBy = SecurityContext.LoggedInUser.Name;
                    _fatwa.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                    _fatwa.Email = txtEmail.Text;
                    _fatwa.QuestionDate = DateTime.Now.ToString("dd/MM/yyyy");

                    _fatwa.IsDeleted = false;
                    _fatwa.Mobile = "";
                    _fatwa.Name = txtName.Text;
                    _fatwa.Question = txtQuestion.Text;
                    _fatwa.Status = 1;
                    FatawaManager.Add(_fatwa);
                    AddMode();
                    ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), Guid.NewGuid().ToString().Substring(0, 8), "alert('Saved Successfully');", true);
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
                    Fatawa _fatwa = new Fatawa();
                    _fatwa = FatawaManager.GetByID(ObjectID);
                    if (null == _fatwa)
                    {
                        dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                        return;
                    }
                    _fatwa.Address = "";
                    _fatwa.Answer = txtAnswer.Text;
                    _fatwa.AnswerDate = DateTime.Now.ToString("dd/MM/yyyy");
                    _fatwa.AnsweredBy = SecurityContext.LoggedInUser.Name;
                    _fatwa.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
                    _fatwa.Email = txtEmail.Text;
                    _fatwa.IsDeleted = false;
                    _fatwa.Mobile = "";
                    _fatwa.Name = txtName.Text;
                    _fatwa.Question = txtQuestion.Text;
                    _fatwa.Status = Convert.ToInt32(ddlStatus.SelectedValue);
                    FatawaManager.Update(_fatwa);
                    EditMode();
                    if (_fatwa.Status == Convert.ToInt32(RootEnums.FatawaStatus.Resolved))
                    {
                        AddEmailtoQueue(_fatwa.Email, _fatwa.Name, _fatwa.Question, _fatwa.Answer);
                    }
                    ScriptManager.RegisterStartupScript(upnall, upnall.GetType(), Guid.NewGuid().ToString().Substring(0, 8), "alert('Saved Successfully');", true);
                }
                catch (Exception ex)
                {
                    dvProblems.InnerText = ex.ToString();
                }
            }

        }
        private void AddEmailtoQueue(string email, string name, string question, string answer)
        {
            // emailSender.EmailSender wbClient = new emailSender.EmailSender();
            EmailSender.EmailSenderSoapClient wbClient = new EmailSender.EmailSenderSoapClient();
            wbClient.AddemailtoQueueNow(0, email, name, "اجابة سوالك في موقع الدكتور نوح:<br/>السؤال<br/>" + question + "<br/>" + "الاجابه<br/>" + answer, "NoTImeFORLove");
            wbClient.ProcessAllPendingEmail("NoTImeFORLove");
        }
        void btnReset_Click(object sender, EventArgs e)
        {
            if (ObjectID > 0)
                EditMode();
            else
                AddMode();
        }
        private void FillDDL()
        {
            ddlCategory.DataSource = ddlCategories.DataSource = CategoryManager.GetAll().Where(t => t.Type == DataLayer.Enums.RootEnums.CategoryType.Fatawa).ToList();
            ddlCategory.DataTextField = ddlCategories.DataTextField = "Name";
            ddlCategory.DataValueField = ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategory.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("تصنيفات الفتاوى...."));
            ddlCategory.Items.Insert(0, new ListItem("تصنيفات الفتاوى...."));

            ddlStatusSearch.DataSource = ddlStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.FatawaStatus));
            ddlStatus.DataTextField = ddlStatusSearch.DataTextField = "Key";
            ddlStatus.DataValueField = ddlStatusSearch.DataValueField = "Value";
            ddlStatusSearch.DataBind();
            ddlStatus.DataBind();

            ddlStatus.Items.Insert(0, new ListItem(""));
            ddlStatusSearch.Items.Insert(0, new ListItem(""));
        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"
        private void AddMode()
        {
            plcControls.Visible = true;
            txtAnswer.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtQuestion.Text = "";
            ddlStatus.SelectedIndex = -1;
            ddlCategories.SelectedIndex = -1;
            ObjectID = 0;
        }
        private void EditMode()
        {
            if (ObjectID > 0)
            {
                Fatawa _ftwa = FatawaManager.GetByID(ObjectID);
                if (null == _ftwa)
                    return;
                //   ddlXsls.SelectedValue = cat.XslID.ToString();
                txtEmail.Text = _ftwa.Email;
                txtName.Text = _ftwa.Name;
                txtQuestion.Text = _ftwa.Question;
                txtAnswer.Text = _ftwa.Answer;
                if (_ftwa.CategoryID != -1)
                    ddlCategories.SelectedValue = _ftwa.CategoryID.ToString();
                else
                    ddlCategories.SelectedIndex = -1;
                ddlStatus.SelectedValue = _ftwa.Status.ToString();
                plcControls.Visible = true;
            }
        }


        /// <summary>
        /// Performs Settings.
        /// </summary>
        private void PerformSettings()
        {
            plcControls.Visible = false;

        }

        #endregion
    }
}