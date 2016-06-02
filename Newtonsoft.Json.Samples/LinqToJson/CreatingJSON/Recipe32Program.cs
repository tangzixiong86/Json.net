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
    public static class Recipe32Program
    {
        public static void Run()
        {
            List<Post> posts = GetPosts();
            JObject o = JObject.FromObject(new
            {
                channel = new
                {
                    title = "James Newton-King",
                    link = "http://james.newtonking.com",
                    description = "James Newton-King's blog.",
                    item =
                            from p in posts
                            orderby p.Title
                            select new
                            {
                                title = p.Title,
                                description = p.Description,
                                link = p.Link,
                                category = p.Categories
                            }
                }
            });
            Console.WriteLine(o.ToString());
        }
        public static List<Post> GetPosts()
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
