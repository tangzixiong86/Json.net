using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// JsonExtensionDataAttribute
    /// </summary>
    public static class Recipe5Program
    {
        public static void Run()
        {
            //The JsonExtensionDataAttribute instructs the JsonSerializer to deserialize properties with no matching field or property on the type into the specified collection.
            //During serialization the values in this collection are written back to the instance's JSON object.
            //This example shows the JsonExtensionDataAttribute being applied to a field, unmatched JSON properties being added to the field's collection during deserialization.
            string json = @"{
                                'DisplayName': 'John Smith',
                                'SAMAccountName': 'contoso\\johns'
                            }";

            DirectoryAccount account = JsonConvert.DeserializeObject<DirectoryAccount>(json);
            Console.WriteLine(account.DisplayName);
            Console.WriteLine(account.Domain);
            Console.WriteLine(account.UserName);
            string jsonStr = JsonConvert.SerializeObject(account);
            Console.WriteLine(jsonStr);
            //output:{"DisplayName":"John Smith","UserName":"johns","Domain":"contoso","SAMAccountName":"contoso\\johns"}
        }
    }
}
