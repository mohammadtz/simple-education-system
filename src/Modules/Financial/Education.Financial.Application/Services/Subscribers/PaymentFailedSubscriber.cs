using Education.Common.Contracts;
using Education.Financial.Domain.Financial;
using Education.Financial.Event;
using Education.Financial.Infrastructure;

namespace Education.Financial.Application.Services.Subscribers;

public class PaymentFailedSubscriber : IEventSubscriber<InvoicePayedFailed>
{
    private readonly FinancialDbContext _context;

    public PaymentFailedSubscriber(FinancialDbContext context)
    {
        _context = context;
    }

    public async Task Handle(InvoicePayedFailed notification, CancellationToken cancellationToken)
    {
        var invoice = await _context.Invoices.FindAsync(notification.Id, cancellationToken);

        if (invoice == null || invoice.PaymentType == PaymentType.PayedSuccessful) return;

        invoice.PaymentType = PaymentType.PaymentFailed;

        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync(cancellationToken);
    }
}