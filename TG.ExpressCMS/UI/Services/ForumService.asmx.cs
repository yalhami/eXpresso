using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Enums;

namespace TGExpressCMSServices
{
    /// <summary>
    /// Summary description for ForumService
    /// </summary>
    [WebService(Namespace = "TGExpressCMSServices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ForumService : System.Web.Services.WebService
    {
        [WebMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownForum(string knownCategoryValues, string category)
        {
            List<AjaxControlToolkit.CascadingDropDownNameValue> Contents = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            List<Forum> forums = ForumManager.GetAll();
            foreach (Forum forum in forums)
            {
                Contents.Add(new AjaxControlToolkit.CascadingDropDownNameValue(forum.Name, forum.ID.ToString()));
            }

            return Contents.ToArray();
        }

        [WebMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownThread(string knownCategoryValues, string category)
        {
            // Get a dictionary of known category/value pairs
            StringDictionary knownCategoryValuesDictionary = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int forumId = 0;
            int.TryParse(knownCategoryValuesDictionary["Forum"], out forumId);
            List<AjaxControlToolkit.CascadingDropDownNameValue> Contents = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            List<ForumThread> forumThreads = ForumThreadManager.GetByForumID(forumId);
            foreach (ForumThread forumThread in forumThreads)
            {
                Contents.Add(new AjaxControlToolkit.CascadingDropDownNameValue(forumThread.Name, forumThread.ID.ToString()));
            }

            return Contents.ToArray();
        }

        [WebMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownPost(string knownCategoryValues, string category)
        {
            // Get a dictionary of known category/value pairs
            StringDictionary knownCategoryValuesDictionary = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);

            int threadId = 0;
            int.TryParse(knownCategoryValuesDictionary["Thread"], out threadId);

            List<AjaxControlToolkit.CascadingDropDownNameValue> Contents = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            List<ForumPost> forumPosts = ForumPostManager.GetByThreadID(threadId);
            foreach (ForumPost forumPost in forumPosts)
            {
                Contents.Add(new AjaxControlToolkit.CascadingDropDownNameValue(forumPost.Name, forumPost.ID.ToString()));
            }

            return Contents.ToArray();
        }

        [WebMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownSecurityUserNotInForum(string knownCategoryValues, string category)
        {
            List<AjaxControlToolkit.CascadingDropDownNameValue> Contents = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            List<ForumUser> forumUsers = ForumUserManager.GetAll();
            IList<Users> users = UsersManager.GetAll().Where(u => forumUsers.Where(fu => fu.UserID == u.ID).FirstOrDefault() == null).ToList();
            foreach (Users user in users)
            {
                Contents.Add(new AjaxControlToolkit.CascadingDropDownNameValue(user.Email, user.ID.ToString()));
            }

            return Contents.ToArray();
        }

        [WebMethod]
        public AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownUser(string knownCategoryValues, string category)
        {
            List<AjaxControlToolkit.CascadingDropDownNameValue> Contents = new List<AjaxControlToolkit.CascadingDropDownNameValue>();
            List<ForumUser> forumUsers = ForumUserManager.GetAll();
            foreach (ForumUser user in forumUsers)
            {
                Contents.Add(new AjaxControlToolkit.CascadingDropDownNameValue(user.UserName, user.UserID.ToString()));
            }

            return Contents.ToArray();
        }

        [WebMethod]
        [SoapDocumentMethod(OneWay = true)]
        public void UpdateForumAndThreadNumbers(string ForumValueID, string ThreadValueID)
        {
            try
            {
                int ForumID = 0;
                int.TryParse(ForumValueID, out ForumID);

                int ThreadID = 0;
                int.TryParse(ThreadValueID, out ThreadID);
                if (ForumID > 0)
                {
                    List<ForumPost> forumPosts = ForumPostManager.GetByPublishedForumID(ForumID);
                    List<ForumPost> forumThreadPosts = ForumPostManager.GetByPublishedThreadID(ThreadID);

                    if (forumPosts.Count > 0)
                    {
                        Forum forum = ForumManager.GetByID(ForumID);
                        forum.LastForumPostID = forumPosts[forumPosts.Count - 1].ID;
                        forum.TotalPosts = forumPosts.Count;
                        ForumManager.Update(forum);
                    }

                    if (forumThreadPosts.Count > 0)
                    {
                        ForumThread forumThread = ForumThreadManager.GetByID(ThreadID);
                        forumThread.LastPostID = forumThreadPosts[forumThreadPosts.Count - 1].ID;
                        forumThread.TotalPosts = forumThreadPosts.Count;
                        ForumThreadManager.Update(forumThread);
                    }
                }
            }
            catch { }
        }

        [WebMethod]
        [SoapDocumentMethod(OneWay = true)]
        public void UpdateForumAndThreadForPosts(string PostsValueIDs)
        {
            try
            {
                List<int> PostIDs = PostsValueIDs.Split(';').Select(p => Convert.ToInt32(p)).ToList();
                for (int i = 0; i < PostIDs.Count; i++)
                {
                    ForumPost forumPost = ForumPostManager.GetByIDWithIsDelete(PostIDs[i]);
                    if (forumPost == null)
                        continue;

                    List<ForumPost> forumPosts = ForumPostManager.GetByPublishedForumID(forumPost.ForumID);
                    List<ForumPost> forumThreadPosts = ForumPostManager.GetByPublishedThreadID(forumPost.ForumThreadID);

                    if (forumPosts.Count > 0)
                    {
                        Forum forum = ForumManager.GetByID(forumPost.ForumID);
                        forum.LastForumPostID = forumPosts[forumPosts.Count - 1].ID;
                        forum.TotalPosts = forumPosts.Count;
                        ForumManager.Update(forum);
                    }

                    if (forumThreadPosts.Count > 0)
                    {
                        ForumThread forumThread = ForumThreadManager.GetByID(forumPost.ForumThreadID);
                        forumThread.LastPostID = forumThreadPosts[forumThreadPosts.Count - 1].ID;
                        forumThread.TotalPosts = forumThreadPosts.Count;
                        ForumThreadManager.Update(forumThread);
                    }
                }
            }
            catch { }
        }

        [WebMethod]
        [SoapDocumentMethod(OneWay = true)]
        public void UpdateForumForThreads(string ThreadValueIDs)
        {
            try
            {
                List<int> ThreadIDs = ThreadValueIDs.Split(';').Select(p => Convert.ToInt32(p)).ToList();
                for (int i = 0; i < ThreadIDs.Count; i++)
                {
                    ForumThread forumThread = ForumThreadManager.GetByIDWithIsDelete(ThreadIDs[i]);
                    if (forumThread == null)
                        continue;

                    List<ForumThread> forumThreads = ForumThreadManager.GetByPublishedForumID(forumThread.ForumID);
                    List<ForumPost> forumPosts = ForumPostManager.GetByPublishedForumID(forumThread.ForumID);

                    Forum forum = ForumManager.GetByID(forumThread.ForumID);
                    if (forum != null)
                    {
                        if (forumThreads.Count > 0)
                        {
                            forum.LastForumThreadID = forumThreads[forumThreads.Count - 1].ID;
                            forum.TotalThreads = forumThreads.Count;
                        }
                        if (forumPosts.Count > 0)
                        {
                            forum.LastForumPostID = forumPosts[forumPosts.Count - 1].ID;
                            forum.TotalPosts = forumPosts.Count;
                        }
                        ForumManager.Update(forum);
                    }
                }
            }
            catch { }
        }

        [WebMethod]
        [SoapDocumentMethod(OneWay = true)]
        public void UpdateForumViews(string ForumValueID)
        {
            try
            {
                int ForumID = 0;
                int.TryParse(ForumValueID, out ForumID);

                ForumManager.UpdateNumberViews(ForumID);
            }
            catch { }
        }

        [WebMethod]
        [SoapDocumentMethod(OneWay = true)]
        public void UpdateThreadViews(string ThreadValueID)
        {
            try
            {
                int ThreadID = 0;
                int.TryParse(ThreadValueID, out ThreadID);

                ForumThreadManager.UpdateNumberViews(ThreadID);
            }
            catch { }
        }
    }
}