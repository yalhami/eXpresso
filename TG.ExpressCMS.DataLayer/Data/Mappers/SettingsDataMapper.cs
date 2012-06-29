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
    public class SettingsDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DEFAULTURL = "DefUrl";
        public const string CN_DEFAULTLANGUAGECODE = "DefLanguageCode";
        public const string CN_ISDEFAULT = "IsDefault";
        public const string CN_PHYSICALPATH = "PhysicalPath";
        public const string CN_ISDELETED = "ISDELETED";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DEFAULTURL = "DefUrl";
        public const string PN_DEFAULTLANGUAGECODE = "DefLanguageCode";
        public const string PN_ISDEFAULT = "ISDEFAULT";
        public const string PN_PHYSICALPATH = "PHYSICALPATH";
        public const string PN_ISDELETED = "ISDELETED";
        #endregion
        #region"Procedures"
        public const string INSERTSettings = "usp_InsertSetting";
        public const string UPDATESettings = "usp_UpdateSetting";
        public const string DELETESettings = "usp_DeleteSetting";
        public const string SELECTSettings = "usp_SelectSetting";
        public const string SELECTALLSettings = "usp_SelectSettingsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Settings obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTSettings;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDefaultURL = new SqlParameter(PN_DEFAULTURL, SqlDbType.NVarChar);
            parameterDefaultURL.Value = obj.DefaultUrl;
            parameterDefaultURL.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDefaultURL);
            SqlParameter parameterDefaultLanguageCode = new SqlParameter(PN_DEFAULTLANGUAGECODE, SqlDbType.NVarChar);
            parameterDefaultLanguageCode.Value = obj.DefaultLanguageCode;
            parameterDefaultLanguageCode.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDefaultLanguageCode);
            SqlParameter parameterIsDefault = new SqlParameter(PN_ISDEFAULT, SqlDbType.Int);
            parameterIsDefault.Value = obj.IsDefault;
            parameterIsDefault.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDefault);
            SqlParameter parameterPhysicalPath = new SqlParameter(PN_PHYSICALPATH, SqlDbType.NVarChar);
            parameterPhysicalPath.Value = obj.PhysicalPath;
            parameterPhysicalPath.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhysicalPath);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Settings obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATESettings;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDefaultURL = new SqlParameter(PN_DEFAULTURL, SqlDbType.NVarChar);
            parameterDefaultURL.Value = obj.DefaultUrl;
            parameterDefaultURL.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDefaultURL);
            SqlParameter parameterDefaultLanguageCode = new SqlParameter(PN_DEFAULTLANGUAGECODE, SqlDbType.NVarChar);
            parameterDefaultLanguageCode.Value = obj.DefaultLanguageCode;
            parameterDefaultLanguageCode.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDefaultLanguageCode);
            SqlParameter parameterIsDefault = new SqlParameter(PN_ISDEFAULT, SqlDbType.Int);
            parameterIsDefault.Value = obj.IsDefault;
            parameterIsDefault.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDefault);
            SqlParameter parameterPhysicalPath = new SqlParameter(PN_PHYSICALPATH, SqlDbType.NVarChar);
            parameterPhysicalPath.Value = obj.PhysicalPath;
            parameterPhysicalPath.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhysicalPath);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
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
            _command.CommandText = DELETESettings;

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

        public Settings GetByID(int ID)
        {

            Settings obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTSettings;

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
                        obj = new Settings();
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
        #region[Get Default]

        public Settings GetDefault()
        {

            Settings obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectDefSetting]";
            
            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Settings();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Settings obj)
        {
            PopulateSettings(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Settings> GetAll()
        {

            Settings obj = null;

            IList<Settings> colobj = new List<Settings>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLSettings;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Settings();
                        colobj = new List<Settings>();
                        while (_dtreader.Read())
                        {
                            obj = GetSettings(_dtreader, colobj);
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
        #region[Get Settings]
        public Settings GetSettings(SqlDataReader _dtr, IList<Settings> colobj)
        {
            Settings obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Settings();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}