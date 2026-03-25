using JuiceStock.Domain.Entities;
using JuiceStock.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JuiceStock.Application.Suppliers
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public Guid CreateSupplier(string name)
        {
            var supplier = new Supplier(name);

            _repository.Add(supplier);
            _repository.Save();

            return supplier.Id;
        }

        public Supplier GetSupplier(Guid id)
        {
            return _repository.GetById(id);
        }

        public void DebitSupplier(Guid supplierId, decimal amount, string description)
        {
            var supplier = _repository.GetById(supplierId);
            supplier.Debit(amount, description);
            _repository.Save();
        }

        public void CreditSupplier(Guid supplierId, decimal amount, string description)
        {
            var supplier = _repository.GetById(supplierId);
            supplier.Credit(amount, description);
            _repository.Save();
        }
        public IReadOnlyCollection<LedgerEntry> GetSupplierLedger(Guid supplierId)
        {
            var supplier = _repository.GetById(supplierId);
            return supplier.LedgerEntries;
        }


        public async Task<(List<LedgerEntry> Entries, int TotalCount)> GetSupplierLedgerPaged(
    Guid supplierId,
    int page,
    int pageSize,
    LedgerEntryType? type,
    DateTime? startDate,
    DateTime? endDate)
        {
            var query = _repository.Query()
                .Where(s => s.Id == supplierId)
                .SelectMany(s => s.LedgerEntries)
                .AsQueryable();

            // 🔹 Filter by type
            if (type.HasValue)
            {
                query = query.Where(e => e.EntryType == type.Value);
            }

            // 🔹 Filter by start date
            if (startDate.HasValue)
            {
                query = query.Where(e => e.EntryDate >= startDate.Value);
            }

            // 🔹 Filter by end date
            if (endDate.HasValue)
            {
                query = query.Where(e => e.EntryDate <= endDate.Value);
            }

            var totalCount = await query.CountAsync();

            var entries = await query
                .OrderByDescending(e => e.EntryDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (entries, totalCount);
        }
    }
}