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
    public class FatawaDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_NAME = "NAME";
        public const string CN_EMAIL = "EMAIL";
        public const string CN_MOBILE = "MOBILE";
        public const string CN_ADDRESS = "ADDRESS";
        public const string CN_QUESTION = "QUESTION";
        public const string CN_ANSWER = "ANSWER";
        public const string CN_ANSWEREDBY = "ANSWERED_BY";
        public const string CN_QUESTIONDATE = "QUESTION_DATE";
        public const string CN_ANSWERDATE = "ANSWER_DATE";
        public const string CN_STATUS = "STATUS";
        public const string CN_ISDELETED = "IS_DELETED";
        public const string CN_CATEGORY_ID = "CATEGORY_ID";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_NAME = "NAME";
        public const string PN_EMAIL = "EMAIL";
        public const string PN_MOBILE = "MOBILE";
        public const string PN_ADDRESS = "ADDRESS";
        public const string PN_QUESTION = "QUESTION";
        public const string PN_ANSWER = "ANSWER";
        public const string PN_ANSWEREDBY = "ANSWERED_BY";
        public const string PN_QUESTIONDATE = "QUESTION_DATE";
        public const string PN_ANSWERDATE = "ANSWER_DATE";
        public const string PN_STATUS = "STATUS";
        public const string PN_ISDELETED = "IS_DELETED";
        public const string PN_CATEGORY_ID = "CATEGORY_ID";
        #endregion
        #region"Procedures"
        public const string INSERTFatawa = "FatawaAdd";
        public const string UPDATEFatawa = "FatawaUpdate";
        public const string DELETEFatawa = "FatawaDelete";
        public const string SELECTFatawa = "FatawaGetFatawaByID";
        public const string FatawaGetActiveFatawa = "FatawaGetActiveFatawa";
        public const string FatawaGetAll = "FatawaGetAll";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetConnectionString();
        #region[Add]

        public int Add(Fatawa obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTFatawa;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterMobile = new SqlParameter(PN_MOBILE, SqlDbType.NVarChar);
            parameterMobile.Value = obj.Mobile;
            parameterMobile.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMobile);
            SqlParameter parameterAddress = new SqlParameter(PN_ADDRESS, SqlDbType.NVarChar);
            parameterAddress.Value = obj.Address;
            parameterAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAddress);
            SqlParameter parameterQuestion = new SqlParameter(PN_QUESTION, SqlDbType.NVarChar);
            parameterQuestion.Value = obj.Question;
            parameterQuestion.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterQuestion);
            SqlParameter parameterAnswer = new SqlParameter(PN_ANSWER, SqlDbType.NVarChar);
            parameterAnswer.Value = obj.Answer;
            parameterAnswer.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAnswer);
            SqlParameter parameterAnsweredBy = new SqlParameter(PN_ANSWEREDBY, SqlDbType.NVarChar);
            parameterAnsweredBy.Value = obj.AnsweredBy;
            parameterAnsweredBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAnsweredBy);
            SqlParameter parameterQuestionDate = new SqlParameter(PN_QUESTIONDATE, SqlDbType.NVarChar);
            parameterQuestionDate.Value = obj.QuestionDate;
            parameterQuestionDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterQuestionDate);
            SqlParameter parameterAnswerDate = new SqlParameter(PN_ANSWERDATE, SqlDbType.NVarChar);
            parameterAnswerDate.Value = obj.AnswerDate;
            parameterAnswerDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAnswerDate);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = obj.Status;
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Bit);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter paramCategoryID = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
            paramCategoryID.Value = obj.CategoryID;
            paramCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramCategoryID);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(Fatawa obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEFatawa;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterName = new SqlParameter(PN_NAME, SqlDbType.NVarChar);
            parameterName.Value = obj.Name;
            parameterName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterName);
            SqlParameter parameterEmail = new SqlParameter(PN_EMAIL, SqlDbType.NVarChar);
            parameterEmail.Value = obj.Email;
            parameterEmail.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterEmail);
            SqlParameter parameterMobile = new SqlParameter(PN_MOBILE, SqlDbType.NVarChar);
            parameterMobile.Value = obj.Mobile;
            parameterMobile.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMobile);
            SqlParameter parameterAddress = new SqlParameter(PN_ADDRESS, SqlDbType.NVarChar);
            parameterAddress.Value = obj.Address;
            parameterAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAddress);
            SqlParameter parameterQuestion = new SqlParameter(PN_QUESTION, SqlDbType.NVarChar);
            parameterQuestion.Value = obj.Question;
            parameterQuestion.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterQuestion);
            SqlParameter parameterAnswer = new SqlParameter(PN_ANSWER, SqlDbType.NVarChar);
            parameterAnswer.Value = obj.Answer;
            parameterAnswer.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAnswer);
            SqlParameter parameterAnsweredBy = new SqlParameter(PN_ANSWEREDBY, SqlDbType.NVarChar);
            parameterAnsweredBy.Value = obj.AnsweredBy;
            parameterAnsweredBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAnsweredBy);
            SqlParameter parameterQuestionDate = new SqlParameter(PN_QUESTIONDATE, SqlDbType.NVarChar);
            parameterQuestionDate.Value = obj.QuestionDate;
            parameterQuestionDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterQuestionDate);
            SqlParameter parameterAnswerDate = new SqlParameter(PN_ANSWERDATE, SqlDbType.NVarChar);
            parameterAnswerDate.Value = obj.AnswerDate;
            parameterAnswerDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterAnswerDate);
            SqlParameter parameterStatus = new SqlParameter(PN_STATUS, SqlDbType.Int);
            parameterStatus.Value = obj.Status;
            parameterStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterStatus);
            SqlParameter parameterIsDeleted = new SqlParameter(PN_ISDELETED, SqlDbType.Bit);
            parameterIsDeleted.Value = obj.IsDeleted;
            parameterIsDeleted.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterIsDeleted);

            SqlParameter paramCategoryID = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
            paramCategoryID.Value = obj.CategoryID;
            paramCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramCategoryID);
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
            _command.CommandText = DELETEFatawa;

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

        public Fatawa GetByID(int ID)
        {

            Fatawa obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTFatawa;

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
                        obj = new Fatawa();
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

        #region[Search]

        public IList<Fatawa> Search(string keyword, int catid)
        {
            Fatawa obj = null;

            IList<Fatawa> colobj = new List<Fatawa>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "[FatawaSearch]";


            #region [Parameters]
            SqlParameter paramkeyword = new SqlParameter("KEYWORD", SqlDbType.NVarChar);
            paramkeyword.Value = keyword;
            paramkeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramkeyword);

            SqlParameter paramcatid = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
            paramcatid.Value = catid;
            paramcatid.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramcatid);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Fatawa();
                        colobj = new List<Fatawa>();
                        while (_dtreader.Read())
                        {
                            obj = GetFatawa(_dtreader, colobj);
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
        #region[Get Entity from reader]
        private void GetEntityFromReader(SqlDataReader _dtr, Fatawa obj)
        {
            PopulateFatawa(_dtr, obj);
        }
        #endregion;
        #region[Get GetPendingFatwa]

        public IList<Fatawa> GetPendingFatwa()
        {

            Fatawa obj = null;

            IList<Fatawa> colobj = new List<Fatawa>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = FatawaGetActiveFatawa;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Fatawa();
                        colobj = new List<Fatawa>();
                        while (_dtreader.Read())
                        {
                            obj = GetFatawa(_dtreader, colobj);
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

        public IList<Fatawa> GetAll()
        {

            Fatawa obj = null;

            IList<Fatawa> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = FatawaGetAll;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Fatawa();
                        colobj = new List<Fatawa>();
                        while (_dtreader.Read())
                        {
                            obj = GetFatawa(_dtreader, colobj);
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
        #region[Get All By Category Paging]

        public IList<Fatawa> GetAllByCategoryByPaging(int catid, int from, int to, ref int totalrows, int status, string keyword)
        {

            Fatawa obj = null;

            IList<Fatawa> colobj = new List<Fatawa>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = "FatawaGetAllByCategoryPaging";

            SqlParameter paramCategoryID = new SqlParameter(PN_CATEGORY_ID, SqlDbType.Int);
            paramCategoryID.Value = catid;
            paramCategoryID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(paramCategoryID);

            SqlParameter pTotalRows = new SqlParameter("TotalRows", SqlDbType.Int);
            pTotalRows.Value = totalrows;
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

            SqlParameter Pstatus = new SqlParameter("STATUS", SqlDbType.Int);
            Pstatus.Value = status;
            Pstatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(Pstatus);

            SqlParameter pKeyword = new SqlParameter("@Keyword", SqlDbType.NVarChar);
            pKeyword.Value = keyword;
            pKeyword.Direction = ParameterDirection.Input;
            _command.Parameters.Add(pKeyword);

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new Fatawa();
                        colobj = new List<Fatawa>();
                        while (_dtreader.Read())
                        {
                            obj = GetFatawa(_dtreader, colobj);
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
        #region[Get Fatawa]
        public Fatawa GetFatawa(SqlDataReader _dtr, IList<Fatawa> colobj)
        {
            Fatawa obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new Fatawa();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}