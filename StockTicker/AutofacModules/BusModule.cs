using System;
using System.Reflection;
using Autofac;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Infrastructure.Logging;
using Module = Autofac.Module;

namespace StockTicker.AutofacModules
{
    public class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            const string connectionString =
                "Endpoint=sb://readify-ipo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SBiN+3OS+GR5t+t3hRZ1lj/vRFXLWyVI5xWdg0Rh+uI=";

            var handlerTypesProvider = new AssemblyScanningTypeProvider(Assembly.GetExecutingAssembly());
            //builder.RegisterType<ConsoleLogger>()
            builder.RegisterType<NullLogger>()
                   .As<ILogger>()
                   .SingleInstance();
            builder.RegisterNimbus(handlerTypesProvider);
            builder.Register(componentContext => new BusBuilder()
                                                     .Configure()
                                                     .WithConnectionString(connectionString)
                                                     .WithNames("StockTicker", Environment.MachineName)
                                                     .WithTypesFrom(handlerTypesProvider)
                                                     .WithAutofacDefaults(componentContext)
                                                     .Build())
                   .As<IBus>()
                   .AutoActivate()
                   .OnActivated(c => c.Instance.Start())
                   .SingleInstance();
        }
    }
}