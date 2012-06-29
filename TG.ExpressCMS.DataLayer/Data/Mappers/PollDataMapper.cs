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
    public class PollDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DATE = "DATE";
        public const string CN_CREATEDBY = "CREATEDBY";
        public const string CN_ISCLOSED = "ISCLOSED";
        public const string CN_ISDELETED = "ISDELETED";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DATE = "DATE";
        public const string PN_CREATEDBY = "CREATEDBY";
        public const string PN_ISCLOSED = "ISCLOSED";
        public const string PN_ISDELETED = "ISDELETED";
        #endregion
        #region"Procedures"
        public const string INSERTPoll = "usp_InsertPoll";
        public const string UPDATEPoll = "usp_UpdatePoll";
        public const string DELETEPoll = "usp_DeletePoll";
        public const string SELECTPoll = "usp_SelectPoll";
        public const string SELECTALLPoll = "usp_SelectPollsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Poll obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTPoll;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.Int);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterIsClosed = new SqlParameter(PN_ISCLOSED, SqlDbType.Int);
            parameterIsClosed.Value = obj.IsClosed;
            parameterIsClosed.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsClosed);
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

        public void Update(Poll obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEPoll;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.Int);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterIsClosed = new SqlParameter(PN_ISCLOSED, SqlDbType.Int);
            parameterIsClosed.Value = obj.IsClosed;
            parameterIsClosed.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsClosed);
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
            _command.CommandText = DELETEPoll;

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

        public Poll GetByID(int ID)
        {

            Poll obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTPoll;

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
                        obj = new Poll();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Poll obj)
        {
            PopulatePoll(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Poll> GetAll()
        {

            Poll obj = null;

            IList<Poll> colobj = new List<Poll>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLPoll;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Poll();
                        colobj = new List<Poll>();
                        while (_dtreader.Read())
                        {
                            obj = GetPoll(_dtreader, colobj);
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
        #region[Get Poll]
        public Poll GetPoll(SqlDataReader _dtr, IList<Poll> colobj)
        {
            Poll obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Poll();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}