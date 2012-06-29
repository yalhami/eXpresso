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
    public class EmailQueueDataMapper : DataMapperBase
    {
        #region"Columns"
        public const string CN_ID = "ID";
        public const string CN_RECIVERADDRESS = "RECIVERADDRESS";
        public const string CN_RECIEVERNAME = "RECIEVERNAME";
        public const string CN_SENDERADDRESS = "SENDERADDRESS";
        public const string CN_SENDERNAME = "SENDERNAME";
        public const string CN_CONTACTID = "CONTACTID";
        public const string CN_SCHEDULEDATE = "SCHEDULEDATE";
        public const string CN_SCHEDULETIME = "SCHEDULETIME";
        public const string CN_SENDINGSTATUS = "SENDINGSTATUS";
        public const string CN_SENTDATE = "SENTDATE";
        public const string CN_DELIVERYSTATUS = "DELIVERYSTATUS";
        public const string CN_MAILID = "MAILID";
        public const string CN_SENT_BY = "SentBy";
        #endregion
        #region"Parameters"
        public const string PN_ID = "ID";
        public const string PN_RECIVERADDRESS = "RECIVERADDRESS";
        public const string PN_RECIEVERNAME = "RECIEVERNAME";
        public const string PN_SENDERADDRESS = "SENDERADDRESS";
        public const string PN_SENDERNAME = "SENDERNAME";
        public const string PN_CONTACTID = "CONTACTID";
        public const string PN_SCHEDULEDATE = "SCHEDULEDATE";
        public const string PN_SCHEDULETIME = "SCHEDULETIME";
        public const string PN_SENDINGSTATUS = "SENDINGSTATUS";
        public const string PN_SENTDATE = "SENTDATE";
        public const string PN_DELIVERYSTATUS = "DELIVERYSTATUS";
        public const string PN_MAILID = "MAILID";
        public const string PN_SENT_BY = "SentBy";
        #endregion
        #region"Procedures"
        public const string INSERTEmailQueue = "usp_InsertEmailQueue";
        public const string UPDATEEmailQueue = "usp_UpdateEmailQueue";
        public const string DELETEEmailQueue = "usp_DeleteEmailQueue";
        public const string SELECTEmailQueue = "usp_SelectEmailQueue";
        public const string SELECTALLEmailQueue = "usp_SelectEmailQueuesAll";
        public const string SELECTALLEmailQueueSearch = "usp_SelectEmailQueueSearch";
        public const string SELECTALLEmailQueueGetcount = "usp_SelectEmailQueueGetPendingCount";
        public const string SELECTALLEmailQueuePending = "[usp_SelectEmailQueueSelectAllPending]";
        #endregion

        SqlConnection _connection = new SqlConnection();
        SqlCommand _command = new SqlCommand();
        SqlDataReader _dtreader = null;
        string _ConnectionString = ConfigManager.GetMailDb();
        #region[Add]

        public int Add(EmailQueue obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = INSERTEmailQueue;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterReciverAddress = new SqlParameter(PN_RECIVERADDRESS, SqlDbType.NVarChar);
            parameterReciverAddress.Value = obj.ReciverAddress;
            parameterReciverAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterReciverAddress);
            SqlParameter parameterRecieverName = new SqlParameter(PN_RECIEVERNAME, SqlDbType.NVarChar);
            parameterRecieverName.Value = obj.RecieverName;
            parameterRecieverName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterRecieverName);
            SqlParameter parameterSenderAddress = new SqlParameter(PN_SENDERADDRESS, SqlDbType.NVarChar);
            parameterSenderAddress.Value = obj.SenderAddress;
            parameterSenderAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSenderAddress);
            SqlParameter parameterSenderName = new SqlParameter(PN_SENDERNAME, SqlDbType.NVarChar);
            parameterSenderName.Value = obj.SenderName;
            parameterSenderName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSenderName);
            SqlParameter parameterContactID = new SqlParameter(PN_CONTACTID, SqlDbType.Int);
            parameterContactID.Value = obj.ContactID;
            parameterContactID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterContactID);
            SqlParameter parameterScheduleDate = new SqlParameter(PN_SCHEDULEDATE, SqlDbType.NVarChar);
            parameterScheduleDate.Value = obj.ScheduleDate;
            parameterScheduleDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterScheduleDate);
            SqlParameter parameterScheduleTime = new SqlParameter(PN_SCHEDULETIME, SqlDbType.NVarChar);
            parameterScheduleTime.Value = obj.ScheduleTime;
            parameterScheduleTime.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterScheduleTime);
            SqlParameter parameterSendingStatus = new SqlParameter(PN_SENDINGSTATUS, SqlDbType.Int);
            parameterSendingStatus.Value = obj.SendingStatus;
            parameterSendingStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSendingStatus);
            SqlParameter parameterSentDate = new SqlParameter(PN_SENTDATE, SqlDbType.NVarChar);
            parameterSentDate.Value = obj.SentDate;
            parameterSentDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSentDate);
            SqlParameter parameterDeliveryStatus = new SqlParameter(PN_DELIVERYSTATUS, SqlDbType.Int);
            parameterDeliveryStatus.Value = obj.DeliveryStatus;
            parameterDeliveryStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDeliveryStatus);
            SqlParameter parameterMailID = new SqlParameter(PN_MAILID, SqlDbType.Int);
            parameterMailID.Value = obj.MailID;
            parameterMailID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMailID);

            SqlParameter parameterSentBy = new SqlParameter(PN_SENT_BY, SqlDbType.Int);
            parameterSentBy.Value = obj.SentBy;
            parameterSentBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSentBy);
            #endregion;

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
            obj.ID = Convert.ToInt32(parameterID.Value);
            return obj.ID;
        }
        #endregion;
        #region[Update]

        public void Update(EmailQueue obj)
        {
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = UPDATEEmailQueue;

            #region [Parameters]
            SqlParameter parameterID = new SqlParameter(PN_ID, SqlDbType.Int);
            parameterID.Value = obj.ID;
            parameterID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterID);
            SqlParameter parameterReciverAddress = new SqlParameter(PN_RECIVERADDRESS, SqlDbType.NVarChar);
            parameterReciverAddress.Value = obj.ReciverAddress;
            parameterReciverAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterReciverAddress);
            SqlParameter parameterRecieverName = new SqlParameter(PN_RECIEVERNAME, SqlDbType.NVarChar);
            parameterRecieverName.Value = obj.RecieverName;
            parameterRecieverName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterRecieverName);
            SqlParameter parameterSenderAddress = new SqlParameter(PN_SENDERADDRESS, SqlDbType.NVarChar);
            parameterSenderAddress.Value = obj.SenderAddress;
            parameterSenderAddress.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSenderAddress);
            SqlParameter parameterSenderName = new SqlParameter(PN_SENDERNAME, SqlDbType.NVarChar);
            parameterSenderName.Value = obj.SenderName;
            parameterSenderName.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSenderName);
            SqlParameter parameterContactID = new SqlParameter(PN_CONTACTID, SqlDbType.Int);
            parameterContactID.Value = obj.ContactID;
            parameterContactID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterContactID);
            SqlParameter parameterScheduleDate = new SqlParameter(PN_SCHEDULEDATE, SqlDbType.NVarChar);
            parameterScheduleDate.Value = obj.ScheduleDate;
            parameterScheduleDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterScheduleDate);
            SqlParameter parameterScheduleTime = new SqlParameter(PN_SCHEDULETIME, SqlDbType.NVarChar);
            parameterScheduleTime.Value = obj.ScheduleTime;
            parameterScheduleTime.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterScheduleTime);
            SqlParameter parameterSendingStatus = new SqlParameter(PN_SENDINGSTATUS, SqlDbType.Int);
            parameterSendingStatus.Value = obj.SendingStatus;
            parameterSendingStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSendingStatus);
            SqlParameter parameterSentDate = new SqlParameter(PN_SENTDATE, SqlDbType.NVarChar);
            parameterSentDate.Value = obj.SentDate;
            parameterSentDate.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSentDate);
            SqlParameter parameterDeliveryStatus = new SqlParameter(PN_DELIVERYSTATUS, SqlDbType.Int);
            parameterDeliveryStatus.Value = obj.DeliveryStatus;
            parameterDeliveryStatus.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterDeliveryStatus);
            SqlParameter parameterMailID = new SqlParameter(PN_MAILID, SqlDbType.Int);
            parameterMailID.Value = obj.MailID;
            parameterMailID.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterMailID);

            SqlParameter parameterSentBy = new SqlParameter(PN_SENT_BY, SqlDbType.Int);
            parameterSentBy.Value = obj.SentBy;
            parameterSentBy.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterSentBy);
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
            _command.CommandText = DELETEEmailQueue;

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

        public EmailQueue GetByID(int ID)
        {

            EmailQueue obj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTEmailQueue;

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
                        obj = new EmailQueue();
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
        private void GetEntityFromReader(SqlDataReader _dtr, EmailQueue obj)
        {
            PopulateEmailQueue(_dtr, obj);
        }
        #endregion;
        #region[Get All]

        public IList<EmailQueue> GetAll()
        {

            EmailQueue obj = null;

            IList<EmailQueue> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLEmailQueue;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new EmailQueue();
                        colobj = new List<EmailQueue>();
                        while (_dtreader.Read())
                        {
                            obj = GetEmailQueue(_dtreader, colobj);
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
        #region[Get All Pending]

        public IList<EmailQueue> GetAllPending()
        {

            EmailQueue obj = null;

            IList<EmailQueue> colobj = new List<EmailQueue>();
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLEmailQueuePending;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new EmailQueue();
                        colobj = new List<EmailQueue>();
                        while (_dtreader.Read())
                        {
                            obj = GetEmailQueue(_dtreader, colobj);
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
        #region[Search]

        public IList<EmailQueue> Search(int mailid, int deliveryStatus, int sentStatus, string date, string recieveremail)
        {

            EmailQueue obj = null;

            IList<EmailQueue> colobj = null;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLEmailQueueSearch;

            #region [Parameters]
            SqlParameter parameterds = new SqlParameter(PN_DELIVERYSTATUS, SqlDbType.Int);
            parameterds.Value = deliveryStatus;
            parameterds.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterds);

            SqlParameter parameterss = new SqlParameter(PN_SENDINGSTATUS, SqlDbType.Int);
            parameterss.Value = sentStatus;
            parameterss.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterss);

            SqlParameter parametersd = new SqlParameter(PN_SENTDATE, SqlDbType.NVarChar);
            parametersd.Value = date;
            parametersd.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parametersd);

            SqlParameter parameterre = new SqlParameter(PN_RECIVERADDRESS, SqlDbType.NVarChar);
            parameterre.Value = recieveremail;
            parameterre.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterre);

            SqlParameter parameterei = new SqlParameter(PN_MAILID, SqlDbType.Int);
            parameterei.Value = mailid;
            parameterei.Direction = ParameterDirection.Input;
            _command.Parameters.Add(parameterei);
            #endregion;

            _connection.Open();
            try
            {
                using (_dtreader = _command.ExecuteReader())
                {
                    if (_dtreader != null && _dtreader.HasRows)
                    {
                        obj = new EmailQueue();
                        colobj = new List<EmailQueue>();
                        while (_dtreader.Read())
                        {
                            obj = GetEmailQueue(_dtreader, colobj);
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
        #region[Get Count]

        public int GetCountforPendingEmails()
        {
            int count = 0;
            _connection.ConnectionString = _ConnectionString;
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = SELECTALLEmailQueueGetcount;


            SqlParameter parameterre = new SqlParameter("Count", SqlDbType.Int);
            parameterre.Value = count;
            parameterre.Direction = ParameterDirection.Output;
            _command.Parameters.Add(parameterre);

            _connection.Open();
            try
            {
                _command.ExecuteScalar();
                count = Convert.ToInt32(parameterre.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

          
                _connection.Close();
            }

            return count;
        }
        #endregion;
        #region[Get EmailQueue]
        public EmailQueue GetEmailQueue(SqlDataReader _dtr, IList<EmailQueue> colobj)
        {
            EmailQueue obj = colobj.Where(t => t.ID == Convert.ToInt32(_dtr[CN_ID].ToString())).SingleOrDefault();
            if (null == obj)
            {
                obj = new EmailQueue();
                colobj.Add(obj);
            }
            return obj;
        }
        #endregion;
    }
}