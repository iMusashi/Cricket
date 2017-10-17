using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardWPF
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

    public class RootObject : IRootObject
    {
        public Provider provider { get; set; }
        public List<Datum> data { get; set; }
        public bool cache { get; set; }

    }
    
    public class RootObjectScore : IRootObject
    {
        public Provider provider { get; set; }
        public string   score { get; set; }
        public string   description { get; set; }
        [JsonProperty(PropertyName="team-1")]
        public string   team1 { get; set; }
        [JsonProperty(PropertyName="team-2")]
        public string   team2 { get; set; }
        public bool cache { get; set; }

    }

    interface IRootObject
    {
        Provider provider { get; set; }

        bool cache { get; set; }
    }
}
