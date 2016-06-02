using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using System.Diagnostics;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// ITraceWriter
    /// The Json.NET serializer supports logging and debugging using the ITraceWriter interface. 
    /// By assigning a trace writer you can capture serialization messages and errors and debug what happens inside the Json.NET serializer when serializing and deserializing JSON.. 
    /// A trace writer can be assigned using properties on JsonSerializerSettings or JsonSerializer.
    /// Json.NET has two implementations of ITraceWriter: MemoryTraceWriter, which keeps messages in memory for simple debugging, like the example above, 
    /// and DiagnosticsTraceWriter, which writes messages to any System.Diagnostics.TraceListeners your application is using.
    /// </summary>
    public static class Recipe27Program
    {
        public static void Run()
        {
            Staff staff = new Staff();
            staff.Name = "Arnie Admin";
            staff.Roles = new List<string> { "Administrator" };
            staff.StartDate = new DateTime(2000, 12, 12, 12, 12, 12, DateTimeKind.Utc);

            ITraceWriter traceWriter = new MemoryTraceWriter();

            JsonConvert.SerializeObject(
                staff,
                new JsonSerializerSettings { TraceWriter = traceWriter, Converters = { new JavaScriptDateTimeConverter() } });

            Console.WriteLine(traceWriter);
            // 2012-11-11T12:08:42.761 Info Started serializing Newtonsoft.Json.Tests.Serialization.Staff. Path ''.
            // 2012-11-11T12:08:42.785 Info Started serializing System.DateTime with converter Newtonsoft.Json.Converters.JavaScriptDateTimeConverter. Path 'StartDate'.
            // 2012-11-11T12:08:42.791 Info Finished serializing System.DateTime with converter Newtonsoft.Json.Converters.JavaScriptDateTimeConverter. Path 'StartDate'.
            // 2012-11-11T12:08:42.797 Info Started serializing System.Collections.Generic.List`1[System.String]. Path 'Roles'.
            // 2012-11-11T12:08:42.798 Info Finished serializing System.Collections.Generic.List`1[System.String]. Path 'Roles'.
            // 2012-11-11T12:08:42.799 Info Finished serializing Newtonsoft.Json.Tests.Serialization.Staff. Path ''.
            // 2013-05-18T21:38:11.255 Verbose Serialized JSON: 
            // {
            //   "Name": "Arnie Admin",
            //   "StartDate": new Date(
            //     976623132000
            //   ),
            //   "Roles": [
            //     "Administrator"
            //   ]
            // }
        }
    }

    public class Staff
    {
        public string Name { get; set; }
        public List<string> Roles { get; set; }
        public DateTime StartDate { get; set; }
    }
}
