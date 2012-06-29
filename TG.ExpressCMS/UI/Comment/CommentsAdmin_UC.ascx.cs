using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.UI.Comment
{
    public partial class CommentsAdmin_UC : System.Web.UI.UserControl
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
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.ibtnDelete.Click += new ImageClickEventHandler(ibtnDelete_Click);
            this.ddlNewsCategory.SelectedIndexChanged += new EventHandler(ddlNewsCategory_SelectedIndexChanged);
            this.Load += new EventHandler(_commentAdd_UC_Load);
            this.gvComment.RowCommand += new GridViewCommandEventHandler(gv_comment_RowCommand);
            this.gvComment.PageIndexChanging += new GridViewPageEventHandler(gv_comment_PageIndexChanging);
            
        }

        void ddlNewsCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNewsCategory.SelectedValue == "")
                return;
            ddlNews.DataSource = NewsItemManager.GetByCategoryID(Convert.ToInt32(ddlNewsCategory.SelectedValue));
            ddlNews.DataTextField = "Name";
            ddlNews.DataValueField = "ID";
            ddlNews.DataBind();
            ddlNews.Items.Insert(0, new ListItem());
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            int newsid = 0;
            int catid = 0;
            Int32.TryParse(ddlNews.SelectedValue, out newsid);
            Int32.TryParse(ddlNewsCategory.SelectedValue, out catid);
           
            {
                gvComment.DataSource = CommentManager.SearchNewsComment(newsid, catid);
                gvComment.DataBind();
            }
        }

        void gv_comment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvComment.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        void gv_comment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditComment")
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
        void _commentAdd_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                PerformSettings();
                FillDDL();
              
            }
        }

        void ibtnadd_Click(object sender, ImageClickEventArgs e)
        {
          
        }

        void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            for (int i = 0; i < gvComment.Rows.Count; i++)
            {
                CheckBox chkItem = (CheckBox)gvComment.Rows[i].FindControl("chkItem");
                if (null == chkItem)
                    continue;
                if (!chkItem.Checked)
                    continue;
                HtmlInputHidden hdnID = (HtmlInputHidden)gvComment.Rows[i].FindControl("hdnID");
                if (null == hdnID)
                    return;
                int _id = Convert.ToInt32(hdnID.Value);

                CommentManager.Delete(_id);

            }
            BindGrid();
          
            plcControls.Visible = false;
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            TG.ExpressCMS.DataLayer.Entities.Comment _comment = new TG.ExpressCMS.DataLayer.Entities.Comment();

            try
            {
                _comment = CommentManager.GetByID(ObjectID);
                if (null == _comment)
                {
                    dvProblems.InnerText = Resources.ExpressCMS.ResourceManager.GetString(ConstantsManager.UnknowErronOccures);
                    return;
                }
                _comment.IsDeleted = false;

                _comment.Status = (TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentStatus)Convert.ToInt32(ddlStatus.SelectedValue);
                _comment.ModifiedValue = txtModifiedDetails.Text;



                CommentManager.Update(_comment);
                EditMode();
             
            }
            catch (Exception ex)
            {
                dvProblems.InnerText = ex.ToString();
            }

            BindGrid();
        }



        void btnReset_Click(object sender, EventArgs e)
        {

            EditMode();

        }

        void btnExit_Click(object sender, EventArgs e)
        {
            plcControls.Visible = false;
        }

        #region "Methods"

        private void EditMode()
        {
            if (ObjectID > 0)
            {
                TG.ExpressCMS.DataLayer.Entities.Comment cat = new TG.ExpressCMS.DataLayer.Entities.Comment();
                cat = CommentManager.GetByID(ObjectID);
                if (null == cat)
                    return;
                ddlStatus.SelectedValue = Convert.ToInt32(cat.Status).ToString();
                txtName.Text = cat.Name;
                txtDetails.Text = cat.IntialValue;
                txtEmail.Text = cat.Email;
                txtIPAddress.Text = cat.IPAddress;
                txtModifiedDetails.Text = cat.ModifiedValue;
                if (txtModifiedDetails.Text == "")
                    txtModifiedDetails.Text = cat.ModifiedValue;
                txtSubject.Text = cat.Subject;
                txtDetails.Enabled = false;
                txtEmail.Enabled = false;
                txtIPAddress.Enabled = false;
                txtName.Enabled = false;
                txtSubject.Enabled = false;
                plcControls.Visible = true;
            }
        }

        /// <summary>
        /// Bind Grid View
        /// </summary>
        private void BindGrid()
        {
            gvComment.DataSource = CommentManager.GetPendingComments();
            gvComment.DataBind();
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
            ddlStatus.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.CommentStatus));
            ddlStatus.DataTextField = "Key";
            ddlStatus.DataValueField = "Value";
            ddlStatus.DataBind();

            ddlStatus.Items.Insert(0, new ListItem());

            ddlNewsCategory.DataSource = CategoryManager.GetAll().Where(t => t.Type == RootEnums.CategoryType.News).ToList();
            ddlNewsCategory.DataTextField = "Name";
            ddlNewsCategory.DataValueField = "ID";
            ddlNewsCategory.DataBind();
            ddlNewsCategory.Items.Insert(0, new ListItem());
        }
        /// <summary>
        /// Get _comment Status
        /// </summary>
        /// <param name="_status"></param>
        /// <returns></returns>
        protected string GetURL(int newsid)
        {
            TG.ExpressCMS.DataLayer.Entities.NewsItem _news = NewsItemManager.GetByID(newsid);
            if (null == _news)
                return "";
            return _news.Url;
        }
        protected string GetStatus(int status)
        {
            if (TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentStatus.Pending == (TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentStatus)status)
            {
                return Resources.ExpressCMS.ResourceManager.GetString("Pending");
            }
            else
                return Resources.ExpressCMS.ResourceManager.GetString("Reviewed");
        }
     
        #endregion

    }
}