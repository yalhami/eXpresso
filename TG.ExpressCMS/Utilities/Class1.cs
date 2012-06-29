using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.DataLayer.Data;
using System.Net.Mail;
using TG.ExpressCMS.DataLayer.Entities;
using System.Net;
using System.Text;

namespace TG.ExpressCMS.Utilities
{
    public static class EmailSenderInteral
    {
        public static void AddemailtoQueueNow(int contactID, string _emailAddress, string _name, string _body, string Hash)
        {
            if (Hash != "NoTImeFORLove")
                return;
            try
            {

                TG.ExpressCMS.DataLayer.Entities.Email _email = new DataLayer.Entities.Email();
                _email.IsDeleted = false;
                _email.Name = _name;
                _email.Details = _body;
                _email.Date = DateTime.Now.ToString("dd/MM/yyyy");
                _email.Type = DataLayer.Enums.RootEnums.EmailType.System;
                EmailManager.Add(_email);

                EmailQueue emailQueue = new EmailQueue();
                emailQueue.ContactID = contactID;
                emailQueue.DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Unknown;
                emailQueue.MailID = _email.ID;
                emailQueue.RecieverName = _name;
                emailQueue.ReciverAddress = _emailAddress;
                emailQueue.ScheduleDate = DateTime.Now.ToString("dd/MM/yyyy");
                emailQueue.ScheduleTime = DateTime.Now.ToShortTimeString();
                emailQueue.SenderAddress = EmailContext.LoadSmtpSettingsFileService().SernderAddress;
                emailQueue.SenderName = EmailContext.LoadSmtpSettingsFileService().SenderName;
                emailQueue.SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.Pending;
                emailQueue.SentDate = DateTime.Now.ToString("dd/MM/yyyy");
                EmailQueueManager.Add(emailQueue);
                return;
            }
            catch (Exception ex)
            {
                UtilitiesManager.WriteFile(ExpressoConfig.GeneralConfigElement.GetPhysicalLoggingPath, ex.ToString(), false, true);
            }
            return;
        }

        public static void ProcessAllPendingEmail(string Hash)
        {
            if (Hash != "NoTImeFORLove")
                return;
            EmailSetting emailSetting = EmailContext.LoadSmtpSettingsFile();

            #region Sending E-Mail

            SmtpClient client = new SmtpClient();

            client.Host = emailSetting.Host;
            client.Port = emailSetting.Port;
            client.EnableSsl = emailSetting.EnableSSL;
            client.UseDefaultCredentials = false;
            if (emailSetting.UseCredential)
            {
                client.Credentials = new NetworkCredential(emailSetting.Username, emailSetting.Password);
            }
            IList<EmailQueue> colItems = null;
            colItems = EmailQueueManager.GetAllPending();
            for (int k = 0; k < colItems.Count; k++)
            {
                try
                {
                    TG.ExpressCMS.DataLayer.Entities.Email _email = new Email();
                    _email = EmailManager.GetByID(colItems[k].MailID);
                    if (_email == null)
                        continue;
                    MailMessage _mail = new MailMessage();
                    _mail.Subject = _email.Name;
                    _mail.IsBodyHtml = true;
                    _mail.From = _mail.Sender = new MailAddress(emailSetting.SernderAddress, emailSetting.SenderName);

                    _mail.Body = "";
                    _mail.Body = _email.Details + EmailContext.GetTrackingCode(_email.ID.ToString());
                    _mail.To.Clear();
                    _mail.To.Add(new MailAddress(colItems[k].ReciverAddress, colItems[k].RecieverName));
                    _mail.BodyEncoding = Encoding.UTF8;
                    _mail.SubjectEncoding = Encoding.UTF8;
                    client.Send(_mail);

                    colItems[k].SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.Sent;
                    colItems[k].DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Unknown;
                    EmailQueueManager.Update(colItems[k]);
                }
                catch (Exception ex)
                {
                    colItems[k].SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.failed;
                    colItems[k].DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Failed;
                    EmailQueueManager.Update(colItems[k]);
                    UtilitiesManager.WriteFile(ExpressoConfig.GeneralConfigElement.GetPhysicalLoggingPath, ex.ToString(), false, true);
                }
            }
            #endregion
        }



