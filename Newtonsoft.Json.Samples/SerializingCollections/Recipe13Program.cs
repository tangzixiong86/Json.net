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
    /// Serializing Collections
    /// To serialize a collection - a generic list, array, dictionary, or your own custom collection - simply call the serializer with the object you want to get JSON for. 
    /// Json.NET will serialize the collection and all of the values it contains.
    /// </summary>
    public static class Recipe13Program
    {
        public static void Run()
        {
            Product p1 = new Product
            {
                Name = "Product 1",
                Price = 99.95m,
                ExpiryDate = new DateTime(2000, 12, 29, 0, 0, 0, DateTimeKind.Utc),
            };
            Product p2 = new Product
            {
                Name = "Product 2",
                Price = 12.50m,
                ExpiryDate = new DateTime(2009, 7, 31, 0, 0, 0, DateTimeKind.Utc),
            };

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(json);
            //[
            //  {
            //    "Name": "Product 1",
            //    "ExpiryDate": "2000-12-29T00:00:00Z",
            //    "Price": 99.95,
            //    "Sizes": null
            //  },
            //  {
            //    "Name": "Product 2",
            //    "ExpiryDate": "2009-07-31T00:00:00Z",
            //    "Price": 12.50,
            //    "Sizes": null
            //  }
            //]
        }
    }
   
}
