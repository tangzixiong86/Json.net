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
    /// Preserving Object References
    /// </summary>
    public static class Recipe10Program
    {
        public static void Run()
        {
            Person p = new Person
            {
                BirthDate = new DateTime(1980, 12, 23, 0, 0, 0, DateTimeKind.Utc),
                LastModified = new DateTime(2009, 2, 20, 12, 59, 21, DateTimeKind.Utc),
                Name = "James"
            };

            List<Person> people = new List<Person>();
            people.Add(p);
            people.Add(p);
            //By default Json.NET will serialize all objects it encounters by value. 
            //If a list contains two Person references and both references point to the same object, 
            //then the JsonSerializer will write out all the names and values for each reference.
            string json = JsonConvert.SerializeObject(people, Formatting.Indented);
            Console.WriteLine(json);

            //[
            //  {
            //    "Name": "James",
            //    "BirthDate": "1980-12-23T00:00:00Z",
            //    "LastModified": "2009-02-20T12:59:21Z"
            //  },
            //  {
            //    "Name": "James",
            //    "BirthDate": "1980-12-23T00:00:00Z",
            //    "LastModified": "2009-02-20T12:59:21Z"
            //  }
            //]

            //In most cases this is the desired result, but in certain scenarios writing the second item in the list as a reference to the first is a better solution. 
            //If the above JSON was deserialized now, then the returned list would contain two completely separate Person objects with the same values. 
            //Writing references by value will also cause problems on objects where a circular reference occurs.
            //Setting PreserveReferencesHandling will track object references when serializing and deserializing JSON.
             json = JsonConvert.SerializeObject(people, Formatting.Indented,
                      new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json);
            //[
            //  {
            //    "$id": "1",
            //    "Name": "James",
            //    "BirthDate": "1983-03-08T00:00Z",
            //    "LastModified": "2012-03-21T05:40Z"
            //  },
            //  {
            //    "$ref": "1"
            //  }
            //]

            List<Person> deserializedPeople = JsonConvert.DeserializeObject<List<Person>>(json,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            Console.WriteLine(deserializedPeople.Count);
            // 2

            Person p1 = deserializedPeople[0];
            Person p2 = deserializedPeople[1];

            Console.WriteLine(p1.Name);
            // James
            Console.WriteLine(p2.Name);
            // James

            bool equal = Object.ReferenceEquals(p1, p2);
            // true
        }
    }
   
}
