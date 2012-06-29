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
    public class MaiciousRequestDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_IPADDRESS = "IPADDRESS";
        public const string CN_URL = "URL";
        public const string CN_DATETIME = "DATETIME";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_IPADDRESS = "IPADDRESS";
        public const string PN_URL = "URL";
        public const string PN_DATETIME = "DATETIME";
        #endregion
        #region"Procedures"
        public const string INSERTMaiciousRequest = "InsertMaliciousRequest";
     //   public const string UPDATEMaiciousRequest = "usp_UpdateMaiciousRequest";
        public const string DELETEMaiciousRequest = "DeleteMaliciousRequests";
   //     public const string SELECTMaiciousRequest = "usp_SelectMaiciousRequest";
        public const string SELECTALLMaiciousRequest = "GetMaliciousRequests";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(MaiciousRequest obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTMaiciousRequest;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterIPAddress = new SqlParameter(PN_IPADDRESS, SqlDbType.NVarChar);
            parameterIPAddress.Value = obj.IPAddress;
            parameterIPAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIPAddress);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterDateTime = new SqlParameter(PN_DATETIME, SqlDbType.NVarChar);
            parameterDateTime.Value = obj.DateTime;
            parameterDateTime.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDateTime);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        //public void Update(MaiciousRequest obj)
        //{
        //    _connection.ConnectionString = _ConnectionString;
        //    _command.Connection = _connection;
        //    _command.CommandType = CommandType.StoredProcedure;
        //    _command.CommandText = UPDATEMaiciousRequest;

        //    #region [Parameters]
        //    SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
        //    parameterID.Value = obj.ID;
        //    parameterID.Direction = ParameterDirection.Input;
        //    _command.Parameters.Add(parameterID);
        //    SqlParameter parameterIPAddress = new SqlParameter(PN_IPADDRESS, SqlDbType.NVarChar);
        //    parameterIPAddress.Value = obj.IPAddress;
        //    parameterIPAddress.Direction = ParameterDirection.Input;
        //    _command.Parameters.Add(parameterIPAddress);
        //    SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
        //    parameterUrl.Value = obj.Url;
        //    parameterUrl.Direction = ParameterDirection.Input;
        //    _command.Parameters.Add(parameterUrl);
        //    SqlParameter parameterDateTime = new SqlParameter(PN_DATETIME, SqlDbType.NVarChar);
        //    parameterDateTime.Value = obj.DateTime;
        //    parameterDateTime.Direction = ParameterDirection.Input;
        //    _command.Parameters.Add(parameterDateTime);
        //    #endregion;

        //    _connection.Open();
        //    _command.ExecuteNonQuery();
        //    _connection.Close();
        //}
        #endregion;
        #region[Delete]

        public void Delete(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = DELETEMaiciousRequest;

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

        //public MaiciousRequest GetByID(int ID)
        //{

        //    MaiciousRequest obj = null;
        //    _connection.ConnectionString = _ConnectionString;
        //    _command.Connection = _connection;
        //    _command.CommandType = CommandType.StoredProcedure;
        //    _command.CommandText = SELECTMaiciousRequest;

        //    #region [Parameters]
        //    SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
        //    parameterID.Value = ID;
        //    parameterID.Direction = ParameterDirection.Input;
        //    _command.Parameters.Add(parameterID);
        //    #endregion;

        //    _connection.Open();
        //    try
        //    {
        //        using (_dtreader = _command.ExecuteReader())
        //        {
        //            if (_dtreader != null && _dtreader.HasRows)
        //            {
        //                obj = new MaiciousRequest();
        //                if (_dtreader.Read())
        //                    GetEntityFromReader(_dtreader, obj);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {

        //        _dtreader.Close();
        //        _connection.Close();
        //    }

        //    return obj;
        //}
        #endregion;
        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, MaiciousRequest obj)
        {
            PopulateMaiciousRequest(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<MaiciousRequest> GetAll()
        {

            MaiciousRequest obj = null;

            IList<MaiciousRequest> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLMaiciousRequest;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new MaiciousRequest();
                        colobj = new List<MaiciousRequest>();
                        while (_dtreader.Read())
                        {
                            obj = GetMaiciousRequest(_dtreader, colobj);
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
        #region[Get MaiciousRequest]
        public MaiciousRequest GetMaiciousRequest(SqlDataReader _dtr, IList<MaiciousRequest> colobj)
        {
            MaiciousRequest obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new MaiciousRequest();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}