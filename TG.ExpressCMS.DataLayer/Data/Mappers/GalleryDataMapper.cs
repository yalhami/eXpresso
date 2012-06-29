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
    public class GalleryDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DESCRIPTION = "DESCRIPTION";
        public const string CN_TAGS = "TAGS";
        public const string CN_DATE = "DATE";
        public const string CN_URL = "URL";
        public const string CN_TYPE = "TYPE";
        public const string CN_PATH = "PATH";
        public const string CN_CREATEDBY = "CREATEDBY";
        public const string CN_ISDELETED = "ISDELETED";
        public const string CN_ISARCHIEVED = "IsArchived";
        public const string CN_CATEGORYID = "CATEGORYID";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DESCRIPTION = "DESCRIPTION";
        public const string PN_TAGS = "TAGS";
        public const string PN_DATE = "DATE";
        public const string PN_URL = "URL";
        public const string PN_TYPE = "TYPE";
        public const string PN_PATH = "PATH";
        public const string PN_CREATEDBY = "CREATEDBY";
        public const string PN_ISDELETED = "ISDELETED";
        public const string PN_ISARCHIEVED = "IsArchived";
        public const string PN_CATEGORYID = "CATEGORYID";
        #endregion
        #region"Procedures"
        public const string INSERTGallery = "usp_InsertGallery";
        public const string UPDATEGallery = "usp_UpdateGallery";
        public const string DELETEGallery = "usp_DeleteGallery";
        public const string SELECTGallery = "usp_SelectGallery";
        public const string SELECTALLGallery = "usp_SelectGalleriesAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Gallery obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTGallery;

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
            SqlParameter parameterTags = new SqlParameter(PN_TAGS, SqlDbType.NVarChar);
            parameterTags.Value = obj.Tags;
            parameterTags.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTags);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterPath = new SqlParameter(PN_PATH, SqlDbType.NVarChar);
            parameterPath.Value = obj.Path;
            parameterPath.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPath);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.Int);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterIsArchieved = new SqlParameter(PN_ISARCHIEVED, SqlDbType.Int);
            parameterIsArchieved.Value = obj.IsArchieved;
            parameterIsArchieved.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsArchieved);
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

        public void Update(Gallery obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEGallery;

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
            SqlParameter parameterTags = new SqlParameter(PN_TAGS, SqlDbType.NVarChar);
            parameterTags.Value = obj.Tags;
            parameterTags.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterTags);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterPath = new SqlParameter(PN_PATH, SqlDbType.NVarChar);
            parameterPath.Value = obj.Path;
            parameterPath.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPath);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.Int);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterIsArchieved = new SqlParameter(PN_ISARCHIEVED, SqlDbType.Int);
            parameterIsArchieved.Value = obj.IsArchieved;
            parameterIsArchieved.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsArchieved);
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
            _command.CommandText = DELETEGallery;

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

        public Gallery GetByID(int ID)
        {

            Gallery obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTGallery;

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
                        obj = new Gallery();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Gallery obj)
        {
            PopulateGallery(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Gallery> GetAll()
        {

            Gallery obj = null;

            IList<Gallery> colobj = new List<Gallery>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLGallery;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Gallery();
                        colobj = new List<Gallery>();
                        while (_dtreader.Read())
                        {
                            obj = GetGallery(_dtreader, colobj);
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
        #region[Search Paging]

        public IList<Gallery> SearchPaging(int from, int to, ref int totalRows, string keyword)
        {

            Gallery obj = null;

            IList<Gallery> colobj = new List<Gallery>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "SearchGalleryPaging";

            #region "Paramters"
            SqlParameter pTotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            pTotalRows.Value = totalRows;
            pTotalRows.Direction = ParameterDirection.Output;
            _command.Parameters.Add(pTotalRows);

            SqlParameter pFrom = new SqlParameter("From", SqlDbType.Int);
            pFrom.Value = from;
            pFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pFrom);

            SqlParameter pTo = new SqlParameter("To", SqlDbType.Int);
            pTo.Value = to;
            pTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTo);

            SqlParameter pKeyword = new SqlParameter("Keyword", SqlDbType.NVarChar);
            pKeyword.Value = keyword;
            pKeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pKeyword);
            #endregion

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Gallery();
                        colobj = new List<Gallery>();
                        while (_dtreader.Read())
                        {
                            obj = GetGallery(_dtreader, colobj);
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
        #region[Get By Category]

        public IList<Gallery> GetbyCategory(int categoryID)
        {

            Gallery obj = null;

            IList<Gallery> colobj = new List<Gallery>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectGalleriesByCategoryID";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = categoryID;
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
                        obj = new Gallery();
                        colobj = new List<Gallery>();
                        while (_dtreader.Read())
                        {
                            obj = GetGallery(_dtreader, colobj);
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
        #region[Get By Category as XML]

        public XmlDocument GetbyCategoryAsXML(int categoryID)
        {   
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectGalleriesByCategoryIDAsXml]";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = categoryID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion;
            XmlDocument xDoc = new XmlDocument();
            _connection.Open();
            XmlReader _dxtreader = null;
            try
            {
                using (_dxtreader = _command.ExecuteXmlReader())
                {
                    if (_dxtreader != null)
                    {
                        _dxtreader.Read();
                        string xml = "<Data>";
                        while (_dxtreader.ReadState != ReadState.EndOfFile)
                        {
                            xml += _dxtreader.ReadOuterXml();
                        } xml = xml.Replace("dbo.", ""); xml += "</Data>";
                        xDoc.LoadXml(xml);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                _dxtreader.Close();
                _connection.Close();
            }

            return xDoc;
        }
        #endregion;
        #region[Get By Category]

        public IList<Gallery> GetAllGalleryByCategoryPages(int categoryID, int from, int to, ref int totalRows)
        {

            Gallery obj = null;

            IList<Gallery> colobj = new List<Gallery>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectGalleriesPaged]";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = categoryID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            SqlParameter pFrom = new SqlParameter("@From", SqlDbType.Int);
            pFrom.Value = from;
            pFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pFrom);

            SqlParameter pTo = new SqlParameter("@To", SqlDbType.Int);
            pTo.Value = to;
            pTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTo);

            SqlParameter ptotal = new SqlParameter("@TotalRows", SqlDbType.Int);
            ptotal.Value = totalRows;
            ptotal.Direction = ParameterDirection.Output;
            _command.Parameters.Add(ptotal);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Gallery();
                        colobj = new List<Gallery>();
                        while (_dtreader.Read())
                        {
                            obj = GetGallery(_dtreader, colobj);
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
                totalRows = Convert.ToInt32(ptotal.Value);
                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;


        #region[Get Gallery]
        public Gallery GetGallery(SqlDataReader _dtr, IList<Gallery> colobj)
        {
            Gallery obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Gallery();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}