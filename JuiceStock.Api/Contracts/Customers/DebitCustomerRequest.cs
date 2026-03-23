namespace JuiceStock.Api.Contracts.Customers
{
    public record DebitCustomerRequest(
      Guid CustomerId,
      decimal Amount,
      string Description
  );
}
