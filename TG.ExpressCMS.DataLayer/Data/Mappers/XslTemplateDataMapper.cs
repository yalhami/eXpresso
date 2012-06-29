using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer;
using TG.ExpressCMS.DataLayer.Config;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class XslTemplateDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_HASH = "HASH";
        public const string CN_CATEGORYID = "CATEGORY_ID";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_HASH = "HASH";
        public const string PN_CATEGORYID = "CATEGORY_ID";
        #endregion
        #region"Procedures"
        public const string INSERTXslTemplate = "usp_InsertXslTemplate";
        public const string UPDATEXslTemplate = "usp_UpdateXslTemplate";
        public const string DELETEXslTemplate = "usp_DeleteXslTemplate";
        public const string SELECTXslTemplate = "usp_SelectXslTemplate";
        public const string SELECTALLXslTemplate = "usp_SelectXslTemplatesAll";
        public const string SELECTALLXslTemplateByCatID ="[usp_SelectXslTemplateByCategoryID]";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(XslTemplate obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTXslTemplate;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterHash.Value = obj.Hash;
            parameterHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHash);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(XslTemplate obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEXslTemplate;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterHash.Value = obj.Hash;
            parameterHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHash);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
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
            _command.CommandText = DELETEXslTemplate;

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

        public XslTemplate GetByID(int ID)
        {

            XslTemplate obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTXslTemplate;

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
                        obj = new XslTemplate();
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
        private void GetEntityFromReader(SqlDataReader _dtr, XslTemplate obj)
        {
            PopulateXslTemplate(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<XslTemplate> GetAll()
        {

            XslTemplate obj = null;

            IList<XslTemplate> colobj = new List<XslTemplate>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLXslTemplate;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new XslTemplate();
                        colobj = new List<XslTemplate>();
                        while (_dtreader.Read())
                        {
                            obj = GetXslTemplate(_dtreader, colobj);
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
        #region[Get By Cat ID]

        public IList<XslTemplate> GetByCategoryID(int CatID)
        {

            XslTemplate obj = null;

            IList<XslTemplate> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLXslTemplateByCatID;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = CatID;
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
                        obj = new XslTemplate();
                        colobj = new List<XslTemplate>();
                        while (_dtreader.Read())
                        {
                            obj = GetXslTemplate(_dtreader, colobj);
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
        #region[Get XslTemplate]
        public XslTemplate GetXslTemplate(SqlDataReader _dtr, IList<XslTemplate> colobj)
        {
            XslTemplate obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new XslTemplate();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}