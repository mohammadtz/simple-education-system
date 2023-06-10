using Education.Common.Contracts;

namespace Education.Financial.Event;

public class InvoicePayedSuccessful : IntegrationEvent
{
    public InvoicePayedSuccessful(Guid id, DateTime occurredOn) : base(id, occurredOn)
    {
    }
}