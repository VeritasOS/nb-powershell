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

// cmdlet to get the jobs releated information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Net;

namespace NBCmdlets
{
    [Cmdlet(VerbsCommon.Set, "NBJobs")]
    public class SetJob : Cmdlet
    {
        [Parameter(Position = 1, ValueFromPipeline = true)]
        public string Token { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipeline = true)]
        public string Master { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipeline = true)]
        public string JobID { get; set; }

        [Parameter(Position = 4)]
        public SwitchParameter Restart
        {
            get { return restart; }
            set { restart = value; }
        }

        private bool restart;

        protected override void ProcessRecord()
        {
            string URL = RestUtil.get_Https_Prefix();
            URL += Master;
            URL += RestUtil.get_Job_URL();
 
            WebHeaderCollection headers = new WebHeaderCollection();
            headers.Add("Authorization:" + Token);

            if (JobID != null && JobID.Length > 0)
            {
                URL += "/" + JobID;
            }

            if (restart)
            {
                URL += RestUtil.JOBS_RESTART_SUFFIX;
                headers.Add("X-NetBackup-Audit-Reason:PowerShell");
            }

            string response = RestUtil.Make_POST_Call(URL, Token, headers);

            WriteObject(response);
        }
    }
}