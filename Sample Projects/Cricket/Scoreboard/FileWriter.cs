using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    class FileWriter
    {
        public string sFileName { get; set; }

        public FileWriter(string sValue)
        {
            sFileName = AppDomain.CurrentDomain.BaseDirectory + sValue;
        }

        internal void WriteToFile(string sValue)
        {
            if (!File.Exists(sFileName))
                File.Create(sFileName);
            File.WriteAllText(sFileName, sValue);
        }
    }
}
