using JuiceStock.Api.Contracts.Ledger;
using JuiceStock.Domain.Entities;

namespace JuiceStock.Api.Mappings
{
    public static class LedgerMappings
    {
        public static LedgerEntryResponse ToResponse(this LedgerEntry entry)
        {
            return new LedgerEntryResponse
            {
                Amount = entry.Amount,
                Type = entry.EntryType.ToString(),
                Description = entry.Description,
                Date = entry.EntryDate
            };
        }
    }
}