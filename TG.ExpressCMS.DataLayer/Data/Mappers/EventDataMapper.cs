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
    public class EventDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_EVENT_ID = "EVENT_ID";
        public const string CN_EVENT_NAME = "EVENT_NAME";
        public const string CN_EVENT_EVENT_LOCATION_ID = "EVENT_EVENT_LOCATION_ID";
        public const string CN_EVENT_DETAILS = "EVENT_DETAILS";
        public const string CN_EVENT_FROM_TOT_DAY = "EVENT_FROM_TOT_DAY";
        public const string CN_EVENT_FROM_TOT_SECOND = "EVENT_FROM_TOT_SECOND";
        public const string CN_EVENT_TO_TOT_DAY = "EVENT_TO_TOT_DAY";
        public const string CN_EVENT_TO_TOT_SECOND = "EVENT_TO_TOT_SECOND";
        public const string CN_EVENT_DURATION = "EVENT_DURATION";
        public const string CN_EVENT_REPEAT_TYPE = "EVENT_REPEAT_TYPE";
        public const string CN_EVENT_EVERY = "EVENT_EVERY";
        public const string CN_EVENT_PERIOD = "EVENT_PERIOD";
        public const string CN_EVENT_REMINDER = "EVENT_REMINDER";
        public const string CN_EVENT_NOTIFY = "EVENT_NOTIFY";
        public const string CN_EVENT_CREATED_BY = "EVENT_CREATED_BY";
        public const string CN_EVENT_CREATED_TOT_DAY = "EVENT_CREATED_TOT_DAY";
        public const string CN_EVENT_CREATED_TOT_SECOND = "EVENT_CREATED_TOT_SECOND";
        public const string CN_EVENT_IMAGE_URL = "EVENT_IMAGE_URL";
        public const string CN_EVENT_CATEGORY_ID = "EVENT_CATEGORY_ID";
        public const string CN_EVENT_IS_DELETED = "EVENT_IS_DELETED";
        #endregion

        #region"Parameters"
        public const string PN_EVENT_ID = "@P_EVENT_ID";
        public const string PN_EVENT_NAME = "@P_EVENT_NAME";
        public const string PN_EVENT_EVENT_LOCATION_ID = "@P_EVENT_EVENT_LOCATION_ID";
        public const string PN_EVENT_DETAILS = "@P_EVENT_DETAILS";
        public const string PN_EVENT_FROM_TOT_DAY = "@P_EVENT_FROM_TOT_DAY";
        public const string PN_EVENT_FROM_TOT_SECOND = "@P_EVENT_FROM_TOT_SECOND";
        public const string PN_EVENT_TO_TOT_DAY = "@P_EVENT_TO_TOT_DAY";
        public const string PN_EVENT_TO_TOT_SECOND = "@P_EVENT_TO_TOT_SECOND";
        public const string PN_EVENT_DURATION = "@P_EVENT_DURATION";
        public const string PN_EVENT_REPEAT_TYPE = "@P_EVENT_REPEAT_TYPE";
        public const string PN_EVENT_EVERY = "@P_EVENT_EVERY";
        public const string PN_EVENT_PERIOD = "@P_EVENT_PERIOD";
        public const string PN_EVENT_REMINDER = "@P_EVENT_REMINDER";
        public const string PN_EVENT_NOTIFY = "@P_EVENT_NOTIFY";
        public const string PN_EVENT_CREATED_BY = "@P_EVENT_CREATED_BY";
        public const string PN_EVENT_CREATED_TOT_DAY = "@P_EVENT_CREATED_TOT_DAY";
        public const string PN_EVENT_CREATED_TOT_SECOND = "@P_EVENT_CREATED_TOT_SECOND";
        public const string PN_EVENT_IMAGE_URL = "@P_EVENT_IMAGE_URL";
        public const string PN_EVENT_CATEGORY_ID = "@P_EVENT_CATEGORY_ID";
        public const string PN_EVENT_IS_DELETED = "@P_EVENT_IS_DELETED";
        #endregion

        #region"Procedures"
        public const string SP_ADD_EVENT = "usp_EventAdd";
        public const string SP_DELETE_EVENT = "usp_EventDelete";
        public const string SP_DELETE_LOGICAL_EVENT = "usp_EventDeleteLogical";
        public const string SP_GET_ALL_EVENT = "usp_EventGetAll";
        public const string SP_GET_EVENT_BY_CATEGORY_ID = "usp_EventGetByCategoryID";
        public const string SP_GET_EVENT_BY_LOCATION_ID = "usp_EventGetByLocationID";
        public const string SP_GET_EVENT_BY_ID = "usp_EventGetByID";
        public const string SP_GET_EVENT_BY_SEARCH = "usp_EventGetBySearch";
        public const string SP_UPDATE_EVENT = "usp_EventUpdate";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(Event obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_EVENT;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_EVENT_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CATEGORY_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.CategoryID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CREATED_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CREATED_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_DETAILS, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_DURATION, System.Data.SqlDbType.Int);
            parameter.Value = obj.Duration;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_EVENT_LOCATION_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LocationID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_EVERY, System.Data.SqlDbType.Int);
            parameter.Value = obj.Every;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_FROM_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.FromDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_FROM_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.FromDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_IMAGE_URL, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.ImageURL;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_NOTIFY, System.Data.SqlDbType.Int);
            parameter.Value = obj.Notify;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_PERIOD, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Period;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_REMINDER, System.Data.SqlDbType.Int);
            parameter.Value = obj.Reminder;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_REPEAT_TYPE, System.Data.SqlDbType.Int);
            parameter.Value = obj.RepeatType;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_TO_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.ToDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_TO_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.ToDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_EVENT_ID].Value);
            return obj.ID;
        }
        #endregion

        #region[Update]
        public void Update(Event obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_EVENT;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_EVENT_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CATEGORY_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.CategoryID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CREATED_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_CREATED_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_DETAILS, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_DURATION, System.Data.SqlDbType.Int);
            parameter.Value = obj.Duration;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_EVENT_LOCATION_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LocationID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_EVERY, System.Data.SqlDbType.Int);
            parameter.Value = obj.Every;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_FROM_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.FromDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_FROM_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.FromDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_IMAGE_URL, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.ImageURL;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_NOTIFY, System.Data.SqlDbType.Int);
            parameter.Value = obj.Notify;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_PERIOD, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Period;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_REMINDER, System.Data.SqlDbType.Int);
            parameter.Value = obj.Reminder;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_REPEAT_TYPE, System.Data.SqlDbType.Int);
            parameter.Value = obj.RepeatType;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_TO_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.ToDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_EVENT_TO_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.ToDate);
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
            _command.CommandText = SP_DELETE_LOGICAL_EVENT;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_ID, SqlDbType.Int);
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
            _command.CommandText = SP_DELETE_EVENT;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_ID, SqlDbType.Int);
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
        public Event GetByID(int ID)
        {
            Event obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_EVENT_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_ID, SqlDbType.Int);
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
                                obj = new Event();
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

        #region[Get By Category ID]
        public List<Event> GetByCategoryID(int CategoryID)
        {
            Event obj = null;
            List<Event> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_EVENT_BY_CATEGORY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_CATEGORY_ID, SqlDbType.Int);
            parameterID.Value = CategoryID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Event>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetEvent(_dtreader, colobj);
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

        #region[Get By Location ID]
        public List<Event> GetByLocationID(int LocationID)
        {
            Event obj = null;
            List<Event> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_EVENT_BY_LOCATION_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EVENT_EVENT_LOCATION_ID, SqlDbType.Int);
            parameterID.Value = LocationID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Event>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetEvent(_dtreader, colobj);
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

        #region[Get By Search]
        public List<Event> GetBySearch(string Keyword, int CategoryID, int LocationID, DateTime? FromDate, DateTime? ToDate)
        {
            Event obj = null;
            List<Event> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_EVENT_BY_SEARCH;

            #region [Parameters]

            SqlParameter parameterID = new SqlParameter(PN_EVENT_CATEGORY_ID, SqlDbType.Int);
            parameterID.Value = CategoryID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_EVENT_EVENT_LOCATION_ID, SqlDbType.Int);
            parameterID.Value = LocationID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_EVENT_NAME, SqlDbType.NVarChar);
            parameterID.Value = Keyword;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_EVENT_FROM_TOT_DAY, SqlDbType.Int);
            if (FromDate.HasValue)
                parameterID.Value = Helper.HelperMethods.GetTotalDays(FromDate.Value);
            else
                parameterID.Value = -1;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_EVENT_TO_TOT_DAY, SqlDbType.Int);
            if (ToDate.HasValue)
                parameterID.Value = Helper.HelperMethods.GetTotalDays(ToDate.Value);
            else
                parameterID.Value = -1;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Event>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetEvent(_dtreader, colobj);
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

        #region[Get All]
        public List<Event> GetAll()
        {
            Event obj = null;

            List<Event> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_EVENT;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Event>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetEvent(_dtreader, colobj);
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

        #region[Get Event]
        public Event GetEvent(SqlDataReader _dtr, IList<Event> colobj)
        {
            Event obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_EVENT_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new Event();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, Event obj)
        {
            PopulateEvent(_dtr, obj);
        }
        #endregion
    }
}