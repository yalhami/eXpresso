using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TG.ExpressCMS.DataLayer.Helper
{
    public static class HelperMethods
    {
        private static DateTime Ref_Date_Time = new DateTime(1900, 1, 1);

        public static int GetTotalDays(DateTime dateTime)
        {
            return (dateTime - Ref_Date_Time).Days;
        }

        public static int GetTotalSeconds(DateTime dateTime)
        {
            DateTime tempDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            return (int)(dateTime - tempDateTime).TotalSeconds;
        }

        public static DateTime ConvertToDateTime(int TotalDays, int TotalSeconds)
        {
            DateTime dateTIme = Ref_Date_Time.AddDays(TotalDays);
            dateTIme = dateTIme.AddSeconds(TotalSeconds);

            return dateTIme;
        }
    }
}