/* ***********************************************************************************************************************************************
Copyright <2019> <Veritas Technologies LLC>

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in 
   the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from 
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, 
BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*********************************************************************************************************************************************** */


// Class to handle REST calls to NetBackup.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Collections.Specialized;
using System.Web.Script.Serialization;

namespace NBCmdlets
{
    // This class helps in making REST calls to the NetBackup APIs.
    class RestUtil
    {
        // URL Strings 
        static string HTTPS_PREFIX = "https://";
        static string LOGIN_URL = ":1556/netbackup/login";
        static string POLICY_URL = ":1556/netbackup/config/policies";
        static string JOB_URL = ":1556/netbackup/admin/jobs";
        public static string PING_URL = ":1556/netbackup/ping";
        public static string TOKEN_KEY_URL = ":1556/netbackup/tokenkey";
        public static string ALERT_URL = ":1556/netbackup/manage/alerts";
        public static string CONFIG_HOST_URL = ":1556/netbackup/config/hosts";
        public static string JOBS_LIMIT_SUFFIX = "?page[limit]=100";
        public static string JOBS_RESTART_SUFFIX = "/restart";

        public static string get_Policy_Url()
        {
            return POLICY_URL;
        }

        public static string get_Login_Url()
        {
            return LOGIN_URL;
        }

        public static string get_Https_Prefix()
        {
            return HTTPS_PREFIX;
        }

        public static string get_Job_URL()
        {
            return JOB_URL;
        }

        // Function to make POST call with JSON data.
        public static string Make_POST_Call(string URL, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(URL);

            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var data = Encoding.ASCII.GetBytes(postData);
            string responseReturn  = "";

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                responseReturn = responseString.ToString();
            }
            catch(Exception e)
            {
                if(e.Message.Contains("Could not create SSL"))
                {
                    Console.WriteLine("Error : " + "Could not create SSL/TLS secure channel. Please try again.");
                }
            }

            return responseReturn;
        }


        // Function to make POST call with Token.
        public static string Make_POST_Call(string URL, string token, WebHeaderCollection headers, string postData = "")
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);

            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            request1.Method = "POST";
            request1.KeepAlive = true;
            request1.Headers = headers;
            request1.ContentType = "application/vnd.netbackup+json;version=2.0";
            string myResponse = "";

            if (postData != "")
            {
                var data = Encoding.ASCII.GetBytes(postData);

                request1.ContentLength = data.Length;

                using (var stream = request1.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            try
            { 
                HttpWebResponse response = (HttpWebResponse)request1.GetResponse();

                using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    myResponse = sr.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                if(e.Message == "The remote server returned an error: (409) Conflict.")
                {
                    Console.WriteLine(e.Message + " UUID specified in the request already exists.");
                    myResponse = e.Message;
                }
            }

            return myResponse;
        }
        
        
        
        // Function to make GET call.
        public static string Make_GET_Call(string URL, string token, WebHeaderCollection headers)
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);

            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            request1.Method = "Get";
            request1.KeepAlive = true;
            request1.Headers = headers;
            request1.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request1.GetResponse();
            string myResponse = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                myResponse = sr.ReadToEnd();
            }

            //Console.WriteLine(myResponse);

            return myResponse;

        }


        // Function to make a GET call, with out headers.
        public static string Make_GET_Call(string URL)
        {
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);

            ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            request1.Method = "Get";
            request1.KeepAlive = true;
            request1.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request1.GetResponse();
            string myResponse = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                myResponse = sr.ReadToEnd();
            }

            return myResponse;

        }

    }
}
