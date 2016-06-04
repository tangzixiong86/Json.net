using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Samples.Models;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;
using System.Data;

namespace Newtonsoft.Json.Samples
{
    /// <summary>
    /// Deserialize a DataSet
    /// This sample deserializes JSON to a DataSet.
    /// </summary>
    public static class Recipe48Program
    {
        public static void Run()
        {
            string json = @"{
                              'Table1': [
                                {
                                  'id': 0,
                                  'item': 'item 0'
                                },
                                {
                                  'id': 1,
                                  'item': 'item 1'
                                }
                              ]
                            }";

            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);

            DataTable dataTable = dataSet.Tables["Table1"];

            Console.WriteLine(dataTable.Rows.Count);
            // 2

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["id"] + " - " + row["item"]);
            }
            // 0 - item 0
            // 1 - item 1
        }
    }
   
}
