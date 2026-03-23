using JuiceStock.Domain.Entities;

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
    }
}