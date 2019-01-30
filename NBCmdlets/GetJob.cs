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

// Class to get the job releated information from NetBackup.
namespace NBCmdlets
{
     [Cmdlet(VerbsCommon.Get, "NBJobs")]
    public class GetJob : Cmdlet
    {
        public static string[] JobOutputAttributeList = new string[] { "jobId", "parentJobId", "jobType", "jobSubType", "policyName", "scheduleType", "scheduleName", "clientName", "backupId", "sourceStorageUnitName", "destinationStorageUnitName", "dataMovement", "status", "state", "kilobytesTransferred", "transportType", "startTime", "endTime" };
        public static List<Dictionary<string, object>> listValDict = new List<Dictionary<string, object>>();

        public static string[] GetOutputAttributeList()
        {
            return JobOutputAttributeList;
        }

        public static bool IsOutputAttribute(string attributeName, string filterType)
        {
            if(filterType == "")
            {
                return true;
            }
            bool isOutput = false;

            // Add more filters when required.
            switch(filterType)
            { 
                case "JOB":
                    isOutput = JobOutputAttributeList.Contains(attributeName);
                    break;
            }
            return isOutput;
        }

        public static void InsertDictIntoList(Dictionary<string, object> valDict)
        {
            if (valDict.Count > 0)
            {
                listValDict.Add(valDict);
            }
        }

        [Parameter(Position = 1, ValueFromPipeline = true)]
        public string Token { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipeline = true)]
        public string Master { get; set; }

        [Parameter(Position = 3, ValueFromPipeline = true)]
        public string JobID { get; set; }

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
                headers.Add("X-NetBackup-Policy-Use-Generic-Schema:true");
            }
            else
            {
                URL += RestUtil.JOBS_LIMIT_SUFFIX;
            }

            List<string> values = new List<string>();
            Dictionary<string, object> valDict = new Dictionary<string, object>();
            GetJob.listValDict.Clear();

            string response = RestUtil.Make_GET_Call(URL, Token, headers);
            
            string jobID = "";

            if(JobID != null && JobID.Length > 0)
            { 
                jobID = JobID;
            }

            JsonUtil.GetAllJSONValuesJobsAttrib(response, valDict, jobID);
            foreach (var dict in listValDict)
            {
                WriteObject(dict, true);
            }
        }
    }
}
