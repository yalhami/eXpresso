using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Xml;
using System.Net;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.Utilities
{
    public static class EmailContext
    {

        public static string GetConfirmationText(string name, string email)
        {
            //  if (HttpContext.Current.Session["GetConfirmationText"] == null)
            {
                string confirmation = UtilitiesManager.ReadFile(HttpContext.Current.Server.MapPath("~/UI/Email/Messages/Confirmation.txt"));
                //     HttpContext.Current.Session["GetConfirmationText"] = confirmation;
                return ReplaceKeywordsinMessages(confirmation, name, email);
            }
            ////  else
            //  {
            // //     return HttpContext.Current.Session["GetConfirmationText"].ToString();
            //  }
        }
        public static string GetSuccessString(string name, string email)
        {
            // if (HttpContext.Current.Session["GetSuccessString"] == null)
            {
                string confirmation = UtilitiesManager.ReadFile(HttpContext.Current.Server.MapPath("~/UI/Email/Messages/Success.txt"));
                //    HttpContext.Current.Session["GetSuccessString"] = confirmation;
                return ReplaceKeywordsinMessages(confirmation, name, email); ;
            }
            //else
            //{
            //    return HttpContext.Current.Session["GetSuccessString"].ToString();
            //}
        }
        public static EmailSetting LoadSmtpSettingsFile()
        {
            EmailSetting _emailSetting = new EmailSetting();
            //if (HttpContext.Current.Session["SmtpandEmailSettings"] == null)
            {
                string filePath = HttpContext.Current.Server.MapPath("~/Settings/SmtpEmailSettings.xml");

                XmlDocument xDoc = new XmlDocument();
                try
                {
                    xDoc.Load(filePath);
                }
                catch
                {
                    return null;
                }
                try
                {
                    _emailSetting.Host = xDoc.ChildNodes[0].ChildNodes[0].Attributes["Host"].Value;
                    _emailSetting.Port = Convert.ToInt32(xDoc.ChildNodes[0].ChildNodes[0].Attributes["Port"].Value);
                    _emailSetting.SernderAddress = xDoc.ChildNodes[0].ChildNodes[0].Attributes["SenderEmail"].Value;
                    _emailSetting.SenderName = xDoc.ChildNodes[0].ChildNodes[0].Attributes["SenderName"].Value;
                    _emailSetting.EnableSSL = Convert.ToBoolean(xDoc.ChildNodes[0].ChildNodes[0].Attributes["EnableSSL"].Value);

                    _emailSetting.UseCredential = Convert.ToBoolean(xDoc.ChildNodes[0].ChildNodes[0].Attributes["UseCredential"].Value);
                    _emailSetting.Username = xDoc.ChildNodes[0].ChildNodes[0].Attributes["Username"].Value;

                    if (xDoc.ChildNodes[0].ChildNodes[0].Attributes["Password"].Value != string.Empty)
                        _emailSetting.Password = EncryptionContext.Decrypt(xDoc.ChildNodes[0].ChildNodes[0].Attributes["Password"].Value);
                    else
                        _emailSetting.Password = "";

                }
                catch
                {
                    return null;
                }

                //   HttpContext.Current.Session["SmtpandEmailSettings"] = _emailSetting;
            }
            ////  else
            //  {
            // //     _emailSetting = (EmailSetting)HttpContext.Current.Session["SmtpandEmailSettings"];
            //  }
            return _emailSetting;
        }
        public static EmailSetting LoadSmtpSettingsFileService()
        {
            EmailSetting _emailSetting = new EmailSetting();

            string filePath = HttpContext.Current.Server.MapPath("~/Settings/SmtpEmailSettings.xml");

            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(filePath);
            }
            catch
            {
                return null;
            }
            try
            {
                _emailSetting.Host = xDoc.ChildNodes[0].ChildNodes[0].Attributes["Host"].Value;
                _emailSetting.Port = Convert.ToInt32(xDoc.ChildNodes[0].ChildNodes[0].Attributes["Port"].Value);
                _emailSetting.SernderAddress = xDoc.ChildNodes[0].ChildNodes[0].Attributes["SenderEmail"].Value;
                _emailSetting.SenderName = xDoc.ChildNodes[0].ChildNodes[0].Attributes["SenderName"].Value;
                _emailSetting.EnableSSL = Convert.ToBoolean(xDoc.ChildNodes[0].ChildNodes[0].Attributes["EnableSSL"].Value);

                _emailSetting.UseCredential = Convert.ToBoolean(xDoc.ChildNodes[0].ChildNodes[0].Attributes["UseCredential"].Value);
                _emailSetting.Username = xDoc.ChildNodes[0].ChildNodes[0].Attributes["Username"].Value;
                if (null != xDoc.ChildNodes[0].ChildNodes[0].Attributes["Password"] && xDoc.ChildNodes[0].ChildNodes[0].Attributes["Password"].Value != string.Empty)
                    _emailSetting.Password = EncryptionContext.Decrypt(xDoc.ChildNodes[0].ChildNodes[0].Attributes["Password"].Value);

            }
            catch
            {
                return null;
            }
            // HttpContext.Current.Session["SmtpandEmailSettings"] = _emailSetting;

            return _emailSetting;
        }
        public static void ClearSmtpCache()
        { HttpContext.Current.Session["SmtpandEmailSettings"] = null; }

        public static string GetTrackingCode(string _mailqueue)
        {
            return "";// "<img style=\"display:none;\" src=" + ExpressoConfig.NewsletterConfigElement.GetTrackingPath + "?" + ConstantsManager.MailDelivered + "=" + _mailqueue + " />";
        }
        private static string ReplaceKeywordsinMessages(string body, string name, string email)
        {
            Contact _contact = ContactManager.GetByEmail(email);
            body = body.Replace("#Name#", name);
            body = body.Replace("#Email#", email);
            body = body.Replace("#Link#", "<a href=http://www.alramz.ae/Userpages/ActivateContact.aspx?ContactGuid=" + _contact.Guid + ">" + "Click Here" + "</a>");

            return body;
        }


    }

}