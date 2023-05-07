using Education.Common.Contracts;
using MediatR;

namespace Education.Common.Services;

public class InMemoryEventBus : IEventBus
{
    private readonly IMediator _mediator;

    public InMemoryEventBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Publish<T>(T @event) where T : IntegrationEvent
    {
        await _mediator.Publish(@event);
    }
}