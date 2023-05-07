using MediatR;

namespace Education.Common.Contracts;

public interface IEventSubscriber<in TIntegrationEvent> : INotificationHandler<TIntegrationEvent>
    where TIntegrationEvent : IntegrationEvent
{
}
