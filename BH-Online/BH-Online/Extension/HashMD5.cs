using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BH_Online.Extension
{
    public static class HashMD5
    {
        //(khi khách hàng đẩy mật khẩu xuoongs ta mã hóa nó)
        public static string ToMD5(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
                sbHash.Append(String.Format("{0:x2}", b));
            return sbHash.ToString();
        }
    }
}
