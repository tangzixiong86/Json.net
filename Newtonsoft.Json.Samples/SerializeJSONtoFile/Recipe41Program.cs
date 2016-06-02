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
    /// Serialize a Dictionary
    /// </summary>
    public static class Recipe41Program
    {
        public static void Run()
        {
            Movie movie = new Movie
            {
                Name = "Bad Boys",
                Year = 1995
            };

            // serialize JSON to a string and then write string to a file
            File.WriteAllText(@"c:\movie.json", JsonConvert.SerializeObject(movie));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"c:\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, movie);
            }
        }
        public class Movie
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }

    }
   
}
