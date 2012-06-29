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
    public class BannerDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_HASH = "HASH";
        public const string CN_DETAILS = "DETAILS";
        public const string CN_CRERATIONDATE = "CREATION_DATE";
        public const string CN_CREATEDBY = "CREATED_BY";
        public const string CN_PUBLISHFROM = "PUBLISH_FROM";
        public const string CN_PUBLISHTO = "PUBLISH_TO";
        public const string CN_CATEGORYID = "CATEGORY_ID";
        public const string CN_STATUS = "STATUS";
        public const string CN_TOTALCOUNT = "TOTAL_COUNT";
        public const string CN_TOTALVIEWS = "TOTAL_PASSED";
        public const string CN_TYPE = "TYPE";
        public const string CN_URL_TYPE = "URL_TYPE";
        public const string CN_URL = "URL";
        public const string CN_USER_SIDE = "USER_SIDE";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_HASH = "HASH";
        public const string PN_DETAILS = "DETAILS";
        public const string PN_CRERATIONDATE = "CREATION_DATE";
        public const string PN_CREATEDBY = "CREATED_BY";
        public const string PN_PUBLISHFROM = "PUBLISH_FROM";
        public const string PN_PUBLISHTO = "PUBLISH_TO";
        public const string PN_CATEGORYID = "CATEGORY_ID";
        public const string PN_STATUS = "STATUS";
        public const string PN_TOTALCOUNT = "TOTAL_COUNT";
        public const string PN_TOTALVIEWS = "TOTAL_PASSED";

        public const string PN_TYPE = "TYPE";
        public const string PN_URL_TYPE = "URL_TYPE";
        public const string PN_URL = "URL";
        public const string PN_USER_SIDE = "USER_SIDE";
        #endregion
        #region"Procedures"
        public const string INSERTBanner = "usp_InsertBanner";
        public const string UPDATEBanner = "usp_UpdateBanner";
        public const string DELETEBanner = "usp_DeleteBanner";
        public const string SELECTBanner = "usp_SelectBanner";
        public const string SELECTALLBanner = "usp_SelectAllBanner";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Banner obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTBanner;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterHash.Value = obj.Hash;
            parameterHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHash);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterCrerationDate = new SqlParameter(PN_CRERATIONDATE, SqlDbType.NVarChar);
            parameterCrerationDate.Value = obj.CrerationDate;
            parameterCrerationDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCrerationDate);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.NVarChar);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterPublishFrom = new SqlParameter(PN_PUBLISHFROM, SqlDbType.NVarChar);
            parameterPublishFrom.Value = obj.PublishFrom;
            parameterPublishFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishFrom);
            SqlParameter parameterPublishTo = new SqlParameter(PN_PUBLISHTO, SqlDbType.NVarChar);
            parameterPublishTo.Value = obj.PublishTo;
            parameterPublishTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishTo);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = obj.Status;
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter pType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            pType.Value = obj.Type;
            pType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pType);
            SqlParameter pTotalCount = new SqlParameter(PN_TOTALCOUNT, SqlDbType.Int);
            pTotalCount.Value = obj.TotalCount;
            pTotalCount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTotalCount);
            SqlParameter pTotalViews = new SqlParameter(PN_TOTALVIEWS, SqlDbType.Int);
            pTotalViews.Value = obj.TotalPassed;
            pTotalViews.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTotalViews);

            SqlParameter pUrlType = new SqlParameter(PN_URL_TYPE, SqlDbType.Int);
            pUrlType.Value = obj.UrlType;
            pUrlType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pUrlType);
            SqlParameter pUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            pUrl.Value = obj.Url;
            pUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pUrl);
            SqlParameter pUserSide = new SqlParameter(PN_USER_SIDE, SqlDbType.NVarChar);
            pUserSide.Value = obj.UserSide;
            pUserSide.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pUserSide);

            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Banner obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEBanner;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterHash = new SqlParameter(PN_HASH, SqlDbType.NVarChar);
            parameterHash.Value = obj.Hash;
            parameterHash.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterHash);
            SqlParameter parameterDetails = new SqlParameter(PN_DETAILS, SqlDbType.NVarChar);
            parameterDetails.Value = obj.Details;
            parameterDetails.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDetails);
            SqlParameter parameterCrerationDate = new SqlParameter(PN_CRERATIONDATE, SqlDbType.NVarChar);
            parameterCrerationDate.Value = obj.CrerationDate;
            parameterCrerationDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCrerationDate);
            SqlParameter parameterCreatedBy = new SqlParameter(PN_CREATEDBY, SqlDbType.NVarChar);
            parameterCreatedBy.Value = obj.CreatedBy;
            parameterCreatedBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCreatedBy);
            SqlParameter parameterPublishFrom = new SqlParameter(PN_PUBLISHFROM, SqlDbType.NVarChar);
            parameterPublishFrom.Value = obj.PublishFrom;
            parameterPublishFrom.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishFrom);
            SqlParameter parameterPublishTo = new SqlParameter(PN_PUBLISHTO, SqlDbType.NVarChar);
            parameterPublishTo.Value = obj.PublishTo;
            parameterPublishTo.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterPublishTo);
            SqlParameter parameterCategoryID = new SqlParameter(PN_CATEGORYID, SqlDbType.Int);
            parameterCategoryID.Value = obj.CategoryID;
            parameterCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterCategoryID);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = obj.Status;
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter pType = new SqlParameter(PN_TYPE, SqlDbType.Int);
            pType.Value = obj.Type;
            pType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pType);
            SqlParameter pTotalCount = new SqlParameter(PN_TOTALCOUNT, SqlDbType.Int);
            pTotalCount.Value = obj.TotalCount;
            pTotalCount.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTotalCount);
            SqlParameter pTotalViews = new SqlParameter(PN_TOTALVIEWS, SqlDbType.Int);
            pTotalViews.Value = obj.TotalPassed;
            pTotalViews.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pTotalViews);
            SqlParameter pUrlType = new SqlParameter(PN_URL_TYPE, SqlDbType.Int);
            pUrlType.Value = obj.UrlType;
            pUrlType.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pUrlType);
            SqlParameter pUrl = new SqlParameter(PN_URL, SqlDbType.NVarChar);
            pUrl.Value = obj.Url;
            pUrl.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pUrl);

            SqlParameter pUserSide = new SqlParameter(PN_USER_SIDE, SqlDbType.NVarChar);
            pUserSide.Value = obj.UserSide;
            pUserSide.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pUserSide);
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
            _command.CommandText = DELETEBanner;

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

        public Banner GetByID(int ID)
        {

            Banner obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTBanner;

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
                        obj = new Banner();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Banner obj)
        {
            PopulateBanner(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Banner> GetAll()
        {

            Banner obj = new Banner();

            IList<Banner> colobj = new List<Banner>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLBanner;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Banner();
                        colobj = new List<Banner>();
                        while (_dtreader.Read())
                        {
                            obj = GetBanner(_dtreader, colobj);
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

        public IList<Banner> GetAllPublished()
        {

            Banner obj = new Banner();

            IList<Banner> colobj = new List<Banner>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "GetallPublishedBanners";

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Banner();
                        colobj = new List<Banner>();
                        while (_dtreader.Read())
                        {
                            obj = GetBanner(_dtreader, colobj);
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
        #region[Get Banner]
        public Banner GetBanner(SqlDataReader _dtr, IList<Banner> colobj)
        {
            Banner obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Banner();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}