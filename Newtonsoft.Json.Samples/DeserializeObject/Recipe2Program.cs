using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using System.IO;
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Json.Samples
{
    public static class Recipe2Program
    {
        /// <summary>
        /// JsonSerializer
        /// </summary>
        public static void Run()
        {
            //For more control over how an object is serialized, the JsonSerializer can be used directly. 
            //The JsonSerializer is able to read and write JSON text directly to a stream via JsonTextReader and JsonTextWriter.
            //Other kinds of JsonWriters can also be used, such as JTokenReader / JTokenWriter, to convert your object to and from LINQ to JSON objects,
            //or BsonReader / BsonWriter, to convert to and from BSON.
            //JsonSerializer has a number of properties on it to customize how it serializes JSON. 
            //These can also be used with the methods on JsonConvert via the JsonSerializerSettings overloads.
            Product product = new Product();
            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99M;
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter sw = new StreamWriter(@"c:\log\json.txt"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, product);
                }
            }
            //output:{"Name":"Apple","ExpiryDate":new Date(1230393600000),"Price":3.99}
        }
    }
}
