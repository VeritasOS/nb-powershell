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

// cmdlet to get the NBU Token.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;


// Class for getting the NetBackup connection token, to call further APIs.
namespace NBCmdlets
{
    [Cmdlet(VerbsCommon.Get, "NBToken")]
    public class GetToken : Cmdlet
    {
        [Parameter(Position=1, Mandatory=true, ValueFromPipeline=true)]
        public string Master { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipeline = true)]
        public string DomainType { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipeline = true)]
        public string DomainName { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public PSCredential Credentials { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public string UserName { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public System.Security.SecureString Password { get; set; }

        protected override void ProcessRecord()
        {
            string URL = RestUtil.get_Https_Prefix();
            URL += Master;
            URL += RestUtil.get_Login_Url();
            string postData;


            if(UserName != null && Password != null && UserName.Length != 0 && Password.Length != 0)
            {
                PSCredential psCred = new PSCredential(UserName, Password);

                //Console.WriteLine(psCred.GetNetworkCredential().Password);

                postData = "{ \"domainType\": \"" + DomainType + "\", \"domainName\": \"" + DomainName + "\", \"userName\": \"" + UserName + "\", \"password\": \"" + psCred.GetNetworkCredential().Password + "\" }";
            }
            else
            {
                postData = "{ \"domainType\": \"" + DomainType + "\", \"domainName\": \"" + DomainName + "\", \"userName\": \"" + Credentials.UserName + "\", \"password\": \"" + Credentials.GetNetworkCredential().Password + "\" }";
            }

            //string postData = "{ \"domainType\": \"vx\", \"domainName\": \"vx\", \"userName\": \"restadmin\", \"password\": \"Gyp.s8m\" }";
            //string postData = "{ \"domainType\": \"" + DomainType + "\", \"domainName\": \"" + DomainName + "\", \"userName\": \"" + Credentials.UserName + "\", \"password\": \"" + Credentials.GetNetworkCredential().Password + "\" }";

            string response = RestUtil.Make_POST_Call(URL, postData);

            string token = JsonUtil.GetJSONValueForKey(response, "token");

            WriteObject(token);

        }
    }
}
