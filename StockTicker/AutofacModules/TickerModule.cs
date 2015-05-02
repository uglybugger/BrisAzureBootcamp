using Autofac;

namespace StockTicker.AutofacModules
{
    public class TickerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Ticker>()
                   .AsSelf()
                   .InstancePerDependency();
        }
    }
}