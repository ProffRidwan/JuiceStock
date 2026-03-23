using JuiceStock.Api.Contracts.Suppliers;
using JuiceStock.Api.Mappings;
using JuiceStock.Application.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace JuiceStock.Api.Controllers;

[ApiController]
[Route("api/suppliers")]
public class SuppliersController : ControllerBase
{
    private readonly SupplierService _supplierService;

    public SuppliersController(SupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost]
    public IActionResult Create(CreateSupplierRequest request)
    {
        var supplierId = _supplierService.CreateSupplier(request.Name);

        return CreatedAtAction(
            nameof(GetById),
            new { id = supplierId },
            null
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var supplier = _supplierService.GetSupplier(id);

        return Ok(supplier.ToResponse());
    }
}