using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Manually Creating JSON
    /// Setting values and creating objects and arrays one at a time gives you total control, but it is more verbose than other options.
    /// </summary>
    public static class Recipe30Program
    {
        public static void Run()
        {
            JArray array = new JArray();
            JValue text = new JValue("Manual text");
            JValue date = new JValue(new DateTime(2000, 5, 23));

            array.Add(text);
            array.Add(date);

            string json = array.ToString();
            // [
            //   "Manual text",
            //   "2000-05-23T00:00:00"
            // ]
        }
    }
   
}
