namespace JuiceStock.Api.Contracts.Customers
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
