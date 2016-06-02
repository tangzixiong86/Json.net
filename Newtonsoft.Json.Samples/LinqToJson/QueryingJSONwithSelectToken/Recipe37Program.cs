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

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// SelectToken with JSONPath
    /// SelectToken supports JSONPath queries.
    /// </summary>
    public static class Recipe37Program
    {
        public static void Run()
        {
            JObject o = JObject.Parse(@"{
                                      'Stores': [
                                        'Lambton Quay',
                                        'Willis Street'
                                      ],
                                      'Manufacturers': [
                                        {
                                          'Name': 'Acme Co',
                                          'Products': [
                                            {
                                              'Name': 'Anvil',
                                              'Price': 50
                                            }
                                          ]
                                        },
                                        {
                                          'Name': 'Contoso',
                                          'Products': [
                                            {
                                              'Name': 'Elbow Grease',
                                              'Price': 99.95
                                            },
                                            {
                                              'Name': 'Headlight Fluid',
                                              'Price': 4
                                            }
                                          ]
                                        }
                                      ]
                                    }");

            // manufacturer with the name 'Acme Co'
            JToken acme = o.SelectToken("$.Manufacturers[?(@.Name == 'Acme Co')]");

            Console.WriteLine(acme);
            // { "Name": "Acme Co", Products: [{ "Name": "Anvil", "Price": 50 }] }

            // name of all products priced 50 and above
            IEnumerable<JToken> pricyProducts = o.SelectTokens("$..Products[?(@.Price >= 50)].Name");

            foreach (JToken item in pricyProducts)
            {
                Console.WriteLine(item);
            }
            // Anvil
            // Elbow Grease
        }
      
    }
   
}
