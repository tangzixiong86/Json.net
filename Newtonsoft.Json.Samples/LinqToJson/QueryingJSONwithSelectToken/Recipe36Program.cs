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
    /// SelectToken
    /// SelectToken()  provides a method to query LINQ to JSON using a single string path to a desired JToken. 
    /// SelectToken makes dynamic queries easy because the entire query is defined in a string.
    /// SelectToken is a method on JToken and takes a string path to a child token. 
    /// SelectToken returns the child token or a null reference if a token couldn't be found at the path's location.
    /// The path is made up of property names and array indexes separated by periods, e.g. Manufacturers[0].Name.
    /// </summary>
    public static class Recipe36Program
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

            string name = (string)o.SelectToken("Manufacturers[0].Name");
            // Acme Co

            decimal productPrice = (decimal)o.SelectToken("Manufacturers[0].Products[0].Price");
            // 50

            string productName = (string)o.SelectToken("Manufacturers[1].Products[0].Name");
            // Elbow Grease
        }
    }
   
}
