using System;
using System.Threading;
using System.Threading.Tasks;
using Nimbus;

namespace StockTicker
{
    public class Ticker
    {
        private readonly IBus _bus;

        public Ticker(IBus bus)
        {
            _bus = bus;
        }

        public async Task DoYourThing()
        {
            var stockPrice = 0.10m;

            while (!Console.KeyAvailable)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Console.WriteLine("Stock price for READIFY is {0}", stockPrice);
                await _bus.Publish(new StockPriceChangedEvent("READIFY", stockPrice));
                stockPrice *= 1.01m;
            }
        }
    }
}