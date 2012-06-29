using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Enums;
using System.Xml;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class SawtyyatManager
    {
        public static int Add(Sawtyyat obj)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Sawtyyat obj)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            objCaller.Update(obj);
        }
        public static Sawtyyat GetByID(int ID)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Sawtyyat> GetAllByType(RootEnums.AudioVideoType type)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            return objCaller.GetAllByType(type);
        }
        public static XmlDocument GetAllByTypeAsXml(RootEnums.AudioVideoType type, int catid)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            return objCaller.GetAllByTypeAsXml(type, catid);
        }
        public static IList<Sawtyyat> GetAllByType(RootEnums.AudioVideoType type, int from, int to, ref int totalrows, string keyword, int catid)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            return objCaller.GetAllByType(type, from, to, ref totalrows, catid, keyword);
        }
        public static void Delete(int ID)
        {
            SawtyyatDataMapper objCaller = new SawtyyatDataMapper();

            objCaller.Delete(ID);
        }
    }
}