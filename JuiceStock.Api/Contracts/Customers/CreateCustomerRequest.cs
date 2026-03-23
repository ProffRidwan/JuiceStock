namespace JuiceStock.Api.Contracts.Customers
{
    //public record CreateCustomerRequest(string Name);
    public class CreateCustomerRequest
    {
        public string Name { get; set; } = string.Empty;
    }

}
