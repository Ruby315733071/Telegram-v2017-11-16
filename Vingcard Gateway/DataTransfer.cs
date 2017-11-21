using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace Telegram_Gateway
{
    public class DataTransfer
    {
        public static String _host = string.Empty;
        public static String _basePath = string.Empty;
        public static String _sessions = null;
        public static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public class JsonObject
        {
            public string id { get; set; }
            public string accessKey { get; set; }
        }

        public static JsonObject ExplainJsonString(String strTmp)
        {
            if (strTmp == null) return null;
            var serializer = new JavaScriptSerializer();
            var ret = serializer.Deserialize<JsonObject>(strTmp);
            return (JsonObject)ret;
        }

        public class JsonObjectID
        {
            public string id { get; set; }
        }

        public static JsonObjectID ExplainJsonIDString(String strTmp)
        {
            if (strTmp == null) return null;
            var serializer = new JavaScriptSerializer();
            var ret = serializer.Deserialize<JsonObjectID>(strTmp);
            return (JsonObjectID)ret;
        }

        
        [Serializable]
        public class RoomInformation
        {
            public string data { get; set; }
            public string extId { get; set; }
            public string reqId { get; set; }
        }

        public static RoomInformation ExplainJsonRoomString(String strTmp)
        {
            if (strTmp == null) return null;
            var serializer = new JavaScriptSerializer();
            var ret = serializer.Deserialize<RoomInformation>(strTmp);
            return (RoomInformation)ret;
        }


        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受 
        }

        public static string send_request(String method, String url, String body = null, DataTransfer.JsonObject auth = null)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = method;
                req.Date = System.DateTime.Now;
                req.Credentials = CredentialCache.DefaultCredentials;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                req.ProtocolVersion = HttpVersion.Version10;
                
                // If a body is sent, the headers should also contain the Content-Type and Content-MD5
                byte[] postBytesbody = null;
                byte[] postBytesAuth = null;

                if (body != null && body != "")
                {
                    #region
                    md5.Initialize();
                    byte[] posttmpBytes = Encoding.UTF8.GetBytes(body);
                    md5.ComputeHash(posttmpBytes);
                    req.ContentType = "application/json;charset=utf-8";
                    String strKey = Convert.ToBase64String(md5.Hash);
                    req.Headers.Add("Content-MD5", strKey);
                    postBytesbody = Encoding.UTF8.GetBytes(body);
                    req.ContentLength = postBytesbody.Length;
                    if (auth == null)
                    {
                        using (Stream reqStream = req.GetRequestStream())
                        {
                            reqStream.Write(postBytesbody, 0, postBytesbody.Length);
                        }
                        //MessageBox.Show(req.Headers.ToString());
                    }

                    #endregion
                }
                
                if (auth != null)
                {
                    #region
                    String to_sign = method + "\n";
                    if (body != null && body != "")
                    {
                        to_sign += req.Headers["Content-MD5"] + "\n";
                        to_sign += req.Headers["Content-Type"] + "\n";
                    }
                    to_sign += req.Headers["Date"] + "\n";

                    int iIndex = url.IndexOf('a', 7);
                    String sTmp = url.Substring(iIndex - 1);
                    to_sign += sTmp;
                    //MessageBox.Show(to_sign);

                    HMACSHA1 hmacsha1 = new HMACSHA1();
                    hmacsha1.Key = Encoding.UTF8.GetBytes(auth.accessKey);

                    byte[] dataBuffer = Encoding.UTF8.GetBytes(to_sign);
                    byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

                    String strTmp = "AWS " + auth.id + ":" + Convert.ToBase64String(hashBytes);
                    req.Headers.Add("Authorization", strTmp);

                    postBytesAuth = Encoding.UTF8.GetBytes(strTmp);
                    //req.ContentLength += hashBytes.Length;
                    using (Stream reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(postBytesbody, 0, postBytesbody.Length);
                    }
                   // MessageBox.Show(req.Headers.ToString());
                    #endregion
                }

                using (WebResponse wr = req.GetResponse())
                {
                    Stream myResponseStream = wr.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    var retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    return retString;
                    //在这里对接收到的页面内容进行处理
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
        }

        public static string HttpGet(string Url, DataTransfer.JsonObject auth = null) 
        {
            string retString = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
               // request.ContentType = "application/json;charset=UTF-8";
                request.Date = System.DateTime.Now;
                request.Credentials = CredentialCache.DefaultCredentials;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                if (auth != null)
                {
                    #region
                    String to_sign = "GET" + "\n" + "\n" + "\n";

                    to_sign += request.Headers["Date"] + "\n";

                    int iIndex = Url.IndexOf('a', 7);
                    String sTmp = Url.Substring(iIndex - 1);
                    to_sign += sTmp;
                    //MessageBox.Show(to_sign);

                    HMACSHA1 hmacsha1 = new HMACSHA1();
                    hmacsha1.Key = Encoding.UTF8.GetBytes(auth.accessKey);

                    byte[] dataBuffer = Encoding.UTF8.GetBytes(to_sign);
                    byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

                    String strTmp = "AWS " + auth.id + ":" + Convert.ToBase64String(hashBytes);
                    request.Headers.Add("Authorization", strTmp);
                    #endregion
                }

                using (WebResponse response = request.GetResponse())
                {
                    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                    retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
            }
            catch
            { }
            return retString; 
        } 
    }
}
