using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Comment
{
    public partial class CommentsUserSide_UC : System.Web.UI.UserControl
    {
        public int ObjectID
        {
            set
            {
                ViewState["ObjectID"] = value;
            }
            get
            {
                if (ViewState["ObjectID"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(ViewState["ObjectID"].ToString());
                }
            }
        }
        public TG.ExpressCMS.DataLayer.Enums.RootEnums.ObjectType ObjectType
        {
            set
            {
                ViewState["ObjectType"] = Convert.ToInt32(value);
            }
            get
            {
                if (ViewState["ObjectType"] == null)
                {
                    return TG.ExpressCMS.DataLayer.Enums.RootEnums.ObjectType.News;
                }
                else
                {
                    return (TG.ExpressCMS.DataLayer.Enums.RootEnums.ObjectType)Convert.ToInt32((ViewState["ObjectType"].ToString()));
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ContactUs_UC_Load);
        }

        void ContactUs_UC_Load(object sender, EventArgs e)
        {
         //   AjaxPro.Utility.RegisterTypeForAjax(typeof(CommentsUserSide_UC), this.Page);
            dvMessage.InnerText = "";
            dvMessage.InnerHtml = "";
            if (!IsPostBack)
                BindComments();
            hdnIPAddress.Value = Request.UserHostAddress;
            hdnObjectID.Value = this.ObjectID.ToString();
            hdnSuccessMsg.Value = Resources.ExpressCMS.ResourceManager.GetString("SuccessComments");
        }

        //[AjaxPro.AjaxMethod]
        public string SubmitForm2(string _name, string _email, string _details, string subject, string ipaddress, string objectid)
        {
            string result = string.Empty;
            TG.ExpressCMS.DataLayer.Entities.Comment _comment = new TG.ExpressCMS.DataLayer.Entities.Comment();

            _comment.Email = HttpUtility.HtmlEncode(_email);
            _comment.IntialValue = HttpUtility.HtmlEncode(_details);
            _comment.Name = HttpUtility.HtmlEncode(_name);
            _comment.Subject = HttpUtility.HtmlEncode(subject);
            _comment.IsDeleted = false;
            _comment.Company = "";
            _comment.Country = "";
            _comment.IPAddress = ipaddress;
            _comment.ModifiedValue = "";
            _comment.ObjectID = Convert.ToInt32(objectid);
            _comment.ObjectType = DataLayer.Enums.RootEnums.ObjectType.News;
            _comment.Type = TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentType.Comment;
            _comment.Status = TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentStatus.Pending;

            CommentManager.Add(_comment);

            return Resources.ExpressCMS.ResourceManager.GetString("CommentAddedSuccess");
        }
        public void BindComments()
        {
            dtComments.DataSource = CommentManager.GetCommentByIDandType(ObjectID, Convert.ToInt32(ObjectType));
            dtComments.DataBind();
        }
    }
}