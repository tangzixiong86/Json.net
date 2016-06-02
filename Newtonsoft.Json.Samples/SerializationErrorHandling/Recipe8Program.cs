using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.IO;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Error Event
    /// The Error event is an event handler found on JsonSerializer. 
    /// The error event is raised whenever an exception is thrown while serializing or deserializing JSON. 
    /// Like all settings found on JsonSerializer, it can also be set on JsonSerializerSettings and passed to the serialization methods on JsonConvert.
    /// </summary>
    public static class Recipe8Program
    {
        public static void Run()
        {
            List<string> errors = new List<string>();
            string jsonStr = @"[
                          '2009-09-09T00:00:00Z',
                          'I am not a date and will error!',
                          [
                            1
                          ],
                          '1977-02-20T00:00:00Z',
                          null,
                          '2000-12-01T00:00:00Z'
                        ]";
            //List<DateTime> c = JsonConvert.DeserializeObject<List<DateTime>>(jsonStr,
            //    new JsonSerializerSettings
            //    {
            //        Error = delegate (object sender, ErrorEventArgs args)
            //        {
            //            errors.Add(args.ErrorContext.Error.Message);
            //            args.ErrorContext.Handled = true;
            //        },
            //        Converters = { new IsoDateTimeConverter() }
            //    });



            //One thing to note with error handling in Json.NET is that an unhandled error will bubble up and raise the event on each of its parents. 
            //For example an unhandled error when serializing a collection of objects will be raised twice, once against the object and then again on the collection.
            //This will let you handle an error either where it occurred or on one of its parents.
            //If you aren't immediately handling an error and only want to perform an action against it once,
            //then you can check to see whether the ErrorEventArgs's CurrentObject is equal to the OriginalObject. 
            //OriginalObject is the object that threw the error and CurrentObject is the object that the event is being raised against. 
            //They will only equal the first time the event is raised against the OriginalObject.
            JsonSerializer serializer = new JsonSerializer();
            serializer.Error += (sender, args) =>
            {
                if (args.CurrentObject == args.ErrorContext.OriginalObject)
                {
                    errors.Add(args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }
            };
            JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
            serializer.Deserialize<List<DateTime>>(reader);

            foreach (string error in errors)
            {
                Console.WriteLine(error);
            }

            // 2009-09-09T00:00:00Z
            // 1977-02-20T00:00:00Z
            // 2000-12-01T00:00:00Z

            // The string was not recognized as a valid DateTime. There is a unknown word starting at index 0.
            // Unexpected token parsing date. Expected String, got StartArray.
            // Cannot convert null value to System.DateTime.
        }
    }
}
