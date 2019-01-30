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


// Utility  file to manipulate JSON responses.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Reflection;

namespace NBCmdlets
{
    // This is a utility file that has helper functions to convert JSON data from API responses to PowerShell objects.
    class JsonUtil
    {
        // Print value for a particular key.
        public static string GetJSONValueForKey(string jsonData, string key)
        {
            if(jsonData == "")
            {
                return "";
            }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            dynamic dobj = jsonSerializer.Deserialize<dynamic>(jsonData);
            string value = dobj[key].ToString();

            return value;
        }

        // Print all values from the supplied JSON string.
        public static List<string> GetAllJSONValues(string jsonData, string key)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            dynamic dobj = jsonSerializer.Deserialize<dynamic>(jsonData);

            List<string> values = new List<string>();

            foreach (var val in dobj.Keys)
            {
                foreach (var val1 in dobj[val])
                {
                    //Console.WriteLine(val1[key]);
                    values.Add(val1[key]);
                }
            }

            return values;
        }

        // Recursive function to get values for nested dictornaries and other containers of pusedo JSON object.
        public static Dictionary<string, object> GetGranularDataFromJson(string itemKey, dynamic itemValue, Dictionary<string, object> valDict, string filterType = "")
        {
            var itemData = "";

            //Console.Write("Key : " + itemKey); // + "Key Type : " + itemKey.GetType());
            if (!(itemValue is Dictionary<string, object>) && !(itemValue is KeyValuePair<string, object>) && !(itemValue is object[]))
            {
                if(itemValue == null)
                {
                    itemData = "Not Set";
                }
                else
                {
                    itemData = itemValue.ToString();
                }

                try
                {
                    if (GetJob.IsOutputAttribute(itemKey, filterType))
                    {
                        valDict.Add(itemKey, itemData);
                    }
                }
                catch(System.ArgumentException)
                {

                }
            }

            if ((itemValue is Dictionary<string, object>) || (itemValue is KeyValuePair<string, object>))
            {
                foreach(var item in itemValue)
                {
                    GetGranularDataFromJson(item.Key, item.Value, valDict, filterType);
                }
            }
            if(itemValue is object[])
            {
                foreach(var entity in itemValue)
                {
                    if(entity is Dictionary<string, object>)
                    {
                        foreach(var subentity in entity)
                        {
                            GetGranularDataFromJson(subentity.Key, subentity.Value, valDict, filterType);
                        }
                    }
                }
            }

            return valDict;
        }

        // Get Policy Information.
        public static Dictionary<string, object> GetAllJSONValuesPolicyAttrib(string jsonData, Dictionary<string, object> valDict)
        {

            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<dynamic>(jsonData);

            foreach(var item in dict["data"])
            {
                valDict = GetGranularDataFromJson(item.Key, item.Value, valDict);
            }

            return valDict;
        }


        //Get Jobs Information.
        public static Dictionary<string, object> GetAllJSONValuesJobsAttrib(string jsonData, Dictionary<string, object> valDict, string parameter_jobID = "")
        {

            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<dynamic>(jsonData);

            foreach (var entity in dict["data"])
            {
                Dictionary<string, object> tempDict = new Dictionary<string, object>();
                valDict.Clear();
                if (entity is Dictionary<string, object>)
                {
                    foreach (var subentity in entity)
                    {
                        GetGranularDataFromJson(subentity.Key, subentity.Value, tempDict, "JOB");
                    }
                }
                if(entity is KeyValuePair<string, object>)
                {
                    GetGranularDataFromJson(entity.Key, entity.Value, tempDict, "JOB");
                }

                GetJob.InsertDictIntoList(tempDict);
            }

            return valDict;
        }


        // Get Aletrs information
        public static Dictionary<string, object> GetAllJSONValuesAlerts(string jsonData, Dictionary<string, object> valDict, string parameter_jobID = "")
        {

            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<dynamic>(jsonData);

            foreach (var entity in dict["data"])
            {
                valDict.Clear();
                if (entity is Dictionary<string, object>)
                {
                    foreach (var subentity in entity)
                    {
                        GetGranularDataFromJson(subentity.Key, subentity.Value, valDict);
                    }
                }
                if (entity is KeyValuePair<string, object>)
                {
                    GetGranularDataFromJson(entity.Key, entity.Value, valDict);
                }

                GetJob.InsertDictIntoList(valDict);
            }

            return valDict;
        }


        public static Dictionary<string, object> GetAllJSONValuesConfigHost(string jsonData, Dictionary<string, object> valDict, string parameter_jobID = "")
        {
            // if the json response is empty, return an empty dict.
            if(jsonData == "")
            {
                return new Dictionary<string,object>();
            }

            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<dynamic>(jsonData);

            foreach (var entity in dict["hosts"])
            {
                Dictionary<string, object> tempDict = new Dictionary<string, object>();
                valDict.Clear();
                if (entity is Dictionary<string, object>)
                {
                    foreach (var subentity in entity)
                    {
                        GetGranularDataFromJson(subentity.Key, subentity.Value, tempDict);
                    }
                }
                if (entity is KeyValuePair<string, object>)
                {
                    GetGranularDataFromJson(entity.Key, entity.Value, tempDict);
                }

                GetConfigHost.InsertDictIntoList(tempDict);
            }

            return valDict;
        }
    
    
    
    }
}
