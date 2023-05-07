namespace Education.Common.Contracts;

public interface IEventBus
{
    Task Publish<T>(T @event)
        where T : IntegrationEvent;
}