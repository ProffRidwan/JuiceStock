
using JuiceStock.Api.Contracts.Suppliers;
using JuiceStock.Domain.Entities;
namespace JuiceStock.Api.Mappings
{
    public static class SupplierMappings
    {
        public static SupplierResponse ToResponse(this Supplier supplier)
        {
            return new SupplierResponse
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Balance = supplier.GetBalance()
            };
        }
    }
}
