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
    public class EventLocationManager
    {
        public static int Add(EventLocation obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            EventLocationDataMapper objCaller = new EventLocationDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(EventLocation obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            EventLocationDataMapper objCaller = new EventLocationDataMapper();

            objCaller.Update(obj);
        }
        public static EventLocation GetByID(int ID)
        {
            if (ID <= 0)
                return null;

            EventLocationDataMapper objCaller = new EventLocationDataMapper();

            return objCaller.GetByID(ID);
        }
        public static List<EventLocation> GetAll()
        {
            EventLocationDataMapper objCaller = new EventLocationDataMapper();

            return objCaller.GetAll();
        }
        public static void DeleteLogical(int ID)
        {
            if (ID <= 0)
                return;

            List<Event> events = EventManager.GetByLocationID(ID);
            if (events.Count > 0)
                throw new Exception("ErrCannotDeleteLocationUsedInEvent");

            EventLocationDataMapper objCaller = new EventLocationDataMapper();
            objCaller.DeleteLogical(ID);
        }
        public static void DeletePhysical(int ID)
        {
            if (ID <= 0)
                return;
            EventLocationDataMapper objCaller = new EventLocationDataMapper();
            objCaller.DeletePhysical(ID);
        }
    }
}