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
    public class CareerPostsDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_JOBID = "JOBID";
        public const string CN_DATE = "DATE";
        public const string CN_EXPERIENCES = "EXPERIENCES";
        public const string CN_CVDOCUMENT = "CVDOCUMENT";
        public const string CN_CVTEXT = "CVTEXT";
        public const string CN_IMAGE = "IMAGE";
        public const string CN_PHONE = "PHONE";
        public const string CN_TITLE = "TITLE";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_JOBID = "JOBID";
        public const string PN_DATE = "DATE";
        public const string PN_EXPERIENCES = "EXPERIENCES";
        public const string PN_CVDOCUMENT = "CVDOCUMENT";
        public const string PN_CVTEXT = "CVTEXT";
        public const string PN_IMAGE = "IMAGE";
        public const string PN_PHONE = "PHONE";
        public const string PN_TITLE = "TITLE";
        #endregion
        #region"Procedures"
        public const string INSERTCareerPosts = "usp_InsertCareerPost";
        public const string UPDATECareerPosts = "usp_UpdateCareerPost";
        public const string DELETECareerPosts = "usp_DeleteCareerPost";
        public const string SELECTCareerPosts = "usp_SelectCareerPost";
        public const string SELECTALLCareerPosts = "usp_SelectCareerPostsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(CareerPosts obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTCareerPosts;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterJobID = new SqlParameter(PN_JOBID, SqlDbType.Int);
            parameterJobID.Value = obj.JobID;
            parameterJobID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterJobID);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);
            SqlParameter parameterExperiences = new SqlParameter(PN_EXPERIENCES, SqlDbType.NVarChar);
            parameterExperiences.Value = obj.Experiences;
            parameterExperiences.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterExperiences);
            SqlParameter parameterCVDocument = new SqlParameter(PN_CVDOCUMENT, SqlDbType.NVarChar);
            parameterCVDocument.Value = obj.CVDocument;
            parameterCVDocument.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCVDocument);
            SqlParameter parameterCVText = new SqlParameter(PN_CVTEXT, SqlDbType.NVarChar);
            parameterCVText.Value = obj.CVText;
            parameterCVText.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCVText);
            SqlParameter parameterImage = new SqlParameter(PN_IMAGE, SqlDbType.NVarChar);
            parameterImage.Value = obj.Image;
            parameterImage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterImage);
            SqlParameter parameterPhone = new SqlParameter(PN_PHONE, SqlDbType.NVarChar);
            parameterPhone.Value = obj.Phone;
            parameterPhone.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhone);
            SqlParameter parameterTitle = new SqlParameter(PN_TITLE, SqlDbType.NVarChar);
            parameterTitle.Value = obj.Title;
            parameterTitle.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTitle);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(CareerPosts obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATECareerPosts;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterJobID = new SqlParameter(PN_JOBID, SqlDbType.Int);
            parameterJobID.Value = obj.JobID;
            parameterJobID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterJobID);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);
            SqlParameter parameterExperiences = new SqlParameter(PN_EXPERIENCES, SqlDbType.NVarChar);
            parameterExperiences.Value = obj.Experiences;
            parameterExperiences.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterExperiences);
            SqlParameter parameterCVDocument = new SqlParameter(PN_CVDOCUMENT, SqlDbType.NVarChar);
            parameterCVDocument.Value = obj.CVDocument;
            parameterCVDocument.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCVDocument);
            SqlParameter parameterCVText = new SqlParameter(PN_CVTEXT, SqlDbType.NVarChar);
            parameterCVText.Value = obj.CVText;
            parameterCVText.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCVText);
            SqlParameter parameterImage = new SqlParameter(PN_IMAGE, SqlDbType.NVarChar);
            parameterImage.Value = obj.Image;
            parameterImage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterImage);
            SqlParameter parameterPhone = new SqlParameter(PN_PHONE, SqlDbType.NVarChar);
            parameterPhone.Value = obj.Phone;
            parameterPhone.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPhone);
            SqlParameter parameterTitle = new SqlParameter(PN_TITLE, SqlDbType.NVarChar);
            parameterTitle.Value = obj.Title;
            parameterTitle.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTitle);
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
            _command.CommandText = DELETECareerPosts;

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

        public CareerPosts GetByID(int ID)
        {

            CareerPosts obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTCareerPosts;

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
                        obj = new CareerPosts();
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
        private void GetEntityFromReader(SqlDataReader _dtr, CareerPosts obj)
        {
            PopulateCareerPosts(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<CareerPosts> GetAll()
        {

            CareerPosts obj = null;

            IList<CareerPosts> colobj = new List<CareerPosts>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLCareerPosts;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new CareerPosts();
                        colobj = new List<CareerPosts>();
                        while (_dtreader.Read())
                        {
                            obj = GetCareerPosts(_dtreader, colobj);
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
        #region[Get CareerPosts]
        public CareerPosts GetCareerPosts(SqlDataReader _dtr, IList<CareerPosts> colobj)
        {
            CareerPosts obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new CareerPosts();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}