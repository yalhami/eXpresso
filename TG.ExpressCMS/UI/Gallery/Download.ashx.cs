
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TG.ExpressCMS.UI.Gallery
{
    /// <summary>
    /// Summary description for Download
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string file = "";
            // get the file name from the querystring
            if (context.Request.QueryString["ImageName"] != null)
            {
                file = context.Request.QueryString["ImageName"].ToString();
            }
            string filename = context.Server.MapPath("~/Upload/Files/Gallery/" + file);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filename);
            try
            {
                if (fileInfo.Exists)
                {
                    context.Response.Clear();
                    context.Response.AddHeader("Content-Disposition", "inline;attachment; filename=\"" + fileInfo.Name + "\"");
                    context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.TransmitFile(fileInfo.FullName);
                    context.Response.Flush();
                }
                else
                {
                    throw new Exception("File not found");
                }
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write(ex.Message);
            }
            finally
            {
                context.Response.End();
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}