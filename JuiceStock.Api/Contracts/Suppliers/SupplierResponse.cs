namespace JuiceStock.Api.Contracts.Suppliers
{
    public class SupplierResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
