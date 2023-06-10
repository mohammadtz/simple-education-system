using Education.Common.Contracts;
using Education.Common.Dto;
using Education.Financial.Application.Services.Commands;
using Education.Financial.Application.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Modules.Financials;

[ApiController]
[Route("api/[Controller]/[Action]")]
public class FinancialsController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public FinancialsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet("{registrationId}")]
    public async Task<ActionResult<Response>> GetInvoiceByRegistration(string registrationId)
    {
        return await _dispatcher.ExecuteQueryAsync(new GetInvoiceByRegistrationQuery.Query { RegistrationId = registrationId });
    }

    [HttpPost("{invoiceId}")]
    public async Task<ActionResult<Response>> Payment(string invoiceId, bool isSuccess)
    {
        return await _dispatcher.ExecuteCommandAsync(new InvoicePaymentCommand.Command
        {
            InvoiceId = invoiceId,
            IsSuccess = isSuccess,
        });
    }
}