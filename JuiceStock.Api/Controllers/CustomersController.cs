using JuiceStock.Api.Contracts.Customers;
using JuiceStock.Application.Customers;
using Microsoft.AspNetCore.Mvc;

namespace JuiceStock.API.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public IActionResult Create(CreateCustomerRequest request)
    {
        var customerId = _customerService.CreateCustomer(request.Name);
        return CreatedAtAction(nameof(GetById), new { id = customerId }, null);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var customer = _customerService.GetCustomer(id);
        return Ok(customer);
    }

    [HttpPost("debit")]
    public IActionResult Debit(DebitCustomerRequest request)
    {
        _customerService.DebitCustomer(
            request.CustomerId,
            request.Amount,
            request.Description
        );

        return Ok();
    }

    [HttpPost("credit")]
    public IActionResult Credit(CreditCustomerRequest request)
    {
        _customerService.CreditCustomer(
            request.CustomerId,
            request.Amount,
            request.Description
        );

        return Ok();
    }
}