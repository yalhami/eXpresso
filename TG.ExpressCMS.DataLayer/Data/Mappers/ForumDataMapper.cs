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
    public class ForumDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_FORUM_ID = "FORUM_ID";
        public const string CN_FORUM_NAME = "FORUM_NAME";
        public const string CN_FORUM_GROUP_ID = "FORUM_FORUM_GROUP_ID";
        public const string CN_FORUM_IS_ACTIVE = "FORUM_IS_ACTIVE";
        public const string CN_FORUM_DETAILS_TEXT = "FORUM_DETAILS_TEXT";
        public const string CN_FORUM_DETAILS_HTML = "FORUM_DETAILS_HTML";
        public const string CN_FORUM_CREATION_TOT_DAY = "FORUM_CREATION_TOT_DAY";
        public const string CN_FORUM_CREATION_TOT_SECOND = "FORUM_CREATION_TOT_SECOND";
        public const string CN_FORUM_CREATED_BY = "FORUM_CREATED_BY";
        public const string CN_FORUM_TOTAL_POSTS = "FORUM_TOTAL_POSTS";
        public const string CN_FORUM_TOTAL_THREADS = "FORUM_TOTAL_THREADS";
        public const string CN_FORUM_LAST_POST_ID = "FORUM_LAST_POST_ID";
        public const string CN_FORUM_LAST_THREAD_ID = "FORUM_LAST_THREAD_ID";
        public const string CN_FORUM_MOST_ACCESS_THREAD_ID = "FORUM_MOST_ACCESS_THREAD_ID";
        public const string CN_FORUM_NUMBER_VIEWS = "FORUM_NUMBER_VIEWS";
        public const string CN_FORUM_IS_DELETED = "FORUM_IS_DELETED";
        #endregion

        #region"Parameters"
        public const string PN_FORUM_ID = "@P_FORUM_ID";
        public const string PN_FORUM_NAME = "@P_FORUM_NAME";
        public const string PN_FORUM_GROUP_ID = "@P_FORUM_GROUP_ID";
        public const string PN_FORUM_IS_ACTIVE = "@P_FORUM_IS_ACTIVE";
        public const string PN_FORUM_DETAILS_TEXT = "@P_FORUM_DETAILS_TEXT";
        public const string PN_FORUM_DETAILS_HTML = "@P_FORUM_DETAILS_HTML";
        public const string PN_FORUM_CREATION_TOT_DAY = "@P_FORUM_CREATION_TOT_DAY";
        public const string PN_FORUM_CREATION_TOT_SECOND = "@P_FORUM_CREATION_TOT_SECOND";
        public const string PN_FORUM_CREATED_BY = "@P_FORUM_CREATED_BY";
        public const string PN_FORUM_TOTAL_POSTS = "@P_FORUM_TOTAL_POSTS";
        public const string PN_FORUM_TOTAL_THREADS = "@P_FORUM_TOTAL_THREADS";
        public const string PN_FORUM_LAST_POST_ID = "@P_FORUM_LAST_POST_ID";
        public const string PN_FORUM_LAST_THREAD_ID = "@P_FORUM_LAST_THREAD_ID";
        public const string PN_FORUM_MOST_ACCESS_THREAD_ID = "@P_FORUM_MOST_ACCESS_THREAD_ID";
        public const string PN_FORUM_NUMBER_VIEWS = "@P_FORUM_NUMBER_VIEWS";
        public const string PN_FORUM_IS_DELETED = "@P_FORUM_IS_DELETED";
        #endregion

        #region"Procedures"
        public const string SP_ADD_FORUM = "usp_ForumAdd";
        public const string SP_UPDATE_FORUM = "usp_ForumUpdate";
        public const string SP_UPDATE_ACTIVE_FORUM = "usp_ForumUpdateActive";
        public const string SP_UPDATE_NUMBER_VIEW_FORUM = "usp_ForumUpdateViews";
        public const string SP_DELETE_FORUM = "usp_ForumDelete";
        public const string SP_DELETE_LOGICAL_FORUM = "usp_ForumDeleteLogical";
        public const string SP_GET_FORUM_BY_ID = "usp_ForumGetById";
        public const string SP_GET_PUBLISHED_FORUM_BY_ID = "usp_ForumGetPublishedById";
        public const string SP_GET_FORUM_BY_GROUP_ID = "usp_ForumGetByGroupId";
        public const string SP_GET_FORUM_BY_SEARCH = "usp_ForumGetBySearch";
        public const string SP_GET_ALL_FORUM = "usp_ForumGetAll";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(Forum obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_FORUM;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_DETAILS_HTML, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_DETAILS_TEXT, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsText;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumGroupID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_IS_ACTIVE, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsActive;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_LAST_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LastForumPostID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_LAST_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LastForumThreadID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_MOST_ACCESS_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.MostAccessForumThreadID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_NUMBER_VIEWS, System.Data.SqlDbType.Int);
            parameter.Value = obj.NumberForumViews;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_TOTAL_POSTS, System.Data.SqlDbType.Int);
            parameter.Value = obj.TotalPosts;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_TOTAL_THREADS, System.Data.SqlDbType.Int);
            parameter.Value = obj.TotalThreads;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_FORUM_ID].Value);
            return obj.ID;
        }
        #endregion

        #region[Update]
        public void Update(Forum obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_FORUM;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_DETAILS_HTML, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_DETAILS_TEXT, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsText;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumGroupID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_IS_ACTIVE, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsActive;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_LAST_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LastForumPostID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_LAST_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.LastForumThreadID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_MOST_ACCESS_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.MostAccessForumThreadID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_NUMBER_VIEWS, System.Data.SqlDbType.Int);
            parameter.Value = obj.NumberForumViews;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_TOTAL_POSTS, System.Data.SqlDbType.Int);
            parameter.Value = obj.TotalPosts;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_TOTAL_THREADS, System.Data.SqlDbType.Int);
            parameter.Value = obj.TotalThreads;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[Update Active]
        public void UpdateActive(int objID, bool IsActive)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_ACTIVE_FORUM;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = objID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_IS_ACTIVE, System.Data.SqlDbType.Bit);
            parameter.Value = IsActive;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[Update Active]
        public void UpdateNumberViews(int objID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_NUMBER_VIEW_FORUM;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = objID;
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
            _command.CommandText = SP_DELETE_LOGICAL_FORUM;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_ID, SqlDbType.Int);
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
            _command.CommandText = SP_DELETE_FORUM;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_ID, SqlDbType.Int);
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
        public Forum GetByID(int ID)
        {
            Forum obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_ID, SqlDbType.Int);
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
                                obj = new Forum();
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

        #region[Get Published By ID]
        public Forum GetPublishedByID(int ID, bool IsActive)
        {
            Forum obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_IS_ACTIVE, SqlDbType.Int);
            parameterID.Value = IsActive;
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
                                obj = new Forum();
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

        #region[Get By Group ID]
        public List<Forum> GetByGroupID(int GroupID)
        {
            Forum obj = null;
            List<Forum> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_BY_GROUP_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_GROUP_ID, SqlDbType.Int);
            parameterID.Value = GroupID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Forum>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForum(_dtreader, colobj);
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
        public List<Forum> GetBySearch(string Keyword, int GroupID)
        {
            Forum obj = null;
            List<Forum> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_BY_SEARCH;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_GROUP_ID, SqlDbType.Int);
            parameterID.Value = GroupID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_NAME, SqlDbType.NVarChar);
            parameterID.Value = Keyword;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Forum>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForum(_dtreader, colobj);
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
        public List<Forum> GetAll()
        {
            Forum obj = null;

            List<Forum> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_FORUM;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<Forum>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForum(_dtreader, colobj);
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

        #region[Get Forum]
        public Forum GetForum(SqlDataReader _dtr, IList<Forum> colobj)
        {
            Forum obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_FORUM_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new Forum();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, Forum obj)
        {
            PopulateForum(_dtr, obj);
        }
        #endregion
    }
}