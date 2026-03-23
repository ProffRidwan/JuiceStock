namespace JuiceStock.Api.Contracts.Ledger
{
    public class CreditRequest
    {
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
