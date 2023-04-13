using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProcessor
{
    public class Result
    {
        [JsonProperty("result")]
        public List<CurrencyModel> Currencies { get; set; }
    }
}
