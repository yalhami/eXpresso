using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Config;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using System.Web;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class NewsItemDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DESCRIPTION = "DESCRIPTION";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_TYPE = "TYPE";
        public const string CN_CATEGORYID = "CATEGORY_ID";
        public const string CN_URL = "URL";
        public const string CN_IMAGE = "IMAGE";
        public const string CN_CREATIONDATE = "CREATION_DATE";
        public const string CN_CREATEDBY = "CREATED_BY";
        public const string CN_CREATIONTIME = "CREATION_TIME";
        public const string CN_PUBLISHFROM = "PUBLISH_FROM";
        public const string CN_PUBLISHTO = "PUBLISH_TO";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_ShowComments = "ShowComments";
        public const string CN_LANG_ID = "LanguageID";
        public const string CN_DATE = "Date";
        public const string CN_OrderNumber = "OrderNumber";
        public const string CN_REF_LANG_ID = "REF_LANG_ID";

        public const string CN_VIEW_COUNT = "ViewCount";
        public const string CN_IS_FEATURED = "IsFeatured";
        public const string CN_KEYWORDS = "Keywords";
        public const string CN_GUID = "GUID";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DESCRIPTION = "DESCRIPTION";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_TYPE = "TYPE";
        public const string PN_CATEGORYID = "CATEGORY_ID";
        public const string PN_URL = "URL";
        public const string PN_IMAGE = "IMAGE";
        public const string PN_CREATIONDATE = "CREATION_DATE";
        public const string PN_CREATEDBY = "CREATED_BY";
        public const string PN_CREATIONTIME = "CREATION_TIME";
        public const string PN_PUBLISHFROM = "PUBLISH_FROM";
        public const string PN_PUBLISHTO = "PUBLISH_TO";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_ShowComments = "ShowComments";
        public const string PN_LANG_ID = "LanguageID";
        public const string PN_DATE = "Date";
        public const string PN_OrderNumber = "OrderNumber";
        public const string PN_REF_LANG_ID = "REF_LANG_ID";
        public const string PN_VIEW_COUNT = "ViewCount";
        public const string PN_IS_FEATURED = "IsFeatured";
        public const string PN_KEYWORDS = "Keywords";
        public const string PN_GUID = "GUID";
        #endregion
        #region"Procedures"
        public const string INSERTNewsItem = "usp_InsertNewsItem";
        public const string UPDATENewsItem = "usp_UpdateNewsItem";
        public const string DELETENewsItem = "usp_DeleteNewsItem";
        public const string SELECTNewsItem = "usp_SelectNewsItem";
        public const string SELECTALLNewsItem = "usp_SelectNewsItemsAll";
        public const string SELECTALLNewsItemByCategoryIDasXML = "usp_SelectNewsItemsByCategoryIDasXML";
        public const string SELECTALLNewsItemByCategoryID = "usp_SelectNewsItemsByCategoryID";
        public const string SELECTALLNewsItemByIDasXML = "[usp_SelectNewsItemasXml]";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(NewsItem obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTNewsItem;

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
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = Convert.ToInt32(obj.URlType);
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterImage = new SqlParameter(PN_IMAGE, SqlDbType.NVarChar);
            parameterImage.Value = obj.Image;
            parameterImage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterImage);
            SqlParameter parameterCreationDate = new SqlParameter(PN_CREATIONDATE, SqlDbType.NVarChar);
            parameterCreationDate.Value = obj.CreationDate;
            parameterCreationDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreationDate);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.Int);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterCreationTime = new SqlParameter(PN_CREATIONTIME, SqlDbType.NVarChar);
            parameterCreationTime.Value = obj.CreationTime;
            parameterCreationTime.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreationTime);
            SqlParameter parameterPublishFrom = new SqlParameter(PN_PUBLISHFROM, SqlDbType.NVarChar);
            parameterPublishFrom.Value = obj.PublishFrom;
            parameterPublishFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishFrom);
            SqlParameter parameterPublishTo = new SqlParameter(PN_PUBLISHTO, SqlDbType.NVarChar);
            parameterPublishTo.Value = obj.PublishTo;
            parameterPublishTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishTo);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter parameterShowComments = new SqlParameter(PN_ShowComments, SqlDbType.Bit);
            parameterShowComments.Value = obj.ShowComments;
            parameterShowComments.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterShowComments);

            SqlParameter paramLangId = new SqlParameter(PN_LANG_ID, SqlDbType.Int);
            paramLangId.Value = obj.LangID;
            paramLangId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangId);

            SqlParameter pDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            pDate.Value = obj.Date;
            pDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pDate);

            SqlParameter pOrderNumber = new SqlParameter(PN_OrderNumber, SqlDbType.Int);
            pOrderNumber.Value = obj.OrderNumber;
            pOrderNumber.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pOrderNumber);

            SqlParameter pRefLangID = new SqlParameter(PN_REF_LANG_ID, SqlDbType.Int);
            pRefLangID.Value = obj.RefLangID;
            pRefLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pRefLangID);

            SqlParameter prefViewCount = new SqlParameter(PN_VIEW_COUNT, SqlDbType.Int);
            prefViewCount.Value = obj.ViewCount;
            prefViewCount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(prefViewCount);

            SqlParameter prefIsFeatured = new SqlParameter(PN_IS_FEATURED, SqlDbType.Int);
            prefIsFeatured.Value = obj.IsFeatured;
            prefIsFeatured.Direction = ParameterDirection.Input;
            _command.Parameters.Add(prefIsFeatured);

            SqlParameter pkeywords = new SqlParameter(PN_KEYWORDS, SqlDbType.NVarChar);
            pkeywords.Value = obj.Keywords;
            pkeywords.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pkeywords);

            SqlParameter pGUID = new SqlParameter(PN_GUID, SqlDbType.NVarChar);
            pGUID.Value = obj.Guid;
            pGUID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pGUID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(NewsItem obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATENewsItem;

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
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = Convert.ToInt32(obj.URlType);
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterImage = new SqlParameter(PN_IMAGE, SqlDbType.NVarChar);
            parameterImage.Value = obj.Image;
            parameterImage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterImage);
            SqlParameter parameterCreationDate = new SqlParameter(PN_CREATIONDATE, SqlDbType.NVarChar);
            parameterCreationDate.Value = obj.CreationDate;
            parameterCreationDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreationDate);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.Int);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterCreationTime = new SqlParameter(PN_CREATIONTIME, SqlDbType.NVarChar);
            parameterCreationTime.Value = obj.CreationTime;
            parameterCreationTime.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreationTime);
            SqlParameter parameterPublishFrom = new SqlParameter(PN_PUBLISHFROM, SqlDbType.NVarChar);
            parameterPublishFrom.Value = obj.PublishFrom;
            parameterPublishFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishFrom);
            SqlParameter parameterPublishTo = new SqlParameter(PN_PUBLISHTO, SqlDbType.NVarChar);
            parameterPublishTo.Value = obj.PublishTo;
            parameterPublishTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishTo);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter parameterShowComments = new SqlParameter(PN_ShowComments, SqlDbType.Bit);
            parameterShowComments.Value = obj.ShowComments;
            parameterShowComments.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterShowComments);

            SqlParameter paramLangId = new SqlParameter(PN_LANG_ID, SqlDbType.Int);
            paramLangId.Value = obj.LangID;
            paramLangId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangId);

            SqlParameter pDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            pDate.Value = obj.Date;
            pDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pDate);

            SqlParameter pOrderNumber = new SqlParameter(PN_OrderNumber, SqlDbType.Int);
            pOrderNumber.Value = obj.OrderNumber;
            pOrderNumber.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pOrderNumber);

            SqlParameter pRefLangID = new SqlParameter(PN_REF_LANG_ID, SqlDbType.Int);
            pRefLangID.Value = obj.RefLangID;
            pRefLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pRefLangID);

            SqlParameter prefViewCount = new SqlParameter(PN_VIEW_COUNT, SqlDbType.Int);
            prefViewCount.Value = obj.ViewCount;
            prefViewCount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(prefViewCount);

            SqlParameter prefIsFeatured = new SqlParameter(PN_IS_FEATURED, SqlDbType.Int);
            prefIsFeatured.Value = obj.IsFeatured;
            prefIsFeatured.Direction = ParameterDirection.Input;
            _command.Parameters.Add(prefIsFeatured);

            SqlParameter pkeywords = new SqlParameter(PN_KEYWORDS, SqlDbType.NVarChar);
            pkeywords.Value = obj.Keywords;
            pkeywords.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pkeywords);

            SqlParameter pGUID = new SqlParameter(PN_GUID, SqlDbType.NVarChar);
            pGUID.Value = obj.Guid;
            pGUID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pGUID);
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
            _command.CommandText = DELETENewsItem;

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

        public NewsItem GetByID(int ID)
        {

            NewsItem obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTNewsItem;

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
                        obj = new NewsItem();
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
        #region[Get By ID]

        public NewsItem GetByGUID(string guid)
        {

            NewsItem obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "SelectNewsbyGuid";

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
                        obj = new NewsItem();
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
        #region[Get By ID as XML]

        public XmlDocument GetByIDasXml(int ID)
        {
            XmlDocument xDoc = new XmlDocument();
            string _xml = "<Data>";
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLNewsItemByIDasXML;

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
                        _dtreader.Read();
                        _xml += _dtreader[0].ToString().Replace("dbo.", "") + "</Data>";
                        xDoc.LoadXml(_xml);
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

            return xDoc;
        }
        #endregion;
        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, NewsItem obj)
        {
            PopulateNewsItem(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<NewsItem> GetAll()
        {

            NewsItem obj = new NewsItem();

            IList<NewsItem> colobj = new List<NewsItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLNewsItem;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new NewsItem();
                        colobj = new List<NewsItem>();
                        while (_dtreader.Read())
                        {
                            obj = GetNewsItem(_dtreader, colobj);
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

        #region[Get All for Arabic Lang]

        public IList<NewsItem> GetAllForAnotherLang()
        {

            NewsItem obj = new NewsItem();

            IList<NewsItem> colobj = new List<NewsItem>();
            _connection.ConnectionString = ConfigManager.GetConnectionStringOfSecurity();
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLNewsItem;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new NewsItem();
                        colobj = new List<NewsItem>();
                        while (_dtreader.Read())
                        {
                            obj = GetNewsItem(_dtreader, colobj);
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

        #region[Get By Hash and Lang ID]

        public IList<NewsItem> GetByLanguageIDandHash(string hash, int languageID)
        {

            NewsItem obj = new NewsItem();

            IList<NewsItem> colobj = new List<NewsItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectNewsItemsByCategoryHashandLang";

            #region [Parameters]
            SqlParameter paramhash = new SqlParameter(CategoryDataMapper.PN_HASH, SqlDbType.NVarChar);
            paramhash.Value = hash;
            paramhash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramhash);

            SqlParameter paramLangID = new SqlParameter(CategoryDataMapper.PN_LANGUAGE_ID, SqlDbType.Int);
            paramLangID.Value = languageID;
            paramLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangID);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new NewsItem();
                        colobj = new List<NewsItem>();
                        while (_dtreader.Read())
                        {
                            obj = GetNewsItem(_dtreader, colobj);
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
        #region[Get By Category ID]
        public IList<NewsItem> GetByCategoryID(int CatID)
        {

            NewsItem obj = new NewsItem();

            IList<NewsItem> colobj = new List<NewsItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLNewsItemByCategoryID;


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
                        obj = new NewsItem();
                        colobj = new List<NewsItem>();
                        while (_dtreader.Read())
                        {
                            obj = GetNewsItem(_dtreader, colobj);
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
        #region[Get By Category ID and Uniques Years]
        public XmlDocument GetByCategoryIDAndUniqueYears(int CatID)
        {

            NewsItem obj = new NewsItem();
            XmlDocument xDoc = new XmlDocument();
            IList<NewsItem> colobj = new List<NewsItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectNewsItemsByCategoryIDAndUniqueYears]";


            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = CatID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            #endregion;


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
        #region[Get By Category ID as XML]

        public XmlDocument GetByCategoryIDasXML(int CatID, int count)
        {
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLNewsItemByCategoryIDasXML;


            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = CatID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            SqlParameter parametercount = new SqlParameter("Count", SqlDbType.Int);
            parametercount.Value = count;
            parametercount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametercount);
            #endregion;


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
        #region[Get By Category ID as XML]

        public XmlDocument GetByCategoryIDasXMLAsRandomWithIsFeatured(int CatID, int isFeatured)
        {
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "NewsGetByCategoryWithIsFeatured";


            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = CatID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            SqlParameter pIsFeatured = new SqlParameter(PN_IS_FEATURED, SqlDbType.Int);
            pIsFeatured.Value = isFeatured;
            pIsFeatured.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pIsFeatured);
            #endregion;


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
        #region[Get By Category ID as XML]

        public XmlDocument GetByKeywordSearchAsXML(string Keyword, int newsID)
        {
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectNewsItemasXmlByKeyword";


            #region [Parameters]
            SqlParameter paramKeyword = new SqlParameter("KEYWORD", SqlDbType.NVarChar);
            paramKeyword.Value = Keyword;
            paramKeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramKeyword);

            SqlParameter pID = new SqlParameter("ID", SqlDbType.Int);
            pID.Value = newsID;
            pID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pID);
            #endregion;


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

        #region[Get By Category ID as XML Paging]

        public XmlDocument GetByCategoryIDasXML(int CatID, int from, int to, ref int totalRows, string keyword, string date, int isFeatured, bool selectRandomly)
        {
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;

            if (selectRandomly)
                _command.CommandText = "[dbo].[SelectAllNewsByCategoryPagingAndRandom]";
            else
                _command.CommandText = "[dbo].[SelectAllNewsByCategoryPaging]";


            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterID.Value = CatID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            SqlParameter pfrom = new SqlParameter("From", SqlDbType.Int);
            pfrom.Value = from;
            pfrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pfrom);

            SqlParameter pTo = new SqlParameter("To", SqlDbType.Int);
            pTo.Value = to;
            pTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTo);

            SqlParameter pdate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            pdate.Value = date;
            pdate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pdate);

            SqlParameter pKey = new SqlParameter("Keyword", SqlDbType.NVarChar);
            pKey.Value = keyword;
            pKey.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pKey);

            SqlParameter ptotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            ptotalRows.Value = from;
            ptotalRows.Direction = ParameterDirection.Output;
            _command.Parameters.Add(ptotalRows);

            SqlParameter pShowFeatured = new SqlParameter("IsFeatured", SqlDbType.Int);
            pShowFeatured.Value = isFeatured;
            pShowFeatured.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pShowFeatured);
            #endregion;

            XmlReader _xmlReader = null;
            _connection.Open();
            string result = "<Data>";
            StringBuilder _result = new StringBuilder();
            _result.Append(result);
            try
            {
                using (_xmlReader = _command.ExecuteXmlReader())
                {
                    if (_xmlReader != null)
                    {
                        _xmlReader.Read();
                        while (_xmlReader.ReadState != ReadState.EndOfFile)
                        {
                            _result.Append(_xmlReader.ReadOuterXml());
                        }
                        _result.Append("</Data>"); xDoc.LoadXml(_result.ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                totalRows = Convert.ToInt32(ptotalRows.Value);
                _xmlReader.Close();
                _connection.Close();
            }
            return xDoc;
        }
        #endregion;

        #region[Get By Search Paging]

        public IList<NewsItem> GetAlLBySearchAndPaging(int from, int to, ref int totalRows, string keyword)
        {
            NewsItem obj = new NewsItem();

            IList<NewsItem> colobj = new List<NewsItem>();

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[dbo].[SelectAllBySearchAndPaging]";


            #region [Parameters]

            SqlParameter pfrom = new SqlParameter("From", SqlDbType.Int);
            pfrom.Value = from;
            pfrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pfrom);

            SqlParameter pTo = new SqlParameter("To", SqlDbType.Int);
            pTo.Value = to;
            pTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTo);

            SqlParameter pKey = new SqlParameter("Keyword", SqlDbType.NVarChar);
            pKey.Value = keyword;
            pKey.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pKey);

            SqlParameter ptotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            ptotalRows.Value = totalRows;
            ptotalRows.Direction = ParameterDirection.Output;
            _command.Parameters.Add(ptotalRows);
            #endregion;


            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        colobj = new List<NewsItem>();

                        while (_dtreader.Read())
                        {
                            obj = GetNewsItem(_dtreader, colobj);
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
                totalRows = Convert.ToInt32(ptotalRows.Value);
                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;

        #region[Get By Search Paging and Creation Date]

        public IList<NewsItem> GetAlLBySearchAndPagingAndCreationDate(int from, int to, ref int totalRows, string keyword, string date, int catid, string orderby)
        {
            NewsItem obj = new NewsItem();

            IList<NewsItem> colobj = new List<NewsItem>();

            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[dbo].[SelectAllBySearchAndPaginganddate]";


            #region [Parameters]

            SqlParameter pfrom = new SqlParameter("From", SqlDbType.Int);
            pfrom.Value = from;
            pfrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pfrom);

            SqlParameter pTo = new SqlParameter("To", SqlDbType.Int);
            pTo.Value = to;
            pTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTo);

            SqlParameter pKey = new SqlParameter("Keyword", SqlDbType.NVarChar);
            pKey.Value = keyword;
            pKey.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pKey);

            SqlParameter ptotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            ptotalRows.Value = totalRows;
            ptotalRows.Direction = ParameterDirection.Output;
            _command.Parameters.Add(ptotalRows);

            SqlParameter pDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            pDate.Value = date;
            pDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pDate);


            SqlParameter pCatId = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            pCatId.Value = catid;
            pCatId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pCatId);

            SqlParameter pOrderbyClause = new SqlParameter("OrderByClause", SqlDbType.NVarChar);
            pOrderbyClause.Value = orderby;
            pOrderbyClause.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pOrderbyClause);
            #endregion;


            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        colobj = new List<NewsItem>();

                        while (_dtreader.Read())
                        {
                            obj = GetNewsItem(_dtreader, colobj);
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
                totalRows = Convert.ToInt32(ptotalRows.Value);
                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;

        #region[Search as XML]

        public XmlDocument SearchandGetXML(string txtKeyWord)
        {
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "SearchNewsasXML";


            #region [Parameters]
            SqlParameter parameterID = new SqlParameter("KEYWORD", SqlDbType.NVarChar);
            parameterID.Value = txtKeyWord;
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
                            string xml = "<Data>"; xml += _dtreader[0].ToString();
                            xml = xml.Replace("dbo.", "");
                            xml += "</Data>";
                            xml = HttpUtility.HtmlDecode(xml);
                            xDoc.LoadXml(xml);
                            break;
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

            return xDoc;
        }
        #endregion;
        #region[Get NewsItem]
        public NewsItem GetNewsItem(SqlDataReader _dtr, IList<NewsItem> colobj)
        {
            NewsItem obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new NewsItem();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}