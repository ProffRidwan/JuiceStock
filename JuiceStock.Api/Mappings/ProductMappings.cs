using JuiceStock.Api.Contracts.Products;
using JuiceStock.Domain.Entities;

namespace JuiceStock.Api.Mappings
{
    public static class ProductMappings
    {
        public static ProductResponse ToResponse(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.ProductCategory?.Name,
                SupplierName = product.Supplier?.Name
            };
        }
    }
}
