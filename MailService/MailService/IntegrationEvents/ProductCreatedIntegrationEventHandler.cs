using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using MailService.Models;
using MailService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductCreatedIntegrationEventHandler : IIntegrationEventHandler<ProductCreatedIntegrationEvent>
    {
        private readonly IEventBus eventBus;
        private readonly IMailService mailService;

        public ProductCreatedIntegrationEventHandler(IEventBus eventBus, IMailService mailService)
        {
            this.eventBus = eventBus;
            this.mailService = mailService;
        }

        public async Task Handle(ProductCreatedIntegrationEvent @event)
        {
            try
            {
                await mailService.SendEmailAsync(new MailRequest
                {
                    Body = $"New product, {@event.ProductName} has been added to system",
                    Subject = "New Product Available",
                    ToEmail = "y3n3rrr@gmail.com",
                });
            }
            catch (Exception ex)
            {
            }
        }
    }
}