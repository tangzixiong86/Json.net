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
    /// Deserializing Collections
    /// To deserialize JSON into a .NET collection,just specify the collection type you want to deserialize to. Json.NET supports a wide range of collection types.
    /// </summary>
    public static class Recipe14Program
    {
        public static void Run()
        {
            string json = @"[
                              {
                                'Name': 'Product 1',
                                'ExpiryDate': '2000-12-29T00:00Z',
                                'Price': 99.95,
                                'Sizes': null
                              },
                              {
                                'Name': 'Product 2',
                                'ExpiryDate': '2009-07-31T00:00Z',
                                'Price': 12.50,
                                'Sizes': null
                              }
                           ]";

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            Console.WriteLine(products.Count);
            // 2

            Product p1 = products[0];

            Console.WriteLine(p1.Name);
            // Product 1
        }
    }
   
}
