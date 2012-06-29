using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.DataLayer.Enums;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.DataLayer.Entities;
using System.Configuration;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.UI.Utilities;

namespace TG.ExpressCMS.UI.Forum
{
    public partial class ForumViewer_UC : System.Web.UI.UserControl
    {
        #region Global
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
        #endregion

        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ForumViewer_UC_Load);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.lbtnAddThread.Click += new EventHandler(lbtnAddThread_Click);
        }
        #endregion

        #region lbtnAddThread_Click
        void lbtnAddThread_Click(object sender, EventArgs e)
        {
            if (SecurityContext.LoggedInUser == null)
                Response.Redirect(UtilitiesManager.GetLoginURL());

            if (SecurityContext.LoggedInForumUser == null)
                Response.Redirect(UtilitiesManager.GetRegistrationForumURL());

            if (!SecurityContext.CheckAccessAddThread())
                return;

            BeginAddMode();
            pnlAddThread.Visible = true;
            upAddThread.Update();
        }
        #endregion

        #region btnAdd_Click
        void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObjectID <= 0)
                    throw new Exception("Error: Forum not found");

                if (SecurityContext.LoggedInUser == null)
                    Response.Redirect(UtilitiesManager.GetLoginURL());

                if (SecurityContext.LoggedInForumUser == null)
                    Response.Redirect(UtilitiesManager.GetRegistrationForumURL());

                DataLayer.Entities.ForumUser forumUser = SecurityContext.LoggedInForumUser;
                if (!SecurityContext.CheckAccessAddThread())
                    throw new Exception("Error: Cann't add post");

                DataLayer.Entities.ForumThread forumThread = new DataLayer.Entities.ForumThread();
                forumThread.CreatedBy = forumUser.UserID;
                forumThread.CreationDate = DateTime.Now;
                forumThread.DetailsHtml = (BadWordFilter.Instance.GetCleanString(HttpUtility.HtmlEncode(txtThreadDetails.Text), BadWordFilter.CleanUpOptions.ReplaceEachWord));
                forumThread.DetailsText = (BadWordFilter.Instance.GetCleanString(HttpUtility.HtmlEncode(txtThreadDetails.Text), BadWordFilter.CleanUpOptions.ReplaceEachWord));
                forumThread.ForumID = ObjectID;
                
                forumThread.IsDeleted = false;
                forumThread.LastPostID = 0;
                forumThread.Name = (BadWordFilter.Instance.GetCleanString(HttpUtility.HtmlEncode(txtThreadName.Text), BadWordFilter.CleanUpOptions.ReplaceEachWord));
                forumThread.NumberThreadViews = 0;
                if (forumUser.IsTrusted)
                    forumThread.Status = RootEnums.ForumThreadStatus.Active;
                else
                    forumThread.Status = RootEnums.ForumThreadStatus.InActive;
                forumThread.TotalPosts = 0;

                ForumThreadManager.Add(forumThread);


                if (forumUser.IsTrusted)
                {
                    ScriptManager.RegisterStartupScript(upAddThread, upAddThread.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumForThreads('" + forumThread.ID + "');", true);
                }

                ScriptManager.RegisterStartupScript(upAddThread, upAddThread.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "alert('" + Resources.ExpressCMS.AddedSuccess + "');", true);

                BeginAddMode();
                BindForumThread(ObjectID);
                pnlAddThread.Visible = false;
                plcForum.Visible = true;

                upnlThreads.Update();


                //emailSender.EmailSender _emailsender = new emailSender.EmailSender();
                //_emailsender.AddemailtoQueueNow(0, SecurityContext.LoggedInUser.Email, forumUser.UserName, Resources.ForumResource.SavedPostSuccessfully, "NoTImeFORLove", emailSender.EmailType.System);
                //_emailsender.AddemailtoQueueNow(0, "Admin", forumUser.UserName, Resources.ForumResource.SavedPostSuccessfully, "NoTImeFORLove", emailSender.EmailType.System);
                //_emailsender.ProcessAllPendingEmail("NoTImeFORLove");


            }
            catch (Exception ex)
            {
                dvAddThreadMessages.InnerText = ex.Message;
            }

        }
        #endregion

        #region ForumViewer_UC_Load
        void ForumViewer_UC_Load(object sender, EventArgs e)
        {
            dvAddThreadMessages.InnerText = "";
            if (!IsPostBack)
            {
                int ForumID = 0;
                int.TryParse(Request.QueryString["ForumID"], out ForumID);

                ObjectID = ForumID;
                DataLayer.Entities.Forum forum = null;
                if (ObjectID > 0)
                {
                    forum = ForumManager.GetPublishedByID(ForumID);
                }
                if (forum != null)
                {
                    BindForum(forum);
                    BindForumThread(forum.ID);
                    //lbtnAddThread.Visible = SecurityContext.CheckAccessAddThread();
                    plcForum.Visible = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumViews('" + forum.ID + "');", true);

                    #region PagePath
                    List<PagePath> allPaths = new List<PagePath>();
                    PagePath pagePath = new PagePath();
                    pagePath.Name = forum.ForumGroupName;
                    pagePath.Url = ConfigContext.GetForumGroupPage;
                    allPaths.Add(pagePath);

                    pagePath = new PagePath();
                    pagePath.Name = forum.Name;
                    pagePath.Url = string.Empty;
                    allPaths.Add(pagePath);

                    ucPagePath.BindPath(allPaths);
                    #endregion
                }
                else
                {
                    plcForum.Visible = false;
                }
                pnlAddThread.Visible = false;
            }
            ScriptManager CurrentScriptManager = ScriptManager.GetCurrent(this.Page);
            CurrentScriptManager.Services.Add(new ServiceReference("~/Services/ForumService.asmx"));
        }
        #endregion

        #endregion

        #region Methods

        #region BindForum
        void BindForum(DataLayer.Entities.Forum forum)
        {
            lblForumName.Text = forum.Name;
            lblForumTotalThreadsValue.Text = forum.TotalThreads.ToString();
            dvForumDetails.InnerHtml = forum.DetailsHtml;

            //lbtnAddThread.Visible = SecurityContext.CheckAccessAddThread();
        }
        #endregion

        #region BindForumThread
        void BindForumThread(int ForumID)
        {
            ucDataPager.PagePath = UtilitiesManager.GetForumURL(ForumID);
            if (SecurityContext.LoggedInForumUser != null)
                ucDataPager.PageSize = SecurityContext.LoggedInForumUser.ThreadsPerPage;

            int resultCount = 0;
            dlThreads.DataSource = ForumThreadManager.GetByPublishedForumID(ForumID, ucDataPager.CurrentPageNumber, ucDataPager.PageSize, ref resultCount);
            dlThreads.DataBind();

            ucDataPager.BindPager(resultCount);
        }
        #endregion

        #region GetThreadURL
        public string GetThreadURL(int ThreadID)
        {
            return UtilitiesManager.GetThreadURL(ThreadID);
        }
        #endregion

        #region GetDateByFormat
        public string GetDateByFormat(object ObjDateTime, string DateTimeFormat)
        {
            DateTime dateTime = (DateTime)(ObjDateTime);
            return dateTime.ToString(DateTimeFormat);
        }
        #endregion

        #region BeginAddMode
        void BeginAddMode()
        {
            txtThreadName.Text = string.Empty;
            txtThreadDetails.Text = string.Empty;

        }
        #endregion

        #region GetForumUserImage
        public string GetForumUserImage(string UserImagePath)
        {
            return ForumUtilities.GetForumUserImage(UserImagePath);
        }
        #endregion

        #region GetForumUserProfile
        public string GetForumUserProfile(int UserId)
        {
            return ForumUtilities.GetForumProfile(UserId);
        }
        #endregion

        #endregion
    }
}