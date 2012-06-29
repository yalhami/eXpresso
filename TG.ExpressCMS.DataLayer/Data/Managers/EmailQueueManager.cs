using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using TG.ExpressCMS.DataLayer.Entities;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class EmailQueueManager
    {
        public static int Add(EmailQueue obj)
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(EmailQueue obj)
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            objCaller.Update(obj);
        }
        public static EmailQueue GetByID(int ID)
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<EmailQueue> GetAll()
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            return objCaller.GetAll();
        }
        public static IList<EmailQueue> GetAllPending()
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            return objCaller.GetAllPending();
        }
        public static int GetCountforPendingEmails()
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            return objCaller.GetCountforPendingEmails();
        }
        public static IList<EmailQueue> Search(string stremailid, string strdeliverstatus, string strsentstatus, string date, string recieveraddressk)
        {
            int deliverStatus = -1;
            int sendingstatus = -1;
            int mailid = -1;
            if (strdeliverstatus != "")
                deliverStatus = Convert.ToInt32(strdeliverstatus);
            if (strsentstatus != "")
                sendingstatus = Convert.ToInt32(strsentstatus);
            if (stremailid != "")
                mailid = Convert.ToInt32(stremailid);

            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            return objCaller.Search(mailid, deliverStatus, sendingstatus, date, recieveraddressk);
        }
        public static void Delete(int ID)
        {
            EmailQueueDataMapper objCaller = new EmailQueueDataMapper();

            objCaller.Delete(ID);
        }
    }
}