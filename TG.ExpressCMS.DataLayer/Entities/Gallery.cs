using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Enums;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Gallery
    {
        public int ID
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public string Description
        {
            set;
            get;
        }
        public string Tags
        {
            set;
            get;
        }
        public string Date
        {
            set;
            get;
        }
        public string Url
        {
            set;
            get;
        }
        public RootEnums.GalleryType Type
        {
            set;
            get;
        }
        public string Path
        {
            set;
            get;
        }
        public int CreatedBy
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public bool IsArchieved
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
    }
}