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
    /// ShouldSerialize
    /// To conditionally serialize a property, add a method that returns boolean with the same name as the property and then prefix the method name with ShouldSerialize. 
    /// The result of the method determines whether the property is serialized. 
    /// If the method returns true then the property will be serialized, if it returns false then the property will be skipped.
    /// </summary>
    public static class Recipe23Program
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

            public bool ShouldSerializeManager()
            {
                // don't serialize the Manager property if an employee is their own manager
                return (Manager != this);
            }
        }
    }
}
