using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProcessor
{
    public class CurrencyModel
    {
        [JsonProperty("key")]
        public string Key { set; get; }

        [JsonProperty("name_en")]
        public string Name { set; get; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("updated_at")]
        public string LastPriceUpdateDate { set; get; }

        [JsonProperty("price_change_24h")]
        public float LastDayPriceChange { set; get; }

        [JsonProperty("price_change_7d")]
        public float LastWeekPriceChange { set; get; }

    }
}
