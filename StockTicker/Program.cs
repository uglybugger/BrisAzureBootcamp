using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockTicker
{
    class Program
    {
        static void Main(string[] args)
        {
            var stockPrice = 0.10m;

            while (!Console.KeyAvailable)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Console.WriteLine("Stock price for READIFY is {0}", stockPrice);
                // publish "StockPriceChangedEvent"
                stockPrice *= 1.01m;
            }
        }
    }
}
