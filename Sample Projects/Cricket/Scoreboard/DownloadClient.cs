using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    class DownloadClient
    {
        WebClient webclient = new WebClient();

        private Lazy<FileWriter> _filewriter;

        public FileWriter filewriter
        {
            get
            {
                if (_filewriter == null)
                    _filewriter = new Lazy<FileWriter>(() =>  new FileWriter("CricketMatches.txt"));
                return _filewriter.Value;

            }
        }


        internal void SetupClientProperties()
        {
            webclient.Headers.Add("apikey", "QlMIEiiW09N9mCV2uylgtbFYwL13");

            string output = webclient.DownloadString("http://cricapi.com/api/cricket/");

            filewriter.WriteToFile(output);
            //string output = JsonConvert.
        }

    }
}
