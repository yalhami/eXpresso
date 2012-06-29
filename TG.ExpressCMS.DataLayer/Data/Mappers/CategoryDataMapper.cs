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
    public class CategoryDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_DESCRIPTION = "DESCRIPTION";
        public const string CN_TYPE = "TYPE";
        public const string CN_ATTRIBUTES = "ATTRIBUTES";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_XSL_ID = "XSL_ID";
        public const string CN_image = "IMAGE";
        public const string CN_LANGUAGE_ID = "LANGUAGEID";
        public const string CN_HASH = "HASH";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_DESCRIPTION = "DESCRIPTION";
        public const string PN_TYPE = "TYPE";
        public const string PN_ATTRIBUTES = "ATTRIBUTES";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_XSL_ID = "XSL_ID";
        public const string PN_image = "IMAGE";
        public const string PN_LANGUAGE_ID = "LANGUAGEID";
        public const string PN_HASH = "HASH";
        #endregion
        #region"Procedures"
        public const string INSERTCategory = "usp_InsertCategory";
        public const string UPDATECategory = "usp_UpdateCategory";
        public const string DELETECategory = "usp_DeleteCategory";
        public const string SELECTCategory = "usp_SelectCategory";
        public const string SELECTALLCategory = "usp_SelectCategoriesAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Category obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTCategory;

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
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = Convert.ToInt32(obj.Type);
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterAttributes = new SqlParameter(PN_ATTRIBUTES, SqlDbType.NVarChar);
            parameterAttributes.Value = obj.Attributes;
            parameterAttributes.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAttributes);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Bit);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterxslID = new SqlParameter(PN_XSL_ID, SqlDbType.Int);
            parameterxslID.Value = obj.XslID;
            parameterxslID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterxslID);

            SqlParameter paramLangID = new SqlParameter(PN_LANGUAGE_ID, SqlDbType.Int);
            paramLangID.Value = obj.LanguageID;
            paramLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangID);


            SqlParameter parameterxsimage = new SqlParameter(PN_image, SqlDbType.NVarChar);
            parameterxsimage.Value = obj.Image;
            parameterxsimage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterxsimage);

            SqlParameter paramHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            paramHash.Value = obj.Hash;
            paramHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramHash);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Category obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATECategory;

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
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = Convert.ToInt32(obj.Type);
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterAttributes = new SqlParameter(PN_ATTRIBUTES, SqlDbType.NVarChar);
            parameterAttributes.Value = obj.Attributes;
            parameterAttributes.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAttributes);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Int);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);
            SqlParameter parameterxslID = new SqlParameter(PN_XSL_ID, SqlDbType.Int);
            parameterxslID.Value = obj.XslID;
            parameterxslID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterxslID);

            SqlParameter paramLangID = new SqlParameter(PN_LANGUAGE_ID, SqlDbType.Int);
            paramLangID.Value = obj.LanguageID;
            paramLangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramLangID);

            SqlParameter parameterxsimage = new SqlParameter(PN_image, SqlDbType.NVarChar);
            parameterxsimage.Value = obj.Image;
            parameterxsimage.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterxsimage);

            SqlParameter paramHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            paramHash.Value = obj.Hash;
            paramHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramHash);
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
            _command.CommandText = DELETECategory;

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

        public Category GetByID(int ID)
        {

            Category obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTCategory;

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
                        obj = new Category();
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

        public XmlDocument GetAllXml(int count, int type)
        {
            string data = "<Data>";
            XmlDocument xdoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectCategoriesAllAsXml]";

            #region [Parameters]


            SqlParameter parametercount = new SqlParameter("Count", SqlDbType.Int);
            parametercount.Value = count;
            parametercount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametercount);

            SqlParameter parametertype = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parametertype.Value = type;
            parametertype.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametertype);
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
                        xdoc.LoadXml(xml);
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

            return xdoc;
        }
        #endregion;

        #region[Get By type as XML paging]

        public XmlDocument GetAllXml(int from, int to, ref int totalRows, int type)
        {
            string data = "<Data>";
            XmlDocument xdoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[usp_SelectCategoriesAllAsXmlPaging]";

            #region [Parameters]


            SqlParameter pfrom = new SqlParameter("From", SqlDbType.Int);
            pfrom.Value = from;
            pfrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pfrom);

            SqlParameter pTo = new SqlParameter("To", SqlDbType.Int);
            pTo.Value = to;
            pTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTo);

            SqlParameter pTotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            pTotalRows.Value = totalRows;
            pTotalRows.Direction = ParameterDirection.Output;
            _command.Parameters.Add(pTotalRows);

            SqlParameter parametertype = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parametertype.Value = type;
            parametertype.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametertype);
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
                        xdoc.LoadXml(xml);
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
                _dxtreader.Close();
                _connection.Close();

            }

            return xdoc;
        }
        #endregion;


        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, Category obj)
        {
            PopulateCategory(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Category> GetAll()
        {

            Category obj = new Category();

            IList<Category> colobj = new List<Category>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLCategory;

            _connection.Open();
            try
            {

                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {

                        while (_dtreader.Read())
                        {
                            obj = GetCategory(_dtreader, colobj);
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
        #region[Get By LanguageID]

        public IList<Category> GetByLanguageID(int langID)
        {

            Category obj = new Category();

            IList<Category> colobj = new List<Category>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectCategoriesByLangID";

            #region [Parameters]
            SqlParameter paramlangID = new SqlParameter(PN_LANGUAGE_ID, SqlDbType.Int);
            paramlangID.Value = langID;
            paramlangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramlangID);
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
                            obj = GetCategory(_dtreader, colobj);
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

        #region[Get By LanguageID]

        public IList<Category> GetByHashCode(string hash)
        {

            Category obj = new Category();

            IList<Category> colobj = new List<Category>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "usp_SelectCategoryByHash";

            #region [Parameters]
            SqlParameter paramlangID = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            paramlangID.Value = hash;
            paramlangID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramlangID);
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
                            obj = GetCategory(_dtreader, colobj);
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
        #region[Get Category]
        public Category GetCategory(SqlDataReader _dtr, IList<Category> colobj)
        {
            Category obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Category();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}