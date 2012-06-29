using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace  TG.ExpressCMS.DataLayer.Data
{
    public class XslTemplateManager
    {
        public static int Add(XslTemplate obj)
        {
            XslTemplateDataMapper objCaller = new XslTemplateDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(XslTemplate obj)
        {
            XslTemplateDataMapper objCaller = new XslTemplateDataMapper();

            objCaller.Update(obj);
        }
        public static XslTemplate GetByID(int ID)
        {
            XslTemplateDataMapper objCaller = new XslTemplateDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<XslTemplate> GetAll()
        {
            XslTemplateDataMapper objCaller = new XslTemplateDataMapper();

            return objCaller.GetAll();
        }
        public static IList<XslTemplate> GetByCategoryID(int catID)
        {
            XslTemplateDataMapper objCaller = new XslTemplateDataMapper();

            return objCaller.GetByCategoryID(catID);
        }
        public static void Delete(int ID)
        {
            XslTemplateDataMapper objCaller = new XslTemplateDataMapper();

            objCaller.Delete(ID);
        }
    }
}