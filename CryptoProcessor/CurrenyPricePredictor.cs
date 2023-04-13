using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProcessor
{
    public static class CurrenyPricePredictor
    {
        private static float predictedPrice = 0;
        public static void PredictPrice(float[] lastPrices)
        {
            if (predictedPrice != 0)
            {
                Console.WriteLine($"\n \r There's a {Math.Abs(predictedPrice - lastPrices[0]) / ((lastPrices[0] + predictedPrice) / 2) * 100}% differnce between predicted and the actual price. Current price: {lastPrices[0]}, predicted price: {predictedPrice} \n \r");
            }
            predictedPrice = (float)(lastPrices[0] * 0.6 + lastPrices[1] * 0.3 + lastPrices[2] * 0.1);
            Console.WriteLine($"We predict the next price will be {predictedPrice}");
        }
    }
}
