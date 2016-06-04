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
    /// Deserialize an Anonymous Type
    /// This sample deserializes JSON into an anonymous type.
    /// </summary>
    public static class Recipe47Program
    {
        public static void Run()
        {
            var definition = new { Name = "" };

            string json1 = @"{'Name':'James'}";
            var customer1 = JsonConvert.DeserializeAnonymousType(json1, definition);

            Console.WriteLine(customer1.Name);
            // James

            string json2 = @"{'Name':'Mike'}";
            var customer2 = JsonConvert.DeserializeAnonymousType(json2, definition);

            Console.WriteLine(customer2.Name);
            // Mike
        }
    }
   
}
