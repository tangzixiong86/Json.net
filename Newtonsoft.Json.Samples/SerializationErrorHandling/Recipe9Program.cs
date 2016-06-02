using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// OnErrorAttribute
    /// The OnErrorAttribute works much like the other .NET serialization attributes that Json.NET supports. 
    /// To use it you simply place the attribute on a method that takes the correct parameters: a StreamingContext and an ErrorContext. 
    /// The name of the method doesn't matter.
    /// In this example accessing the Roles property will throw an exception when no roles have been set. 
    /// The HandleError method will set the error when serializing Roles as handled and allow Json.NET to continue serializing the class.
    /// </summary>
    public static class Recipe9Program
    {
        public static void Run()
        {
            PersonError person = new PersonError
            {
                Name = "George Michael Bluth",
                Age = 16,
                Roles = null,
                Title = "Mister Manager"
            };
            string json = JsonConvert.SerializeObject(person,Formatting.Indented);

            Console.WriteLine(json);
            //{
            //  "Name": "George Michael Bluth",
            //  "Age": 16,
            //  "Title": "Mister Manager"
            //}
        }
    }
    public class PersonError
    {
        private List<string> _roles;

        public string Name { get; set; }
        public int Age { get; set; }

        public List<string> Roles
        {
            get
            {
                if (_roles == null)
                {
                    throw new Exception("Roles not loaded!");
                }

                return _roles;
            }
            set { _roles = value; }
        }

        public string Title { get; set; }

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
}
