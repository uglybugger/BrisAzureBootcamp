using Nimbus.MessageContracts;

namespace StockTicker
{
    public class StockPriceChangedEvent : IBusEvent
    {
        public string AsxCode { get; set; }
        public decimal StockPrice { get; set; }

        public StockPriceChangedEvent()
        {
        }

        public StockPriceChangedEvent(string asxCode, decimal stockPrice)
        {
            AsxCode = asxCode;
            StockPrice = stockPrice;
        }
    }
}