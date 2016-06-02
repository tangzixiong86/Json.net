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
    /// CamelCasePropertyNamesContractResolver
    /// The IContractResolver interface provides a way to customize how the JsonSerializer serializes and deserializes .NET objects to JSON without placing attributes on your classes. 
    /// Anything that can be set on an object, collection, property, etc, using attributes or methods to control serialization can also be set using an IContractResolver.
    /// CamelCasePropertyNamesContractResolver inherits from DefaultContractResolver and simply overrides the JSON property name to be written in camelcase.
    /// </summary>
    public static class Recipe25Program
    {
        public static void Run()
        {
            Product product = new Product
            {
                ExpiryDate = new DateTime(2010, 12, 20, 18, 1, 0, DateTimeKind.Utc),
                Name = "Widget",
                Price = 9.99m,
                Sizes = new[] { "Small", "Medium", "Large" }
            };

            string json =
                JsonConvert.SerializeObject(
                    product,
                    Formatting.Indented,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
                    );
            Console.WriteLine("CamelCasePropertyNamesContractResolver:" + json);

            //{
            //  "name": "Widget",
            //  "expiryDate": "2010-12-20T18:01:00Z",
            //  "price": 9.99,
            //  "sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}
        }
    }
  

}
