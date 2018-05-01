using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardWPF
{
    public class ScoreboardBL
    {
        public string sFilePath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "Scoreboard.txt";

        private WebClient _webclient;

        public WebClient webclient
        {
            get
            {
                if (_webclient == null)
                    _webclient = new WebClient();
                return _webclient;
            }
        }

        internal Action<IRootObject> scoreboardBO;

        internal ScoreboardBL(Action<IRootObject> ScoreboardBO)
        {
            scoreboardBO = ScoreboardBO;
            webclient.Headers.Add("apikey", "your api key");
        }

        internal void DownloadCricketInfo()
        {
            
            string cricData = webclient.DownloadString("http://www.cricapi.com/api/cricket/");

            RootObject scoreboardData;
            DeserializeCricData(cricData, out scoreboardData);

            scoreboardBO(scoreboardData);
        }

        internal RootObjectScore DownloadCricketInfo(string unique_id)
        {
            //webclient.Headers.Add("apikey", "your api key");
            string dlstring = "http://www.cricapi.com/api/cricketScore?unique_id=" + unique_id;
            string cricData = webclient.DownloadString(dlstring);

            RootObjectScore scoreboardData;
            DeserializeCricData(cricData, out scoreboardData);

            return scoreboardData;
            //scoreboardBO(scoreboardData);
        }

        private void DeserializeCricData(string cricData, out RootObject scoreboardData)
        {
            scoreboardData = JsonConvert.DeserializeObject<RootObject>(cricData);
        }

        private void DeserializeCricData(string cricData, out RootObjectScore scoreboardData)
        {
            scoreboardData = JsonConvert.DeserializeObject<RootObjectScore>(cricData);
        }
    }
}
