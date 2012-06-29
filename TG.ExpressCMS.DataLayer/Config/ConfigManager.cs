using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;

namespace TG.ExpressCMS.DataLayer.Config
{
    public static class ConfigManager
    {
        public static string GetConnectionString()
        {
            return Decrypt(ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString);
        }
        public static string GetConnectionStringOfSecurity()
        {
            return Decrypt(ConfigurationManager.ConnectionStrings["SecurityDB"].ConnectionString);
        }
        public static string GetConnectionSecondary()
        {
            return Decrypt(ConfigurationManager.ConnectionStrings["SecondaryDb"].ConnectionString);
        }
        public static string GetMailDb()
        {
            return Decrypt(ConfigurationManager.ConnectionStrings["MailDB"].ConnectionString);
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
    }
}
