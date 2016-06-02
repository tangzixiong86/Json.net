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
    /// Loading JSON from a file
    /// JSON can also be loaded directly from a file using ReadFrom(JsonReader).
    /// </summary>
    public static class Recipe29Program
    {
        public static void Run()
        {
            using (StreamReader reader = File.OpenText(@"computer.json"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                // do stuff
            }
        }
    }
   
}
