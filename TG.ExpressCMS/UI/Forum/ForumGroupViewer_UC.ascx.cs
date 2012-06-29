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
    public partial class ForumGroupViewer_UC : System.Web.UI.UserControl
    {
        #region Events

        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ForumGroupViewer_UC_Load);
            this.dlGroups.ItemDataBound += new DataListItemEventHandler(dlGroups_ItemDataBound);
        }
        #endregion

        #region dlGroups_ItemDataBound
        void dlGroups_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    int GroupID = Convert.ToInt32(dlGroups.DataKeys[e.Item.ItemIndex]);
                    DataList dlForums = e.Item.FindControl("dlForums") as DataList;
                    dlForums.ItemDataBound += new DataListItemEventHandler(dlForums_ItemDataBound);
                    dlForums.DataSource = ForumManager.GetByGroupID(GroupID);
                    dlForums.DataBind();
                    break;
            }
        }
        #endregion

        #region dlForums_ItemDataBound
        void dlForums_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    HtmlInputHidden hdnForumLastThread = e.Item.FindControl("hdnForumLastThread") as HtmlInputHidden;
                    int LastForumThreadID = Convert.ToInt32(hdnForumLastThread.Value);

                    HyperLink hlForumLastThread = e.Item.FindControl("hlForumLastThread") as HyperLink;
                    if (LastForumThreadID > 0)
                    {
                        hlForumLastThread.Visible = true;
                        hlForumLastThread.NavigateUrl = UtilitiesManager.GetThreadURL(LastForumThreadID);
                    }
                    else
                    {
                        hlForumLastThread.Visible = false;
                    }
                    break;
            }
        }
        #endregion

        #region ForumGroupViewer_UC_Load
        void ForumGroupViewer_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindForumGroup();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region BindForumGroup
        void BindForumGroup()
        {
            dlGroups.DataSource = ForumGroupManager.GetAll();
            dlGroups.DataBind();
        }
        #endregion

        #region GetForumURL
        public string GetForumURL(int ForumID)
        {
            return UtilitiesManager.GetForumURL(ForumID);
        }
        #endregion

        #region GetThreadURL
        public string GetThreadURL(int ThreadID)
        {
            return UtilitiesManager.GetThreadURL(ThreadID);
        }
        #endregion

        #endregion
    }
}