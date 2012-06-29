using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Config;
using System.Xml;
using TG.ExpressCMS.DataLayer.Entities;
using System.IO;
using System.Web;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class MenuItemDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DESCRIPTION = "DESCRIPTION";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_TYPE = "TYPE";
        public const string CN_CATEGORYID = "CATEGORY_ID";
        public const string CN_URL = "URL";
        public const string CN_ORDERNUMBER = "ORDERNUMBER";
        public const string CN_MENUID = "MENUID";
        public const string CN_IMAGE = "IMAGE";
        public const string CN_CREATIONDATE = "CREATION_DATE";
        public const string CN_CREATEDBY = "CREATED_BY";
        public const string CN_CREATIONTIME = "CREATION_TIME";
        public const string CN_PUBLISHFROM = "PUBLISH_FROM";
        public const string CN_PUBLISHTO = "PUBLISH_TO";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_LANG_ID = "LanguageID";
        public const string CN_REF_LANG = "Ref_Lang_ID";
        public const string CN_IS_PUBLISHED = "IsPublished";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DESCRIPTION = "DESCRIPTION";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_TYPE = "TYPE";
        public const string PN_CATEGORYID = "CATEGORY_ID";
        public const string PN_URL = "URL";
        public const string PN_ORDERNUMBER = "ORDERNUMBER";
        public const string PN_MENUID = "MENUID";
        public const string PN_IMAGE = "IMAGE";
        public const string PN_CREATIONDATE = "CREATION_DATE";
        public const string PN_CREATEDBY = "CREATED_BY";
        public const string PN_CREATIONTIME = "CREATION_TIME";
        public const string PN_PUBLISHFROM = "PUBLISH_FROM";
        public const string PN_PUBLISHTO = "PUBLISH_TO";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_LANG_ID = "LanguageID";
        public const string PN_REF_LANG = "Ref_Lang_ID";
        public const string PN_IS_PUBLISHED = "IsPublished";
        #endregion
        #region"Procedures"
        public const string INSERTMenuItem = "usp_InsertMenuItem";
        public const string UPDATEMenuItem = "usp_UpdateMenuItem";
        public const string DELETEMenuItem = "usp_DeleteMenuItem";
        public const string SELECTMenuItem = "usp_SelectMenuItem";
        public const string SELECTMenuItemasXml = "[usp_SelectMenuItemasXml]";
        public const string SELECTALLMenuItem = "usp_SelectMenuItemsAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(MenuItem obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTMenuItem;

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
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterCategoryId = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryId.Value = obj.CategoryId;
            parameterCategoryId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryId);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterOrderNumber = new SqlParameter(PN_ORDERNUMBER, SqlDbType.Int);
            parameterOrderNumber.Value = obj.OrderNumber;
            parameterOrderNumber.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterOrderNumber);
            SqlParameter parameterMenuID = new SqlParameter(PN_MENUID, SqlDbType.Int);
            parameterMenuID.Value = obj.MenuID;
            parameterMenuID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMenuID);
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
            parameterPublishFrom.Value = "1/1/1900";
            parameterPublishFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishFrom);
            SqlParameter parameterPublishTo = new SqlParameter(PN_PUBLISHTO, SqlDbType.NVarChar);
            parameterPublishTo.Value = "1/1/1900"; ;
            parameterPublishTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishTo);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter paramLangId = new SqlParameter(PN_LANG_ID, SqlDbType.Int);
            paramLangId.Value = obj.LangID;
            paramLangId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangId);

            SqlParameter RefLangID = new SqlParameter(PN_REF_LANG, SqlDbType.Int);
            RefLangID.Value = obj.RefLangID;
            RefLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(RefLangID);


            SqlParameter pIsPublished = new SqlParameter(PN_IS_PUBLISHED, SqlDbType.Bit);
            pIsPublished.Value = obj.IsPublished;
            pIsPublished.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pIsPublished);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(MenuItem obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEMenuItem;

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
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterCategoryId = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryId.Value = obj.CategoryId;
            parameterCategoryId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryId);
            SqlParameter parameterUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            parameterUrl.Value = obj.Url;
            parameterUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUrl);
            SqlParameter parameterOrderNumber = new SqlParameter(PN_ORDERNUMBER, SqlDbType.Int);
            parameterOrderNumber.Value = obj.OrderNumber;
            parameterOrderNumber.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterOrderNumber);
            SqlParameter parameterMenuID = new SqlParameter(PN_MENUID, SqlDbType.Int);
            parameterMenuID.Value = obj.MenuID;
            parameterMenuID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMenuID);
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
            parameterPublishFrom.Value = "1/1/1900"; ;
            parameterPublishFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishFrom);
            SqlParameter parameterPublishTo = new SqlParameter(PN_PUBLISHTO, SqlDbType.NVarChar);
            parameterPublishTo.Value = "1/1/1900"; ;
            parameterPublishTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishTo);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter paramLangId = new SqlParameter(PN_LANG_ID, SqlDbType.Int);
            paramLangId.Value = obj.LangID;
            paramLangId.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangId);

            SqlParameter RefLangID = new SqlParameter(PN_REF_LANG, SqlDbType.Int);
            RefLangID.Value = obj.RefLangID;
            RefLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(RefLangID);

            SqlParameter pIsPublished = new SqlParameter(PN_IS_PUBLISHED, SqlDbType.Bit);
            pIsPublished.Value = obj.IsPublished;
            pIsPublished.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pIsPublished);
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
            _command.CommandText = DELETEMenuItem;

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

        public MenuItem GetByID(int ID)
        {

            MenuItem obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTMenuItem;

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
                        obj = new MenuItem();
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

            string _xml = string.Empty;
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTMenuItemasXml;

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

                        if (_dtreader.Read())
                        {
                            _xml = "<Data>";
                            _xml += _dtreader[0].ToString().Replace("dbo.", "");
                            _xml += "</Data>";
                            _xml = HttpUtility.HtmlDecode(_xml);
                            xDoc.Load(new StringReader(_xml));


                            XmlDeclaration xmldecl;
                            xmldecl = xDoc.CreateXmlDeclaration("1.0", null, null);
                            xmldecl.Encoding = "UTF-8";
                            xmldecl.Standalone = "yes";

                            XmlElement root = xDoc.DocumentElement;
                            xDoc.InsertBefore(xmldecl, root);

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
        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, MenuItem obj)
        {
            PopulateMenuItem(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<MenuItem> GetAll()
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLMenuItem;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {

                        while (_dtreader.Read())
                        {
                            obj = GetMenuItem(_dtreader, colobj);
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
        #region[Get All fro Arabic lang]

        public IList<MenuItem> GetAllforLang()
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = ConfigManager.GetConnectionSecondary();

            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLMenuItem;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {

                        while (_dtreader.Read())
                        {
                            obj = GetMenuItem(_dtreader, colobj);
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

        #region[Get All Published Search]

        public IList<MenuItem> GetAllPublishedSearch(string keyword, int catid, int menuID)
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "MenuGetallSearch";

            #region [Parameters]
            SqlParameter parametercatID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parametercatID.Value = catid;
            parametercatID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametercatID);

            SqlParameter pkeyword = new SqlParameter("KEYWORD", SqlDbType.NVarChar);
            pkeyword.Value = keyword;
            pkeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pkeyword);

            SqlParameter pMenuID = new SqlParameter(PN_MENUID, SqlDbType.Int);
            pMenuID.Value = menuID;
            pMenuID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pMenuID);
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
                            obj = GetMenuItem(_dtreader, colobj);
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
        public IList<MenuItem> GetAllPublishedSearchforAdmin(string keyword, int catid, int menuID)
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "MenuGetallSearchforAdmin";

            #region [Parameters]
            SqlParameter parametercatID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parametercatID.Value = catid;
            parametercatID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametercatID);

            SqlParameter pkeyword = new SqlParameter("KEYWORD", SqlDbType.NVarChar);
            pkeyword.Value = keyword;
            pkeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pkeyword);

            SqlParameter pMenuID = new SqlParameter(PN_MENUID, SqlDbType.Int);
            pMenuID.Value = menuID;
            pMenuID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pMenuID);
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
                            obj = GetMenuItem(_dtreader, colobj);
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
        #region[Get All Paging]

        public IList<MenuItem> GetAllPaging(int from, int to, ref int totalRows, string keyword)
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[DBO].[usp_SelectMenuItemsSearchPaging]";

            #region Paramters

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

            SqlParameter pKeyword = new SqlParameter("@Keyword", SqlDbType.NVarChar);
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

                        while (_dtreader.Read())
                        {
                            obj = GetMenuItem(_dtreader, colobj);
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
                totalRows = Convert.ToInt32(pTotalRows.Value);
                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;
        #region[Get By Category and LanguageID]

        public IList<MenuItem> GetAllByCategoryandLang(string hash, int langid)
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectMenuItemByLangandHash]";

            #region [Parameters]
            SqlParameter paramhash = new SqlParameter(CategoryDataMapper.PN_HASH, SqlDbType.NVarChar);
            paramhash.Value = hash;
            paramhash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramhash);

            SqlParameter paramLangID = new SqlParameter(CategoryDataMapper.PN_LANGUAGE_ID, SqlDbType.Int);
            paramLangID.Value = langid;
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

                        while (_dtreader.Read())
                        {
                            obj = GetMenuItem(_dtreader, colobj);
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

        #region Search

        public IList<MenuItem> Search(string keyword)
        {

            MenuItem obj = new MenuItem();

            IList<MenuItem> colobj = new List<MenuItem>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectMenuItemsSearch]";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter("KEYWORD", SqlDbType.NVarChar);
            parameterID.Value = keyword;
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
                            obj = GetMenuItem(_dtreader, colobj);
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
        #region[Get MenuItem]
        public MenuItem GetMenuItem(SqlDataReader _dtr, IList<MenuItem> colobj)
        {
            MenuItem obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new MenuItem();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}