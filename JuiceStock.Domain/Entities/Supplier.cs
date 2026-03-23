using JuiceStock.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JuiceStock.Domain.Entities
{
    public class Supplier
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<LedgerEntry> _ledgerEntries = new();
        public IReadOnlyCollection<LedgerEntry> LedgerEntries => _ledgerEntries.AsReadOnly();

        private Supplier() { }

        public Supplier(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        // WE PAY SUPPLIER (Debit → reduces liability)
        public void Debit(decimal amount, string description)
        {
            ValidateAmount(amount);

            var entry = LedgerEntry.Create(
                amount,
                LedgerEntryType.Debit,
                description,
                Id
            );

            _ledgerEntries.Add(entry);
        }

        // SUPPLIER GIVES US GOODS (Credit → increases liability)
        public void Credit(decimal amount, string description)
        {
            ValidateAmount(amount);

            var entry = LedgerEntry.Create(
                amount,
                LedgerEntryType.Credit,
                description,
                Id
            );

            _ledgerEntries.Add(entry);
        }

        public decimal GetBalance()
        {
            var creditTotal = _ledgerEntries
                .Where(x => x.EntryType == LedgerEntryType.Credit)
                .Sum(x => x.Amount);

            var debitTotal = _ledgerEntries
                .Where(x => x.EntryType == LedgerEntryType.Debit)
                .Sum(x => x.Amount);

            return creditTotal - debitTotal;
        }

        private static void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Amount must be greater than zero.");
        }
    }
}