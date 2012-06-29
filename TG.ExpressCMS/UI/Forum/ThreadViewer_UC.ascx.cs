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

namespace TG.ExpressCMS.UI.Forum
{
    public partial class ThreadViewer_UC : System.Web.UI.UserControl
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
            this.Load += new EventHandler(ThreadsViewer_UC_Load);
            base.OnInit(e);
        }
        #endregion

        #region ThreadsViewer_UC_Load
        void ThreadsViewer_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ThreadID = 0;
                int.TryParse(Request.QueryString["ThreadID"], out ThreadID);

                ObjectID = ThreadID;
                DataLayer.Entities.ForumThread forumThread = null;
                DataLayer.Entities.Forum forum = null;
                if (ObjectID > 0)
                {
                    forumThread = ForumThreadManager.GetByPublishedID(ThreadID);
                    if (forumThread != null)
                        forum = ForumManager.GetPublishedByID(forumThread.ForumID);
                }
                if (forum != null && forumThread != null)
                {
                    BindForumThread(forumThread);
                    BindPosts(forumThread.ID);
                    plcThread.Visible = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateThreadViews('" + forumThread.ID + "');", true);

                    #region PagePath

                    List<PagePath> allPaths = new List<PagePath>();
                    PagePath pagePath = new PagePath();
                    pagePath.Name = forum.ForumGroupName;
                    pagePath.Url = ConfigContext.GetForumGroupPage;
                    allPaths.Add(pagePath);

                    pagePath = new PagePath();
                    pagePath.Name = forum.Name;
                    pagePath.Url = UtilitiesManager.GetForumURL(forum.ID);
                    allPaths.Add(pagePath);

                    pagePath = new PagePath();
                    pagePath.Name = forumThread.Name;
                    pagePath.Url = string.Empty;
                    allPaths.Add(pagePath);

                    ucPagePath.BindPath(allPaths);
                    #endregion
                }
                else
                {
                    plcThread.Visible = false;
                }
            }
            ScriptManager CurrentScriptManager = ScriptManager.GetCurrent(this.Page);
            CurrentScriptManager.Services.Add(new ServiceReference("~/Services/ForumService.asmx"));
        }
        #endregion

        #endregion

        #region Methods

        #region BindForumThread
        void BindForumThread(DataLayer.Entities.ForumThread forumThread)
        {
            lblThreadName.Text = forumThread.Name;
            lblThreadTotalPostsValue.Text = forumThread.TotalPosts.ToString();
            dvThreadDetails.InnerHtml = forumThread.DetailsHtml;
            hypForumUserProfile.Text = forumThread.UserSummary.UserName;
            hypForumUserProfile.NavigateUrl = ForumUtilities.GetForumProfile(forumThread.UserSummary.UserID);
            imgUser.ImageUrl = GetForumUserImage(forumThread.UserSummary.Image);
            ratingThreadUser.CurrentRating = forumThread.UserSummary.UserRateValue;
            if (forumThread.TotalPosts == null)
                lblTotalPosts.Text = "0";
            else
                lblTotalPosts.Text = forumThread.TotalPosts.ToString();
            hypAddPost.NavigateUrl = GetAddPostURL(forumThread.ID, 0);
        }
        #endregion

        #region BindPosts
        void BindPosts(int ThreadID)
        {
            ucDataPager.PagePath = UtilitiesManager.GetThreadURL(ThreadID);
            if (SecurityContext.LoggedInForumUser != null)
                ucDataPager.PageSize = SecurityContext.LoggedInForumUser.PostsPerPage;

            int resultCount = 0;
            dlPosts.DataSource = ForumPostManager.GetByPublishedThreadID(ThreadID, ucDataPager.CurrentPageNumber, ucDataPager.PageSize, ref resultCount);
            dlPosts.DataBind();

            ucDataPager.BindPager(resultCount);
        }
        #endregion

        #region GetDateByFormat
        public string GetDateByFormat(object ObjDateTime, string DateTimeFormat)
        {
            DateTime dateTime = (DateTime)(ObjDateTime);
            return dateTime.ToString(DateTimeFormat);
        }
        #endregion

        #region GetAddPostURL
        public string GetAddPostURL(int ThreadID, int PostID)
        {
            return UtilitiesManager.GetAddPostURL(ThreadID, PostID);
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