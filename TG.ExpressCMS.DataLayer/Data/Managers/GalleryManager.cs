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
    public class GalleryManager
    {
        public static int Add(Gallery obj)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Gallery obj)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            objCaller.Update(obj);
        }
        public static Gallery GetByID(int ID)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Gallery> GetAll()
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.GetAll();
        }
        public static IList<Gallery> SearchPaging(int from, int to, ref int totalRows, string keyword)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.SearchPaging(from, to, ref totalRows, keyword);
        }
        public static IList<Gallery> GetPagesItems(int from, int to, ref int totalrows, int categoryid)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.GetAllGalleryByCategoryPages(categoryid, from, to, ref totalrows);
        }

        public static IList<Gallery> GetByCategory(int catID)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.GetbyCategory(catID);
        }
        public static XmlDocument GetByCategoryAsXML(int catID)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            return objCaller.GetbyCategoryAsXML(catID);
        }
        public static void Delete(int ID)
        {
            GalleryDataMapper objCaller = new GalleryDataMapper();

            objCaller.Delete(ID);
        }
    }
}