using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using MailService.Models;
using MailService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Product.API.Services;
using RabbitMQ.Client;
using System;
using System.Threading.Tasks;

namespace MailService
{
    public class Program
    {
        private static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        public static IConfigurationRoot configuration;

        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var sp = services.BuildServiceProvider();
            IEventBus eventBus = sp.GetRequiredService<IEventBus>();
            eventBus.Subscribe<ProductCreatedIntegrationEvent, ProductCreatedIntegrationEventHandler>();

            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            // kick off asynchronous stuff
            _quitEvent.WaitOne();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .Build();

            services.AddTransient<IMailService, Services.MailService>();
            services.AddTransient<ProductCreatedIntegrationEventHandler>();

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddSingleton(sp =>
            {
                EventBusConfig config = new()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "MailService",
                    EventBusType = EventBusType.RabbitMQ,
                    Connection = new ConnectionFactory()
                    {
                        HostName = "localhost",
                        Port = 5672,
                        UserName = "guest",
                        Password = "guest"
                    }
                };

                return EventBusFactory.Create(config, sp);
            });
        }
    }
}