using System;
using EventBus.Base.Events;

namespace EventBus.Base.Abstraction
{
    //servislerin hangi eventi subscript yapacaklarini soyledikleri EventBus
    public interface IEventBus
    {
        Task Publish(IntegrationEvent @event);

        void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void UnSubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    }
}