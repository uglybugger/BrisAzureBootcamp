using System;
using System.Threading.Tasks;
using Nimbus.Handlers;

namespace StockTicker.EventHandlers.WhenTheStockPriceChanges
{
    public class CalculateMyNetWorth : IHandleMulticastEvent<StockPriceChangedEvent>
    {
        public async Task Handle(StockPriceChangedEvent busEvent)
        {
            if (busEvent.AsxCode != "READIFY") return;

            var unitHoldings = 10m;
            var netWorth = busEvent.StockPrice*unitHoldings;

            Console.WriteLine("My net worth is {0}", netWorth);
        }
    }
}