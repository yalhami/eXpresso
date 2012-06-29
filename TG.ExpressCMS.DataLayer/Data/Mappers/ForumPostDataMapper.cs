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
    public class ForumPostDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_FORUM_POST_ID = "FORUM_POST_ID";
        public const string CN_FORUM_POST_NAME = "FORUM_POST_NAME";
        public const string CN_FORUM_POST_THREAD_ID = "FORUM_POST_THREAD_ID";
        public const string CN_FORUM_POST_FORUM_ID = "FORUM_POST_FORUM_ID";
        public const string CN_FORUM_POST_PARENT_POST_ID = "FORUM_POST_PARENT_POST_ID";
        public const string CN_FORUM_POST_CREATION_TOT_DAY = "FORUM_POST_CREATION_TOT_DAY";
        public const string CN_FORUM_POST_CREATION_TOT_SECOND = "FORUM_POST_CREATION_TOT_SECOND";
        public const string CN_FORUM_POST_CREATED_BY = "FORUM_POST_CREATED_BY";
        public const string CN_FORUM_POST_STATUS = "FORUM_POST_STATUS";
        public const string CN_FORUM_POST_IS_DELETED = "FORUM_POST_IS_DELETED";
        public const string CN_FORUM_POST_DETAILS_TEXT = "FORUM_POST_DETAILS_TEXT";
        public const string CN_FORUM_POST_DETAILS_HTML = "FORUM_POST_DETAILS_HTML";
        #endregion

        #region"Parameters"
        public const string PN_FORUM_POST_ID = "@P_FORUM_POST_ID";
        public const string PN_FORUM_POST_NAME = "@P_FORUM_POST_NAME";
        public const string PN_FORUM_POST_THREAD_ID = "@P_FORUM_POST_THREAD_ID";
        public const string PN_FORUM_POST_FORUM_ID = "@P_FORUM_POST_FORUM_ID";
        public const string PN_FORUM_POST_PARENT_POST_ID = "@P_FORUM_POST_PARENT_POST_ID";
        public const string PN_FORUM_POST_CREATION_TOT_DAY = "@P_FORUM_POST_CREATION_TOT_DAY";
        public const string PN_FORUM_POST_CREATION_TOT_SECOND = "@P_FORUM_POST_CREATION_TOT_SECOND";
        public const string PN_FORUM_POST_CREATED_BY = "@P_FORUM_POST_CREATED_BY";
        public const string PN_FORUM_POST_STATUS = "@P_FORUM_POST_STATUS";
        public const string PN_FORUM_POST_IS_DELETED = "@P_FORUM_POST_IS_DELETED";
        public const string PN_FORUM_POST_DETAILS_TEXT = "@P_FORUM_POST_DETAILS_TEXT";
        public const string PN_FORUM_POST_DETAILS_HTML = "@P_FORUM_POST_DETAILS_HTML";
        #endregion

        #region"Procedures"
        public const string SP_ADD_FORUM_POST = "usp_ForumPostAdd";
        public const string SP_UPDATE_FORUM_POST = "usp_ForumPostUpdate";
        public const string SP_DELETE_FORUM_POST = "usp_ForumPostDelete";
        public const string SP_DELETE_LOGICAL_FORUM_POST = "usp_ForumPostDeleteLogical";
        public const string SP_GET_FORUM_POST_BY_ID = "usp_ForumPostGetById";
        public const string SP_GET_ALL_FORUM_POST = "usp_ForumPostGetAll";
        public const string SP_GET_FORUM_POST_BY_FORUM_ID = "usp_ForumPostGetByForumId";
        public const string SP_GET_PUBLISHED_FORUM_POST_BY_FORUM_ID = "usp_ForumPostGetPublishedByForumId";
        public const string SP_GET_FORUM_POST_BY_THREAD_ID = "usp_ForumPostGetByThreadId";
        public const string SP_GET_PUBLISHED_FORUM_POST_BY_THREAD_ID = "usp_ForumPostGetPublishedByThreadId";
        public const string SP_GET_PUBLISHED_FORUM_POST_BY_THREAD_ID_WITH_PAGING = "usp_ForumPostGetPublishedByThIdWithPaging";
        public const string SP_GET_FORUM_POST_BY_PARENT_POST_ID = "usp_ForumPostGetByParPostId";
        public const string SP_GET_FORUM_POST_BY_SEARCH = "usp_ForumPostGetBySearch";
        public const string SP_UPDATE_STATUS_FORUM_POST = "usp_ForumPostUpdateStatus";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(ForumPost obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_FORUM_POST;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_POST_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_DETAILS_HTML, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_DETAILS_TEXT, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsText;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_STATUS, System.Data.SqlDbType.Int);
            parameter.Value = (int)obj.Status;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_PARENT_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ParentPostID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumThreadID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_FORUM_POST_ID].Value);
            return obj.ID;
        }
        #endregion

        #region[Update]
        public void Update(ForumPost obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_FORUM_POST;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_DETAILS_HTML, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsHtml;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_DETAILS_TEXT, System.Data.SqlDbType.NText);
            parameter.Value = obj.DetailsText;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_FORUM_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_STATUS, System.Data.SqlDbType.Int);
            parameter.Value = (int)obj.Status;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_PARENT_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ParentPostID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_THREAD_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ForumThreadID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[UpdateStatus]
        public void UpdateStatus(int objID, Enums.RootEnums.ForumPostStatus ForumPostStatus)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_STATUS_FORUM_POST;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_POST_ID, System.Data.SqlDbType.Int);
            parameter.Value = objID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_POST_STATUS, System.Data.SqlDbType.Int);
            parameter.Value = (int)ForumPostStatus;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);
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
            _command.CommandText = SP_DELETE_FORUM_POST;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_ID, SqlDbType.Int);
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
            _command.CommandText = SP_DELETE_LOGICAL_FORUM_POST;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_ID, SqlDbType.Int);
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
        public ForumPost GetByID(int ID, int IsDeleted)
        {
            ForumPost obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_POST_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_IS_DELETED, SqlDbType.Int);
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
                                obj = new ForumPost();
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
        public List<ForumPost> GetByForumID(int ForumID)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_POST_BY_FORUM_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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
        public List<ForumPost> GetByPublishedForumID(int ForumID, Enums.RootEnums.ForumPostStatus ForumPostStatus)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_POST_BY_FORUM_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumPostStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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

        #region[Get By Thread ID]
        public List<ForumPost> GetByThreadID(int ThreadID)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_POST_BY_THREAD_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ThreadID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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

        #region[Get By Published Thread ID]
        public List<ForumPost> GetByPublishedThreadID(int ThreadID, Enums.RootEnums.ForumPostStatus ForumPostStatus)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_POST_BY_THREAD_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ThreadID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumPostStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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

        #region[Get By Published Thread ID With Paging]
        public List<ForumPost> GetByPublishedThreadIDWithPaging(int ThreadID, Enums.RootEnums.ForumPostStatus ForumPostStatus, int PageNumber, int PageSize, ref int ResultCount)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_PUBLISHED_FORUM_POST_BY_THREAD_ID_WITH_PAGING;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ThreadID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumPostStatus;
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
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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

        #region[Get By Parent Post ID]
        public List<ForumPost> GetByParentPostID(int ParentPostID)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_POST_BY_PARENT_POST_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_PARENT_POST_ID, SqlDbType.Int);
            parameterID.Value = ParentPostID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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
        public List<ForumPost> GetBySearch(string keyword, int ForumID, int ThreadID, int ParentPostID, int UserID, Enums.RootEnums.ForumPostStatus ForumPostStatus)
        {
            ForumPost obj = null;
            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_POST_BY_SEARCH;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_POST_NAME, SqlDbType.NVarChar);
            parameterID.Value = keyword;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_FORUM_ID, SqlDbType.Int);
            parameterID.Value = ForumID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_THREAD_ID, SqlDbType.Int);
            parameterID.Value = ThreadID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_PARENT_POST_ID, SqlDbType.Int);
            parameterID.Value = ParentPostID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_CREATED_BY, SqlDbType.Int);
            parameterID.Value = UserID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_POST_STATUS, SqlDbType.Int);
            parameterID.Value = (int)ForumPostStatus;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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
        public List<ForumPost> GetAll()
        {
            ForumPost obj = null;

            List<ForumPost> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_FORUM_POST;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumPost>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumPost(_dtreader, colobj);
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

        #region[Get ForumPost]
        public ForumPost GetForumPost(SqlDataReader _dtr, IList<ForumPost> colobj)
        {
            ForumPost obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_FORUM_POST_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new ForumPost();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, ForumPost obj)
        {
            PopulateForumPost(_dtr, obj);
            PopulateForumUserSummary(_dtr, obj.UserSummary);
        }
        #endregion
    }
}