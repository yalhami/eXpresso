using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using TG.ExpressCMS.DataLayer.Entities;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class VolunteerManager
    {
        public static int Add(Volunteer obj)
        {
            VolunteerDataMapper objCaller = new VolunteerDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Volunteer obj)
        {
            VolunteerDataMapper objCaller = new VolunteerDataMapper();

            objCaller.Update(obj);
        }
        public static Volunteer GetByID(int ID)
        {
            VolunteerDataMapper objCaller = new VolunteerDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Volunteer> GetAll()
        {
            VolunteerDataMapper objCaller = new VolunteerDataMapper();

            return objCaller.GetAll();
        }
        public static IList<LookupDetails> GetAllCountries()
        {
            VolunteerDataMapper objCaller = new VolunteerDataMapper();

            return objCaller.GetAllCountries();
        }
        public static void Delete(int ID)
        {
            VolunteerDataMapper objCaller = new VolunteerDataMapper();

            objCaller.Delete(ID);
        }
    }
}