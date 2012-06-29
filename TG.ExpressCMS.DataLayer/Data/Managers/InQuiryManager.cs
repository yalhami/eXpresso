using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class InQuiryManager
    {
        public static int Add(InQuiry obj)
        {
            InQuiryDataMapper objCaller = new InQuiryDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(InQuiry obj)
        {
            InQuiryDataMapper objCaller = new InQuiryDataMapper();

            objCaller.Update(obj);
        }
        public static InQuiry GetByID(int ID)
        {
            InQuiryDataMapper objCaller = new InQuiryDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<InQuiry> GetAll()
        {
            InQuiryDataMapper objCaller = new InQuiryDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            InQuiryDataMapper objCaller = new InQuiryDataMapper();

            objCaller.Delete(ID);
        }
    }
}