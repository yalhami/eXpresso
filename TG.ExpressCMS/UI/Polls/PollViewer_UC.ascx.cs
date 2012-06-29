using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using System.Collections;

namespace TG.ExpressCMS.UI
{
    public partial class PollViewer_UC : System.Web.UI.UserControl
    {

        public Poll _poll
        {

            get
            {
                if (Session["_poll"] == null)
                {
                    Poll _polls = PollManager.GetAll().Where(t => t.IsDeleted == false).FirstOrDefault();
                    Session["_poll"] = _polls;
                    return _polls;
                }
                else
                {
                    return (Poll)(Session["_poll"]);
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(PollViewer_UC_Load);

            this.btnVote.Click += new EventHandler(btnVote_Click);
        }

        void btnVote_Click(object sender, EventArgs e)
        {
            bool canVote = CanVote();
            if (!canVote)
            {
                ScriptManager.RegisterStartupScript(upnlVote, upnlVote.GetType(), Guid.NewGuid().ToString().Substring(0, 7), "alert('" + Resources.ExpressCMS.PolledBefore + "');", true);

                return;
            }
            for (int i = 0; i < rdblstAnswers.Items.Count; i++)
            {
                if (rdblstAnswers.Items[i].Selected)
                {
                    PollDetails _pollDetails = PollDetailsManager.GetByID(Convert.ToInt32(rdblstAnswers.Items[i].Value));
                    _pollDetails.Count++;
                    PollDetailsManager.Update(_pollDetails);
                }
            }
            dvmessages.InnerText = Resources.ExpressCMS.PollSubmitted;

            SetCookies();
            ScriptManager.RegisterStartupScript(upnlVote, upnlVote.GetType(), "JiS", "alert('" + Resources.ExpressCMS.ThnkUVote + "');", true);
            //btnVote.Enabled = false
            ;
        }
        private void SetCookies()
        {
            HttpCookie aCookie = new HttpCookie("Vok");
            aCookie.Value = _poll.ID.ToString();
            aCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(aCookie);
        }
        private bool CanVote()
        {
            if (Request.Cookies["Vok"] == null)
                return true;
            if (Request.Cookies["Vok"].Value == null)
                return true;
            if (Request.Cookies["Vok"].Value == _poll.ID.ToString())
            {
                return false;
            }
            else
                return true;
        }


        void PollViewer_UC_Load(object sender, EventArgs e)
        {
            dvmessages.InnerText = string.Empty;
            if (!IsPostBack)
            {
                FillReadioButtonList();
                FillResult();
                GetPollName();
                btnVote.Attributes.Add("onclick", "return CheckFields('" + Resources.ExpressCMS.plzselectanasnwer + "');");
            }
            bool canVote = CanVote();
            if (!canVote)
            {
                //  btnVote.Enabled = false;
                btnVote.ToolTip = Resources.ExpressCMS.PolledBefore;
            }
        }

        private void FillReadioButtonList()
        {
            IList<PollDetails> colPollDetails = PollDetailsManager.GetByPollID(_poll.ID);
            rdblstAnswers.DataSource = colPollDetails;
            rdblstAnswers.DataTextField = "Name";
            rdblstAnswers.DataValueField = "ID";
            rdblstAnswers.DataBind();
        }
        private void FillResult()
        {
            dtlst.DataSource = PollDetailsManager.GetByPollID(_poll.ID);

            dtlst.DataBind();
        }
        private void PerformSettings()
        {
            lblPollQuestion.Text = _poll.Name;
        }
        protected Unit GetWidth(int _count)
        {
            int totalCount = PollDetailsManager.GetPollTotalCount(_poll.ID);
            double percentage = Convert.ToDouble(_count) / Convert.ToDouble(totalCount);
            percentage = percentage * 100;
            if (percentage <= 0)
                percentage = 1;
            Unit unit = new Unit(percentage);
            return unit;
        }
        protected string GetPercentage(int count)
        {
            int totalCount = PollDetailsManager.GetPollTotalCount(_poll.ID);
            double percentage = Convert.ToDouble(count) / Convert.ToDouble(totalCount);
            percentage = percentage * 100;
            percentage = Math.Round(percentage, 2);
            return percentage.ToString();
        }
        protected string GetVoteCultureCode()
        {
            return Resources.ExpressCMS.Vote;
        }
        protected string GetCloseToolTip()
        {
            return Resources.ExpressCMS.ibtnClose;
        }
        protected string GetPollName()
        {
            lblPollName.Text = _poll.Name;
            lblPollQuestion.Text = _poll.Name;
            return _poll.Name;
        }
    }
}