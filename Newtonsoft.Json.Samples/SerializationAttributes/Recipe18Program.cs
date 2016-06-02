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
    /// DataMemberAttribute
    /// If a class has many properties and you only want to serialize a small subset of them, 
    /// then adding JsonIgnore to all the others will be tedious and error prone. 
    /// The way to tackle this scenario is to add the DataContractAttribute to the class and DataMemberAttribute to the properties to serialize. 
    /// This is opt-in serialization - only the properties you mark up will be serialized, unlike opt-out serialization using JsonIgnoreAttribute.
    /// </summary>
    public static class Recipe18Program
    {
        public static void Run()
        {
            Computer computer = new Computer()
            {
                Name = "thinkpad 404",
                SalePrice=10000,
                Manufacture="lenovo",
                StockCount=2,
                WholeSalePrice=20000,
                NextShipmentDate = new DateTime(2015, 12, 1)
            };
            string json = JsonConvert.SerializeObject(computer, Formatting.Indented);
            Console.WriteLine(json);
            //{
            //   "Name": "thinkpad 404",
            //  "SalePrice": 10000.0
            //}
        }
    }
    [DataContract]
    public class Computer
    {
        // included in JSON
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal SalePrice { get; set; }

        // ignored
        public string Manufacture { get; set; }
        public int StockCount { get; set; }
        public decimal WholeSalePrice { get; set; }
        public DateTime NextShipmentDate { get; set; }
    }

}
