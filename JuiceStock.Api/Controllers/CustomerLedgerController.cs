using JuiceStock.Api.Contracts.Ledger;
using JuiceStock.Api.Mappings;
using JuiceStock.Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace JuiceStock.Api.Controllers;

[ApiController]
[Route("api/customers/{customerId:guid}/ledger")]
public class CustomerLedgerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerLedgerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("credit")]
    public IActionResult Credit(Guid customerId, CreditRequest request)
    {
        _customerService.CreditCustomer(
            customerId,
            request.Amount,
            request.Description
        );

        return NoContent();
    }

    [HttpPost("debit")]
    public IActionResult Debit(Guid customerId, DebitRequest request)
    {
        _customerService.DebitCustomer(
            customerId,
            request.Amount,
            request.Description
        );

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetLedger(Guid customerId, [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
    {
        var entries = _customerService.GetCustomerLedger(customerId);

        var pagedEntries = entries
        .OrderByDescending(e => e.EntryDate)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(e => e.ToResponse())
        .ToList();

        return Ok(pagedEntries);
    }
}