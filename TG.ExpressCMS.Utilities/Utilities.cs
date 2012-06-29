using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer;
using System.Configuration;
using System.Text;
using System.IO;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Xsl;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.Utilities;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using TG.ExpressCMS.Configuration;


namespace TG.ExpressCMS
{
    public static class UtilitiesManager
    {
        public static Dictionary<string, int> GetEnumDataSource(System.Resources.ResourceManager ResourceManager, Type myEnumType)
        {
            Dictionary<string, int> returnCollection = new Dictionary<string, int>();
            string[] enumNames = Enum.GetNames(myEnumType);

            for (int i = 0; i <= enumNames.Length - 1; i++)
            {
                try
                {
                    returnCollection.Add(ResourceManager.GetString(enumNames[i]).ToString(), (int)Enum.Parse(myEnumType, enumNames[i]));
                }
                catch
                {
                    returnCollection.Add((enumNames[i]).ToString() + "", (int)Enum.Parse(myEnumType, enumNames[i]));
                    continue;
                }
            }

            return returnCollection;
        }
        private static Stream SaveJPGWithCompressionSetting(Stream imageStream, string szFileName)
        {
            Bitmap imageFile = new Bitmap(imageStream);
            try
            {
                EncoderParameters eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)80);
                ImageCodecInfo ici = GetCodecInfo("image/jpeg");
                imageFile.Save(szFileName, ici, eps);
            }
            catch
            {
                imageFile.Save(szFileName);
            }
            StreamReader sr = new StreamReader(szFileName);
            return sr.BaseStream;
        }

        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            foreach (ImageCodecInfo encoder in ImageCodecInfo.GetImageEncoders())
                if (encoder.MimeType == mimeType)
                    return encoder;
            throw new ArgumentOutOfRangeException(
                string.Format("'{0}' not supported", mimeType));
        }
        public static string GetSavedFile(FileUpload fUploader, bool autoGenerateName)
        {
            string guid = string.Empty;

            if (fUploader.PostedFile != null)
            {
                try
                {
                    if (!fUploader.PostedFile.FileName.Contains('.'))
                        return guid;
                    string[] fileext = fUploader.PostedFile.FileName.Split('.');
                    if (autoGenerateName)
                    {
                        guid = Guid.NewGuid().ToString();
                        guid += "." + fileext[fileext.Length - 1].ToString();
                    }
                    else
                        guid = fUploader.PostedFile.FileName;

                    SaveJPGWithCompressionSetting(fUploader.FileContent, ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + guid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return guid;
        }
        public static string GetSavedFile(FileUpload fUploader, bool autoGenerateName, bool generateThumbnail)
        {
            string guid = string.Empty;

            if (fUploader.PostedFile != null)
            {
                try
                {
                    if (!fUploader.PostedFile.FileName.Contains('.'))
                        return guid;
                    string[] fileext = fUploader.PostedFile.FileName.Split('.');
                    if (autoGenerateName)
                    {
                        guid = Guid.NewGuid().ToString();
                        guid += "." + fileext[fileext.Length - 1].ToString();
                    }
                    else
                        guid = fUploader.PostedFile.FileName;

                    SaveJPGWithCompressionSetting(fUploader.FileContent, ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + guid);
                    if (generateThumbnail)
                    {
                        Bitmap thumbnail = CreateThumbnail(ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + guid, 180, 140);
                        thumbnail.Save(ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + "Thumb-" + guid);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return guid;
        }
        public static string GetFormattedDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
        public static string GetFormattedDate(string date)
        {
            return date.ToString(CacheContext.PortalCulture);
        }
        public static DateTime GetFormattedDateasDate(string date)
        {
            return DateTime.Parse(date, CacheContext.PortalCulture);
        }
        public static string GetFormattedDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
        public static string GetFormattedTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
        public static string GetSavedFileforGallery(FileUpload fUploader, bool autoGenerateName, bool generateThumbnail)
        {
            string guid = string.Empty;

            if (fUploader.PostedFile != null)
            {
                try
                {
                    if (!fUploader.PostedFile.FileName.Contains('.'))
                        return guid;
                    string[] fileext = fUploader.PostedFile.FileName.Split('.');
                    if (autoGenerateName)
                    {
                        guid = Guid.NewGuid().ToString();
                        guid += "." + fileext[1].ToString();
                    }
                    else
                        guid = fUploader.PostedFile.FileName;
                    if (!Directory.Exists((ConfigContext.GetGalleryUploadPath)))
                    {
                        Directory.CreateDirectory((ConfigContext.GetGalleryUploadPath));
                    }
                    fUploader.SaveAs(ConfigContext.GetGalleryUploadPath + guid);

                    //Generate Thumbnail
                    if (generateThumbnail)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + guid);                        
                        SaveJPGWithCompressionSetting(fUploader.FileContent, ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + guid);
                        //Bitmap thumbnail = CreateThumbnail(ConfigContext.GetGalleryUploadPath + guid, 180, 140);
                        //thumbnail.Save(ConfigContext.GetGalleryUploadPath + "Thumb-" + guid);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return guid;
        }
        public static string GetSavedFileforGallery(Telerik.Web.UI.UploadedFile fUploader, bool autoGenerateName, bool generateThumbnail)
        {
            string guid = string.Empty;

            if (fUploader != null)
            {
                try
                {

                    if (!fUploader.FileName.Contains('.'))
                        return guid;

                    if (autoGenerateName)
                    {
                        guid = Guid.NewGuid().ToString();
                        guid += fUploader.GetExtension();
                    }
                    else
                        guid = fUploader.GetName();
                    if (!Directory.Exists((ConfigContext.GetGalleryUploadPath)))
                    {
                        Directory.CreateDirectory((ConfigContext.GetGalleryUploadPath));
                    }
                    fUploader.SaveAs(ConfigContext.GetGalleryUploadPath + guid);

                    //Generate Thumbnail
                    if (generateThumbnail)
                    {
                        Bitmap thumbnail = CreateThumbnail(ConfigContext.GetGalleryUploadPath + guid, 180, 140);
                        thumbnail.Save(ConfigContext.GetGalleryUploadPath + "Thumb-" + guid);
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return guid;
        }

        public static string GetForumURL(int ForumID)
        {
            return ConfigContext.GetForumPage + "?ForumID=" + ForumID;
        }
        public static string GetThreadURL(int ThreadID)
        {
            return ConfigContext.GetForumThreadPage + "?ThreadID=" + ThreadID;
        }
        public static string GetAddPostURL(int ThreadID, int PostID)
        {
            return ConfigContext.GetAddPostPage + "?ThreadID=" + ThreadID + "&PostID=" + PostID;
        }
        public static string GetRegistrationForumURL()
        {
            return ConfigContext.GetRegistrationForumURL;
        }
        public static string GetLoginURL()
        {
            return ConfigContext.GetLoginURL;
        }
        public static string GetEventDetailsURL(int EventID)
        {
            return ConfigContext.GetEventDetails + "?EventID=" + EventID;
        }
        public static string GetNewsURL(NewsItem newsItem)
        {
            if (null == newsItem)
                return "Err";
            if (newsItem.URlType == DataLayer.Enums.RootEnums.NewsItemURLType.Internal)
            {
                return ConfigurationManager.AppSettings["DefNewsDetailsPage"] + "ND=" + newsItem.ID;
            }
            else
            {
                return newsItem.Url;
            }
        }

        public static string GetSavedFile(Telerik.Web.UI.UploadedFile fUploader, bool autoGenerateName)
        {
            string guid = string.Empty;

            if (fUploader != null)
            {
                try
                {
                    if (!fUploader.FileName.Contains('.'))
                        return guid;

                    if (autoGenerateName)
                    {
                        guid = Guid.NewGuid().ToString();
                        guid += fUploader.GetExtension();
                    }
                    else
                        guid = fUploader.GetName();
                    if (File.Exists(ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + "\\" + guid))
                    {
                        guid = fUploader.GetNameWithoutExtension() + "_" + Guid.NewGuid().ToString().Substring(0, 3).ToString() + fUploader.GetExtension();
                    }
                    fUploader.SaveAs(ExpressoConfig.GeneralConfigElement.GetPhysicalUploadPath + "\\" + guid);

                }


                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return guid;
        }

        public static string GetNewsURL(int newsID)
        {
            if (newsID <= 0)
                return "Err";
            NewsItem newsItem = NewsItemManager.GetByID(newsID);
            if (null == newsItem)
                return "Err";
            if (newsItem.URlType == DataLayer.Enums.RootEnums.NewsItemURLType.Internal)
            {
                return ConfigurationManager.AppSettings["DefNewsDetailsPage"] + "ND=" + newsID;
            }
            else
            {
                return newsItem.Url;
            }
        }

        /// <summary>
        /// Transform xml data using xsl stylesheet text
        /// </summary>
        /// <param name="xmlText">xml data</param>
        /// <param name="xslText">xsl stylesheet text</param>
        /// <returns>Outputted content from xsl stylesheet</returns>
        public static string TransformXMLWithXSLText(string xmlText, string xslText)
        {
            try
            {
                //check that there is some xml
                if (string.IsNullOrEmpty(xmlText)) return "";
                //check that there is some xsl
                if (string.IsNullOrEmpty(xslText)) return "";

                //create a stringbuilder object to hold outputted html
                var sb = new StringBuilder();
                //load a string reader from the xml data
                using (StringReader xmlStringReader = new StringReader(xmlText))
                {
                    //create an xpath document from the xml data
                    XPathDocument xPathDoc = new XPathDocument(xmlStringReader);
                    //create a string reader for the xsl data
                    using (StringReader xslStringReader = new StringReader(xslText))
                    {
                        //pass xsl text into xmltextreader
                        using (XmlReader styleSheet = new XmlTextReader(xslStringReader))
                        {
                            //create the transformation class
                            XslCompiledTransform xslTrans = new XslCompiledTransform();
                            //load the xsl into the transformer
                            xslTrans.Load(styleSheet);
                            //create a stringwriter for outputting html to
                            using (StringWriter sw = new StringWriter(sb))
                            {
                                //do the actual transform of Xml
                                xslTrans.Transform(xPathDoc, null, sw);
                            }
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return "";
            }
        }

        /// <summary>
        /// Transform xml data using xsl stylesheet text
        /// </summary>
        /// <param name="xmlText">xml data</param>
        /// <param name="xslText">xsl stylesheet text</param>
        /// <returns>Outputted content from xsl stylesheet</returns>
        public static string TransformXMLWithXSLText(string xmlText, string xslText, XsltArgumentList arguments)
        {
            try
            {
                //check that there is some xml
                if (string.IsNullOrEmpty(xmlText)) return "";
                //check that there is some xsl
                if (string.IsNullOrEmpty(xslText)) return "";

                //create a stringbuilder object to hold outputted html
                var sb = new StringBuilder();
                //load a string reader from the xml data
                using (StringReader xmlStringReader = new StringReader(xmlText))
                {
                    //create an xpath document from the xml data
                    XPathDocument xPathDoc = new XPathDocument(xmlStringReader);
                    //create a string reader for the xsl data
                    using (StringReader xslStringReader = new StringReader(xslText))
                    {
                        //pass xsl text into xmltextreader
                        using (XmlReader styleSheet = new XmlTextReader(xslStringReader))
                        {
                            //create the transformation class
                            XslCompiledTransform xslTrans = new XslCompiledTransform();
                            //load the xsl into the transformer
                            xslTrans.Load(styleSheet);
                            //create a stringwriter for outputting html to
                            using (StringWriter sw = new StringWriter(sb))
                            {
                                //do the actual transform of Xml
                                xslTrans.Transform(xPathDoc, arguments, sw);
                            }
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return "";
            }
        }



        public static string ReadFile(string path)
        {
            string result = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                result = reader.ReadToEnd();
            }
            return
                result;
        }

        public static void WriteFile(string path, string data, bool userWriteLine, bool append)
        {
            string result = string.Empty;
            string olddata = string.Empty;
            if (!append)
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write("");
                }
            }
            else
            {
                olddata = ReadFile(path);

            }
            olddata += data;
            using (StreamWriter writer = new StreamWriter(path))
            {
                if (!userWriteLine)
                    writer.Write(olddata);
                else
                    writer.WriteLine(olddata);
            }
        }
        public static Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {

            System.Drawing.Bitmap bmpOut = null;

            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);

                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;

                int lnNewWidth = 0;

                int lnNewHeight = 0;

                //*** If the image is smaller than a thumbnail just return it

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {

                    lnRatio = (decimal)lnWidth / loBMP.Width;

                    lnNewWidth = lnWidth;

                    decimal lnTemp = loBMP.Height * lnRatio;

                    lnNewHeight = (int)lnTemp;

                }
                else
                {

                    lnRatio = (decimal)lnHeight / loBMP.Height;

                    lnNewHeight = lnHeight;

                    decimal lnTemp = loBMP.Width * lnRatio;

                    lnNewWidth = (int)lnTemp;

                }

                // System.Drawing.Image imgOut =

                //      loBMP.GetThumbnailImage(lnNewWidth,lnNewHeight,

                //                              null,IntPtr.Zero);

                // *** This code creates cleaner (though bigger) thumbnails and properly

                // *** and handles GIF files better by generating a white background for

                // *** transparent images (as opposed to black)

                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);

                Graphics g = Graphics.FromImage(bmpOut);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);

                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);

                loBMP.Dispose();

            }

            catch
            {
                return null;
            }

            return bmpOut;
        }
        public static void GenerateExcelFiles(string filename, GridView gv)
        {

            string attachment = "attachment; filename=" + filename + ".xls";

            HttpContext.Current.Response.ClearContent();

            HttpContext.Current.Response.AddHeader("content-disposition", attachment);

            HttpContext.Current.Response.ContentType = "application/ms-excel";

            StringWriter sw = new StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);

            // Create a form to contain the grid

            HtmlForm frm = new HtmlForm();

            gv.Parent.Controls.Add(frm);

            frm.Attributes["runat"] = "server";

            frm.Controls.Add(gv);


            frm.RenderControl(htw);

            //GridView1.RenderControl(htw);

            HttpContext.Current.Response.Write(sw.ToString());

            HttpContext.Current.Response.End();
        }
        public static string GetForumUserImage(string UserImagePath)
        {
            if (string.IsNullOrEmpty(UserImagePath))
                return "~/App_themes/UserSide/DefaultUser.png";
            return UserImagePath;
        }
    }

}
