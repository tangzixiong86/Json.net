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
    /// Creating JSON from an object
    /// The last option is to create a JSON object from a non-JSON type using the FromObject()  method. 
    /// Internally, FromObject will use the JsonSerializer to serialize the object to LINQ to JSON objects instead of text.
    /// The example below shows creating a JSON object from an anonymous object, but any .NET type can be used with FromObject to create JSON.
    /// </summary>
    public static class Recipe35Program
    {
        public static void Run()
        {
            string jsonText = @"{
                              'short': {
                                'original': 'http://www.foo.com/',
                                'short': 'krehqk',
                                'error': {
                                  'code': 0,
                                  'msg': 'No action taken'
                                }
                              }
                            }";

            JObject json = JObject.Parse(jsonText);

            Shortie shortie = new Shortie
            {
                Original = (string)json["short"]["original"],
                Short = (string)json["short"]["short"],
                Error = new ShortieException
                {
                    Code = (int)json["short"]["error"]["code"],
                    ErrorMessage = (string)json["short"]["error"]["msg"]
                }
            };

            Console.WriteLine(shortie.Original);
            // http://www.foo.com/

            Console.WriteLine(shortie.Error.ErrorMessage);
            // No action taken
        }
    }
    public class Shortie
    {
        public string Original { get; set; }
        public string Shortened { get; set; }
        public string Short { get; set; }
        public ShortieException Error { get; set; }
    }

    public class ShortieException
    {
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
    }

}
