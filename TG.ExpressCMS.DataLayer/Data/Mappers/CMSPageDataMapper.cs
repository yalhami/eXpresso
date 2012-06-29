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
    public class CMSPageDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DESCRIPTION = "DESCRIPTION";
        public const string CN_KEYWORD = "KEYWORDS";
        public const string CN_METTAGS = "METATAG";
        public const string CN_TEMPLATENAME = "TEMPLATENAME";
        public const string CN_TYPE = "TYPE";
        public const string CN_PAGE_CONTENT = "PageContent";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DESCRIPTION = "DESCRIPTION";
        public const string PN_KEYWORD = "KEYWORDS";
        public const string PN_METTAGS = "METATAG";
        public const string PN_TEMPLATENAME = "TEMPLATENAME";
        public const string PN_TYPE = "TYPE";
        public const string PN_PAGE_CONTENT = "PageContent";
        #endregion
        #region"Procedures"
        public const string INSERTCMSPage = "usp_InsertPage";
        public const string UPDATECMSPage = "usp_UpdatePage";
        public const string DELETECMSPage = "usp_DeletePage";
        public const string SELECTCMSPage = "usp_SelectPage";
        public const string SELECTALLCMSPage = "usp_SelectPagesAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(CMSPage obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTCMSPage;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDescription = new SqlParameter(PN_DESCRIPTION, SqlDbType.NVarChar);
            parameterDescription.Value = obj.Description;
            parameterDescription.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDescription);
            SqlParameter parameterKeyword = new SqlParameter(PN_KEYWORD, SqlDbType.NVarChar);
            parameterKeyword.Value = obj.Keyword;
            parameterKeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterKeyword);
            SqlParameter parameterMetTags = new SqlParameter(PN_METTAGS, SqlDbType.NVarChar);
            parameterMetTags.Value = obj.MetTags;
            parameterMetTags.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMetTags);

            SqlParameter parameterTemplateName = new SqlParameter(PN_TEMPLATENAME, SqlDbType.NVarChar);
            parameterTemplateName.Value = obj.TemplateName;
            parameterTemplateName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTemplateName);

            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);

            SqlParameter pageContent = new SqlParameter(PN_PAGE_CONTENT, SqlDbType.NVarChar);
            pageContent.Value = obj.PageContent;
            pageContent.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pageContent); 
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(CMSPage obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATECMSPage;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterDescription = new SqlParameter(PN_DESCRIPTION, SqlDbType.NVarChar);
            parameterDescription.Value = obj.Description;
            parameterDescription.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDescription);
            SqlParameter parameterKeyword = new SqlParameter(PN_KEYWORD, SqlDbType.NVarChar);
            parameterKeyword.Value = obj.Keyword;
            parameterKeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterKeyword);
            SqlParameter parameterMetTags = new SqlParameter(PN_METTAGS, SqlDbType.NVarChar);
            parameterMetTags.Value = obj.MetTags;
            parameterMetTags.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMetTags);


            SqlParameter parameterTemplateName = new SqlParameter(PN_TEMPLATENAME, SqlDbType.NVarChar);
            parameterTemplateName.Value = obj.TemplateName;
            parameterTemplateName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTemplateName);

            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);

            SqlParameter pageContent = new SqlParameter(PN_PAGE_CONTENT, SqlDbType.NVarChar);
            pageContent.Value = obj.PageContent;
            pageContent.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pageContent); 
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
            _command.CommandText = DELETECMSPage;

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

        public CMSPage GetByID(int ID)
        {

            CMSPage obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTCMSPage;

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
                        obj = new CMSPage();
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
        private void GetEntityFromReader(SqlDataReader _dtr, CMSPage obj)
        {
            PopulateCMSPage(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<CMSPage> GetAll()
        {

            CMSPage obj = null;

            IList<CMSPage> colobj = new List<CMSPage>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLCMSPage;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new CMSPage();
                        colobj = new List<CMSPage>();
                        while (_dtreader.Read())
                        {
                            obj = GetCMSPage(_dtreader, colobj);
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
        #region[Get CMSPage]
        public CMSPage GetCMSPage(SqlDataReader _dtr, IList<CMSPage> colobj)
        {
            CMSPage obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new CMSPage();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}