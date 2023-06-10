using Education.Common.Contracts;
using Education.Financial.Domain.Financial;
using Education.Financial.Event;
using Education.Financial.Infrastructure;

namespace Education.Financial.Application.Services.Subscribers;

public class PaymentSuccessSubscriber : IEventSubscriber<InvoicePayedSuccessful>
{
    private readonly FinancialDbContext _context;

    public PaymentSuccessSubscriber(FinancialDbContext context)
    {
        _context = context;
    }

    public async Task Handle(InvoicePayedSuccessful notification, CancellationToken cancellationToken)
    {
        var invoice = await _context.Invoices.FindAsync(notification.Id, cancellationToken);

        if (invoice == null) return;

        invoice.PaymentType = PaymentType.PayedSuccessful;

        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync(cancellationToken);
    }
}