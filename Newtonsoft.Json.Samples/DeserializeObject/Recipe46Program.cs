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
    /// Deserialize an Object 
    /// This sample deserializes JSON to an object.
    /// </summary>
    public static class Recipe46Program
    {
        public static void Run()
        {
            string json = @"{
              'Email': 'james@example.com',
              'Active': true,
              'CreatedDate': '2013-01-20T00:00:00Z',
              'Roles': [
                'User',
                'Admin'
              ]
            }";

            Account account = JsonConvert.DeserializeObject<Account>(json);

            Console.WriteLine(account.Email);
            // james@example.com
        }
    }

}
