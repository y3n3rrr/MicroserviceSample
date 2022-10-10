using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.API.Services
{
    public class ProductCreatedIntegrationEvent : IntegrationEvent
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public ProductCreatedIntegrationEvent()
        {
        }

        public ProductCreatedIntegrationEvent(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
    }
}