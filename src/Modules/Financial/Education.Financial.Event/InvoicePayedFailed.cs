using Education.Common.Contracts;

namespace Education.Financial.Event;

public class InvoicePayedFailed : IntegrationEvent
{
    public InvoicePayedFailed(Guid id, DateTime occurredOn) : base(id, occurredOn)
    {
    }
}