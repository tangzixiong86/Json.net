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
    /// ConstructorHandling setting
    ///  Default:First attempt to use the public default constructor, then fall back to single paramatized constructor, then the non-public default constructor.  
    /// AllowNonPublicDefaultConstructor:Json.NET will use a non-public default constructor before falling back to a paramatized constructor.  
    /// </summary>
    public static class Recipe51Program
    {
        public static void Run()
        {
            string json = @"{'Url':'http://www.google.com'}";

            try
            {
                JsonConvert.DeserializeObject<Website>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Value cannot be null.
                // Parameter name: website
            }

            Website website = JsonConvert.DeserializeObject<Website>(json, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            });

            Console.WriteLine(website.Url);
            // http://www.google.com
        }
    }
    public class Website
    {
        public string Url { get; set; }

        private Website()
        {
        }

        public Website(Website website)
        {
            if (website == null)
            {
                throw new ArgumentNullException(nameof(website));
            }

            Url = website.Url;
        }
    }

}
