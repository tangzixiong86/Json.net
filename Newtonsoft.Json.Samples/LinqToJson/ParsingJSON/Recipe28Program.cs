using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Parsing JSON text
    /// JSON values can be read from a string using Parse(String).
    /// </summary>
    public static class Recipe28Program
    {
        public static void Run()
        {
            JObject o = JObject.Parse(@"{
                              'CPU': 'Intel',
                              'Drives': [
                                'DVD read/writer',
                                '500 gigabyte hard drive'
                              ]
                            }");

            string cpu = (string)o["CPU"];
            // Intel
            string firstDrive = (string)o["Drives"][0];
            // DVD read/writer
            IList<string> allDrives = o["Drives"].Select(t => (string)t).ToList();
            // DVD read/writer
            // 500 gigabyte hard drive

            string json = @"[
                              'Small',
                              'Medium',
                              'Large'
                            ]";

            JArray a = JArray.Parse(json);
        }
    }
   

}
