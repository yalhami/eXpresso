using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class SettingsManager
    {
        public static int Add(Settings obj)
        {
            SettingsDataMapper objCaller = new SettingsDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Settings obj)
        {
            SettingsDataMapper objCaller = new SettingsDataMapper();

            objCaller.Update(obj);
        }
        public static Settings GetByID(int ID)
        {
            SettingsDataMapper objCaller = new SettingsDataMapper();

            return objCaller.GetByID(ID);
        }
        public static Settings GetDefault()
        {
            SettingsDataMapper objCaller = new SettingsDataMapper();

            return objCaller.GetDefault();
        }
        public static IList<Settings> GetAll()
        {
            SettingsDataMapper objCaller = new SettingsDataMapper();

            return objCaller.GetAll();
        }
        public static void Delete(int ID)
        {
            SettingsDataMapper objCaller = new SettingsDataMapper();

            objCaller.Delete(ID);
        }
    }
}