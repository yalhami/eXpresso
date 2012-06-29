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
    public class CommentDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_SUBJECT = "SUBJECT";
        public const string CN_COMPANY = "COMPANY";
        public const string CN_EMAIL = "EMAIL";
        public const string CN_COUNTRY = "COUNTRY";
        public const string CN_OBJECTID = "OBJECT_ID";
        public const string CN_OBJECTTYPE = "OBJECT_TYPE";
        public const string CN_TYPE = "TYPE";
        public const string CN_STATUS = "STATUS";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_INTIALVALUE = "INTIAL_DETAILS";
        public const string CN_MODIFIEDVALUE = "MODIFIED_DETAILS";
        public const string CN_IPADDRESS = "IP_ADDRESS";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_SUBJECT = "SUBJECT";
        public const string PN_COMPANY = "COMPANY";
        public const string PN_EMAIL = "EMAIL";
        public const string PN_COUNTRY = "COUNTRY";
        public const string PN_OBJECTID = "OBJECT_ID";
        public const string PN_OBJECTTYPE = "OBJECT_TYPE";
        public const string PN_TYPE = "TYPE";
        public const string PN_STATUS = "STATUS";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_INTIALVALUE = "INTIAL_DETAILS";
        public const string PN_MODIFIEDVALUE = "MODIFIED_DETAILS";
        public const string PN_IPADDRESS = "IP_ADDRESS";
        #endregion
        #region"Procedures"
        public const string INSERTComment = "usp_InsertComment";
        public const string UPDATEComment = "usp_UpdateComment";
        public const string DELETEComment = "usp_DeleteComment";
        public const string SELECTComment = "usp_SelectComment";
        public const string SELECTALLComment = "usp_SelectCommentsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Comment obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTComment;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterSubject = new SqlParameter(PN_SUBJECT, SqlDbType.NVarChar);
            parameterSubject.Value = obj.Subject;
            parameterSubject.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSubject);
            SqlParameter parameterCompany = new SqlParameter(PN_COMPANY, SqlDbType.NVarChar);
            parameterCompany.Value = obj.Company;
            parameterCompany.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCompany);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterCountry = new SqlParameter(PN_COUNTRY, SqlDbType.NVarChar);
            parameterCountry.Value = obj.Country;
            parameterCountry.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCountry);
            SqlParameter parameterObjectID = new SqlParameter(PN_OBJECTID, SqlDbType.Int);
            parameterObjectID.Value = obj.ObjectID;
            parameterObjectID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterObjectID);
            SqlParameter parameterObjectType = new SqlParameter(PN_OBJECTTYPE, SqlDbType.Int);
            parameterObjectType.Value = obj.ObjectType;
            parameterObjectType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterObjectType);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = obj.Status;
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterIntialValue = new SqlParameter(PN_INTIALVALUE, SqlDbType.NVarChar);
            parameterIntialValue.Value = obj.IntialValue;
            parameterIntialValue.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIntialValue);
            SqlParameter parameterModifiedValue = new SqlParameter(PN_MODIFIEDVALUE, SqlDbType.NVarChar);
            parameterModifiedValue.Value = obj.ModifiedValue;
            parameterModifiedValue.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterModifiedValue);
            SqlParameter parameterIPAddress = new SqlParameter(PN_IPADDRESS, SqlDbType.NVarChar);
            parameterIPAddress.Value = obj.IPAddress;
            parameterIPAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIPAddress);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Comment obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEComment;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterSubject = new SqlParameter(PN_SUBJECT, SqlDbType.NVarChar);
            parameterSubject.Value = obj.Subject;
            parameterSubject.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSubject);
            SqlParameter parameterCompany = new SqlParameter(PN_COMPANY, SqlDbType.NVarChar);
            parameterCompany.Value = obj.Company;
            parameterCompany.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCompany);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterCountry = new SqlParameter(PN_COUNTRY, SqlDbType.NVarChar);
            parameterCountry.Value = obj.Country;
            parameterCountry.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCountry);
            SqlParameter parameterObjectID = new SqlParameter(PN_OBJECTID, SqlDbType.Int);
            parameterObjectID.Value = obj.ObjectID;
            parameterObjectID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterObjectID);
            SqlParameter parameterObjectType = new SqlParameter(PN_OBJECTTYPE, SqlDbType.Int);
            parameterObjectType.Value = obj.ObjectType;
            parameterObjectType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterObjectType);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = obj.Status;
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterIntialValue = new SqlParameter(PN_INTIALVALUE, SqlDbType.NVarChar);
            parameterIntialValue.Value = obj.IntialValue;
            parameterIntialValue.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIntialValue);
            SqlParameter parameterModifiedValue = new SqlParameter(PN_MODIFIEDVALUE, SqlDbType.NVarChar);
            parameterModifiedValue.Value = obj.ModifiedValue;
            parameterModifiedValue.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterModifiedValue);
            SqlParameter parameterIPAddress = new SqlParameter(PN_IPADDRESS, SqlDbType.NVarChar);
            parameterIPAddress.Value = obj.IPAddress;
            parameterIPAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIPAddress);
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
            _command.CommandText = DELETEComment;

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

        public Comment GetByID(int ID)
        {

            Comment obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTComment;

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
                        obj = new Comment();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Comment obj)
        {
            PopulateComment(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Comment> GetAll()
        {

            Comment obj = null;

            IList<Comment> colobj = new List<Comment>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLComment;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Comment();
                        colobj = new List<Comment>();
                        while (_dtreader.Read())
                        {
                            obj = GetComment(_dtreader, colobj);
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
        #region[Search Comment]

        public IList<Comment> SearchNewsComment(int objectid, int categoryid)
        {

            Comment obj = null;

            IList<Comment> colobj = new List<Comment>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectCommentsByNewsCategoryandObjectID]";

            #region [Parameters]
            SqlParameter parameterobjID = new SqlParameter(PN_OBJECTID, SqlDbType.Int);
            parameterobjID.Value = objectid;
            parameterobjID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterobjID);

            SqlParameter parametercategoryid = new SqlParameter(NewsItemDataMapper.PN_CATEGORYID, SqlDbType.Int);
            parametercategoryid.Value = categoryid;
            parametercategoryid.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametercategoryid);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Comment();
                        colobj = new List<Comment>();
                        while (_dtreader.Read())
                        {
                            obj = GetComment(_dtreader, colobj);
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
        #region[Get Pending Comments]

        public IList<Comment> GetPendingComments()
        {

            Comment obj = null;

            IList<Comment> colobj = new List<Comment>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectCommentsAllPending]";

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Comment();
                        colobj = new List<Comment>();
                        while (_dtreader.Read())
                        {
                            obj = GetComment(_dtreader, colobj);
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
        #region[Get Comments by Object ID and Type]

        public IList<Comment> GetCommentsByTypeandID(int ObjectID, int ObjectType)
        {

            Comment obj = null;

            IList<Comment> colobj = new List<Comment>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectCommentsByTypeandID]";

            #region [Parameters]
            SqlParameter parameterobjID = new SqlParameter(PN_OBJECTID, SqlDbType.Int);
            parameterobjID.Value = ObjectID;
            parameterobjID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterobjID);

            SqlParameter parameterobjtype = new SqlParameter(PN_OBJECTTYPE, SqlDbType.Int);
            parameterobjtype.Value = ObjectType;
            parameterobjtype.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterobjtype);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Comment();
                        colobj = new List<Comment>();
                        while (_dtreader.Read())
                        {
                            obj = GetComment(_dtreader, colobj);
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
        #region[Get Comment]
        public Comment GetComment(SqlDataReader _dtr, IList<Comment> colobj)
        {
            Comment obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Comment();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}