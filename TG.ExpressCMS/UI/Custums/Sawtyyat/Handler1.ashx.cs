using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TG.ExpressCMS.UI.Custums.Sawtyyat
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Server.ScriptTimeout = 3600;

            //You could easily make this dymanic
            //For example, you could pass parameters in the the querystring        
            string FileName = context.Server.MapPath("~/upload/files/" + context.Request.QueryString["FileName"]);

            //Set the content type, we're gonna send mp3 data
            context.Response.ContentType = "audio/mpeg";

            //Name the stream
            context.Response.AppendHeader("icy-name", "Dr-Nouh Website");
            //Give your url
            context.Response.AppendHeader("icy-url", "www.drnouh.com");
            //Note: I often read the ID3's from the file directly.  I use some code written by Kevin Pisarsky (www.pisarsky.com)
            //I left it out of this version for simplicity.


            //At this point, you might wonder why we don't just use the WriteFile or TransmitFile method...

            //These will *work*, however, they also will send the Content-Length HTTP header.  This makes it work
            //more like a download, and less like a stream.

            //Although you are using a file as your source, this
            //is a real "stream" of data.  This is important, as Windows Media Player cannot save a stream, but
            //it can easily save a download.  If you want to prevent easy saving and downloading, the streaming
            //method is required.  If you don't care, you probably don't need this script anyway.


            //Don't buffer the output; send it as it goes
            context.Response.Buffer = false;

            const int ChunkSize = 10000;
            System.IO.Stream iStream = null;
            byte[] Buffer = new byte[ChunkSize + 1];
            int CurrentLength = 0;
            long DataToRead = 0;


            try
            {
                //Open the file.
                iStream = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

                //Total bytes to read
                DataToRead = iStream.Length;

                //Read the bytes, send chunks at a time

                while (DataToRead > 0)
                {
                    //Verify that the client is connected.

                    if (context.Response.IsClientConnected)
                    {
                        //Read the data in Buffer
                        CurrentLength = iStream.Read(Buffer, 0, ChunkSize);

                        //Write the data to the current output stream.
                        context.Response.OutputStream.Write(Buffer, 0, CurrentLength);

                        //We're not buffering output; if we were, we would flush here.

                        Buffer = new byte[ChunkSize + 1];
                        // Clear the Buffer
                        DataToRead = DataToRead - CurrentLength;


                    }
                    else
                    {
                        //Prevent infinite loop if user disconnects
                        DataToRead = -1;

                    }

                }


            }
            catch (Exception ex)
            {
                //Log your errors, if you're keeping score


            }
            finally
            {
                if ((iStream == null) == false)
                {
                    //Close the file stream
                    iStream.Close();
                }

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