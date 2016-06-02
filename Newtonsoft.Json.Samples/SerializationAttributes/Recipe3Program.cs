using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Serialization Attributes
    /// </summary>
    public static class Recipe3Program
    {
        public static void Run()
        {
            //As well as using the built-in Json.NET attributes, Json.NET also looks for the SerializableAttribute (if IgnoreSerializableAttribute on DefaultContractResolver is set to false) 
            //DataContractAttribute,DataMemberAttribute, and NonSerializedAttribute and attributes when determining how JSON is to be serialized and deserialized. 
            //Json.NET attributes take precedence over standard .NET serialization attributes (e.g. if both JsonPropertyAttribute and DataMemberAttribute 
            //are present on a property and both customize the name, the name from JsonPropertyAttribute will be used).
            Person person = new Person();
            person.Name = "John Smith";
            person.BirthDate = new DateTime(2000, 12, 28);
            person.Department = "human resource department";
            person.LastModified = new DateTime(2015, 2, 18); 
            string jsonStr = JsonConvert.SerializeObject(person);
            System.Console.WriteLine(jsonStr);
            //output:{"Name":"John Smith","BirthDate":"2000-12-28T00:00:00","LastModified":new Date(1424188800000)}
        }
    }
}
