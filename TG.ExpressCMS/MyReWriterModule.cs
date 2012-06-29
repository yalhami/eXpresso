using System;
using System.Web;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS
{
    public class MyReWriterModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;

            string url = app.Request.RawUrl;

            if (url.ToLower().Contains("/article-") || url.ToLower().Contains("/news-"))
            {
                int indexs = url.LastIndexOf('-');
                int id = 0;
                //  int.TryParse(url.Substring(indexs + 1, url.Length - (indexs + 1)), out id);
                string guid = url.Substring(indexs + 1, url.Length - (indexs + 1));

                app.Context.RewritePath("/Userpages/Newsdetails.aspx?NewsGUID=" + guid);
            }
            else
                if (url.ToLower().Contains("/home"))
                {
                    app.Context.RewritePath("/Userpages/default.aspx");
                }
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
    }
}
