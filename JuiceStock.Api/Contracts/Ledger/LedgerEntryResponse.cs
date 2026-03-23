namespace JuiceStock.Api.Contracts.Ledger
{
    public class LedgerEntryResponse
    {
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
