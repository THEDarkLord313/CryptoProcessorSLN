using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProcessor
{
    public static class Report
    {
        public static void SaveObjectJson(CurrencyModel cm)
        {
            if (File.Exists("Prices.json"))
            {
                var jsonString = File.ReadAllText("Prices.json");
                var currencyList = JsonConvert.DeserializeObject<List<CurrencyModel>>(jsonString)
                  ?? new List<CurrencyModel>();
                currencyList.Add(cm);
                jsonString = JsonConvert.SerializeObject(currencyList, Formatting.Indented);
                File.WriteAllText("Prices.json", jsonString);
            }
            else
            {
                List<CurrencyModel> currencies = new List<CurrencyModel>
                    {
                        cm
                    };
                var jsonString = JsonConvert.SerializeObject(currencies, Formatting.Indented);
                File.WriteAllText("Prices.json", jsonString);
            }
        }
    }
}
