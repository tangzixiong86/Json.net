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
    /// Creating JSON with LINQ
    /// Declaratively creating JSON objects using LINQ is a fast way to create JSON from collections of values.
    /// </summary>
    public static class Recipe31Program
    {
        public static void Run()
        {
            List<Post> posts = GetPosts();

            JObject rss =
                new JObject(
                    new JProperty("channel",
                        new JObject(
                            new JProperty("title", "James Newton-King"),
                            new JProperty("link", "http://james.newtonking.com"),
                            new JProperty("description", "James Newton-King's blog."),
                            new JProperty("item",
                                new JArray(
                                    from p in posts
                                    orderby p.Title
                                    select new JObject(
                                        new JProperty("title", p.Title),
                                        new JProperty("description", p.Description),
                                        new JProperty("link", p.Link),
                                        new JProperty("category",
                                            new JArray(
                                                from c in p.Categories
                                                select new JValue(c)))))))));

            Console.WriteLine(rss.ToString());

            //{
            //  "channel": {
            //    "title": "James Newton-King",
            //    "link": "http://james.newtonking.com",
            //    "description": "James Newton-King\'s blog.",
            //    "item": [
            //      {
            //        "title": "Json.NET 1.3 + New license + Now on CodePlex",
            //        "description": "Annoucing the release of Json.NET 1.3, the MIT license and being available on CodePlex",
            //        "link": "http://james.newtonking.com/projects/json-net.aspx",
            //        "category": [
            //          "Json.NET",
            //          "CodePlex"
            //        ]
            //      },
            //      {
            //        "title": "LINQ to JSON beta",
            //        "description": "Annoucing LINQ to JSON",
            //        "link": "http://james.newtonking.com/projects/json-net.aspx",
            //        "category": [
            //          "Json.NET",
            //          "LINQ"
            //        ]
            //      }
            //    ]
            //  }
            //}
        }
        public static  List<Post> GetPosts()
        {
            List<Post> posts = new List<Post>()
            {
                new Post() {Title="Json.NET 1.3 + New license + Now on CodePlex",
                    Description ="Annoucing the release of Json.NET 1.3, the MIT license and being available on CodePlex",
                    Link ="http://james.newtonking.com/projects/json-net.aspx",Categories=new List<string>() { "Json.NET", "CodePlex" } },
                  new Post() {Title="LINQ to JSON beta",
                    Description ="Annoucing LINQ to JSON",
                    Link ="http://james.newtonking.com/projects/json-net.aspx",Categories=new List<string>() { "Json.NET", "LINQ" } }
            };
            return posts;
        }
    }
   


}
