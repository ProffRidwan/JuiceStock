using JuiceStock.Api.Contracts.Common;
using JuiceStock.Api.Contracts.Ledger;
using JuiceStock.Api.Mappings;
using JuiceStock.Application.Customers;
using JuiceStock.Domain.Enums;
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
    public async Task<IActionResult> GetLedger(
    Guid customerId,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] LedgerEntryType? type = null,
    [FromQuery] DateTime? startDate = null,
    [FromQuery] DateTime? endDate = null)
    {
        var (entries, totalCount) = await _customerService
            .GetCustomerLedgerPaged(
                customerId,
                page,
                pageSize,
                type,
                startDate,
                endDate);

        var response = new PagedResponse<LedgerEntryResponse>
        {
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
            Data = entries.Select(e => e.ToResponse()).ToList()
        };

        return Ok(response);
    }
}