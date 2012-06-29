using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Config;
using TG.ExpressCMS.DataLayer.Entities;
using System.Xml;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class MarqueeItemsDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_ISDELETED = "ISDELETED";
        public const string CN_CATEGORYID = "CATEGORY_ID";
        public const string CN_URL = "URL";
        public const string CN_URLTYPE = "URLTYPE";
        public const string CN_TEXT = "TEXT";
        public const string CN_IMAGE = "IMAGE";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_ISDELETED = "ISDELETED";
        public const string PN_CATEGORYID = "CATEGORY_ID";
        public const string PN_URL = "URL";
        public const string PN_URLTYPE = "URLTYPE";
        public const string PN_TEXT = "TEXT";
        public const string PN_IMAGE = "IMAGE";
        #endregion
        #region"Procedures"
        public const string INSERTMarqueeItems = "usp_InsertMarqueeItem";
        public const string UPDATEMarqueeItems = "usp_UpdateMarqueeItem";
        public const string DELETEMarqueeItems = "usp_DeleteMarqueeItem";
        public const string SELECTMarqueeItems = "usp_SelectMarqueeItem";
        public const string SELECTALLMarqueeItems = "usp_SelectMarqueeItemsAll";
        public const string SELECTALLMarqueeItemsByCatID = "usp_SelectMarqueeItemsByCatID";
        public const string SELECTALLMarqueeItemsByIDasXml = "[usp_SelectMarqueeItemasXml]";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(MarqueeItems obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTMarqueeItems;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterUrlType = new SqlParameter(PN_URLTYPE, SqlDbType.Int);
            parameterUrlType.Value = Convert.ToInt32(obj.UrlType);
            parameterUrlType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrlType);
            SqlParameter parameterText = new SqlParameter(PN_TEXT, SqlDbType.NVarChar);
            parameterText.Value = obj.Text;
            parameterText.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterText);

            SqlParameter parameterImage = new SqlParameter(PN_IMAGE, SqlDbType.NVarChar);
            parameterImage.Value = obj.Image;
            parameterImage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterImage);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(MarqueeItems obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEMarqueeItems;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterUrlType = new SqlParameter(PN_URLTYPE, SqlDbType.Int);
            parameterUrlType.Value = Convert.ToInt32(obj.UrlType);
            parameterUrlType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrlType);
            SqlParameter parameterText = new SqlParameter(PN_TEXT, SqlDbType.NVarChar);
            parameterText.Value = obj.Text;
            parameterText.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterText);

            SqlParameter parameterImage = new SqlParameter(PN_IMAGE, SqlDbType.NVarChar);
            parameterImage.Value = obj.Image;
            parameterImage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterImage);
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
            _command.CommandText = DELETEMarqueeItems;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
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

        public MarqueeItems GetByID(int ID)
        {

            MarqueeItems obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTMarqueeItems;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
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
                        obj = new MarqueeItems();
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
        #region[Get By ID as Xml]

        public XmlDocument GetByIDasXml(int ID)
        {
            XmlDocument xDoc = new XmlDocument();
            string _xml = string.Empty;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLMarqueeItemsByIDasXml;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion;

            _connection.Open();
            XmlReader _dxtreader = null;
            try
            {
                using (_dxtreader = _command.ExecuteXmlReader())
                {
                    if (_dxtreader != null)
                    {
                        _dxtreader.Read();
                        string xml = "<Data>";
                        while (_dxtreader.ReadState != ReadState.EndOfFile)
                        {
                            xml += _dxtreader.ReadOuterXml();


                        } xml = xml.Replace("dbo.", ""); xml += "</Data>";
                        xDoc.LoadXml(xml);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                _dxtreader.Close();
                _connection.Close();
            }

            return xDoc;
        }
        #endregion;
        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, MarqueeItems obj)
        {
            PopulateMarqueeItems(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<MarqueeItems> GetAll()
        {

            MarqueeItems obj = null;

            IList<MarqueeItems> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLMarqueeItems;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new MarqueeItems();
                        colobj = new List<MarqueeItems>();
                        while (_dtreader.Read())
                        {
                            obj = GetMarqueeItems(_dtreader, colobj);
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
        #region[Get By Category ID]

        public IList<MarqueeItems> GetByCategoryID(int catID)
        {

            MarqueeItems obj = null;

            IList<MarqueeItems> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLMarqueeItemsByCatID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = catID;
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
                        obj = new MarqueeItems();
                        colobj = new List<MarqueeItems>();
                        while (_dtreader.Read())
                        {
                            obj = GetMarqueeItems(_dtreader, colobj);
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
        #region[Get MarqueeItems]
        public MarqueeItems GetMarqueeItems(SqlDataReader _dtr, IList<MarqueeItems> colobj)
        {
            MarqueeItems obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new MarqueeItems();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}