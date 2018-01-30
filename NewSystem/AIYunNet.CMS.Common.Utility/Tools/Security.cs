using System;
using System.Management;
using System.Security.Cryptography;
using System.Security;
using System.Collections;
using System.Text;
using System.Web;
using AIYunNet.CMS.Domain.DataHelper;
using System.Data;

namespace AIYunNet.CMS.Common.Utility.Tools
{
    public class Security
    {
        /// <summary>
        /// 获取唯一标识
        /// </summary>
        /// <returns></returns>
        public string GetRequestKey()
        {
            string UserHostName = HttpContext.Current.Request.UserHostName;
            string Platform = HttpContext.Current.Request.Browser.Platform.ToString();//获取客户端使用平台的名字 
            string BrowserId = HttpContext.Current.Request.Browser.Id;
            string Version = HttpContext.Current.Request.Browser.Version.ToString();//获取客户端浏览器的完整版本号
            string key = GetHash("ip" + UserHostName + "name" + Platform + "Browser" + BrowserId + "id" + Version);
            return key;
        }
        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }


    }
}
