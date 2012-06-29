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
    public partial class AddPost_UC : System.Web.UI.UserControl
    {
        #region Global
        private int ForumThreadID
        {
            set
            {
                ViewState[ConstantsManager.ThreadID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.ThreadID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.ThreadID]);
                }
                else
                {
                    return -1;
                }
            }
        }
        private int ForumID
        {
            set
            {
                ViewState[ConstantsManager.ForumID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.ForumID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.ForumID]);
                }
                else
                {
                    return -1;
                }
            }
        }
        private int ParentPostID
        {
            set
            {
                ViewState[ConstantsManager.PostID] = value;
            }
            get
            {
                if (null != ViewState[ConstantsManager.PostID])
                {
                    return Convert.ToInt32(ViewState[ConstantsManager.PostID]);
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
            this.Load += new EventHandler(AddPost_UC_Load);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
        }
        #endregion

        #region btnAdd_Click
        void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (SecurityContext.LoggedInUser == null)
                    Response.Redirect(UtilitiesManager.GetLoginURL());

                if (SecurityContext.LoggedInForumUser == null)
                    Response.Redirect(UtilitiesManager.GetRegistrationForumURL());

                if (!SecurityContext.CheckAccessAddPost())
                    throw new Exception("Error: Cann't add post");

                if (ForumThreadID <= 0)
                    throw new Exception("Error: Thread not found");

                if (ParentPostID < 0)
                    throw new Exception("Error: Post not found");

                if (ForumID <= 0)
                    throw new Exception("Error: Forum not found");

                DataLayer.Entities.ForumUser forumUser = SecurityContext.LoggedInForumUser;

                DataLayer.Entities.ForumPost forumPost = new DataLayer.Entities.ForumPost();
                forumPost.CreatedBy = forumUser.UserID;
                forumPost.CreationDate = DateTime.Now;
                forumPost.DetailsHtml = (BadWordFilter.Instance.GetCleanString(HttpUtility.HtmlEncode(txtPostDetails.Text), BadWordFilter.CleanUpOptions.ReplaceEachWord));
                forumPost.DetailsText = (BadWordFilter.Instance.GetCleanString(HttpUtility.HtmlEncode(txtPostDetails.Text), BadWordFilter.CleanUpOptions.ReplaceEachWord));
                forumPost.ForumID = ForumID;
                forumPost.ForumThreadID = ForumThreadID;
                forumPost.IsDeleted = false;
                forumPost.Name = (BadWordFilter.Instance.GetCleanString(HttpUtility.HtmlEncode(txtPostSubject.Text), BadWordFilter.CleanUpOptions.ReplaceEachWord));
                forumPost.ParentPostID = ParentPostID;
                if (forumUser.IsTrusted)
                    forumPost.Status = RootEnums.ForumPostStatus.Active;
                else
                    forumPost.Status = RootEnums.ForumPostStatus.InActive;

                ForumPostManager.Add(forumPost);

                //emailSender.EmailSender _emailsender = new emailSender.EmailSender();
                //_emailsender.AddemailtoQueueNow(0, SecurityContext.LoggedInUser.Email, forumUser.UserName, Resources.ForumResource.SavedPostSuccessfully, "NoTImeFORLove", emailSender.EmailType.System);
                //_emailsender.AddemailtoQueueNow(0, "Admin", forumUser.UserName, Resources.ForumResource.SavedPostSuccessfully, "NoTImeFORLove", emailSender.EmailType.System);
                //_emailsender.ProcessAllPendingEmail("NoTImeFORLove");

                dvAddPostSuccessfully.Visible = true;
                pnlAddPost.Visible = false;

                if (forumUser.IsTrusted)
                {
                    ScriptManager.RegisterStartupScript(upAddPosts, upAddPosts.GetType(), Guid.NewGuid().ToString().Substring(0, 9), "UpdateForumAndThreadNumbers('" + ForumID + "','" + ForumThreadID + "');", true);
                }
            }
            catch (Exception ex)
            {
                dvAddPostsProblems.InnerText = ex.Message;
                dvAddPostsProblems.Visible = true;
            }
            try
            {
                SendReplytoThreadandPosts(ForumThreadID);
            }
            catch 
            {
                
            }
        }
        #endregion

        #region AddPost_UC_Load
        void AddPost_UC_Load(object sender, EventArgs e)
        {
            dvAddPostSuccessfully.Visible = false;
            dvAddPostsProblems.Visible = false;
            if (!IsPostBack)
            {
                int ThreadID = 0;
                int.TryParse(Request.QueryString["ThreadID"], out ThreadID);

                int PostID = 0;
                int.TryParse(Request.QueryString["PostID"], out PostID);

                ForumThreadID = ThreadID;
                ParentPostID = PostID;
                DataLayer.Entities.ForumThread forumThread = null;
                if (ThreadID > 0)
                {
                    forumThread = ForumThreadManager.GetByID(ThreadID);
                }

                try
                {
                    if (SecurityContext.LoggedInUser == null)
                        Response.Redirect(UtilitiesManager.GetLoginURL());

                    if (SecurityContext.LoggedInForumUser == null)
                        Response.Redirect(UtilitiesManager.GetRegistrationForumURL());

                    if (!SecurityContext.CheckAccessAddPost())
                        throw new Exception("Error: Cann't add post");

                    if (forumThread == null)
                        throw new Exception("Error: Thread not found");

                    ForumID = forumThread.ForumID;

                    DataLayer.Entities.ForumPost forumPost = null;
                    if (PostID > 0)
                    {
                        forumPost = ForumPostManager.GetByID(PostID);
                    }
                    if (PostID == 0 || forumPost != null)
                    {
                        pnlAddPost.Visible = true;
                        hypReturn.NavigateUrl = UtilitiesManager.GetThreadURL(ThreadID);
                    }
                    else
                        throw new Exception("Error: Post not found");
                }
                catch (Exception ex)
                {
                    dvAddPostsProblems.InnerText = ex.Message;
                    dvAddPostsProblems.Visible = true;
                    pnlAddPost.Visible = false;
                }
            }
            ScriptManager CurrentScriptManager = ScriptManager.GetCurrent(this.Page);
            CurrentScriptManager.Services.Add(new ServiceReference("~/Services/ForumService.asmx"));
        }
        #endregion

        #endregion

        #region Send Email
        private void SendReplytoThreadandPosts(int threadid)
        {
            IList<TG.ExpressCMS.DataLayer.Entities.ForumPost> colposts = ForumPostManager.GetByThreadID(threadid);
            for (int i = 0; i < colposts.Count; i++)
            {
                TG.ExpressCMS.DataLayer.Entities.Users _user1 = UsersManager.GetByID(colposts[i].CreatedBy);
                if (_user1 == null)
                    continue;
                AddEmailtoQueue(_user1.Email, _user1.Name, colposts[i].DetailsText);
            }
        }
        private void AddEmailtoQueue(string email, string name, string repdetails)
        {
            EmailSender.EmailSenderSoapClient wbClient = new EmailSender.EmailSenderSoapClient();
            wbClient.AddemailtoQueueNow2(CacheContext._DefaultSettings.Name, email, name, UtilitiesManager.ReadFile(Server.MapPath("~/Settings/NewReplyOnThread.txt")) + "<br/>" + repdetails, "NoTImeFORLove");
            wbClient.ProcessAllPendingEmail("NoTImeFORLove");
        }
        #endregion
    }
}