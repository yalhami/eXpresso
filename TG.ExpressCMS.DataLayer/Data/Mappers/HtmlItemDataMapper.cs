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
    public class HtmlItemDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_HASH = "HASH";

        public const string CN_TYPE = "TYPE";
        public const string CN_STATUS = "STATUS";
        public const string CN_DATE = "DATE";

        public const string CN_LANGUAGE_ID = "LANGUAGEID";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_HASH = "HASH";

        public const string PN_TYPE = "TYPE";
        public const string PN_STATUS = "STATUS";
        public const string PN_DATE = "DATE";

        public const string PN_LANGUAGE_ID = "LANGUAGEID";
        #endregion
        #region"Procedures"
        public const string INSERTHtmlItem = "usp_InsertHtmlItem";
        public const string UPDATEHtmlItem = "usp_UpdateHtmlItem";
        public const string DELETEHtmlItem = "usp_DeleteHtmlItem";
        public const string SELECTHtmlItem = "usp_SelectHtmlItem";
        public const string SELECTHtmlItemByHashName = "usp_SelectHtmlItemByHashName";
        public const string SELECTALLHtmlItem = "usp_SelectHtmlItemsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(HtmlItem obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTHtmlItem;

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
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Bit);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter parameterHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterHash.Value = obj.Hash;
            parameterHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHash);

            SqlParameter paramType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            paramType.Value = Convert.ToInt32(obj.Type);
            paramType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramType);

            SqlParameter paramStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            paramStatus.Value = obj.Status;
            paramStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramStatus);

            SqlParameter paramDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            paramDate.Value = obj.Date;
            paramDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramDate);

            SqlParameter paramlangID = new SqlParameter(PN_LANGUAGE_ID, SqlDbType.Int);
            paramlangID.Value = obj.LanguageID;
            paramlangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramlangID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(HtmlItem obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEHtmlItem;

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
            SqlParameter parameterHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterHash.Value = obj.Hash;
            parameterHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHash);

            SqlParameter paramType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            paramType.Value = Convert.ToInt32(obj.Type);
            paramType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramType);

            SqlParameter paramStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            paramStatus.Value = obj.Status;
            paramStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramStatus);

            SqlParameter paramDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            paramDate.Value = obj.Hash;
            paramDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramDate);

            SqlParameter paramlangID = new SqlParameter(PN_LANGUAGE_ID, SqlDbType.Int);
            paramlangID.Value = obj.LanguageID;
            paramlangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramlangID);
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
            _command.CommandText = DELETEHtmlItem;

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

        public HtmlItem GetByID(int ID)
        {

            HtmlItem obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTHtmlItem;

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
                        obj = new HtmlItem();
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
        #region[Get By Hash Name]

        public HtmlItem GetByHashName(string hashName)
        {

            HtmlItem obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTHtmlItemByHashName;

            #region [Parameters]
            SqlParameter parameterhash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterhash.Value = hashName;
            parameterhash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterhash);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new HtmlItem();
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
        #region[Get By Hash Name]

        public HtmlItem GetByHashNameandLangID(string hashName, int langid)
        {

            HtmlItem obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectHtmlItemByHashNameandLangID";

            #region [Parameters]
            SqlParameter parameterhash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterhash.Value = hashName;
            parameterhash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterhash);

            SqlParameter paramlang = new SqlParameter(PN_LANGUAGE_ID, SqlDbType.Int);
            paramlang.Value = langid;
            paramlang.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramlang);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new HtmlItem();
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
        private void GetEntityFromReader(SqlDataReader _dtr, HtmlItem obj)
        {
            PopulateHtmlItem(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<HtmlItem> GetAll()
        {

            HtmlItem obj = null;

            IList<HtmlItem> colobj = new List<HtmlItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLHtmlItem;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new HtmlItem();
                        colobj = new List<HtmlItem>();
                        while (_dtreader.Read())
                        {
                            obj = GetHtmlItem(_dtreader, colobj);
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
        #region[Get All]

        public IList<HtmlItem> Search(string keyword)
        {

            HtmlItem obj = null;

            IList<HtmlItem> colobj = new List<HtmlItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SearchHtmlItem]";

            #region [Parameters]
            SqlParameter parameterhash = new SqlParameter("Keyword", SqlDbType.NVarChar);
            parameterhash.Value = keyword;
            parameterhash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterhash);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new HtmlItem();
                        colobj = new List<HtmlItem>();
                        while (_dtreader.Read())
                        {
                            obj = GetHtmlItem(_dtreader, colobj);
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
        #region[Get HtmlItem]
        public HtmlItem GetHtmlItem(SqlDataReader _dtr, IList<HtmlItem> colobj)
        {
            HtmlItem obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new HtmlItem();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}