using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoreboard
{
    class Program
    {
        private static Lazy<DownloadClient> _objClient;

        public static DownloadClient objClient
        {
            get
            {
                if (_objClient == null)
                    _objClient = new Lazy<DownloadClient>(() => new DownloadClient());
                return _objClient.Value;
            }
        }

        

        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.Serialize();
            objClient.SetupClientProperties();
            obj.DeSerialize();

        }

        void DeSerialize()
        {
            //FileReader objReader = new FileReader("SerializedCustomer");
            FileReader objReader = new FileReader("CricketMatches.txt");
            string sContent = objReader.ReadFile();

            //dynamic obj = JsonConvert.DeserializeObject(sContent);

            //Customer obj = JsonConvert.DeserializeObject<Customer>(sContent);
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(sContent);
            
        }

        void Serialize()
        {
            Customer obj = new Customer()
            {
                Id = 1,
                Gender = true,
                Name = "Keshav",
                DateOfBirth = new DateTime(1990, 5, 11)
            };

            FileWriter objWriter = new FileWriter("SerializedCustomer");
            string sValue = JsonConvert.SerializeObject(obj);
            objWriter.WriteToFile(sValue);
        }
    }
}
