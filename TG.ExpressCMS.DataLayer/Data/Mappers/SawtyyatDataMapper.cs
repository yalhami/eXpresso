using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Config;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Enums;
using System.Xml;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class SawtyyatDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_PATH = "PATH";
        public const string CN_TYPE = "TYPE";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_DATE = "DATE";
        public const string CN_CATEGORY_ID = "CategoryID";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_PATH = "PATH";
        public const string PN_TYPE = "TYPE";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_DATE = "DATE";
        public const string PN_CATEGORY_ID = "CategoryID";
        #endregion
        #region"Procedures"
        public const string INSERTSawtyyat = "SawtyyatAdd";
        public const string UPDATESawtyyat = "SawtyyatUpdate";
        public const string DELETESawtyyat = "SawtyyatDelete";
        public const string SELECTSawtyyat = "SawtyyatGetByID";
        public const string SELECTALLSawtyyat = "SawtyyatGetAllByType";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Sawtyyat obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTSawtyyat;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterPath = new SqlParameter(PN_PATH, SqlDbType.NVarChar);
            parameterPath.Value = obj.Path;
            parameterPath.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPath);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);

            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
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

        public void Update(Sawtyyat obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATESawtyyat;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterPath = new SqlParameter(PN_PATH, SqlDbType.NVarChar);
            parameterPath.Value = obj.Path;
            parameterPath.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPath);
            SqlParameter parameterType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterType.Value = obj.Type;
            parameterType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterType);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterDate = new SqlParameter(PN_DATE, SqlDbType.NVarChar);
            parameterDate.Value = obj.Date;
            parameterDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDate);

            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
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
            _command.CommandText = DELETESawtyyat;

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

        public Sawtyyat GetByID(int ID)
        {

            Sawtyyat obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTSawtyyat;

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
                        obj = new Sawtyyat();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Sawtyyat obj)
        {
            PopulateSawtyyat(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Sawtyyat> GetAllByType(RootEnums.AudioVideoType _rootEnums)
        {

            Sawtyyat obj = null;

            IList<Sawtyyat> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLSawtyyat;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterID.Value = Convert.ToInt32(_rootEnums);
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
                        obj = new Sawtyyat();
                        colobj = new List<Sawtyyat>();
                        while (_dtreader.Read())
                        {
                            obj = GetSawtyyat(_dtreader, colobj);
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
        #region[Get All]

        public XmlDocument GetAllByTypeAsXml(RootEnums.AudioVideoType _rootEnums, int _catid)
        {
            XmlDocument xDoc = new XmlDocument();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "dbo.SawtyyatGetByTypeasXml";



            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterID.Value = Convert.ToInt32(_rootEnums);
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);

            SqlParameter _catID = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
            _catID.Value = Convert.ToInt32(_catid);
            _catID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(_catID);
            #endregion;

            string _xml = "<Data>";

            _connection.Open();
            XmlReader _reader = null;
            try
            {
                using (_reader = _command.ExecuteXmlReader())
                {
                    _reader.Read();
                    while (_reader.ReadState != ReadState.EndOfFile)
                    {
                        _xml += _reader.ReadOuterXml();
                      
                    }
                    _xml = _xml.Replace("dbo.", "");
                    _xml += "</Data>";
                    xDoc.LoadXml(_xml);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                _reader.Close();
                _connection.Close();
            }

            return xDoc;
        }
        #endregion;
        #region[Get All By Type Paging]

        public IList<Sawtyyat> GetAllByType(RootEnums.AudioVideoType _rootEnums, int from, int to, ref int totalrows, int catid, string keyword)
        {

            Sawtyyat obj = null;

            IList<Sawtyyat> colobj = new List<Sawtyyat>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[dbo].[SawtyyatGetAllByTypePaging]";

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_TYPE, SqlDbType.Int);
            parameterID.Value = Convert.ToInt32(_rootEnums);
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


            SqlParameter pTotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            pTotalRows.Value = 0;
            pTotalRows.Direction = ParameterDirection.Output;
            _command.Parameters.Add(pTotalRows);

            SqlParameter pcatID = new SqlParameter("CategoryID", SqlDbType.Int);
            pcatID.Value = catid;
            pcatID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pcatID);

            SqlParameter pKeyword = new SqlParameter("Keyword", SqlDbType.NVarChar);
            pKeyword.Value = keyword;
            pKeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pKeyword);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Sawtyyat();
                        colobj = new List<Sawtyyat>();
                        while (_dtreader.Read())
                        {
                            obj = GetSawtyyat(_dtreader, colobj);
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
                totalrows = Convert.ToInt32(pTotalRows.Value);
                _dtreader.Close();
                _connection.Close();
            }

            return colobj;
        }
        #endregion;
        #region[Get Sawtyyat]
        public Sawtyyat GetSawtyyat(SqlDataReader _dtr, IList<Sawtyyat> colobj)
        {
            Sawtyyat obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Sawtyyat();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}