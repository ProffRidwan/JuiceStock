namespace JuiceStock.Api.Contracts.Ledger
{
    public class DebitRequest
    {
       public decimal Amount { get; set; }
        public string Description { get; set; } = string .Empty;
    }
}
