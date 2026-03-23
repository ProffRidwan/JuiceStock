using System;
using System.Collections.Generic;
using System.Linq;
using JuiceStock.Domain.Enums;

namespace JuiceStock.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<LedgerEntry> _ledgerEntries = new();
        public IReadOnlyCollection<LedgerEntry> LedgerEntries => _ledgerEntries.AsReadOnly();

        private Customer() { }

        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        // CUSTOMER OWES US (Debit)
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

        // CUSTOMER PAYS US (Credit)
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

        // CALCULATED BALANCE (NO STORED BALANCE)
        public decimal GetBalance()
        {
            var debitTotal = _ledgerEntries
                .Where(x => x.EntryType == LedgerEntryType.Debit)
                .Sum(x => x.Amount);

            var creditTotal = _ledgerEntries
                .Where(x => x.EntryType == LedgerEntryType.Credit)
                .Sum(x => x.Amount);

            return debitTotal - creditTotal;
        }

        private static void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Amount must be greater than zero.");
        }
    }
}