using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    class FileReader
    {
        public string sFileName { get; set; }

        public FileReader(string sValue)
        {
            sFileName = AppDomain.CurrentDomain.BaseDirectory + sValue;
        }

        internal string ReadFile()
        {
            string sData = File.ReadAllText(sFileName);
            return sData;
        }

    }
}
