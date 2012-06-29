using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TG.ExpressCMS.UI.Custums.Sawtyyat
{
    public partial class frmSoundsPlayer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected override void OnInit(EventArgs e)
        {
            this.PreRender += new EventHandler(frmSoundsPlayer_PreRender);
           
            base.OnInit(e);
        }

        void frmSoundsPlayer_PreRender(object sender, EventArgs e)
        {
            string xp = "  <object runat=\"server\" id=\"MediaPlayer\" classid=\"CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6\"standby=\"Loading MicroSoft Windows Media Player components...\" type=\"application/x-oleobject\" width=\"90%\" height=\"64\"><param name=\"url\" runat=\"server\" id=\"url\" value=\"XXXX\">            <param name=\"animationatStart\" value=\"true\">            <param name=\"transparentatStart\" value=\"true\">            <param name=\"autoStart\" value=\"true\">            <param name=\"showControls\" value=\"true\">            <param name=\"ShowDisplay\" value=\"true\">            <embed type=\"application/x-mplayer2\" name=\"MediaPlayer\" controls=\"ControlPanel,StatusBar\"                height=\"64\" width=\"90%\" autostart=\"true\">				  </embed></object>";
            if (Request.QueryString["SoundID"] != null)
            {
                xp = xp.Replace("XXXX", Request.QueryString["SoundID"]);
            }
            dvIdea.InnerHtml = xp;
        }
    }
}