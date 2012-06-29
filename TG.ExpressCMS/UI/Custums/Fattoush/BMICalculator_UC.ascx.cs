using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Custums.Fattoush
{
    public partial class BMICalculator_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(BMICalculator_UC_Load);


        }


        void BMICalculator_UC_Load(object sender, EventArgs e)
        {
            dvresult.InnerText = "";
            if (!IsPostBack)
            {
                PerformSettings();
            }
        }

        private void PerformSettings()
        {
            txtlength.Text = "";
            txtWidth.Text = "";

        }
    }
}