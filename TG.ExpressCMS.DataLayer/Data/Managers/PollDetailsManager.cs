using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using TG.ExpressCMS.DataLayer.Entities;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class PollDetailsManager
    {
        public static int Add(PollDetails obj)
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(PollDetails obj)
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            objCaller.Update(obj);
        }
        public static PollDetails GetByID(int ID)
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<PollDetails> GetAll()
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            return objCaller.GetAll();
        }
        public static IList<PollDetails> GetByPollID(int pollID)
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            return objCaller.GetByPollID(pollID);
        }
        public static void Delete(int ID)
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            objCaller.Delete(ID);
        }
        public static int GetPollTotalCount(int pollID)
        {
            PollDetailsDataMapper objCaller = new PollDetailsDataMapper();

            return objCaller.GetTotalCount(pollID);
        }
    }
}