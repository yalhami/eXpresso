using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class PollManager
    {
        public static int Add(Poll obj)
        {
            PollDataMapper objCaller = new PollDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Poll obj)
        {
            PollDataMapper objCaller = new PollDataMapper();

            objCaller.Update(obj);
        }
        public static Poll GetByID(int ID)
        {
            PollDataMapper objCaller = new PollDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Poll> GetAll()
        {
            PollDataMapper objCaller = new PollDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            PollDataMapper objCaller = new PollDataMapper();

            objCaller.Delete(ID);
        }
    }
}