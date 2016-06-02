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
    /// Getting values by Property Name or Collection Index
    /// LINQ to JSON provides a number of methods for getting data from its objects. 
    /// The index methods on JObject/JArray let you quickly get data by its property name on an object or index in a collection, 
    /// while Children()  lets you get ranges of data as IEnumerable<JToken> to then query using LINQ.
    /// The simplest way to get a value from LINQ to JSON is to use the Item[ Object]  index on JObject/JArray 
    /// and then cast the returned JValue to the type you want. 
    /// </summary>
    public static class Recipe33Program
    {
        public static void Run()
        {
            string json = @"{
                              'channel': {
                                'title': 'James Newton-King',
                                'link': 'http://james.newtonking.com',
                                'description': 'James Newton-King\'s blog.',
                                'item': [
                                  {
                                    'title': 'Json.NET 1.3 + New license + Now on CodePlex',
                                    'description': 'Annoucing the release of Json.NET 1.3, the MIT license and the source on CodePlex',
                                    'link': 'http://james.newtonking.com/projects/json-net.aspx',
                                    'categories': [
                                      'Json.NET',
                                      'CodePlex'
                                    ]
                                  },
                                  {
                                    'title': 'LINQ to JSON beta',
                                    'description': 'Annoucing LINQ to JSON',
                                    'link': 'http://james.newtonking.com/projects/json-net.aspx',
                                    'categories': [
                                      'Json.NET',
                                      'LINQ'
                                    ]
                                  }
                                ]
                              }
                            }";

            JObject rss = JObject.Parse(json);

            string rssTitle = (string)rss["channel"]["title"];
            // James Newton-King

            string itemTitle = (string)rss["channel"]["item"][0]["title"];
            // Json.NET 1.3 + New license + Now on CodePlex

            JArray categories = (JArray)rss["channel"]["item"][0]["categories"];
            // ["Json.NET", "CodePlex"]

            IList<string> categoriesText = categories.Select(c => (string)c).ToList();
            // Json.NET
            // CodePlex
        }
      
    }
   
}
