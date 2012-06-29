using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.Utilities;

namespace TG.ExpressCMS.UI.Custums.Fatwa
{
    public partial class FatwaDetailsViewer_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(FatwaDetailsViewer_UC_Load);
        }

        void FatwaDetailsViewer_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFatwaDetails();
            }
        }
        private void GetFatwaDetails()
        {
            if (null == Request.QueryString[ConstantsManager.FatwaID])
                return;

            int fatwaid = 0;
            Int32.TryParse(Request.QueryString[ConstantsManager.FatwaID], out fatwaid);

            TG.ExpressCMS.DataLayer.Entities.Fatawa _fatwa = TG.ExpressCMS.DataLayer.Data.FatawaManager.GetByID(fatwaid);

            if (null == _fatwa)
                return;
            dvdate.InnerText = _fatwa.AnswerDate;
            dvanswer.InnerHtml = _fatwa.Answer;
            dvquestion.InnerText = _fatwa.Question;
            dvansweredBy.InnerText = "تمت الاجابه بواسطة: " + _fatwa.AnsweredBy;
        }
    }
}