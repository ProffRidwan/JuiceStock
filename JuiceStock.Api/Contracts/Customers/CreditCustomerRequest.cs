namespace JuiceStock.Api.Contracts.Customers
{
    public record CreditCustomerRequest(
     Guid CustomerId,
     decimal Amount,
     string Description
 );
}
