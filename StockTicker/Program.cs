using System.Threading.Tasks;
using Autofac;

namespace StockTicker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            using (var container = IoC.LetThereBeIoC())
            {
                //var ticker = new Ticker();
                var ticker = container.Resolve<Ticker>();
                await ticker.DoYourThing();
            }
        }
    }
}