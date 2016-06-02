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
    /// JsonIgnoreAttribute
    /// One of the common problems encountered when serializing .NET objects to JSON is that the JSON ends up containing a lot of unwanted properties and values. 
    /// This can be especially significant when returning JSON to the client. More JSON means more bandwidth and a slower website.
    /// To solve the issue of unwanted JSON, Json.NET has a range of built-in options to fine-tune what gets written from a serialized object.
    /// By default Json.NET will include all of a class's public properties and fields in the JSON it creates. 
    /// Adding the JsonIgnoreAttribute to a property tells the serializer to always skip writing it to the JSON result.
    /// </summary>
    public static class Recipe17Program
    {
        public static void Run()
        {
            Car car = new Car
            {
                Model = "SUV",
                Year = new DateTime(2015, 12, 1),
                Features = new List<string> { "cheap", "beautiful" },
                LastModified = new DateTime(2016, 4, 1)
            };
            string json = JsonConvert.SerializeObject(car, Formatting.Indented);
            Console.WriteLine(json);
            //{
            //  "Model": "SUV",
            //  "Year": "2015-12-01T00:00:00",
            //  "Features": [
            //    "cheap",
            //    "beautiful"
            //  ]
            //}
        }
    }
    public class Car
    {
        // included in JSON
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public List<string> Features { get; set; }
        // ignored
        [JsonIgnore]
        public DateTime LastModified { get; set; }
    }

}
