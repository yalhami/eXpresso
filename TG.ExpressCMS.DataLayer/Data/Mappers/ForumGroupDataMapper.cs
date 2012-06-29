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
    public class ForumGroupDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_FORUM_GROUP_ID = "FORUM_GROUP_ID";
        public const string CN_FORUM_GROUP_NAME = "FORUM_GROUP_NAME";
        public const string CN_FORUM_GROUP_ORDER_ID = "FORUM_GROUP_ORDER_ID";
        public const string CN_FORUM_GROUP_CREATION_TOT_DAY = "FORUM_GROUP_CREATION_TOT_DAY";
        public const string CN_FORUM_GROUP_CREATION_TOT_SECOND = "FORUM_GROUP_CREATION_TOT_SECOND";
        public const string CN_FORUM_GROUP_CREATED_BY = "FORUM_GROUP_CREATED_BY";
        public const string CN_FORUM_GROUP_IS_DELETED = "FORUM_GROUP_IS_DELETED";
        #endregion

        #region"Parameters"
        public const string PN_FORUM_GROUP_ID = "@P_FORUM_GROUP_ID";
        public const string PN_FORUM_GROUP_NAME = "@P_FORUM_GROUP_NAME";
        public const string PN_FORUM_GROUP_ORDER_ID = "@P_FORUM_GROUP_ORDER_ID";
        public const string PN_FORUM_GROUP_CREATION_TOT_DAY = "@P_FORUM_GROUP_CREATION_TOT_DAY";
        public const string PN_FORUM_GROUP_CREATION_TOT_SECOND = "@P_FORUM_GROUP_CREATION_TOT_SECOND";
        public const string PN_FORUM_GROUP_CREATED_BY = "@P_FORUM_GROUP_CREATED_BY";
        public const string PN_FORUM_GROUP_IS_DELETED = "@P_FORUM_GROUP_IS_DELETED";
        #endregion

        #region"Procedures"
        public const string SP_ADD_FORUM_GROUP = "usp_ForumGroupAdd";
        public const string SP_UPDATE_FORUM_GROUP = "usp_ForumGroupUpdate";
        public const string SP_DELETE_FORUM_GROUP = "usp_ForumGroupDelete";
        public const string SP_DELETE_LOGICAL_FORUM_GROUP = "usp_ForumGroupDeleteLogical";
        public const string SP_GET_FORUM_GROUP_BY_ID = "usp_ForumGroupGetById";
        public const string SP_GET_ALL_FORUM_GROUP = "usp_ForumGroupGetAll";
        #endregion

        #region Global
        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #endregion

        #region[Add]
        public int Add(ForumGroup obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_ADD_FORUM_GROUP;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_GROUP_ID, System.Data.SqlDbType.Int);
            parameter.Direction = System.Data.ParameterDirection.Output;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_ORDER_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.OrderID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(_command.Parameters[PN_FORUM_GROUP_ID].Value);
            return obj.ID;
        }
        #endregion;

        #region[Update]
        public void Update(ForumGroup obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_UPDATE_FORUM_GROUP;

            #region [Parameters]
            SqlParameter parameter = new SqlParameter(PN_FORUM_GROUP_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.ID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_CREATED_BY, System.Data.SqlDbType.Int);
            parameter.Value = obj.CreatedBy;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_CREATION_TOT_DAY, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalDays(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_CREATION_TOT_SECOND, System.Data.SqlDbType.Int);
            parameter.Value = Helper.HelperMethods.GetTotalSeconds(obj.CreationDate);
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_IS_DELETED, System.Data.SqlDbType.Bit);
            parameter.Value = obj.IsDeleted;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_NAME, System.Data.SqlDbType.NVarChar);
            parameter.Value = obj.Name;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);

            parameter = new SqlParameter(PN_FORUM_GROUP_ORDER_ID, System.Data.SqlDbType.Int);
            parameter.Value = obj.OrderID;
            parameter.Direction = System.Data.ParameterDirection.Input;
            _command.Parameters.Add(parameter);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;

        #region[Delete]
        public void DeleteLogical(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_DELETE_LOGICAL_FORUM_GROUP;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_GROUP_ID, SqlDbType.Int);
            parameterID.Value = ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;

        #region[DeletePhysical]
        public void DeletePhysical(int ID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_DELETE_FORUM_GROUP;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_GROUP_ID, SqlDbType.Int);
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
        public ForumGroup GetByID(int ID)
        {
            ForumGroup obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_FORUM_GROUP_BY_ID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_FORUM_GROUP_ID, SqlDbType.Int);
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
                        while (_dtreader.Read())
                        {
                            if (obj == null)
                                obj = new ForumGroup();
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
        #endregion;

        #region[Get All]
        public List<ForumGroup> GetAll()
        {
            ForumGroup obj = null;

            List<ForumGroup> colobj = null;

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SP_GET_ALL_FORUM_GROUP;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    colobj = new List<ForumGroup>();
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        while (_dtreader.Read())
                        {
                            obj = GetForumGroup(_dtreader, colobj);
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

        #region[Get ForumGroup]
        public ForumGroup GetForumGroup(SqlDataReader _dtr, IList<ForumGroup> colobj)
        {
            ForumGroup obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_FORUM_GROUP_ID].ToString())).FirstOrDefault();
            if (null == obj)
            {
                obj = new ForumGroup();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;

        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, ForumGroup obj)
        {
            PopulateForumGroup(_dtr, obj);
        }
        #endregion;
    }
}