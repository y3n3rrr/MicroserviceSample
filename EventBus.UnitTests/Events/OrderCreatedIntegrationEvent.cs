using EventBus.Base.Events;

namespace EventBus.UnitTests.Events
{
    public class OrderCreatedIntegrationEvent : IntegrationEvent
    {
        public int Id { get; set; }

        public OrderCreatedIntegrationEvent(int id)
        {
            Id = id;
        }
    }
}