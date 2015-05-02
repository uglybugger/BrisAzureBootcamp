using System;
using System.Threading.Tasks;
using Nimbus.Handlers;

namespace StockTicker.EventHandlers.WhenTheStockPriceChanges
{
    public class CalculateGraemesNetWorth : IHandleMulticastEvent<StockPriceChangedEvent>
    {
        public async Task Handle(StockPriceChangedEvent busEvent)
        {
            if (busEvent.AsxCode != "READIFY") return;

            var unitHoldings = 1000000m;
            var netWorth = busEvent.StockPrice*unitHoldings;

            Console.WriteLine("G2's net worth is {0}", netWorth);
        }
    }
}