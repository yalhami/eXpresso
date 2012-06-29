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
    public class ContactDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_FIRSTNAME = "FIRSTNAME";
        public const string CN_SURNAME = "SURNAME";
        public const string CN_EMAIL = "EMAIL";
        public const string CN_MOBILE = "MOBILE";
        public const string CN_PHONE2 = "PHONE2";
        public const string CN_ZIPCODE = "ZIPCODE";
        public const string CN_GUID = "GUID";
        public const string CN_STATUS = "STATUS";
        public const string CN_ISDELETED = "ISDELETED";
        public const string CN_COUNTRY = "COUNTRY";
        public const string CN_COMPANY = "COMPANY";
        public const string CN_NOTES = "NOTES";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_FIRSTNAME = "FIRSTNAME";
        public const string PN_SURNAME = "SURNAME";
        public const string PN_EMAIL = "EMAIL";
        public const string PN_MOBILE = "MOBILE";
        public const string PN_PHONE2 = "PHONE2";
        public const string PN_ZIPCODE = "ZIPCODE";
        public const string PN_GUID = "GUID";
        public const string PN_STATUS = "STATUS";
        public const string PN_ISDELETED = "ISDELETED";
        public const string PN_COUNTRY = "COUNTRY";
        public const string PN_COMPANY = "COMPANY";
        public const string PN_NOTES = "NOTES";
        #endregion
        #region"Procedures"
        public const string INSERTContact = "usp_InsertContact";
        public const string UPDATEContact = "usp_UpdateContact";
        public const string DELETEContact = "usp_DeleteContact";
        public const string SELECTContact = "usp_SelectContact";
        public const string SELECTALLContact = "usp_SelectContactsAll";
        public const string SELECTContactbyGuid = "usp_SelectContactByGuid";
        public const string SELECTContactbyGroupID = "[dbo].[usp_SelectContactByGroupID]";

        public const string PCNAssignContacttoGroup = "ContactsGroupInsert";
        public const string DeleteContactsfromGroups = "ContactsGroupDeleteByContactID";
        public const string DeleteContactFromCertainGroup = "[ContactsGroupDeleteByContactIDAndGroupId]";
        public const string DeleteFromContactbyGroup = "[ContactsGroupDeleteByGroupId]";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetMailDb();


        public void AssignContacttoGroup(int contactID, int groupID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = PCNAssignContacttoGroup;

            #region [Parameters]
            SqlParameter ContactsID = new SqlParameter("ContactsID", SqlDbType.Int);
            ContactsID.Value = contactID;
            ContactsID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(ContactsID);
            SqlParameter GroupID = new SqlParameter("GroupID", SqlDbType.Int);
            GroupID.Value = groupID;
            GroupID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(GroupID);
            #endregion
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }


        public void DeleteContactfromGroups(int contactID)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = DeleteContactsfromGroups;

            #region [Parameters]
            SqlParameter ContactsID = new SqlParameter("ContactsID", SqlDbType.Int);
            ContactsID.Value = contactID;
            ContactsID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(ContactsID);

            #endregion
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        public void DeleteContactfromGroup(int contactID,int groupId)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = DeleteContactFromCertainGroup;

            #region [Parameters]
            SqlParameter ContactsID = new SqlParameter("ContactsID", SqlDbType.Int);
            ContactsID.Value = contactID;
            ContactsID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(ContactsID);

            SqlParameter pgroupId = new SqlParameter("GroupID", SqlDbType.Int);
            pgroupId.Value = groupId;
            pgroupId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pgroupId);

            #endregion
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        public void DeleteContactfromGroup(int groupId)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = DeleteFromContactbyGroup;

            #region [Parameters]
        

            SqlParameter pgroupId = new SqlParameter("GroupID", SqlDbType.Int);
            pgroupId.Value = groupId;
            pgroupId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pgroupId);

            #endregion
            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        public IList<int> GetContactsGroup(int contactID)
        {
            IList<int> colintegers = new List<int>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "ContactsGroupGetByContactID";

            #region [Parameters]
            SqlParameter ContactsID = new SqlParameter("ContactsID", SqlDbType.Int);
            ContactsID.Value = contactID;
            ContactsID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(ContactsID);

            #endregion
            _connection.Open();
            try
            {

                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {

                        while (_dtreader.Read())
                            colintegers.Add(Convert.ToInt32(_dtreader["GroupID"]));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return colintegers;
        }

        #region[Add]

        public int Add(Contact obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTContact;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterFirstName = new SqlParameter(PN_FIRSTNAME, SqlDbType.NVarChar);
            parameterFirstName.Value = obj.FirstName;
            parameterFirstName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterFirstName);
            SqlParameter parameterSurName = new SqlParameter(PN_SURNAME, SqlDbType.NVarChar);
            parameterSurName.Value = obj.SurName;
            parameterSurName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSurName);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterMobile = new SqlParameter(PN_MOBILE, SqlDbType.NVarChar);
            parameterMobile.Value = obj.Mobile;
            parameterMobile.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMobile);
            SqlParameter parameterPhone2 = new SqlParameter(PN_PHONE2, SqlDbType.NVarChar);
            parameterPhone2.Value = obj.Phone2;
            parameterPhone2.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhone2);
            SqlParameter parameterZipCode = new SqlParameter(PN_ZIPCODE, SqlDbType.NVarChar);
            parameterZipCode.Value = obj.ZipCode;
            parameterZipCode.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterZipCode);
            SqlParameter parameterGuid = new SqlParameter(PN_GUID, SqlDbType.NVarChar);
            parameterGuid.Value = obj.Guid;
            parameterGuid.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterGuid);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = Convert.ToInt32(obj.Status);
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterCountry = new SqlParameter(PN_COUNTRY, SqlDbType.NVarChar);
            parameterCountry.Value = obj.Country;
            parameterCountry.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCountry);
            SqlParameter parameterCompany = new SqlParameter(PN_COMPANY, SqlDbType.NVarChar);
            parameterCompany.Value = obj.Company;
            parameterCompany.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCompany);
            SqlParameter parameterNotes = new SqlParameter(PN_NOTES, SqlDbType.NVarChar);
            parameterNotes.Value = obj.Notes;
            parameterNotes.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterNotes);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Contact obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEContact;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterFirstName = new SqlParameter(PN_FIRSTNAME, SqlDbType.NVarChar);
            parameterFirstName.Value = obj.FirstName;
            parameterFirstName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterFirstName);
            SqlParameter parameterSurName = new SqlParameter(PN_SURNAME, SqlDbType.NVarChar);
            parameterSurName.Value = obj.SurName;
            parameterSurName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSurName);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterMobile = new SqlParameter(PN_MOBILE, SqlDbType.NVarChar);
            parameterMobile.Value = obj.Mobile;
            parameterMobile.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMobile);
            SqlParameter parameterPhone2 = new SqlParameter(PN_PHONE2, SqlDbType.NVarChar);
            parameterPhone2.Value = obj.Phone2;
            parameterPhone2.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhone2);
            SqlParameter parameterZipCode = new SqlParameter(PN_ZIPCODE, SqlDbType.NVarChar);
            parameterZipCode.Value = obj.ZipCode;
            parameterZipCode.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterZipCode);
            SqlParameter parameterGuid = new SqlParameter(PN_GUID, SqlDbType.NVarChar);
            parameterGuid.Value = obj.Guid;
            parameterGuid.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterGuid);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = Convert.ToInt32(obj.Status);
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterCountry = new SqlParameter(PN_COUNTRY, SqlDbType.NVarChar);
            parameterCountry.Value = obj.Country;
            parameterCountry.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCountry);
            SqlParameter parameterCompany = new SqlParameter(PN_COMPANY, SqlDbType.NVarChar);
            parameterCompany.Value = obj.Company;
            parameterCompany.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCompany);
            SqlParameter parameterNotes = new SqlParameter(PN_NOTES, SqlDbType.NVarChar);
            parameterNotes.Value = obj.Notes;
            parameterNotes.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterNotes);
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
            _command.CommandText = DELETEContact;

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

        public Contact GetByID(int ID)
        {

            Contact obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTContact;

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
                        obj = new Contact();
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
        #region[Get By GuID]

        public Contact GetByGuid(string guid)
        {

            Contact obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTContactbyGuid;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_GUID, SqlDbType.NVarChar);
            parameterID.Value = guid;
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
                        obj = new Contact();
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

        public Contact GetByEmail(string eMail)
        {

            Contact obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "dbo.[usp_SelectContactByEmail]";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterID.Value = eMail;
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
                        obj = new Contact();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Contact obj)
        {
            PopulateContact(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Contact> GetAll()
        {

            Contact obj = null;

            IList<Contact> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLContact;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Contact();
                        colobj = new List<Contact>();
                        while (_dtreader.Read())
                        {
                            obj = GetContact(_dtreader, colobj);
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
        #region[Get By Group ID]

        public IList<Contact> GetByGroupID(int groupID)
        {

            Contact obj = null;

            IList<Contact> colobj = new List<Contact>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTContactbyGroupID;


            #region [Parameters]
            SqlParameter parameterID = new SqlParameter("Group" + GroupDataMapper.PN_ID, SqlDbType.Int);
            parameterID.Value = groupID;
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
                        obj = new Contact();

                        while (_dtreader.Read())
                        {
                            obj = GetContact(_dtreader, colobj);
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
        #region[Get Contact]
        public Contact GetContact(SqlDataReader _dtr, IList<Contact> colobj)
        {
            Contact obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Contact();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}