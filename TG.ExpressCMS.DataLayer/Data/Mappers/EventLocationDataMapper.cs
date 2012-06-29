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
    public class EventLocationDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_EVENT_LOCATION_ID = "EVENT_LOCATION_ID";
        public const string CN_EVENT_LOCATION_NAME = "EVENT_LOCATION_NAME";
        public const string CN_EVENT_LOCATION_IS_DELETED = "EVENT_LOCATION_IS_DELETED";
        #endregion

        #region"Parameters"
        public const string PN_EVENT_LOCATION_ID = "@P_EVENT_LOCATION_ID";
        public const string PN_EVENT_LOCATION_NAME = "@P_EVENT_LOCATION_NAME";
        public const string PN_EVENT_LOCATION_IS_DELETED = "@P_EVENT_LOCATION_IS_DELETED";
        #endregion

        #region"Procedures"
        public const string SP_ADD_EVENT_LOCATION = "usp_EventLocationAdd";
        public const string SP_DELETE_EVENT_LOCATION = "usp_EventLocationDelete";
        public const string SP_DELETE_LOGICAL_EVENT_LOCATION = "usp_EventLocationDeleteLogical";
        public const string SP_GET_ALL_EVENT_LOCATION = "usp_EventLocationGetAll";
        public const string SP_GET_EVENT_LOCATION_BY_ID = "usp_EventLocationGetByID";
        public const string SP_UPDATE_EVENT_LOCATION = "usp_EventLocationUpdate";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(EventLocation obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_EVENT_LOCATION;

            #region [Parameters]

            SqlParameter parameter = new SqlParameter(PN_EVENT_LOCATION_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_LOCATION_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_LOCATION_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_EVENT_LOCATION_ID].Value);
            return obj.ID;
        }
        #endregion

        #region[Update]
        public void Update(EventLocation obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_EVENT_LOCATION;

            #region [Parameters]

            SqlParameter parameter = new SqlParameter(PN_EVENT_LOCATION_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_LOCATION_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_LOCATION_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[DeleteLogical]
        public void DeleteLogical(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_DELETE_LOGICAL_EVENT_LOCATION;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_LOCATION_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[DeletePhysical]
        public void DeletePhysical(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_DELETE_EVENT_LOCATION;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_LOCATION_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[Get By ID]
        public EventLocation GetByID(int ID)
        {
            EventLocation obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_EVENT_LOCATION_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_LOCATION_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            if (obj == null)
                                obj = new EventLocation();
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

            return obj;
        }
        #endregion

        #region[Get All]
        public List<EventLocation> GetAll()
        {
            EventLocation obj = null;

            List<EventLocation> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_EVENT_LOCATION;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<EventLocation>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetEventLocation(_dtreader, colobj);
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
        #endregion

        #region[Get Event Location]
        public EventLocation GetEventLocation(SqlDataReader _dtr, IList<EventLocation> colobj)
        {
            EventLocation obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_EVENT_LOCATION_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new EventLocation();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, EventLocation obj)
        {
            PopulateEventLocation(_dtr, obj);
        }
        #endregion
    }
}