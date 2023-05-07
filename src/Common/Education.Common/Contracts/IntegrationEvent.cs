using MediatR;

namespace Education.Common.Contracts;

public abstract class IntegrationEvent : INotification
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }

    protected IntegrationEvent(Guid id, DateTime occurredOn)
    {
        this.Id = id;
        this.OccurredOn = occurredOn;
    }
}