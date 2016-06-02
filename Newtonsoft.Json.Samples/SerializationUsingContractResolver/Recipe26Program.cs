using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// DefaultContractResolver
    /// The DefaultContractResolver is the default resolver used by the serializer.It provides many avenues of extensibility in the form of virtual methods that can be overridden.
    /// This example sets a JsonConverter for a type using an IContractResolver. 
    /// Using a contract resolver here is useful because DateTime is not your own type and it is not possible to place a JsonConverterAttribute on it.
    /// </summary>
    public static class Recipe26Program
    {
        public static void Run()
        {
            LogEntry entry = new LogEntry
            {
                LogDate = new DateTime(2009, 2, 15, 0, 0, 0, DateTimeKind.Utc),
                Details = "Application started."
            };

            string json = JsonConvert.SerializeObject(entry,
                Formatting.Indented,
                new JsonSerializerSettings { ContractResolver=new  ConverterContractResolver() });
            Console.WriteLine(json);
        }
    }
    public class ConverterContractResolver : DefaultContractResolver
    {
        public  static readonly ConverterContractResolver Instance = new ConverterContractResolver();

        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);

            // this will only be called once and then cached
            if (objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset))
            {
                contract.Converter = new JavaScriptDateTimeConverter();
            }

            return contract;
        }
    }

}
