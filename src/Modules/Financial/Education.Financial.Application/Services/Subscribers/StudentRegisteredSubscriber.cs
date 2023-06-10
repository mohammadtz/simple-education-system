using Education.Common.Contracts;
using Education.Courses.Event;
using Education.Financial.Domain.Financial;
using Education.Financial.Infrastructure;

namespace Education.Financial.Application.Services.Subscribers;

public class StudentRegisteredSubscriber : IEventSubscriber<StudentRegisteredToCourseEvent>
{
    private readonly FinancialDbContext _context;

    public StudentRegisteredSubscriber(FinancialDbContext context)
    {
        _context = context;
    }

    public async Task Handle(StudentRegisteredToCourseEvent notification, CancellationToken cancellationToken)
    {
        var invoice = new Invoice
        {
            SourceId = notification.Id,
            Type = InvoiceType.Registration,
            PaymentType = PaymentType.NotPay,
            Price = 15000
        };

        await _context.Invoices.AddAsync(invoice, cancellationToken);
        await _context.SaveChangesAsync();
    }
}