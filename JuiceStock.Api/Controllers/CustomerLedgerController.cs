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
      [FromQuery] GetLedgerRequest request)
    {
        var (entries, totalCount) = await _customerService
            .GetCustomerLedgerPaged(
                customerId,
                request.Page,
                request.PageSize,
                request.Type,
                request.StartDate,
                request.EndDate);

        var response = new PagedResponse<LedgerEntryResponse>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize),
            Data = entries.Select(e => e.ToResponse()).ToList()
        };

        return Ok(response);
    }
}