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
    /// Serialize a Dictionary
    /// </summary>
    public static class Recipe40Program
    {
        public static void Run()
        {
            Dictionary<string, int> points = new Dictionary<string, int>
                                            {
                                                { "James", 9001 },
                                                { "Jo", 3474 },
                                                { "Jess", 11926 }
                                            };

            string json = JsonConvert.SerializeObject(points, Formatting.Indented);

            Console.WriteLine(json);
            // {
            //   "James": 9001,
            //   "Jo": 3474,
            //   "Jess": 11926
            // }
        }

    }
   
}
