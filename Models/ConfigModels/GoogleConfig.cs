using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfigModels
{
    public class GoogleConfig
    {
        //       "ApiKey": "",
        //"SearchEngineId": "",
        public string API_KEY { get; set; } = null!;
        public string SEARCH_ENGINE_ID { get; set; } = null!;
        public string CLIENT_ID { get; set; } = null!;
        public string CLIENT_SECRET { get; set;} = null!;
    }
}
