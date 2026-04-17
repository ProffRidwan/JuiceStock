namespace JuiceStock.Api.Contracts.Products
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
    }
}
