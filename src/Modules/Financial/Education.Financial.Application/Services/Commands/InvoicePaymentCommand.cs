using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Financial.Domain.Payments;
using Education.Financial.Event;
using Education.Financial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Education.Financial.Application.Services.Commands;

public abstract class InvoicePaymentCommand
{
    public class Command : ICommand<Response>
    {
        public Guid Id { get; }
        public string InvoiceId { get; set; } = null!;
        public bool IsSuccess { get; set; }
    }

    public class Handler : ICommandHandler<Command, Response>
    {
        private readonly FinancialDbContext _context;
        private readonly IEventBus _eventBus;

        public Handler(FinancialDbContext context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var response = new Response();
            var invoiceId = Guid.Parse(request.InvoiceId);

            try
            {
                var hasSuccessPayment = await _context.Invoices.AnyAsync(x => x.Id == invoiceId && x.PaymentType == Domain.Financial.PaymentType.PayedSuccessful);

                if (hasSuccessPayment) return response.NotValid("You Are Pay this invoice before");

                var payment = new Payment
                {
                    InvoiceId = invoiceId,
                    ReferenceId = Guid.NewGuid().ToString(),
                    IsSuccess = request.IsSuccess
                };

                await _context.Payments.AddAsync(payment, cancellationToken);
                await _context.SaveChangesAsync();

                if (request.IsSuccess)
                {
                    await _eventBus.Publish(new InvoicePayedSuccessful(invoiceId, DateTime.Now));
                }
                else
                {
                    throw new Exception("Payment Failed");
                }

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await _eventBus.Publish(new InvoicePayedFailed(invoiceId, DateTime.Now));
                return response.Exception(e);
            }
        }
    }
}