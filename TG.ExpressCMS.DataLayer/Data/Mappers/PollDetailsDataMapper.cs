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
    public class PollDetailsDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_POLLID = "POLLID";
        public const string CN_NAME = "NAME";
        public const string CN_COUNT = "COUNT";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_POLLID = "POLLID";
        public const string PN_NAME = "NAME";
        public const string PN_COUNT = "COUNT";
        #endregion
        #region"Procedures"
        public const string INSERTPollDetails = "usp_InsertPollDetail";
        public const string UPDATEPollDetails = "usp_UpdatePollDetail";
        public const string DELETEPollDetails = "usp_DeletePollDetail";
        public const string SELECTPollDetails = "usp_SelectPollDetail";
        public const string SELECTALLPollDetails = "usp_SelectPollDetailsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(PollDetails obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTPollDetails;

            #region [Parameters]
            SqlParameter pollID = new SqlParameter(PN_ID, SqlDbType.Int);
            pollID.Value = obj.ID;
            pollID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(pollID);
            SqlParameter parameterPollID = new SqlParameter(PN_POLLID, SqlDbType.Int);
            parameterPollID.Value = obj.PollID;
            parameterPollID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPollID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterCount = new SqlParameter(PN_COUNT, SqlDbType.Int);
            parameterCount.Value = obj.Count;
            parameterCount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCount);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(pollID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(PollDetails obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEPollDetails;

            #region [Parameters]
            SqlParameter pollID = new SqlParameter(PN_ID, SqlDbType.Int);
            pollID.Value = obj.ID;
            pollID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pollID);
            SqlParameter parameterPollID = new SqlParameter(PN_POLLID, SqlDbType.Int);
            parameterPollID.Value = obj.PollID;
            parameterPollID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPollID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterCount = new SqlParameter(PN_COUNT, SqlDbType.Int);
            parameterCount.Value = obj.Count;
            parameterCount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCount);
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
            _command.CommandText = DELETEPollDetails;

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

        public PollDetails GetByID(int ID)
        {

            PollDetails obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTPollDetails;

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
                        obj = new PollDetails();
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
        private void GetEntityFromReader(SqlDataReader _dtr, PollDetails obj)
        {
            PopulatePollDetails(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<PollDetails> GetAll()
        {

            PollDetails obj = null;

            IList<PollDetails> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLPollDetails;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new PollDetails();
                        colobj = new List<PollDetails>();
                        while (_dtreader.Read())
                        {
                            obj = GetPollDetails(_dtreader, colobj);
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
        #region[Get By PollID]

        public IList<PollDetails> GetByPollID(int pollID)
        {

            PollDetails obj = null;

            IList<PollDetails> colobj = new List<PollDetails>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectPollDetailByPollID]";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_POLLID, SqlDbType.Int);
            parameterID.Value = pollID;
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
                        obj = new PollDetails();
                        colobj = new List<PollDetails>();
                        while (_dtreader.Read())
                        {
                            obj = GetPollDetails(_dtreader, colobj);
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
        public int GetTotalCount(int pollID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectPollDetailCountByPollID";


            #region [Parameters]
            SqlParameter parameterpollID = new SqlParameter(PN_POLLID, SqlDbType.Int);
            parameterpollID.Value = pollID;
            parameterpollID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterpollID);

            SqlParameter parameterCount = new SqlParameter("Count", SqlDbType.Int);
            parameterCount.Value = DBNull.Value;
            parameterCount.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterCount);
            #endregion;


            _connection.Open();
            _command.ExecuteNonQuery();
            pollID = Convert.ToInt32(parameterCount.Value);
            _connection.Close();

            return pollID;
        }

        #endregion;
        #region[Get PollDetails]
        public PollDetails GetPollDetails(SqlDataReader _dtr, IList<PollDetails> colobj)
        {
            PollDetails obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new PollDetails();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}