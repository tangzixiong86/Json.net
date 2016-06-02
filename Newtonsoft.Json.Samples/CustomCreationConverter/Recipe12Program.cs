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
    /// CustomCreationConverter
    /// The CustomCreationConverter< T>  is a JsonConverter that provides a way to customize how an object is created during JSON deserialization. 
    /// Once the object has been created it will then have values populated onto it by the serializer.
    /// </summary>
    public static class Recipe12Program
    {
        public static void Run()
        {
            string json= @"
            [
              {
                ""FirstName"": ""Maurice"",
                ""LastName"": ""Moss"",
                ""BirthDate"": ""1981 -03-08T00:00Z"",
                ""Department"": ""IT"",
                ""JobTitle"": ""Support""
              },
             {
                ""FirstName"": ""Jen"",
                ""LastName"": ""Barber"",
                ""BirthDate"": ""1985-12-10T00:00Z"",
                ""Department"": ""IT"",
                ""JobTitle"": ""Manager""
              }
             
            ]";

            List<IPerson> people = JsonConvert.DeserializeObject<List<IPerson>>(json, new PersonConverter());

            IPerson person = people[0];

            Console.WriteLine(person.GetType());
            // Newtonsoft.Json.Tests.Employee

            Console.WriteLine(person.FirstName);
            // Maurice

            Employee employee = (Employee)person;

            Console.WriteLine(employee.JobTitle);
            // Support
        }
    }
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime BirthDate { get; set; }
    }

    public class Employee : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Department { get; set; }
        public string JobTitle { get; set; }
    }

    public class PersonConverter : CustomCreationConverter<IPerson>
    {
        public override IPerson Create(Type objectType)
        {
            return new Employee();
        }
    }

}
