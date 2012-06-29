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
    public class RolesDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        #endregion
        #region"Procedures"
        public const string INSERTRoles = "usp_InsertRole";
        public const string UPDATERoles = "usp_UpdateRole";
        public const string DELETERoles = "usp_DeleteRole";
        public const string SELECTRoles = "usp_SelectRole";
        public const string SELECTALLRoles = "usp_SelectRolesAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionStringOfSecurity();
        #region[Add]

        public int Add(Roles obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTRoles;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Roles obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATERoles;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
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
            _command.CommandText = DELETERoles;

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

        public Roles GetByID(int ID)
        {

            Roles obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTRoles;

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
                        obj = new Roles();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Roles obj)
        {
            PopulateRoles(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Roles> GetAll()
        {

            Roles obj = null;

            IList<Roles> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLRoles;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Roles();
                        colobj = new List<Roles>();
                        while (_dtreader.Read())
                        {
                            obj = GetRoles(_dtreader, colobj);
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
        #region[Add Roles to User]
        public void AddRolestoUser(int userID, int roleID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_InsertUserRole";

            #region [Parameters]
            SqlParameter parameterUser = new SqlParameter("UserID", SqlDbType.Int);
            parameterUser.Value = userID;
            parameterUser.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUser);

            SqlParameter parameterroleID = new SqlParameter("RoleID", SqlDbType.Int);
            parameterroleID.Value = roleID;
            parameterroleID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterroleID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;
        #region[Add Roles to Page]
        public void AddRolestoPage(int pageID, int roleID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_InsertPageRole";

            #region [Parameters]
            SqlParameter parameterUser = new SqlParameter("PageID", SqlDbType.Int);
            parameterUser.Value = pageID;
            parameterUser.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUser);

            SqlParameter parameterroleID = new SqlParameter("RoleID", SqlDbType.Int);
            parameterroleID.Value = roleID;
            parameterroleID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterroleID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;
        #region[Delete User Role]
        public void DeletePageRole(int pageID, int roleID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_DeletePageRole";

            #region [Parameters]
            SqlParameter parameterUser = new SqlParameter("PageID", SqlDbType.Int);
            parameterUser.Value = pageID;
            parameterUser.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUser);

            SqlParameter parameterroleID = new SqlParameter("RoleID", SqlDbType.Int);
            parameterroleID.Value = roleID;
            parameterroleID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterroleID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;#region[Delete User Role]
        #region[Delete User Role]
        public void DeleteUserRole(int userID, int roleID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_DeleteUserRole";

            #region [Parameters]
            SqlParameter parameterUser = new SqlParameter("UserID", SqlDbType.Int);
            parameterUser.Value = userID;
            parameterUser.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUser);

            SqlParameter parameterroleID = new SqlParameter("RoleID", SqlDbType.Int);
            parameterroleID.Value = roleID;
            parameterroleID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterroleID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        #endregion;
        
        #region[Get Roles By Page]

        public IList<Roles> GetRolesByPage(int pageId)
        {

            Roles obj = null;

            IList<Roles> colobj = new List<Roles>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectRoleforPage]";

            #region [Parameters]
            SqlParameter parameterpage = new SqlParameter("PageID", SqlDbType.Int);
            parameterpage.Value = pageId;
            parameterpage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterpage);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Roles();
                        colobj = new List<Roles>();
                        while (_dtreader.Read())
                        {
                            obj = GetRoles(_dtreader, colobj);
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
        #region[Get Users By User ID]

        public IList<Roles> GetRolesByUserID(int userID)
        {

            Roles obj = null;

            IList<Roles> colobj = new List<Roles>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectRoleforUser]";

            #region [Parameters]
            SqlParameter parameteruserID = new SqlParameter("UserID", SqlDbType.Int);
            parameteruserID.Value = userID;
            parameteruserID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameteruserID);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Roles();
                        colobj = new List<Roles>();
                        while (_dtreader.Read())
                        {
                            obj = GetRoles(_dtreader, colobj);
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
        #region[Get Roles]
        public Roles GetRoles(SqlDataReader _dtr, IList<Roles> colobj)
        {
            Roles obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Roles();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}