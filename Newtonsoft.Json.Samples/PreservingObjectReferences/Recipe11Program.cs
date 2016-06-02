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
    /// IsReference
    /// The PreserveReferencesHandling setting on the JsonSerializer will change how all objects are serialized and deserialized. 
    /// For fine grain control over which objects and members should be serialized as a reference there is the IsReference property on the JsonObjectAttribute, JsonArrayAttribute and JsonPropertyAttribute.
    /// Setting IsReference on JsonObjectAttribute or JsonArrayAttribute to true will mean the JsonSerializer will always serialize the type the attribute is against as a reference.
    /// Setting IsReference on the JsonPropertyAttribute to true will serialize only that property as a reference.
    /// </summary>
    public static class Recipe11Program
    {
        public static void Run()
        {
            List<EmployeeReference> list = new List<EmployeeReference>();
            EmployeeReference emp1 = new EmployeeReference { Name = "Jim" };
            EmployeeReference emp2 = new EmployeeReference { Name = "Jhone", Manager = emp1 };
            list.Add(emp1);
            list.Add(emp2);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            Console.WriteLine(json);
            //when EmployeeReference class has  [JsonObject(IsReference =true)]
            //[
            //  {
            //    "$id": "1",
            //    "Name": "Jim",
            //    "Manager": null
            //  },
            //  {
            //    "$id": "2",
            //    "Name": "Jhone",
            //    "Manager": {
            //      "$ref": "1"
            //    }
            //  }
            //]

            //when EmployeeReference class has not  [JsonObject(IsReference =true)]
            //[
            //  {
            //    "Name": "Jim",
            //    "Manager": null
            //  },
            //  {
            //    "Name": "Jhone",
            //    "Manager": {
            //      "Name": "Jim",
            //      "Manager": null
            //    }
            //  }
            //]


            //json = JsonConvert.SerializeObject(people, Formatting.Indented,
            //         new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
        }
    }
   //[JsonObject(IsReference =true)]
    public class EmployeeReference
    {
        public string Name { get; set; }
        public EmployeeReference Manager { get; set; }
    }

}
