using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;

namespace Newtonsoft.Json.Samples
{
    public static class Recipe1Program
    {
        /// <summary>
        /// JsonConvert
        /// </summary>
        public static void Run()
        {
            //For simple scenarios where you want to convert to and from a JSON string, 
            //the SerializeObject() and DeserializeObject() methods on JsonConvert provide an easy-to-use wrapper over JsonSerializer.
            //SerializeObject and DeserializeObject both have overloads that take a JsonSerializerSettings object.
            //JsonSerializerSettings lets you use many of the JsonSerializer settings listed below while still using the simple serialization methods. 
            Product product = new Product();
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            product.Sizes = new string[] { "Small", "Medium", "Large" };
            string jsonStr = JsonConvert.SerializeObject(product,Formatting.Indented);
            System.Console.WriteLine(jsonStr);
        }
    }
}
