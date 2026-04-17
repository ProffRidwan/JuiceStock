using JuiceStock.Domain.Enums;

namespace JuiceStock.Api.Contracts.Ledger
{
    public class GetLedgerRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public LedgerEntryType? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
