using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Product
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
        public string Serial
        {
            set;
            get;
        }
        public double PublicPrice
        {
            set;
            get;
        }
        public double PrivatePrice
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
        public string ProducingDate
        {
            set;
            get;
        }
        public string ExpiryDate
        {
            set;
            get;
        }
        public string Value
        {
            set;
            get;
        }
        public string Picture1
        {
            set;
            get;
        }
        public string Picture2
        {
            set;
            get;
        }
        public double Weight
        {
            set;
            get;
        }
        public double Height
        {
            set;
            get;
        }
        public double Tax
        {
            set;
            get;
        }
        public double Discount
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public int Quantity
        {
            set;
            get;
        }
        public int Provider
        {
            set;
            get;
        }
    }
}