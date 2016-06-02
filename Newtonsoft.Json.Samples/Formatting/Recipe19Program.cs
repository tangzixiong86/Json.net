using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// NullValueHandling
    /// NullValueHandling is an option on the JsonSerializer and controls how the serializer handles properties with a null value. 
    /// By setting a value of NullValueHandling.Ignore the JsonSerializer skips writing any properties that have a value of null.
    /// NullValueHandling can also be customized on individual properties using the JsonPropertyAttribute. 
    /// The JsonPropertyAttribute value of NullValueHandling will override the setting on the JsonSerializer for that property.
    /// </summary>
    public static class Recipe19Program
    {
        public static void Run()
        {
            Movie movie = new Movie();
            movie.Name = "Bad Boys III";
            movie.Description = "It's no Bad Boys";

            string included = JsonConvert.SerializeObject(movie,
                Formatting.Indented,
                new JsonSerializerSettings { });

            // {
            //   "Name": "Bad Boys III",
            //   "Description": "It's no Bad Boys",
            //   "Classification": null,
            //   "Studio": null,
            //   "ReleaseDate": null,
            //   "ReleaseCountries": null
            // }

            string ignored = JsonConvert.SerializeObject(movie,
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            // {
            //   "Name": "Bad Boys III",
            //   "Description": "It's no Bad Boys"
            // }
        }
    }
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public string Studio { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<string> ReleaseCountries { get; set; }
    }

}
