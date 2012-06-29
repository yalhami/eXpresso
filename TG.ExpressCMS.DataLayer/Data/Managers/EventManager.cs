using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class EventManager
    {
        public static int Add(Event obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            if (obj.FromDate > obj.ToDate)
                throw new Exception("ErrFromDateLessThanToDate");

            EventDataMapper objCaller = new EventDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Event obj)
        {
            if (obj == null)
                throw new Exception("Object is null");

            if (obj.FromDate > obj.ToDate)
                throw new Exception("ErrFromDateLessThanToDate");

            EventDataMapper objCaller = new EventDataMapper();

            objCaller.Update(obj);
        }
        public static Event GetByID(int ID)
        {
            if (ID <= 0)
                return null;

            EventDataMapper objCaller = new EventDataMapper();

            return objCaller.GetByID(ID);
        }
        public static List<Event> GetAll()
        {
            EventDataMapper objCaller = new EventDataMapper();

            return objCaller.GetAll();
        }
        public static List<Event> GetByCategoryID(int CategoryID)
        {
            if (CategoryID <= 0)
                return new List<Event>();

            EventDataMapper objCaller = new EventDataMapper();

            return objCaller.GetByCategoryID(CategoryID);
        }
        public static List<Event> GetByLocationID(int LocationID)
        {
            if (LocationID <= 0)
                return new List<Event>();

            EventDataMapper objCaller = new EventDataMapper();

            return objCaller.GetByLocationID(LocationID);
        }
        public static List<Event> GetBySearch(string Keyword, int CategoryID, int LocationID, DateTime? FromDate, DateTime? ToDate)
        {
            EventDataMapper objCaller = new EventDataMapper();

            return objCaller.GetBySearch(Keyword, CategoryID, LocationID, FromDate, ToDate);
        }
        public static void DeleteLogical(int ID)
        {
            if (ID <= 0)
                return;
            EventDataMapper objCaller = new EventDataMapper();
            objCaller.DeleteLogical(ID);
        }
        public static void DeletePhysical(int ID)
        {
            if (ID <= 0)
                return;
            EventDataMapper objCaller = new EventDataMapper();
            objCaller.DeletePhysical(ID);
        }
        public static bool ValidAddEvent(Event obj, DateTime dateTime)
        {
            DateTime FromDateTime = obj.FromDate;
            DateTime ToDateTime = obj.ToDate;
            FromDateTime = new DateTime(FromDateTime.Year, FromDateTime.Month, FromDateTime.Day);
            ToDateTime = new DateTime(ToDateTime.Year, ToDateTime.Month, ToDateTime.Day);
            if (FromDateTime <= dateTime && ToDateTime >= dateTime)
            {
                int dayDifference = 0;
                switch (obj.RepeatType)
                {
                    case Enums.RootEnums.EventRepeatType.DoNotRepeat:
                        return FromDateTime.Year == dateTime.Year && FromDateTime.Month == dateTime.Month && FromDateTime.Day == dateTime.Day;
                    case Enums.RootEnums.EventRepeatType.Daily:
                        //every days
                        dayDifference = (dateTime - FromDateTime).Days % obj.Every;
                        return dayDifference == 0;
                    case Enums.RootEnums.EventRepeatType.Weekly:
                        dayDifference = (dateTime - FromDateTime).Days % (obj.Every * 7);
                        if (dayDifference < 7)
                        {
                            List<int> daysOnWeek = new List<int>();
                            if (!string.IsNullOrEmpty(obj.Period))
                                daysOnWeek = obj.Period.Split(';').Select(p => Convert.ToInt32(p)).ToList();
                            return daysOnWeek.Contains((int)dateTime.DayOfWeek);
                        }
                        break;
                    case Enums.RootEnums.EventRepeatType.Monthly:
                        int monthDiff = (dateTime.Year - FromDateTime.Year) * 12 + dateTime.Month - FromDateTime.Month;
                        if (monthDiff % obj.Every == 0)
                        {
                            int dayInMonth = 0;
                            int.TryParse(obj.Period, out dayInMonth);
                            if (RootEnums.EventMonthlyType.Last == (RootEnums.EventMonthlyType)dayInMonth)
                                return DateTime.DaysInMonth(dateTime.Year, dateTime.Month) == dateTime.Day;
                            return dateTime.Day == dayInMonth;
                        }
                        break;
                    case Enums.RootEnums.EventRepeatType.Yearly:
                        int yearDiff = (dateTime.Year - FromDateTime.Year) % obj.Every;
                        return yearDiff == 0 && dateTime.Month == FromDateTime.Month && dateTime.Day == FromDateTime.Day;
                }
            }
            return false;
        }
    }
}