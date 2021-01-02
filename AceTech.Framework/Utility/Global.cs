using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AceTech.Framework.Utility
{
    public static class Global
    {
        #region Properties
        public static bool LoginSucceed = false;
        public static bool IsClosed = false;
        #endregion
        #region Methods
        public static string GetStringMD5(string originalStr)
        {
            string md5Result = string.Empty;
            if (string.IsNullOrWhiteSpace(originalStr))
            {
                return md5Result;
            }
            using (MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(originalStr);
                byte[] md5Bytes = md5Provider.ComputeHash(dataBytes);
                StringBuilder md5Builder = new StringBuilder();
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    md5Builder.Append(md5Bytes[i].ToString("x2"));
                }
                md5Result = md5Builder.ToString();
            }
            return md5Result;
        }
        #endregion
    }
}
