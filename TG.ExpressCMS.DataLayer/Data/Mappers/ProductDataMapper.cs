using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Config;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class ProductDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_PRODUCT_ID = "ID";
        public const string CN_PRODUCT_NAME = "NAME";
        public const string CN_PRODUCT_SERIAL = "SERIAL";
        public const string CN_PRODUCT_PUBLICPRICE = "PUBLIC_PRICE";
        public const string CN_PRODUCT_PRIVATEPRICE = "PRIVATE_PRICE";
        public const string CN_PRODUCT_CATEGORYID = "CATEGORY_ID";
        public const string CN_PRODUCT_PRODUCINGDATE = "PRODUCTION_DATE";
        public const string CN_PRODUCT_EXPIRYDATE = "EXPIRY_DATE";
        public const string CN_PRODUCT_VALUE = "VALUE";

        public const string CN_PRODUCT_PICTURE1 = "IMAGE";
        public const string CN_PRODUCT_PICTURE2 = "IMAGE1";
        public const string CN_PRODUCT_WEIGHT = "WEIGHT";
        public const string CN_PRODUCT_HEIGHT = "HEIGHT";
        public const string CN_PRODUCT_TAX = "TAX";
        public const string CN_PRODUCT_DISCOUNT = "DISCOUNT";
        public const string CN_PRODUCT_ISDELETED = "IS_DELETED";
        public const string CN_PRODUCT_QUANTITY = "QUANTITY";
        public const string CN_PRODUCT_PROVIDER = "PROVIDER";
        #endregion
        #region"Parameters"
        public const string PN_PRODUCT_ID = "@ID";
        public const string PN_PRODUCT_NAME = "@NAME";
        public const string PN_PRODUCT_SERIAL = "@SERIAL";
        public const string PN_PRODUCT_PUBLICPRICE = "@PUBLIC_PRICE";
        public const string PN_PRODUCT_PRIVATEPRICE = "@PRIVATE_PRICE";
        public const string PN_PRODUCT_CATEGORYID = "@CATEGORY_ID";
        public const string PN_PRODUCT_PRODUCINGDATE = "@PRODUCTION_DATE";
        public const string PN_PRODUCT_EXPIRYDATE = "@EXPIRY_DATE";
        public const string PN_PRODUCT_VALUE = "@VALUE";

        public const string PN_PRODUCT_PICTURE1 = "@IMAGE";
        public const string PN_PRODUCT_PICTURE2 = "@IMAGE1";
        public const string PN_PRODUCT_WEIGHT = "@WEIGHT";
        public const string PN_PRODUCT_HEIGHT = "@HEIGHT";
        public const string PN_PRODUCT_TAX = "@TAX";
        public const string PN_PRODUCT_DISCOUNT = "@DISCOUNT";
        public const string PN_PRODUCT_ISDELETED = "@IS_DELETED";
        public const string PN_PRODUCT_QUANTITY = "@QUANTITY";
        public const string PN_PRODUCT_PROVIDER = "@PROVIDER";
        #endregion
        #region"Procedures"
        public const string PCN_PRODUCT_ADD = "ProductAdd";
        public const string PCN_PRODUCT_UPDATE = "ProductUpdate";
        public const string PCN_PRODUCT_DELETE = "ProductDelete";
        public const string PCN_PRODUCT_GETBYID = "ProductGetByID";
        public const string PCN_PRODUCT_GETALL = "ProductGetAll";
        public const string PCN_PRODUCT_GETBYCATEGORY = "ProductGetAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Product obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCN_PRODUCT_ADD;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_PRODUCT_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_PRODUCT_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterSerial = new SqlParameter(PN_PRODUCT_SERIAL, SqlDbType.NVarChar);
            parameterSerial.Value = obj.Serial;
            parameterSerial.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSerial);
            SqlParameter parameterPublicPrice = new SqlParameter(PN_PRODUCT_PUBLICPRICE, SqlDbType.Decimal);
            parameterPublicPrice.Value = obj.PublicPrice;
            parameterPublicPrice.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublicPrice);
            SqlParameter parameterPrivatePrice = new SqlParameter(PN_PRODUCT_PRIVATEPRICE, SqlDbType.Decimal);
            parameterPrivatePrice.Value = obj.PrivatePrice;
            parameterPrivatePrice.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPrivatePrice);
            SqlParameter parameterCategoryID = new SqlParameter(PN_PRODUCT_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterProducingDate = new SqlParameter(PN_PRODUCT_PRODUCINGDATE, SqlDbType.NVarChar);
            parameterProducingDate.Value = obj.ProducingDate;
            parameterProducingDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterProducingDate);
            SqlParameter parameterExpiryDate = new SqlParameter(PN_PRODUCT_EXPIRYDATE, SqlDbType.NVarChar);
            parameterExpiryDate.Value = obj.ExpiryDate;
            parameterExpiryDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterExpiryDate);
            SqlParameter parameterValue = new SqlParameter(PN_PRODUCT_VALUE, SqlDbType.NVarChar);
            parameterValue.Value = obj.Value;
            parameterValue.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterValue);
            SqlParameter parameterTax = new SqlParameter(PN_PRODUCT_TAX, SqlDbType.Decimal);
            parameterTax.Value = obj.Tax;
            parameterTax.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTax);
            SqlParameter parameterPicture1 = new SqlParameter(PN_PRODUCT_PICTURE1, SqlDbType.NVarChar);
            parameterPicture1.Value = obj.Picture1;
            parameterPicture1.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPicture1);
            SqlParameter parameterPicture2 = new SqlParameter(PN_PRODUCT_PICTURE2, SqlDbType.NVarChar);
            parameterPicture2.Value = obj.Picture2;
            parameterPicture2.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPicture2);
            SqlParameter parameterWeight = new SqlParameter(PN_PRODUCT_WEIGHT, SqlDbType.Decimal);
            parameterWeight.Value = obj.Weight;
            parameterWeight.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterWeight);
            SqlParameter parameterHeight = new SqlParameter(PN_PRODUCT_HEIGHT, SqlDbType.Decimal);
            parameterHeight.Value = obj.Height;
            parameterHeight.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHeight);
         
            SqlParameter parameterDiscount = new SqlParameter(PN_PRODUCT_DISCOUNT, SqlDbType.Decimal);
            parameterDiscount.Value = obj.Discount;
            parameterDiscount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDiscount);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_PRODUCT_ISDELETED, SqlDbType.Bit);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterQuantity = new SqlParameter(PN_PRODUCT_QUANTITY, SqlDbType.Int);
            parameterQuantity.Value = obj.Quantity;
            parameterQuantity.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterQuantity);
            SqlParameter parameterProvider = new SqlParameter(PN_PRODUCT_PROVIDER, SqlDbType.Int);
            parameterProvider.Value = obj.Provider;
            parameterProvider.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterProvider);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Product obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCN_PRODUCT_UPDATE;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_PRODUCT_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_PRODUCT_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterSerial = new SqlParameter(PN_PRODUCT_SERIAL, SqlDbType.NVarChar);
            parameterSerial.Value = obj.Serial;
            parameterSerial.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSerial);
            SqlParameter parameterPublicPrice = new SqlParameter(PN_PRODUCT_PUBLICPRICE, SqlDbType.Decimal);
            parameterPublicPrice.Value = obj.PublicPrice;
            parameterPublicPrice.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublicPrice);
            SqlParameter parameterPrivatePrice = new SqlParameter(PN_PRODUCT_PRIVATEPRICE, SqlDbType.Decimal);
            parameterPrivatePrice.Value = obj.PrivatePrice;
            parameterPrivatePrice.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPrivatePrice);
            SqlParameter parameterCategoryID = new SqlParameter(PN_PRODUCT_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterProducingDate = new SqlParameter(PN_PRODUCT_PRODUCINGDATE, SqlDbType.NVarChar);
            parameterProducingDate.Value = obj.ProducingDate;
            parameterProducingDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterProducingDate);
            SqlParameter parameterExpiryDate = new SqlParameter(PN_PRODUCT_EXPIRYDATE, SqlDbType.NVarChar);
            parameterExpiryDate.Value = obj.ExpiryDate;
            parameterExpiryDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterExpiryDate);
            SqlParameter parameterValue = new SqlParameter(PN_PRODUCT_VALUE, SqlDbType.NVarChar);
            parameterValue.Value = obj.Value;
            parameterValue.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterValue);
            SqlParameter parameterTax = new SqlParameter(PN_PRODUCT_TAX, SqlDbType.Decimal);
            parameterTax.Value = obj.Tax;
            parameterTax.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTax);
            SqlParameter parameterPicture1 = new SqlParameter(PN_PRODUCT_PICTURE1, SqlDbType.NVarChar);
            parameterPicture1.Value = obj.Picture1;
            parameterPicture1.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPicture1);
            SqlParameter parameterPicture2 = new SqlParameter(PN_PRODUCT_PICTURE2, SqlDbType.NVarChar);
            parameterPicture2.Value = obj.Picture2;
            parameterPicture2.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPicture2);
            SqlParameter parameterWeight = new SqlParameter(PN_PRODUCT_WEIGHT, SqlDbType.Decimal);
            parameterWeight.Value = obj.Weight;
            parameterWeight.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterWeight);
            SqlParameter parameterHeight = new SqlParameter(PN_PRODUCT_HEIGHT, SqlDbType.Decimal);
            parameterHeight.Value = obj.Height;
            parameterHeight.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHeight);
          
            SqlParameter parameterDiscount = new SqlParameter(PN_PRODUCT_DISCOUNT, SqlDbType.Decimal);
            parameterDiscount.Value = obj.Discount;
            parameterDiscount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDiscount);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_PRODUCT_ISDELETED, SqlDbType.Bit);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterQuantity = new SqlParameter(PN_PRODUCT_QUANTITY, SqlDbType.Int);
            parameterQuantity.Value = obj.Quantity;
            parameterQuantity.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterQuantity);
            SqlParameter parameterProvider = new SqlParameter(PN_PRODUCT_PROVIDER, SqlDbType.Int);
            parameterProvider.Value = obj.Provider;
            parameterProvider.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterProvider);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;
        #region[Delete]

        public void Delete(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCN_PRODUCT_DELETE;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_PRODUCT_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;
        #region[Get By ID]

        public Product GetByID(int ID)
        {

            Product obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCN_PRODUCT_GETBYID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_PRODUCT_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Product();
                        if (_dtreader.Read())
                            GetEntityFromReader(_dtreader, obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                _dtreader.Close();
                _connection.Close();
            }

            return obj;
        }
        #endregion;
        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, Product obj)
        {
            PopulateProduct(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Product> GetAll()
        {

            Product obj = null;

            IList<Product> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCN_PRODUCT_GETBYID;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Product();
                        colobj = new List<Product>();
                        while (_dtreader.Read())
                        {
                            obj = GetProduct(_dtreader, colobj);
                            GetEntityFromReader(_dtreader, obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;
        #region[Get By Category]

        public IList<Product> GetByCategoryID(int catID)
        {

            Product obj = null;

            IList<Product> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCN_PRODUCT_GETBYCATEGORY;

            SqlParameter parameterCategoryID = new SqlParameter(PN_PRODUCT_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Product();
                        colobj = new List<Product>();
                        while (_dtreader.Read())
                        {
                            obj = GetProduct(_dtreader, colobj);
                            GetEntityFromReader(_dtreader, obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;
        #region[Get Product]
        public Product GetProduct(SqlDataReader _dtr, IList<Product> colobj)
        {
            Product obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_PRODUCT_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Product();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}