using JuiceStock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuiceStock.Domain.Entities
{
    public class LedgerEntry
    {
        public Guid Id { get; private set; }
        public DateTime EntryDate { get; private set; }
        public decimal Amount { get; private set; }
        public LedgerEntryType EntryType { get; private set; }
        public string Description { get; private set; }
        public Guid ReferenceId { get; private set; }

        // For EF Core (later)
        private LedgerEntry() { }

        private LedgerEntry(
            decimal amount,
            LedgerEntryType entryType,
            string description,
            Guid referenceId)
        {
            Id = Guid.NewGuid();
            EntryDate = DateTime.UtcNow;
            Amount = amount;
            EntryType = entryType;
            Description = description;
            ReferenceId = referenceId;
        }

        public static LedgerEntry Create(
            decimal amount,
            LedgerEntryType entryType,
            string description,
            Guid referenceId)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            return new LedgerEntry(amount, entryType, description, referenceId);
        }
    }
}