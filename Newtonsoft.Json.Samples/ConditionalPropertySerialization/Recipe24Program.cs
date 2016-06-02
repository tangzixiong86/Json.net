using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.Reflection;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// IContractResolver
    /// ShouldSerialize can also be set using an IContractResolver. 
    /// Conditionally serializing a property using an IContractResolver is useful if you don't want to place a ShouldSerialize method on a class or you didn't declare the class and are unable to..
    /// This example sets up conditional serialization for a property using an IContractResolver. This is useful if you want to conditionally serialize a property but don't want to add additional methods to your type.
    /// </summary>
    public static class Recipe24Program
    {
        public static void Run()
        {
            Employee joe = new Employee();
            joe.Name = "Joe Employee";
            Employee mike = new Employee();
            mike.Name = "Mike Manager";

            joe.Manager = mike;

            // mike is his own manager
            // ShouldSerialize will skip this property
            mike.Manager = mike;

            string json = JsonConvert.SerializeObject(new[] { joe, mike }, Formatting.Indented);
            // [
            //   {
            //     "Name": "Joe Employee",
            //     "Manager": {
            //       "Name": "Mike Manager"
            //     }
            //   },
            //   {
            //     "Name": "Mike Manager"
            //   }
            // ]
        }
        public class Employee
        {
            public string Name { get; set; }
            public Employee Manager { get; set; }
        }
    }
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public  static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(Employee) && property.PropertyName == "Manager")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        Recipe24Program.Employee e = (Recipe24Program.Employee)instance;
                        return e.Manager != e;
                    };
            }

            return property;
        }
    }

}
