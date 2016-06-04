using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Data;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Serialize Unindented JSON
    /// This sample serializes an object to JSON without any formatting or indentation whitespace.
    /// </summary>
    public static class Recipe45Program
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

            string json = JsonConvert.SerializeObject(account);
            // {"Email":"james@example.com","Active":true,"CreatedDate":"2013-01-20T00:00:00Z","Roles":["User","Admin"]}

            Console.WriteLine(json);
        }
    }

}
