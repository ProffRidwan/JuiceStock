namespace JuiceStock.Api.Contracts.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid SupplierId { get; set; }
    }
}
