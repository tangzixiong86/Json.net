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
    /// SelectToken with LINQ
    /// SelectToken can be used in combination with standard LINQ methods.
    /// </summary>
    public static class Recipe38Program
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

            IList<string> storeNames = o.SelectToken("Stores").Select(s => (string)s).ToList();
            // Lambton Quay
            // Willis Street

            IList<string> firstProductNames = o["Manufacturers"].Select(m => (string)m.SelectToken("Products[1].Name")).ToList();
            // null
            // Headlight Fluid

            decimal totalPrice = o["Manufacturers"].Sum(m => (decimal)m.SelectToken("Products[0].Price"));
            // 149.95
        }
    }
   
}
