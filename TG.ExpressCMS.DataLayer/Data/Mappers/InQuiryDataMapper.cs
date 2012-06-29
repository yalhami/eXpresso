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
    public class InQuiryDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DESCRIPTION = "DESCRIPTION";
        public const string CN_EMAIL = "EMAIL";
        public const string CN_PHONE = "PHONE";
        public const string CN_COUNTRY = "COUNTRY";
        public const string CN_STATUS = "STATUS";
        public const string CN_ISDELETED = "IS_DELETED";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DESCRIPTION = "DESCRIPTION";
        public const string PN_EMAIL = "EMAIL";
        public const string PN_PHONE = "PHONE";
        public const string PN_COUNTRY = "COUNTRY";
        public const string PN_STATUS = "STATUS";
        public const string PN_ISDELETED = "IS_DELETED";
        #endregion
        #region"Procedures"
        public const string INSERTInQuiry = "usp_InsertInQuiry";
        public const string UPDATEInQuiry = "usp_UpdateInQuiry";
        public const string DELETEInQuiry = "usp_DeleteInQuiry";
        public const string SELECTInQuiry = "usp_SelectInQuiry";
        public const string SELECTALLInQuiry = "usp_SelectInQuiriesAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(InQuiry obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTInQuiry;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDescription = new SqlParameter(PN_DESCRIPTION, SqlDbType.NVarChar);
            parameterDescription.Value = obj.Description;
            parameterDescription.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDescription);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterPhone = new SqlParameter(PN_PHONE, SqlDbType.NVarChar);
            parameterPhone.Value = obj.Phone;
            parameterPhone.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhone);
            SqlParameter parameterCountry = new SqlParameter(PN_COUNTRY, SqlDbType.NVarChar);
            parameterCountry.Value = obj.Country;
            parameterCountry.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCountry);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = Convert.ToInt32(obj.Status);
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
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

        public void Update(InQuiry obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEInQuiry;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDescription = new SqlParameter(PN_DESCRIPTION, SqlDbType.NVarChar);
            parameterDescription.Value = obj.Description;
            parameterDescription.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDescription);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterPhone = new SqlParameter(PN_PHONE, SqlDbType.NVarChar);
            parameterPhone.Value = obj.Phone;
            parameterPhone.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhone);
            SqlParameter parameterCountry = new SqlParameter(PN_COUNTRY, SqlDbType.NVarChar);
            parameterCountry.Value = obj.Country;
            parameterCountry.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCountry);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = Convert.ToInt32(obj.Status);
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
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
            _command.CommandText = DELETEInQuiry;

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

        public InQuiry GetByID(int ID)
        {

            InQuiry obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTInQuiry;

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
                        obj = new InQuiry();
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
        private void GetEntityFromReader(SqlDataReader _dtr, InQuiry obj)
        {
            PopulateInQuiry(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<InQuiry> GetAll()
        {

            InQuiry obj = null;

            IList<InQuiry> colobj = new List<InQuiry>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLInQuiry;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new InQuiry();
                        colobj = new List<InQuiry>();
                        while (_dtreader.Read())
                        {
                            obj = GetInQuiry(_dtreader, colobj);
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
        #region[Get InQuiry]
        public InQuiry GetInQuiry(SqlDataReader _dtr, IList<InQuiry> colobj)
        {
            InQuiry obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new InQuiry();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}