using JuiceStock.Domain.Entities;
using JuiceStock.Domain.Enums;
using Microsoft.EntityFrameworkCore;
namespace JuiceStock.Application.Customers
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Guid CreateCustomer(string name)
        {
            var customer = new Customer(name);
            _repository.Add(customer);
            _repository.Save();

            return customer.Id;
        }

        public Customer GetCustomer(Guid customerId)
        {
            return _repository.GetById(customerId);
        }

        public void DebitCustomer(Guid customerId, decimal amount, string description)
        {
            var customer = _repository.GetById(customerId);

            customer.Debit(amount, description);

            _repository.Save();
        }

        public void CreditCustomer(Guid customerId, decimal amount, string description)
        {
            var customer = _repository.GetById(customerId);

            customer.Credit(amount, description);

            _repository.Save();
        }

        public decimal GetBalance(Guid customerId)
        {
            var customer = _repository.GetById(customerId);
            return customer.GetBalance();
        }
        public IReadOnlyCollection<LedgerEntry> GetCustomerLedger(Guid customerId)
        {
            var customer = _repository.GetById(customerId);
            return customer.LedgerEntries;
        }
        public async Task<(List<LedgerEntry> Entries, int TotalCount)> GetCustomerLedgerPaged(
  Guid customerId,
  int page,
  int pageSize,
  LedgerEntryType? type,
  DateTime? startDate,
  DateTime? endDate)
        {
            var query = _repository.Query()
                .Where(c => c.Id == customerId)
                .SelectMany(c => c.LedgerEntries)
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