using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newtonsoft.Json.Samples.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<string> Categories { get; set; }
    }
}
