using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// DateTime JsonConverters
    /// The default format used by Json.NET is the ISO 8601 standard: "2012-03-19T07:22Z".
    /// Prior to Json.NET 4.5 dates were written using the Microsoft format: "\/Date(1198908717056)\/". 
    /// If you want to use this format, or you want to maintain compatibility with Microsoft JSON serializers or older versions of Json.NET, then change the DateFormatHandling setting to MicrosoftDateFormat.
    /// The DateTimeZoneHandling setting can be used to convert a DateTime's DateTimeKind when serializing. 
    /// For example set DateTimeZoneHandling to Utc to serialize all DateTimes as UTC dates. Note that this setting does not effect DateTimeOffsets.
    /// If your dates don't follow the ISO 8601 standard, then the DateFormatString setting can be used to customize the format of date strings that are read and written using .NET's custom date and time format syntax.
    /// With no standard for dates in JSON, the number of possible different formats when interoping with other systems is endless. 
    /// Fortunately Json.NET has a solution to deal with reading and writing custom dates: JsonConverters. A JsonConverter is used to override how a type is serialized.
    /// </summary>
    public static class Recipe16Program
    {
        public static void Run()
        {
            LogEntry entry = new LogEntry
            {
                LogDate = new DateTime(2009, 2, 15, 0, 0, 0, DateTimeKind.Utc),
                Details = "Application started."
            };

            //From Json.NET 4.5 and onwards dates are written using the ISO 8601 format by default, and using this converter is unnecessary.
            //IsoDateTimeConverter serializes a DateTime to an ISO 8601 formatted string: "2009-02-15T00:00:00Z"
            //The IsoDateTimeConverter class has a property, DateTimeFormat, to further customize the formatted string.

            string isoJson = JsonConvert.SerializeObject(entry);
            // {"Details":"Application started.","LogDate":"2009-02-15T00:00:00Z"}
            Console.WriteLine("IsoDateTimeConverter:" + isoJson);

            JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            string microsoftJson = JsonConvert.SerializeObject(entry, microsoftDateFormatSettings);
            // {"Details":"Application started.","LogDate":"\/Date(1234656000000)\/"}
            Console.WriteLine("MicrosoftDateFormat:" + microsoftJson);


            //The JavaScriptDateTimeConverter class is one of the two DateTime JsonConverters that come with Json.NET. 
            //This converter serializes a DateTime as a JavaScript Date object: new Date(1234656000000)
            //Technically this is invalid JSON according to the spec, but all browsers and some JSON frameworks, including Json.NET, support it.
            string javascriptJson = JsonConvert.SerializeObject(entry, new JavaScriptDateTimeConverter());
            // {"Details":"Application started.","LogDate":new Date(1234656000000)}
            Console.WriteLine("JavaScriptDateTimeConverter:" + javascriptJson);
        }
    }
    public class LogEntry
    {
        public string Details { get; set; }
        public DateTime LogDate { get; set; }
    }

}
