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
    public class ForumThreadDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_FORUM_THREAD_ID = "FORUM_THREAD_ID";
        public const string CN_FORUM_THREAD_NAME = "FORUM_THREAD_NAME";
        public const string CN_FORUM_THREAD_FORUM_ID = "FORUM_THREAD_FORUM_ID";
        public const string CN_FORUM_THREAD_CREATION_TOT_DAY = "FORUM_THREAD_CREATION_TOT_DAY";
        public const string CN_FORUM_THREAD_CREATION_TOT_SECOND = "FORUM_THREAD_CREATION_TOT_SECOND";
        public const string CN_FORUM_THREAD_CREATED_BY = "FORUM_THREAD_CREATED_BY";
        public const string CN_FORUM_THREAD_NUMBER_VIEWS = "FORUM_THREAD_NUMBER_VIEWS";
        public const string CN_FORUM_THREAD_STATUS = "FORUM_THREAD_STATUS";
        public const string CN_FORUM_THREAD_IS_DELETED = "FORUM_THREAD_IS_DELETED";
        public const string CN_FORUM_THREAD_TOTAL_POSTS = "FORUM_THREAD_TOTAL_POSTS";
        public const string CN_FORUM_THREAD_DETAILS_TEXT = "FORUM_THREAD_DETAILS_TEXT";
        public const string CN_FORUM_THREAD_DETAILS_HTML = "FORUM_THREAD_DETAILS_HTML";
        public const string CN_FORUM_THREAD_LAST_POST_ID = "FORUM_THREAD_LAST_POST_ID";
        #endregion

        #region"Parameters"
        public const string PN_FORUM_THREAD_ID = "@P_FORUM_THREAD_ID";
        public const string PN_FORUM_THREAD_NAME = "@P_FORUM_THREAD_NAME";
        public const string PN_FORUM_THREAD_FORUM_ID = "@P_FORUM_THREAD_FORUM_ID";
        public const string PN_FORUM_THREAD_CREATION_TOT_DAY = "@P_FORUM_THREAD_CREATION_TOT_DAY";
        public const string PN_FORUM_THREAD_CREATION_TOT_SECOND = "@P_FORUM_THREAD_CREATION_TOT_SECOND";
        public const string PN_FORUM_THREAD_CREATED_BY = "@P_FORUM_THREAD_CREATED_BY";
        public const string PN_FORUM_THREAD_NUMBER_VIEWS = "@P_FORUM_THREAD_NUMBER_VIEWS";
        public const string PN_FORUM_THREAD_STATUS = "@P_FORUM_THREAD_STATUS";
        public const string PN_FORUM_THREAD_IS_DELETED = "@P_FORUM_THREAD_IS_DELETED";
        public const string PN_FORUM_THREAD_TOTAL_POSTS = "@P_FORUM_THREAD_TOTAL_POSTS";
        public const string PN_FORUM_THREAD_DETAILS_TEXT = "@P_FORUM_THREAD_DETAILS_TEXT";
        public const string PN_FORUM_THREAD_DETAILS_HTML = "@P_FORUM_THREAD_DETAILS_HTML";
        public const string PN_FORUM_THREAD_LAST_POST_ID = "@P_FORUM_THREAD_LAST_POST_ID";
        #endregion

        #region"Procedures"
        public const string SP_ADD_FORUM_THREAD = "usp_ForumThreadAdd";
        public const string SP_UPDATE_FORUM_THREAD = "usp_ForumThreadUpdate";
        public const string SP_DELETE_FORUM_THREAD = "usp_ForumThreadDelete";
        public const string SP_UPDATE_STATUS_FORUM_THREAD = "usp_ForumThreadUpdateStatus";
        public const string SP_UPDATE_NUMBER_VIEWS_FORUM_THREAD = "usp_ForumThreadUpdateViews";
        public const string SP_DELETE_LOGICAL_FORUM_THREAD = "usp_ForumThreadDeleteLogical";
        public const string SP_GET_FORUM_THREAD_BY_ID = "usp_ForumThreadGetById";
        public const string SP_GET_PUBLISHED_FORUM_THREAD_BY_ID = "usp_ForumThreadGetPublishedById";
        public const string SP_GET_ALL_FORUM_THREAD = "usp_ForumThreadGetAll";
        public const string SP_GET_FORUM_THREAD_BY_FORUM_ID = "usp_ForumThreadGetByForumId";
        public const string SP_GET_PUBLISHED_FORUM_THREAD_BY_FORUM_ID = "usp_ForumThreadGetPublishedByForumId";
        public const string SP_GET_PUBLISHED_FORUM_THREAD_BY_FORUM_ID_WITH_PAGING = "usp_ForumThreadGetPublishedByFIdWithPg";
        public const string SP_GET_FORUM_THREAD_BY_SEARCH = "usp_ForumThreadGetBySearch";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(ForumThread obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_FORUM_THREAD;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_DETAILS_HTML, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_DETAILS_TEXT, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsText;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_STATUS, System.Data.SqlDbType.Int);
            parameter.Value = (int)obj.Status;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_LAST_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LastPostID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_NUMBER_VIEWS, System.Data.SqlDbType.Int);
            parameter.Value = obj.NumberThreadViews;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_TOTAL_POSTS, System.Data.SqlDbType.Int);
            parameter.Value = obj.TotalPosts;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_FORUM_THREAD_ID].Value);
            return obj.ID;
        }
        #endregion

        #region[Update]
        public void Update(ForumThread obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_FORUM_THREAD;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_DETAILS_HTML, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_DETAILS_TEXT, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsText;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_STATUS, System.Data.SqlDbType.Int);
            parameter.Value = (int)obj.Status;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_LAST_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LastPostID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_NUMBER_VIEWS, System.Data.SqlDbType.Int);
            parameter.Value = obj.NumberThreadViews;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_THREAD_TOTAL_POSTS, System.Data.SqlDbType.Int);
            parameter.Value = obj.TotalPosts;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[UpdateStatus]
        public void UpdateStatus(int ID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_STATUS_FORUM_THREAD;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumThreadStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[Update Number Views]
        public void UpdateNumberViews(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_STATUS_FORUM_THREAD;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_ID, SqlDbType.Int);
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
            _command.CommandText = SP_DELETE_FORUM_THREAD;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
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
            _command.CommandText = SP_DELETE_LOGICAL_FORUM_THREAD;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_ID, SqlDbType.Int);
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
        public ForumThread GetByID(int ID, int IsDeleted)
        {
            ForumThread obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_THREAD_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_IS_DELETED, SqlDbType.Int);
            parameterID.Value = IsDeleted;
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
                                obj = new ForumThread();
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

        #region[Get By Published ID]
        public ForumThread GetByPublishedID(int ID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus)
        {
            ForumThread obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_THREAD_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumThreadStatus;
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
                                obj = new ForumThread();
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

        #region[Get By Forum ID]
        public List<ForumThread> GetByForumID(int ForumID)
        {
            ForumThread obj = null;
            List<ForumThread> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_THREAD_BY_FORUM_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumThread>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumThread(_dtreader, colobj);
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

        #region[Get By Published Forum ID]
        public List<ForumThread> GetByPublishedForumID(int ForumID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus)
        {
            ForumThread obj = null;
            List<ForumThread> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_THREAD_BY_FORUM_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumThreadStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumThread>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumThread(_dtreader, colobj);
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

        #region[Get By Published Forum ID With Paging]
        public List<ForumThread> GetByPublishedForumIDWithPaging(int ForumID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus, int PageNumber, int PageSize, ref int ResultCount)
        {
            ForumThread obj = null;
            List<ForumThread> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_THREAD_BY_FORUM_ID_WITH_PAGING;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumThreadStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_PAGE_NUMBER, SqlDbType.Int);
            parameterID.Value = PageNumber;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_PAGE_SIZE, SqlDbType.Int);
            parameterID.Value = PageSize;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    int colNumber = 0;
                    colobj = new List<ForumThread>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumThread(_dtreader, colobj);
                            GetEntityFromReader(_dtreader, obj);

                            colNumber = _dtreader.GetOrdinal("Total_Rows");
                            ResultCount = _dtreader.GetInt32(colNumber);
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
        public List<ForumThread> GetBySearch(string keyword, int ForumID, Enums.RootEnums.ForumThreadStatus ForumThreadStatus)
        {
            ForumThread obj = null;
            List<ForumThread> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_THREAD_BY_SEARCH;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_THREAD_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_NAME, SqlDbType.NVarChar);
            parameterID.Value = keyword;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_THREAD_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumThreadStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumThread>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumThread(_dtreader, colobj);
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
        public List<ForumThread> GetAll()
        {
            ForumThread obj = null;

            List<ForumThread> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_FORUM_THREAD;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumThread>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumThread(_dtreader, colobj);
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

        #region[Get ForumThread]
        public ForumThread GetForumThread(SqlDataReader _dtr, List<ForumThread> colobj)
        {
            ForumThread obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_FORUM_THREAD_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new ForumThread();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, ForumThread obj)
        {
            PopulateForumThread(_dtr, obj);
            PopulateForumUserSummary(_dtr, obj.UserSummary);
        }
        #endregion
    }
}