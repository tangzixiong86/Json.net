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
using Newtonsoft.Json.Converters;
using System.Data;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Serialize Raw JSON value
    /// This sample uses JRaw properties to serialize JSON with raw content.
    /// </summary>
    public static class Recipe44Program
    {
        public static void Run()
        {
            JavaScriptSettings settings = new JavaScriptSettings
            {
                OnLoadFunction = new JRaw("OnLoad"),
                OnUnloadFunction = new JRaw("function(e) { alert(e); }")
            };

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            Console.WriteLine(json);
            // {
            //   "OnLoadFunction": OnLoad,
            //   "OnUnloadFunction": function(e) { alert(e); }
            // }
        }
    }
    public class JavaScriptSettings
    {
        public JRaw OnLoadFunction { get; set; }
        public JRaw OnUnloadFunction { get; set; }
    }
}
