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
    public class BlocksDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_USECATEGORY = "USECATEGORY";
        public const string CN_USEXSL = "USEXSL";
        public const string CN_REGISTERTAG = "REGISTERTAG";
        public const string CN_USEHTML = "USEHTML";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_USECATEGORY = "USECATEGORY";
        public const string PN_USEXSL = "USEXSL";
        public const string PN_REGISTERTAG = "REGISTERTAG";
        public const string PN_USEHTML = "USEHTML";
        #endregion
        #region"Procedures"
        public const string INSERTBlocks = "usp_InsertBlock";
        public const string UPDATEBlocks = "usp_UpdateBlock";
        public const string DELETEBlocks = "usp_DeleteBlock";
        public const string SELECTBlocks = "usp_SelectBlock";
        public const string SELECTALLBlocks = "usp_SelectBlocksAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Blocks obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTBlocks;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterUseCategory = new SqlParameter(PN_USECATEGORY, SqlDbType.Int);
            parameterUseCategory.Value = obj.UseCategory;
            parameterUseCategory.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUseCategory);
            SqlParameter parameterUseXSL = new SqlParameter(PN_USEXSL, SqlDbType.Int);
            parameterUseXSL.Value = obj.UseXSL;
            parameterUseXSL.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUseXSL);
            SqlParameter parameterRegisterTag = new SqlParameter(PN_REGISTERTAG, SqlDbType.NVarChar);
            parameterRegisterTag.Value = obj.RegisterTag;
            parameterRegisterTag.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterRegisterTag);
            SqlParameter parameterUseHtml = new SqlParameter(PN_USEHTML, SqlDbType.Int);
            parameterUseHtml.Value = obj.UseHtml;
            parameterUseHtml.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUseHtml);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Blocks obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEBlocks;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterUseCategory = new SqlParameter(PN_USECATEGORY, SqlDbType.Int);
            parameterUseCategory.Value = obj.UseCategory;
            parameterUseCategory.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUseCategory);
            SqlParameter parameterUseXSL = new SqlParameter(PN_USEXSL, SqlDbType.Int);
            parameterUseXSL.Value = obj.UseXSL;
            parameterUseXSL.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUseXSL);
            SqlParameter parameterRegisterTag = new SqlParameter(PN_REGISTERTAG, SqlDbType.NVarChar);
            parameterRegisterTag.Value = obj.RegisterTag;
            parameterRegisterTag.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterRegisterTag);
            SqlParameter parameterUseHtml = new SqlParameter(PN_USEHTML, SqlDbType.Int);
            parameterUseHtml.Value = obj.UseHtml;
            parameterUseHtml.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterUseHtml);
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
            _command.CommandText = DELETEBlocks;

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

        public Blocks GetByID(int ID)
        {

            Blocks obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTBlocks;

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
                        obj = new Blocks();
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
        private void GetEntityFromReader(SqlDataReader _dtr, Blocks obj)
        {
            PopulateBlocks(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<Blocks> GetAll()
        {

            Blocks obj = null;

            IList<Blocks> colobj = new List<Blocks>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLBlocks;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Blocks();
                        colobj = new List<Blocks>();
                        while (_dtreader.Read())
                        {
                            obj = GetBlocks(_dtreader, colobj);
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
        #region[Get Blocks]
        public Blocks GetBlocks(SqlDataReader _dtr, IList<Blocks> colobj)
        {
            Blocks obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Blocks();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}