using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CryptoProcessor
{
    internal class Program
    {
        static Timer timer = new Timer(0.1);
        static void Main(string[] args)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            Console.ReadKey();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 300000 ms = 5m
            timer.Interval = 300000;
            Dictionary<string, CurrencyModel> currency = new Dictionary<string, CurrencyModel>();
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api.wallex.ir/v1/currencies/stats");
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                var currencyList = JsonConvert.DeserializeObject<Result>(json);
                foreach (var c in currencyList.Currencies)
                {
                    currency.Add(c.Key, c);
                }

                float[] prices = new float[] { currency["BTC"].Price, currency["BTC"].LastDayPriceChange + currency["BTC"].Price, currency["BTC"].Price + currency["BTC"].LastWeekPriceChange };
                CurrenyPricePredictor.PredictPrice(prices);
                Report.SaveObjectJson(currency["BTC"]);
            }
        }
    }
}
