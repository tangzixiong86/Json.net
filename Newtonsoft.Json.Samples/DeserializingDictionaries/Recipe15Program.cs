using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Deserializing Dictionaries
    /// Using Json.NET you can also deserialize a JSON object into a .NET generic dictionary. 
    /// The JSON object's property names and values will be added to the dictionary.
    /// </summary>
    public static class Recipe15Program
    {
        public static void Run()
        {
            string json = @"{""key1"":""value1"",""key2"":""value2""}";

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            Console.WriteLine(values.Count);
            // 2

            Console.WriteLine(values["key1"]);
            // value1
        }
    }
   
}
