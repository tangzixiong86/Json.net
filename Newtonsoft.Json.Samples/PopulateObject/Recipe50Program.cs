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
    /// Populate an Object
    /// This sample populates an existing object instance with values from JSON.
    /// </summary>
    public static class Recipe50Program
    {
        public static void Run()
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Admin"
                }
            };

            string json = @"{
              'Active': false,
              'Roles': [
                'Expired'
              ]
            }";

            JsonConvert.PopulateObject(json, account);

            Console.WriteLine(account.Email);
            // james@example.com

            Console.WriteLine(account.Active);
            // false

            Console.WriteLine(string.Join(", ", account.Roles.ToArray()));
            // User, Admin, Expired
        }
    }

}
