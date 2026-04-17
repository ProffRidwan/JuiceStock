using JuiceStock.Api.Contracts.Common;
using JuiceStock.Api.Contracts.Ledger;
using JuiceStock.Api.Mappings;
using JuiceStock.Application.Customers;
using JuiceStock.Application.Suppliers;
using JuiceStock.Domain.Enums;
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
        public async Task<IActionResult> GetLedger(
    Guid supplierId,
        [FromQuery] GetLedgerRequest request)
        {
            var (entries, totalCount) = await _supplierService
                .GetSupplierLedgerPaged(
                    supplierId,
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
}
