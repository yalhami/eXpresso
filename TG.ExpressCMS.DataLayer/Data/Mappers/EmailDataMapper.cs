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
    public class EmailDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_ISDELETED = "ISDELETED";
        public const string CN_DATE = "DATE";
        public const string CN_TYPE = "TYPE";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_ISDELETED = "ISDELETED";
        public const string PN_DATE = "DATE";
        public const string PN_TYPE = "TYPE";
        #endregion
        #region"Procedures"
        public const string INSERTEmail = "usp_InsertEmail";
        public const string UPDATEEmail = "usp_UpdateEmail";
        public const string DELETEEmail = "usp_DeleteEmail";
        public const string SELECTEmail = "usp_SelectEmail";
        public const string SELECTALLEmail = "usp_SelectEmailsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetMailDb();
        #region[Add]

        public int Add(Email obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTEmail;

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
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);

            SqlParameter pType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            pType.Value = obj.Type;
            pType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pType);
          
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Email obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEEmail;

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
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);


            SqlParameter pType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            pType.Value = obj.Type;
            pType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pType);
          
          
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
            _command.CommandText = DELETEEmail;

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

        public Email GetByID(int ID)
        {

            Email obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTEmail;

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
                        obj = new Email();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Email obj)
        {
            PopulateEmail(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Email> GetAll()
        {

            Email obj = null;

            IList<Email> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLEmail;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Email();
                        colobj = new List<Email>();
                        while (_dtreader.Read())
                        {
                            obj = GetEmail(_dtreader, colobj);
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
        #region[Get Email]
        public Email GetEmail(SqlDataReader _dtr, IList<Email> colobj)
        {
            Email obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Email();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}