        public static void AddemailtoQueueNow2(string sendername, string recemail, string _recname, string _body, string Hash)
        {
            if (Hash != "NoTImeFORLove")
                return;
            try
            {

                TG.ExpressCMS.DataLayer.Entities.Email _email = new DataLayer.Entities.Email();
                _email.IsDeleted = false;
                _email.Name = _recname;
                _email.Details = _body;
                _email.Date = DateTime.Now.ToString("dd/MM/yyyy");
                _email.Type = DataLayer.Enums.RootEnums.EmailType.System;
                EmailManager.Add(_email);

                EmailQueue emailQueue = new EmailQueue();
                emailQueue.ContactID = 0;
                emailQueue.DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Unknown;
                emailQueue.MailID = _email.ID;
                emailQueue.RecieverName = _recname;
                emailQueue.ReciverAddress = recemail;
                emailQueue.ScheduleDate = DateTime.Now.ToString("dd/MM/yyyy");
                emailQueue.ScheduleTime = DateTime.Now.ToShortTimeString();
                emailQueue.SenderAddress = EmailContext.LoadSmtpSettingsFileService().SernderAddress;
                emailQueue.SenderName = sendername;
                emailQueue.SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.Pending;
                emailQueue.SentDate = DateTime.Now.ToString("dd/MM/yyyy");

                EmailQueueManager.Add(emailQueue);
                return;
            }
            catch (Exception ex)
            {
                UtilitiesManager.WriteFile(ExpressoConfig.GeneralConfigElement.GetPhysicalLoggingPath, ex.ToString(), false, true);
            }
            return;
        }

        public static void SendEmail(int mailid, string colIntegers, string scheduledate, string scheduletime, string Hash)
        {
            if (Hash != "NoTImeFORLove")
                return;
            EmailSetting emailSetting = EmailContext.LoadSmtpSettingsFile();

            #region Adding Mail Queue
            string[] ids = colIntegers.Split(',');


            for (int i = 0; i < ids.Count(); i++)
            {
                if (ids[i] == "")
                    continue;

                int groupid = Convert.ToInt32(ids[i].ToString());
                IList<Contact> colContacts = ContactManager.GetByGroupID(groupid);
                for (int k = 0; k < colContacts.Count; k++)
                {
                    EmailQueue emailQueue = new EmailQueue();
                    emailQueue.ContactID = colContacts[k].ID;
                    emailQueue.DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Unknown;
                    emailQueue.MailID = mailid;
                    emailQueue.RecieverName = colContacts[k].FullName;
                    emailQueue.ReciverAddress = colContacts[k].Email;
                    emailQueue.ScheduleDate = scheduledate;
                    emailQueue.ScheduleTime = scheduletime;
                    emailQueue.SenderAddress = emailSetting.SernderAddress;
                    emailQueue.SenderName = emailSetting.SenderName;
                    emailQueue.SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.Pending;
                    emailQueue.SentDate = DateTime.Now.ToString("dd/MM/yyyy");
                    EmailQueueManager.Add(emailQueue);
                }
            }

            #endregion
            #region Sending E-Mail

            SmtpClient client = new SmtpClient();
            Email email = EmailManager.GetByID(mailid);
            client.Host = emailSetting.Host;
            client.Port = emailSetting.Port;
            client.EnableSsl = emailSetting.EnableSSL;
            client.UseDefaultCredentials = emailSetting.UseCredential;
            if (emailSetting.UseCredential)
            {
                client.Credentials = new NetworkCredential(emailSetting.Username, emailSetting.Password);
            }
            MailMessage _mail = new MailMessage();
            _mail.Subject = email.Name;
            _mail.IsBodyHtml = true;
            _mail.From = _mail.Sender = new MailAddress(emailSetting.SernderAddress, emailSetting.SenderName);
            IList<EmailQueue> colEmails = null;
            colEmails = EmailQueueManager.GetAllPending();

            for (int i = 0; i < colEmails.Count; i++)
            {
                try
                {
                    _mail.Body = "";
                    _mail.Body = email.Details + EmailContext.GetTrackingCode(colEmails[i].ID.ToString());
                    _mail.To.Clear();
                    _mail.To.Add(new MailAddress(colEmails[i].ReciverAddress, colEmails[i].RecieverName));
                    client.Send(_mail);
                    _mail.Subject = email.Name;
                    colEmails[i].SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.Sent;
                    colEmails[i].DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Unknown;
                    EmailQueueManager.Update(colEmails[i]);
                }
                catch (Exception ex)
                {
                    colEmails[i].SendingStatus = DataLayer.Enums.RootEnums.SendingStatus.failed;
                    colEmails[i].DeliveryStatus = DataLayer.Enums.RootEnums.DeliveryStatus.Failed;
                    EmailQueueManager.Update(colEmails[i]);
                    UtilitiesManager.WriteFile(ExpressoConfig.GeneralConfigElement.GetPhysicalLoggingPath, ex.ToString(), false, true);
                }

            }
            #endregion
        }
    }
}