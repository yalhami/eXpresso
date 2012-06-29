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
    public class UsersDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_EMAIL = "EMAIL";
        public const string CN_PASSWORD = "PASSWORD";
        public const string CN_ISACTIVE = "ISACTIVE";
        public const string CN_Type = "Type";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_EMAIL = "EMAIL";
        public const string PN_PASSWORD = "PASSWORD";
        public const string PN_ISACTIVE = "ISACTIVE";
        public const string PN_Type = "Type";
        #endregion
        #region"Procedures"
        public const string INSERTUsers = "usp_InsertUser";
        public const string UPDATEUsers = "usp_UpdateUser";
        public const string DELETEUsers = "usp_DeleteUser";
        public const string SELECTUsers = "usp_SelectUser";
        public const string SELECTUsersByEmail = "usp_SelectUserByEmail";
        public const string SELECTALLUsers = "usp_SelectUsersAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionStringOfSecurity();
        #region[Add]

        public int Add(Users obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTUsers;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterPassword = new SqlParameter(PN_PASSWORD, SqlDbType.NVarChar);
            parameterPassword.Value = obj.Password;
            parameterPassword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPassword);
            SqlParameter parameterIsActive = new SqlParameter(PN_ISACTIVE, SqlDbType.Bit);
            parameterIsActive.Value = obj.IsActive;
            parameterIsActive.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsActive);

            SqlParameter parameterType = new SqlParameter(PN_Type, SqlDbType.Int);
            parameterType.Value = Convert.ToInt32(obj.Type);
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Users obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEUsers;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterPassword = new SqlParameter(PN_PASSWORD, SqlDbType.NVarChar);
            parameterPassword.Value = obj.Password;
            parameterPassword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPassword);
            SqlParameter parameterIsActive = new SqlParameter(PN_ISACTIVE, SqlDbType.Bit);
            parameterIsActive.Value = obj.IsActive;
            parameterIsActive.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsActive);

            SqlParameter parameterType = new SqlParameter(PN_Type, SqlDbType.Int);
            parameterType.Value = Convert.ToInt32(obj.Type);
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
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
            _command.CommandText = DELETEUsers;

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

        #region[Get By Email]

        public Users GetByEmail(string email)
        {

            Users obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTUsersByEmail;

            #region [Parameters]
            SqlParameter parameteremail = new SqlParameter(CN_EMAIL, SqlDbType.NVarChar);
            parameteremail.Value = email;
            parameteremail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameteremail);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Users();
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
        #region[Get By Email]

        public bool ValidateUserPermission(string pagename, int userid)
        {

            bool hasAccess = false;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_ValidateUserPermission";

            #region [Parameters]
            SqlParameter paramPageName = new SqlParameter(CMSPageDataMapper.CN_NAME, SqlDbType.NVarChar);
            paramPageName.Value = pagename;
            paramPageName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramPageName);

            SqlParameter paramuserID = new SqlParameter(PN_ID, SqlDbType.Int);
            paramuserID.Value = userid;
            paramuserID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramuserID);

            SqlParameter paramHasAccess = new SqlParameter("HASACCESS", SqlDbType.Int);
            paramHasAccess.Value = userid;
            paramHasAccess.Direction = ParameterDirection.Output;
            _command.Parameters.Add(paramHasAccess);
            #endregion;

            _connection.Open();
            try
            {
                _command.ExecuteNonQuery();
                int count = Convert.ToInt32(paramHasAccess.Value);
                if (count > 0)
                    hasAccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }

            return hasAccess;
        }
        #endregion;
        #region[Get By ID]

        public Users GetByID(int ID)
        {

            Users obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTUsers;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(CN_ID, SqlDbType.Int);
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
                        obj = new Users();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Users obj)
        {
            PopulateUsers(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Users> GetAll()
        {

            Users obj = null;

            IList<Users> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLUsers;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Users();
                        colobj = new List<Users>();
                        while (_dtreader.Read())
                        {
                            obj = GetUsers(_dtreader, colobj);
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
        #region[Get Users]
        public Users GetUsers(SqlDataReader _dtr, IList<Users> colobj)
        {
            Users obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Users();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}