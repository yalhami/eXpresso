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
    public class VolunteerDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_EMAIL = "EMAIL";
        public const string CN_CV = "CV";
        public const string CN_MESSAGE = "MESSAGE";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_EMAIL = "EMAIL";
        public const string PN_CV = "CV";
        public const string PN_MESSAGE = "MESSAGE";
        #endregion
        #region"Procedures"
        public const string INSERTVolunteer = "InsertVolunteer";
        public const string UPDATEVolunteer = "UpdateVolunteer";
        public const string DELETEVolunteer = "DeleteVolunteer";
        public const string SELECTVolunteer = "SelectVolunteerByID";
        public const string SELECTALLVolunteer = "SelectallVolunteer";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Volunteer obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTVolunteer;

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
            SqlParameter parameterCV = new SqlParameter(PN_CV, SqlDbType.NVarChar);
            parameterCV.Value = obj.CV;
            parameterCV.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCV);
            SqlParameter parameterMessage = new SqlParameter(PN_MESSAGE, SqlDbType.NVarChar);
            parameterMessage.Value = obj.Message;
            parameterMessage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMessage);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Volunteer obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEVolunteer;

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
            SqlParameter parameterCV = new SqlParameter(PN_CV, SqlDbType.NVarChar);
            parameterCV.Value = obj.CV;
            parameterCV.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCV);
            SqlParameter parameterMessage = new SqlParameter(PN_MESSAGE, SqlDbType.NVarChar);
            parameterMessage.Value = obj.Message;
            parameterMessage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMessage);
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
            _command.CommandText = DELETEVolunteer;

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

        public Volunteer GetByID(int ID)
        {

            Volunteer obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTVolunteer;

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
                        obj = new Volunteer();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Volunteer obj)
        {
            PopulateVolunteer(_dtr, obj);
        }
        #endregion;

        #region[Get All]

        public IList<Volunteer> GetAll()
        {

            Volunteer obj = null;

            IList<Volunteer> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLVolunteer;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Volunteer();
                        colobj = new List<Volunteer>();
                        while (_dtreader.Read())
                        {
                            obj = GetVolunteer(_dtreader, colobj);
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

        #region[Get Countries]

        public IList<LookupDetails> GetAllCountries()
        {

            LookupDetails obj = null;

            IList<LookupDetails> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.Text;
            _command.CommandText = "select NAME,LOOKUP_ID from dbo.LOOKUP_DETAILS where LOOKUP_ID=1 Order by Name";

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new LookupDetails();
                        colobj = new List<LookupDetails>();
                        while (_dtreader.Read())
                        {
                            obj = GetLookup(_dtreader, colobj);
                            GetEntityFromReaderLookup(_dtreader, obj);
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

        #region[Get Volunteer]
        public Volunteer GetVolunteer(SqlDataReader _dtr, IList<Volunteer> colobj)
        {
            Volunteer obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Volunteer();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;

        #region[Get Lookup]
        public LookupDetails GetLookup(SqlDataReader _dtr, IList<LookupDetails> colobj)
        {
            //LookupDetails obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr["LOOKUP_ID"].ToString())).SingleOrDefault();
            LookupDetails obj = null;
            if (null == obj)
            {
                obj = new LookupDetails();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
        #region[Get Entity from reader]
        private void GetEntityFromReaderLookup(SqlDataReader _dtr, LookupDetails obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal("LOOKUP_ID");
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal("NAME");
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }

        }
        #endregion;
    }
}