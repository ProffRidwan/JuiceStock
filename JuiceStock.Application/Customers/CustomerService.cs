using JuiceStock.Domain.Entities;

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
    }
}