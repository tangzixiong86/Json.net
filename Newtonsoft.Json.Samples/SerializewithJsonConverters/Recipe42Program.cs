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
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Serialize with JsonConverters
    /// This sample uses a JsonConverter to customize how JSON is serialized.
    /// </summary>
    public static class Recipe42Program
    {
        public static void Run()
        {
            List<StringComparison> stringComparisons = new List<StringComparison>
                                                            {
                                                                StringComparison.CurrentCulture,
                                                                StringComparison.Ordinal
                                                            };

            string jsonWithoutConverter = JsonConvert.SerializeObject(stringComparisons);

            Console.WriteLine(jsonWithoutConverter);
            // [0,4]

            string jsonWithConverter = JsonConvert.SerializeObject(stringComparisons,new StringEnumConverter());

            Console.WriteLine(jsonWithConverter);
            // ["CurrentCulture","Ordinal"]

            List<StringComparison> newStringComparsions = JsonConvert.DeserializeObject<List<StringComparison>>(
                jsonWithConverter,
                new StringEnumConverter());

            Console.WriteLine(string.Join(", ", newStringComparsions.Select(c => c.ToString()).ToArray()));
            // CurrentCulture, Ordinal
        }
    }

}
