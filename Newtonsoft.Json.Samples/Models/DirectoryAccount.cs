using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Samples.Models
{
    public class DirectoryAccount
    {
        // normal deserialization
        public string DisplayName { get; set; }

        // these properties are set in OnDeserialized
        public string UserName { get; set; }
        public string Domain { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // SAMAccountName is not deserialized to any property
            // and so it is added to the extension data dictionary
            string samAccountName = (string)_additionalData["SAMAccountName"];

            Domain = samAccountName.Split('\\')[0];
            UserName = samAccountName.Split('\\')[1];
        }
        public DirectoryAccount()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
    }
}
