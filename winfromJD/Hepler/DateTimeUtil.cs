using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace winfromJD.Hepler
{
    public static class DateTimeUtil
    {
        /// <summary>
        /// 时间戳计时开始时间
        /// </summary>
        private static DateTime timeStampStartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// DateTime转换为10位时间戳（单位：秒）
        /// </summary>
        /// <param name="dateTime"> DateTime</param>
        /// <returns>10位时间戳（单位：秒）</returns>
        public static long DateTimeToTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - timeStampStartTime).TotalSeconds;
        }
        /// <summary>
        /// DateTime转换为13位时间戳（单位：毫秒）
        /// </summary>
        /// <param name="dateTime"> DateTime</param>
        /// <returns>13位时间戳（单位：毫秒）</returns>
        public static long DateTimeToLongTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - timeStampStartTime).TotalMilliseconds;
        }
        /// <summary>
        /// 10位时间戳（单位：秒）转换为DateTime
        /// </summary>
        /// <param name="timeStamp">10位时间戳（单位：秒）</param>
        /// <returns>DateTime</returns>
        public static DateTime TimeStampToDateTime(long timeStamp)
        {
            return timeStampStartTime.AddSeconds(timeStamp).ToLocalTime();
        }
        /// <summary>
        /// 13位时间戳（单位：毫秒）转换为DateTime
        /// </summary>
        /// <param name="longTimeStamp">13位时间戳（单位：毫秒）</param>
        /// <returns>DateTime</returns>
        public static DateTime LongTimeStampToDateTime(long longTimeStamp)
        {
            return timeStampStartTime.AddMilliseconds(longTimeStamp).ToLocalTime();
        }
    }
    public static class UnicodeString 
    {
        /// <summary>  
        /// 字符串转Unicode  
        /// </summary>  
        /// <param name="source">源字符串</param>  
        /// <returns>Unicode编码后的字符串</returns>  
        public static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }
        /// <summary>    
        /// 字符串转为UniCode码字符串    
        /// </summary>    
        /// <param name="s"></param>    
        /// <returns></returns>    
        public static string StringToUnicode(string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }
        /// <summary>    
        /// Unicode字符串转为正常字符串    
        /// </summary>    
        /// <param name="srcText"></param>    
        /// <returns></returns>    
        public static string UnicodeToString(string srcText)
        {
            Regex regex = new Regex(@"\\u([0-9A-F]){4}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            var results = regex.Matches(srcText);
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            foreach (Match item in results)
            {
                string s = item.Value.Replace("\\u", "");
                sb.Append(Convert.ToChar(Convert.ToInt32(s, 16)).ToString());
            }

            string result = sb.ToString();
            return result;
        }
    }
    public class GetPost
    {
        public static string HttpPost(string url, string postdata, string cookies)

        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;
            HttpWebRequest request = null;

            HttpWebResponse response = null;

            try
            {

                request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = "POST";

                byte[] data = Encoding.UTF8.GetBytes(postdata);

                request.ContentType = "application/x-www-form-urlencoded";

                //电脑            
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.0.0 Safari/537.36";
                //手机
                //request.UserAgent = "jdapp;android;11.1.0;;;appBuild/98139;ef/1;ep/%7B%22hdid%22%3A%22JM9F1ywUPwflvMIpYPok0tt5k9kW4ArJEU3lfLhxBqw%3D%22%2C%22ts%22%3A1656050704998%2C%22ridx%22%3A-1%2C%22cipher%22%3A%7B%22od%22%3A%22%22%2C%22ad%22%3A%22Y2CzCJc5ZWU5CtHsENU0Cm%3D%3D%22%2C%22ud%22%3A%22Y2CzCJc5ZWU5CtHsENU0Cm%3D%3D%22%2C%22ov%22%3A%22CtS%3D%22%2C%22sv%22%3A%22DI4nBtO%3D%22%7D%2C%22ciphertype%22%3A5%2C%22version%22%3A%221.2.0%22%2C%22appname%22%3A%22com.jingdong.app.mall%22%7D;jdSupportDarkMode/0;Mozilla/5.0 (Linux; Android 5.1.1; SM-G9750 Build/LMY47I; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/52.0.2743.100 Mobile Safari/537.36";
                
                request.ContentLength = data.Length;

                request.Headers.Add("cookie", cookies);

                Stream newStream = request.GetRequestStream();

                newStream.Write(data, 0, data.Length);

                newStream.Close();



                response = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string result = reader.ReadToEnd();

                reader.Close();

                request.Abort();

                response.Close();

                return result;

            }

            catch (Exception ex)

            {

                if (request != null) request.Abort();

                if (response != null) response.Close();

                return string.Empty;

            }



        }

        public static string GetRequest(string url, string cookies)
        {
            ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidate;

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            if (cookies != "")
            {
                myRequest.Headers.Add("cookie", cookies);
            }

            myRequest.Method = "GET";

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();

            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

            string content = reader.ReadToEnd();

            reader.Close();

            return content;

        }
        //定义方法：
        private static bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            //为了通过证书验证，总是返回true
            return true;
        }
    }

    
    public class win32images 
    {
        public class Win32Helper
        {
            [DllImport("user32.dll", EntryPoint = "SystemParametersInfoA")]
            internal static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, string lpvparam, Int32 fuwinIni);
        }
        /// <summary>
        /// 设置桌面背景
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        public static int SetWallpaper(string imgPath)
        {
            return Win32Helper.SystemParametersInfo(20, 1, imgPath, 0x1 | 0x2);
        }
    }

}
