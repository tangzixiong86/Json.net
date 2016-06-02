using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Samples.Models
{
    public class User
    {
        public string UserName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public UserStatus Status { get; set; }

    }
}
