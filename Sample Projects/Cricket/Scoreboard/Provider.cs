using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    public class Provider
    {
        public string url { get; set; }
        public string source { get; set; }
        public string pubDate { get; set; }
    }

    public class Datum
    {
        public string title { get; set; }
        public string description { get; set; }
        public string unique_id { get; set; }
    }

    public class RootObject
    {
        public Provider provider { get; set; }
        public List<Datum> data { get; set; }
        public bool cache { get; set; }
        
    }
}
