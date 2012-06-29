using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI;
using System.IO;

namespace TGExpressCMSServices
{
    /// <summary>
    /// </summary>
    [WebService(Namespace = "TGExpressCMSServices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class EventWebService : System.Web.Services.WebService
    {
        //[ScriptMethod(UseHttpGet = false, XmlSerializeString = true)]
        //public string GetEventTemplate(string EventCategoryID, string pageNumber, string pageSize, string XslTemplateID)
        //{
        //    try
        //    {
        //        int PortalID = 0;
        //        int.TryParse(portalId, out PortalID);

        //        int LanguageID = 0;
        //        int.TryParse(languageId, out LanguageID);

        //        int PageNumber = 0;
        //        int.TryParse(pageNumber, out PageNumber);

        //        int PageSize = 0;
        //        int.TryParse(pageSize, out PageSize);

        //        int eventCatID = 0;
        //        int.TryParse(EventCategoryID, out eventCatID);

        //        int XslID = 0;
        //        int.TryParse(XslTemplateID, out XslID);

        //        EngineServicePage page = new EngineServicePage();

        //        Control ctl = page.LoadControl("~" + EngineUtilites.EngineConfig.PortalFolders.ServicesPath + "Event/GUI/EventTemplateService_UC.ascx");
        //        ctl.ID = "EventTemplateService_UCCat" + eventCatID + "Xsl" + XslID;

        //        ((Eskadenia.Framework.Event.Web.UI.Services.EventTemplateService_UC)ctl).LoadEvent(PortalID, LanguageID, eventCatID, PageNumber, PageSize, XslID);
        //        page.Controls.Add(ctl);

        //        // Render the page and capture the resulting HTML.
        //        StringWriter writer = new StringWriter();
        //        HttpContext.Current.Server.Execute(page, writer, false);

        //        // Return that HTML, as a string.
        //        return ((Eskadenia.Framework.Event.Web.UI.Services.EventTemplateService_UC)ctl).TotalCount + writer.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, XmlSerializeString = true)]
        public string GetHtmlEventItems(string Year, string Month, string Day, string CategoryID)
        {
            try
            {
                DateTime dateTime = new DateTime(Convert.ToInt32(Year), Convert.ToInt32(Month), Convert.ToInt32(Day));
                int catID = 0;
                int.TryParse(CategoryID, out catID);

                // Create a new Page and add the control to it.
                Page page = new Page();
                Control ucEventViewerService = page.LoadControl("~/Services/Event/GUI/EventViewerService_UC.ascx");
                ucEventViewerService.ID = "EventViewerService_UCCat" + CategoryID;

                page.Controls.Add(ucEventViewerService);
                ((TG.ExpressCMS.UI.Services.EventViewerService_UC)ucEventViewerService).LoadEvents(dateTime, catID);

                // Render the page and capture the resulting HTML.
                StringWriter writer = new StringWriter();
                HttpContext.Current.Server.Execute(page, writer, false);

                // Return that HTML, as a string.
                return writer.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
