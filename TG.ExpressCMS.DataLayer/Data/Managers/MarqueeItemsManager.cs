using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class MarqueeItemsManager
    {
        public static int Add(MarqueeItems obj)
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(MarqueeItems obj)
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            objCaller.Update(obj);
        }
        public static MarqueeItems GetByID(int ID)
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            return objCaller.GetByID(ID);
        }
        public static XmlDocument GetByIDasXml(int ID)
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            return objCaller.GetByIDasXml(ID);
        }
        public static IList<MarqueeItems> GetAll()
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            return objCaller.GetAll();
        }
        public static IList<MarqueeItems> GetbyCategoryID(int catID)
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            return objCaller.GetByCategoryID(catID);
        }
        public static void Delete(int ID)
        {
            MarqueeItemsDataMapper objCaller = new MarqueeItemsDataMapper();

            objCaller.Delete(ID);
        }
    }
}