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
    public class ForumUserDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_FORUM_USER_ID = "FORUM_USER_ID";
        public const string CN_FORUM_USER_NAME = "FORUM_USER_NAME";
        public const string CN_FORUM_USER_USER_ID = "FORUM_USER_USER_ID";
        public const string CN_FORUM_USER_ROLE_ID = "FORUM_USER_ROLE_ID";
        public const string CN_FORUM_USER_IS_TRUSTED = "FORUM_USER_IS_TRUSTED";
        public const string CN_FORUM_USER_IS_BANNED = "FORUM_USER_IS_BANNED";
        public const string CN_FORUM_USER_BANNED_TOT_DAY = "FORUM_USER_BANNED_TOT_DAY";
        public const string CN_FORUM_USER_BANNED_TOT_SECOND = "FORUM_USER_BANNED_TOT_SECOND";
        public const string CN_FORUM_USER_BIRTH_TOT_DAY = "FORUM_USER_BIRTH_TOT_DAY";
        public const string CN_FORUM_USER_BIRTH_TOT_SECOND = "FORUM_USER_BIRTH_TOT_SECOND";
        public const string CN_FORUM_USER_JOIN_TOT_DAY = "FORUM_USER_JOIN_TOT_DAY";
        public const string CN_FORUM_USER_JOIN_TOT_SECOND = "FORUM_USER_JOIN_TOT_SECOND";
        public const string CN_FORUM_USER_IMAGE = "FORUM_USER_IMAGE";
        public const string CN_FORUM_USER_SIGNATURE = "FORUM_USER_SIGNATURE";
        public const string CN_FORUM_USER_POSTS_PER_PAGE = "FORUM_USER_POSTS_PER_PAGE";
        public const string CN_FORUM_USER_THREADS_PER_PAGE = "FORUM_USER_THREADS_PER_PAGE";
        public const string CN_FORUM_USER_FORUM_USER_TYPE = "FORUM_USER_USER_TYPE";
        public const string CN_FORUM_USER_USER_RATE_VALUE = "FORUM_USER_USER_RATE_VALUE";
        public const string CN_FORUM_USER_IS_DELETED = "FORUM_USER_IS_DELETED";
        #endregion

        #region"Parameters"
        public const string PN_FORUM_USER_ID = "@P_FORUM_USER_ID";
        public const string PN_FORUM_USER_NAME = "@P_FORUM_USER_NAME";
        public const string PN_FORUM_USER_USER_ID = "@P_FORUM_USER_USER_ID";
        public const string PN_FORUM_USER_ROLE_ID = "@P_FORUM_USER_ROLE_ID";
        public const string PN_FORUM_USER_IS_TRUSTED = "@P_FORUM_USER_IS_TRUSTED";
        public const string PN_FORUM_USER_IS_BANNED = "@P_FORUM_USER_IS_BANNED";
        public const string PN_FORUM_USER_BANNED_TOT_DAY = "@P_FORUM_USER_BANNED_TOT_DAY";
        public const string PN_FORUM_USER_BANNED_TOT_SECOND = "@P_FORUM_USER_BANNED_TOT_SECOND";
        public const string PN_FORUM_USER_BIRTH_TOT_DAY = "@P_FORUM_USER_BIRTH_TOT_DAY";
        public const string PN_FORUM_USER_BIRTH_TOT_SECOND = "@P_FORUM_USER_BIRTH_TOT_SECOND";
        public const string PN_FORUM_USER_JOIN_TOT_DAY = "@P_FORUM_USER_JOIN_TOT_DAY";
        public const string PN_FORUM_USER_JOIN_TOT_SECOND = "@P_FORUM_USER_JOIN_TOT_SECOND";
        public const string PN_FORUM_USER_IMAGE = "@P_FORUM_USER_IMAGE";
        public const string PN_FORUM_USER_SIGNATURE = "@P_FORUM_USER_SIGNATURE";
        public const string PN_FORUM_USER_POSTS_PER_PAGE = "@P_FORUM_USER_POSTS_PER_PAGE";
        public const string PN_FORUM_USER_THREADS_PER_PAGE = "@P_FORUM_USER_THREADS_PER_PAGE";
        public const string PN_FORUM_USER_FORUM_USER_TYPE = "@P_FORUM_USER_USER_TYPE";
        public const string PN_FORUM_USER_USER_RATE_VALUE = "@P_FORUM_USER_USER_RATE_VALUE";
        public const string PN_FORUM_USER_IS_DELETED = "@P_FORUM_USER_IS_DELETED";
        #endregion

        #region"Procedures"
        public const string SP_ADD_FORUM = "usp_ForumUserAdd";
        public const string SP_UPDATE_FORUM = "usp_ForumUserUpdate";
        public const string SP_UPDATE_TRUSTED_FORUM_USER = "usp_ForumUserUpdateTrusted";
        public const string SP_UPDATE_BANNED_FORUM_USER = "usp_ForumUserUpdateBanned";
        public const string SP_DELETE_FORUM = "usp_ForumUserDelete";
        public const string SP_DELETE_LOGICAL_FORUM = "usp_ForumUserDeleteLogical";
        public const string SP_GET_FORUM_USER_BY_ID = "usp_ForumUserGetById";
        public const string SP_GET_FORUM_USER_BY_USER_ID = "usp_ForumUserGetByUserId";
        public const string SP_GET_ALL_FORUM_USER = "usp_ForumUserGetAll";
        public const string SP_GET_FORUM_USER_BY_SEARCH = "usp_ForumUserGetBySearch";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(ForumUser obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_FORUM;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_USER_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BANNED_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.BannedDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BANNED_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.BannedDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BIRTH_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.BirthDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BIRTH_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.BirthDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_FORUM_USER_TYPE, System.Data.SqlDbType.Int);
            parameter.Value = (int)obj.ForumUserType;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IMAGE, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Image;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_BANNED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsBanned;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_TRUSTED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsTrusted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_JOIN_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.JoinDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_JOIN_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.JoinDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.UserName;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_POSTS_PER_PAGE, System.Data.SqlDbType.Int);
            parameter.Value = obj.PostsPerPage;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_ROLE_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.RoleID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_SIGNATURE, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Signature;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_THREADS_PER_PAGE, System.Data.SqlDbType.Int);
            parameter.Value = obj.ThreadsPerPage;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_USER_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.UserID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_USER_RATE_VALUE, System.Data.SqlDbType.Int);
            parameter.Value = obj.UserRateValue;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_FORUM_USER_ID].Value);
            return obj.ID;
        }
        #endregion

        #region[Update]
        public void Update(ForumUser obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_FORUM;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_USER_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BANNED_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.BannedDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BANNED_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.BannedDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BIRTH_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.BirthDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BIRTH_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.BirthDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_FORUM_USER_TYPE, System.Data.SqlDbType.Int);
            parameter.Value = (int)obj.ForumUserType;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IMAGE, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Image;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_BANNED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsBanned;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_TRUSTED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsTrusted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_JOIN_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.JoinDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_JOIN_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.JoinDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.UserName;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_POSTS_PER_PAGE, System.Data.SqlDbType.Int);
            parameter.Value = obj.PostsPerPage;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_ROLE_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.RoleID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_SIGNATURE, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Signature;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_THREADS_PER_PAGE, System.Data.SqlDbType.Int);
            parameter.Value = obj.ThreadsPerPage;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_USER_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.UserID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_USER_RATE_VALUE, System.Data.SqlDbType.Int);
            parameter.Value = obj.UserRateValue;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[UpdateTrusted]
        public void UpdateTrusted(int objID, bool IsTrusted)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_TRUSTED_FORUM_USER;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_USER_ID, System.Data.SqlDbType.Int);
            parameter.Value = objID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_TRUSTED, System.Data.SqlDbType.Bit);
            parameter.Value = IsTrusted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);
            #endregion

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion

        #region[UpdateBanned]
        public void UpdateBanned(int objID, bool IsBanned, DateTime BannedDate)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_BANNED_FORUM_USER;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_USER_ID, System.Data.SqlDbType.Int);
            parameter.Value = objID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_IS_BANNED, System.Data.SqlDbType.Bit);
            parameter.Value = IsBanned;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BANNED_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(BannedDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_USER_BANNED_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(BannedDate);
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
            _command.CommandText = SP_DELETE_FORUM;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_USER_ID, SqlDbType.Int);
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
            _command.CommandText = SP_DELETE_LOGICAL_FORUM;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_USER_ID, SqlDbType.Int);
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
        public ForumUser GetByID(int ID)
        {
            ForumUser obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_USER_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_USER_ID, SqlDbType.Int);
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
                                obj = new ForumUser();
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

        #region[Get By User ID]
        public ForumUser GetByUserID(int UserID)
        {
            ForumUser obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_USER_BY_USER_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_USER_USER_ID, SqlDbType.Int);
            parameterID.Value = UserID;
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
                                obj = new ForumUser();
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
        public List<ForumUser> GetAll()
        {
            ForumUser obj = null;

            List<ForumUser> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_FORUM_USER;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumUser>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumUser(_dtreader, colobj);
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
        public List<ForumUser> GetBySearch(string keyword, Enums.RootEnums.ForumUserTrusted ForumUserTrusted, Enums.RootEnums.ForumUserBanned ForumUserBanned, Enums.RootEnums.ForumUserType ForumUserType)
        {
            ForumUser obj = null;

            List<ForumUser> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_USER_BY_SEARCH;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_USER_NAME, SqlDbType.NVarChar);
            parameterID.Value = keyword;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_USER_IS_TRUSTED, SqlDbType.Int);
            parameterID.Value = (int)ForumUserTrusted;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_USER_IS_BANNED, SqlDbType.Int);
            parameterID.Value = (int)ForumUserBanned;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            parameterID = new SqlParameter(PN_FORUM_USER_FORUM_USER_TYPE, SqlDbType.Int);
            parameterID.Value = (int)ForumUserType;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumUser>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumUser(_dtreader, colobj);
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

        #region[Get ForumUser]
        public ForumUser GetForumUser(SqlDataReader _dtr, IList<ForumUser> colobj)
        {
            ForumUser obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_FORUM_USER_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new ForumUser();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, ForumUser obj)
        {
            PopulateForumUser(_dtr, obj);
        }
        #endregion
    }
}