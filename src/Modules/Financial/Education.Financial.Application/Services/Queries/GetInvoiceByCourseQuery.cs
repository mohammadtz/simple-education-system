using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Financial.Domain.Financial;
using Education.Financial.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Education.Financial.Application.Services.Queries;

public abstract class GetInvoiceByRegistrationQuery
{
    public class Query : IQuery<Response>
    {
        public string? RegistrationId { get; set; }
    }

    public class Handler : IQueryHandler<Query, Response>
    {
        private readonly FinancialDbContext _context;

        public Handler(FinancialDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                if (request.RegistrationId == null)
                    return response.NotValid("CourseId is not valid");

                var result = await _context.Invoices.FirstOrDefaultAsync(x =>
                    x.SourceId == Guid.Parse(request.RegistrationId) && x.Type == InvoiceType.Registration, cancellationToken);

                return response.Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return response.Exception(e);
            }
        }
    }
}