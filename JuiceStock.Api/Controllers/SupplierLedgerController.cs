using JuiceStock.Api.Contracts.Ledger;
using JuiceStock.Api.Mappings;
using JuiceStock.Application.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace JuiceStock.Api.Controllers
{
    [ApiController]
    [Route("api/suppliers/{supplierId:guid}/ledger")]
    public class SupplierLedgerController : ControllerBase
    {
        private readonly SupplierService _supplierService;


        public SupplierLedgerController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost]
        public IActionResult Credit(Guid supplierId, CreditRequest request)
        {
            _supplierService.CreditSupplier(
                supplierId,
                request.Amount,
               request.Description
                );

            return NoContent();
        }

        [HttpPost]
        public IActionResult Debiit(Guid supplierId, DebitRequest request)
        {
            _supplierService.DebitSupplier(
                supplierId,
                request.Amount,
                request.Description
                );
            return NoContent();

        }
        [HttpGet]
        public IActionResult GetLedger(Guid supplierId, [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
        {
            var entries = _supplierService.GetSupplierLedger(supplierId);

            var pagedEntries = entries
            .OrderByDescending(e => e.EntryDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => e.ToResponse())
            .ToList();

            return Ok(pagedEntries);
        }
    }
}
