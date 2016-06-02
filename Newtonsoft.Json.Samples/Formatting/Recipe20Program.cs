using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// DefaultValueHandling
    /// DefaultValueHandling is an option on the JsonSerializer and controls how the serializer handles properties with a default value. 
    /// Setting a value of DefaultValueHandling.Ignore will make the JsonSerializer skip writing any properties that have a default value to the JSON result. 
    /// For object references this will be null. For value types like int and DateTime the serializer will skip the default uninitialized value for that value type.
    /// Json.NET also allows you to customize what the default value of an individual property is using the DefaultValueAttribute.
    /// For example, if a string property called Department always returns an empty string in its default state 
    /// and you don't want that empty string in your JSON, then placing the DefaultValueAttribute on Department with that value will mean Department is no longer written to JSON unless it has a value.
    /// DefaultValueHandling can also be customized on individual properties using the JsonPropertyAttribute. 
    /// The JsonPropertyAttribute value of DefaultValueHandling will override the setting on the JsonSerializer for that property.
    /// </summary>
    public static class Recipe20Program
    {
        public static void Run()
        {
            Invoice invoice = new Invoice
            {
                Company = "Acme Ltd.",
                Amount = 50.0m,
                Paid = false,
                FollowUpDays = 30,
                FollowUpEmailAddress = string.Empty,
                PaidDate = null
            };

            string included = JsonConvert.SerializeObject(invoice,
                Formatting.Indented,
                new JsonSerializerSettings { });

            // {
            //   "Company": "Acme Ltd.",
            //   "Amount": 50.0,
            //   "Paid": false,
            //   "PaidDate": null,
            //   "FollowUpDays": 30,
            //   "FollowUpEmailAddress": ""
            // }

            string ignored = JsonConvert.SerializeObject(invoice,
                Formatting.Indented,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });

            // {
            //   "Company": "Acme Ltd.",
            //   "Amount": 50.0
            // }
        }
    }
    public class Invoice
    {
        public string Company { get; set; }
        public decimal Amount { get; set; }

        // false is default value of bool
        public bool Paid { get; set; }
        // null is default value of nullable
        public DateTime? PaidDate { get; set; }

        //customize default values
        [DefaultValue(30)]
        public int FollowUpDays { get; set; }

        [DefaultValue("")]
        public string FollowUpEmailAddress { get; set; }
    }

}
